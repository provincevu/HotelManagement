using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace HotelManagement
{
    public static class DataBase
    {
        private static string dbFile = "hotel.db";
        private static string connString = $"Data Source={dbFile};Version=3;";

        // Bật foreign key constraints cho mọi kết nối
        private static void EnableForeignKeys(SQLiteConnection con)
        {
            using (var pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
            {
                pragmaCmd.ExecuteNonQuery();
            }
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists(dbFile))
            {
                SQLiteConnection.CreateFile(dbFile);
            }
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);

                // RoomTypes
                string sqlRoomTypes = @"CREATE TABLE IF NOT EXISTS RoomTypes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TypeName TEXT NOT NULL UNIQUE,
                    Price REAL NOT NULL
                )";
                using (var cmd = new SQLiteCommand(sqlRoomTypes, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Roles
                string sqlRoles = @"CREATE TABLE IF NOT EXISTS Roles (
                     RoleId INTEGER PRIMARY KEY AUTOINCREMENT,
                     RoleName TEXT NOT NULL UNIQUE
                )";
                using (var cmd = new SQLiteCommand(sqlRoles, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Customers (UserName is PRIMARY KEY)
                string sqlCustomers = @"CREATE TABLE IF NOT EXISTS Customers (
                    UserName TEXT PRIMARY KEY,
                    PassWord TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    IdentityNumber TEXT NOT NULL UNIQUE,
                    Phone TEXT,
                    RoleId INTEGER,
                    FOREIGN KEY(RoleId) REFERENCES Roles(RoleId)
                        ON UPDATE CASCADE
                        ON DELETE SET NULL
                )";
                using (var cmd = new SQLiteCommand(sqlCustomers, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Rooms (có CASCADE)
                string sqlRooms = @"CREATE TABLE IF NOT EXISTS Rooms (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomNumber TEXT NOT NULL UNIQUE,
                    RoomTypeId INTEGER NOT NULL,
                    Status TEXT NOT NULL,
                    FOREIGN KEY(RoomTypeId) REFERENCES RoomTypes(Id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                )";
                using (var cmd = new SQLiteCommand(sqlRooms, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Bookings (CustomerUserName là TEXT)
                string sqlBookings = @"CREATE TABLE IF NOT EXISTS Bookings (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomId INTEGER NOT NULL,
                    CustomerUserName TEXT NOT NULL,
                    CheckInDate TEXT NOT NULL,
                    CheckOutDate TEXT NOT NULL,
                    FOREIGN KEY(RoomId) REFERENCES Rooms(Id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE,
                    FOREIGN KEY(CustomerUserName) REFERENCES Customers(UserName)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                )";
                using (var cmd = new SQLiteCommand(sqlBookings, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Invoices (có CASCADE)
                string sqlInvoices = @"CREATE TABLE IF NOT EXISTS Invoices (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    BookingId INTEGER NOT NULL,
                    TotalAmount REAL NOT NULL,
                    CreatedDate TEXT NOT NULL,
                    FOREIGN KEY(BookingId) REFERENCES Bookings(Id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                )";
                using (var cmd = new SQLiteCommand(sqlInvoices, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ---- READ ----

        public static List<Dictionary<string, object>> GetAllRooms()
        {
            var result = new List<Dictionary<string, object>>();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"SELECT Rooms.*, RoomTypes.TypeName, RoomTypes.Price
                               FROM Rooms JOIN RoomTypes ON Rooms.RoomTypeId = RoomTypes.Id";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader.GetValue(i);
                        result.Add(row);
                    }
                }
            }
            return result;
        }

        public static List<Dictionary<string, object>> GetAllRoomTypes()
        {
            var result = new List<Dictionary<string, object>>();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "SELECT * FROM RoomTypes";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader.GetValue(i);
                        result.Add(row);
                    }
                }
            }
            return result;
        }

        public static List<Dictionary<string, object>> GetAllCustomers()
        {
            var result = new List<Dictionary<string, object>>();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"SELECT Customers.*, Roles.RoleName
                               FROM Customers LEFT JOIN Roles ON Customers.RoleId = Roles.RoleId";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader.GetValue(i);
                        result.Add(row);
                    }
                }
            }
            return result;
        }

        public static List<Dictionary<string, object>> GetAllBookings()
        {
            var result = new List<Dictionary<string, object>>();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"SELECT Bookings.*, Rooms.RoomNumber, Customers.Name AS CustomerName
                               FROM Bookings
                               JOIN Rooms ON Bookings.RoomId = Rooms.Id
                               JOIN Customers ON Bookings.CustomerUserName = Customers.UserName";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader.GetValue(i);
                        result.Add(row);
                    }
                }
            }
            return result;
        }

        public static List<Dictionary<string, object>> GetAllInvoices()
        {
            var result = new List<Dictionary<string, object>>();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"SELECT Invoices.*, Bookings.RoomId, Bookings.CustomerUserName
                               FROM Invoices
                               JOIN Bookings ON Invoices.BookingId = Bookings.Id";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                            row[reader.GetName(i)] = reader.GetValue(i);
                        result.Add(row);
                    }
                }
            }
            return result;
        }

        // ---- ADD ----

        public static bool AddRoomType(string typeName, double price)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO RoomTypes(TypeName, Price) VALUES(@typeName, @price)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@typeName", typeName);
                    cmd.Parameters.AddWithValue("@price", price);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddRoom(string roomNumber, int roomTypeId, string status)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO Rooms(RoomNumber, RoomTypeId, Status) VALUES(@num, @typeId, @status)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@num", roomNumber);
                    cmd.Parameters.AddWithValue("@typeId", roomTypeId);
                    cmd.Parameters.AddWithValue("@status", status);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddCustomer(string username, string password, string name, string identityNumber, string phone, int? roleId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO Customers(UserName, PassWord, Name, IdentityNumber, Phone, RoleId) VALUES(@username, @password, @name, @idnum, @phone, @roleId)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@idnum", identityNumber);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    if (roleId.HasValue)
                        cmd.Parameters.AddWithValue("@roleId", roleId.Value);
                    else
                        cmd.Parameters.AddWithValue("@roleId", DBNull.Value);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddBooking(int roomId, string customerUserName, string checkIn, string checkOut)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"INSERT INTO Bookings(RoomId, CustomerUserName, CheckInDate, CheckOutDate)
                               VALUES(@room, @cust, @in, @out)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@room", roomId);
                    cmd.Parameters.AddWithValue("@cust", customerUserName);
                    cmd.Parameters.AddWithValue("@in", checkIn);
                    cmd.Parameters.AddWithValue("@out", checkOut);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddInvoice(int bookingId, double totalAmount, string createdDate)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"INSERT INTO Invoices(BookingId, TotalAmount, CreatedDate)
                               VALUES(@booking, @amount, @date)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@booking", bookingId);
                    cmd.Parameters.AddWithValue("@amount", totalAmount);
                    cmd.Parameters.AddWithValue("@date", createdDate);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        // ---- UPDATE ----

        public static bool UpdateRoomType(int id, string typeName, double price)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "UPDATE RoomTypes SET TypeName=@typeName, Price=@price WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@typeName", typeName);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@id", id);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool UpdateRoom(int id, string roomNumber, int roomTypeId, string status)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "UPDATE Rooms SET RoomNumber=@num, RoomTypeId=@typeId, Status=@status WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@num", roomNumber);
                    cmd.Parameters.AddWithValue("@typeId", roomTypeId);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool UpdateCustomer(string username, string password, string name, string identityNumber, string phone, int? roleId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "UPDATE Customers SET PassWord=@password, Name=@name, IdentityNumber=@idnum, Phone=@phone, RoleId=@roleId WHERE UserName=@username";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@idnum", identityNumber);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    if (roleId.HasValue)
                        cmd.Parameters.AddWithValue("@roleId", roleId.Value);
                    else
                        cmd.Parameters.AddWithValue("@roleId", DBNull.Value);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool UpdateBooking(int id, int roomId, string customerUserName, string checkIn, string checkOut)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"UPDATE Bookings SET RoomId=@room, CustomerUserName=@cust, CheckInDate=@in, CheckOutDate=@out WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@room", roomId);
                    cmd.Parameters.AddWithValue("@cust", customerUserName);
                    cmd.Parameters.AddWithValue("@in", checkIn);
                    cmd.Parameters.AddWithValue("@out", checkOut);
                    cmd.Parameters.AddWithValue("@id", id);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool UpdateInvoice(int id, int bookingId, double totalAmount, string createdDate)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"UPDATE Invoices SET BookingId=@booking, TotalAmount=@amount, CreatedDate=@date WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@booking", bookingId);
                    cmd.Parameters.AddWithValue("@amount", totalAmount);
                    cmd.Parameters.AddWithValue("@date", createdDate);
                    cmd.Parameters.AddWithValue("@id", id);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        // ---- DELETE ----

        public static bool DeleteRoomType(int id)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM RoomTypes WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool DeleteRoom(int id)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM Rooms WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool DeleteCustomer(string username)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM Customers WHERE UserName=@username";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool DeleteBooking(int id)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM Bookings WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool DeleteInvoice(int id)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM Invoices WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        // ---- LOGIN ----

        public static bool CheckLogin(string username, string password)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "SELECT COUNT(*) FROM Customers WHERE UserName=@user AND PassWord=@pass";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // ---- REGISTER ----
        public static bool RegisterUser(string username, string password, string name, string identityNumber, string phone)
        {
            return AddCustomer(username, password, name, identityNumber, phone, null);
        }
    }
}