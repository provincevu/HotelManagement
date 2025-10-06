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

                // RoomStatuses
                string sqlRoomStatuses = @"CREATE TABLE IF NOT EXISTS RoomStatuses (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    StatusName TEXT NOT NULL UNIQUE
                )";
                using (var cmd = new SQLiteCommand(sqlRoomStatuses, con))
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

                // Staff (UserName PK, RoleId FK)
                string sqlStaff = @"CREATE TABLE IF NOT EXISTS Staff (
                    UserName TEXT PRIMARY KEY,
                    PassWord TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    IdentityNumber TEXT NOT NULL UNIQUE,
                    Phone TEXT,
                    RoleId INTEGER,
                    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
                )";
                using (var cmd = new SQLiteCommand(sqlStaff, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Sex
                string sqlSex = @"CREATE TABLE IF NOT EXISTS Sex (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    SexName TEXT NOT NULL UNIQUE
                )";
                using (var cmd = new SQLiteCommand(sqlSex, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // thêm các giá trị mặc định
                string checkSexSql = "SELECT COUNT(*) FROM Sex";
                using (var cmd = new SQLiteCommand(checkSexSql, con))
                {
                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        string insertSex = @"INSERT INTO Sex(SexName) VALUES
                            ('Nam'), ('Nữ'), ('Khác')";
                        using (var insertCmd = new SQLiteCommand(insertSex, con))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                // Customers (Phone PK)
                string sqlCustomers = @"CREATE TABLE IF NOT EXISTS Customers (
                    Name TEXT NOT NULL,
                    Birth TEXT,
                    SexId INTEGER,
                    Phone TEXT PRIMARY KEY,
                    FOREIGN KEY (SexId) REFERENCES Sex(Id)
                )";
                using (var cmd = new SQLiteCommand(sqlCustomers, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Rooms (StatusId là FK, không phải TEXT)
                string sqlRooms = @"CREATE TABLE IF NOT EXISTS Rooms (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomNumber TEXT NOT NULL UNIQUE,
                    RoomTypeId INTEGER NOT NULL,
                    StatusId INTEGER NOT NULL,
                    FOREIGN KEY(RoomTypeId) REFERENCES RoomTypes(Id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE,
                    FOREIGN KEY(StatusId) REFERENCES RoomStatuses(Id)
                )";
                using (var cmd = new SQLiteCommand(sqlRooms, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Bookings (CustomerPhone là TEXT, FK tới Customers.Phone)
                string sqlBookings = @"CREATE TABLE IF NOT EXISTS Bookings (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoomId INTEGER NOT NULL,
                    CustomerPhone TEXT NOT NULL,
                    CheckInDate TEXT NOT NULL,
                    CheckOutDate TEXT NOT NULL,
                    FOREIGN KEY(RoomId) REFERENCES Rooms(Id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE,
                    FOREIGN KEY(CustomerPhone) REFERENCES Customers(Phone)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                )";
                using (var cmd = new SQLiteCommand(sqlBookings, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Invoices (BookingId FK)
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

                string sqlRoomCustomers = @"CREATE TABLE IF NOT EXISTS RoomCustomers (
                    RoomId INTEGER NOT NULL,
                    CustomerPhone TEXT NOT NULL,
                    PRIMARY KEY (RoomId, CustomerPhone),
                    FOREIGN KEY(RoomId) REFERENCES Rooms(Id)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE,
                    FOREIGN KEY(CustomerPhone) REFERENCES Customers(Phone)
                        ON UPDATE CASCADE
                        ON DELETE CASCADE
                )";
                using (var cmd = new SQLiteCommand(sqlRoomCustomers, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // --- Khởi tạo sẵn 1 Role là "super admin" và 1 tài khoản admin ---
                int superAdminRoleId = AddRoleIfNotExists("super admin", con);
                AddAdminIfNotExists(superAdminRoleId, con);
            }
        }


        // ---- ROLE ----
        public static int AddRole(string roleName)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO Roles(RoleName) VALUES(@name); SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", roleName);
                    try
                    {
                        object id = cmd.ExecuteScalar();
                        return Convert.ToInt32(id);
                    }
                    catch
                    {
                        return -1;
                    }
                }
            }
        }

        // Thêm role nếu chưa tồn tại, trả về RoleId
        private static int AddRoleIfNotExists(string roleName, SQLiteConnection con)
        {
            EnableForeignKeys(con);
            string checkSql = "SELECT RoleId FROM Roles WHERE RoleName=@name";
            using (var checkCmd = new SQLiteCommand(checkSql, con))
            {
                checkCmd.Parameters.AddWithValue("@name", roleName);
                var result = checkCmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);

                string insertSql = "INSERT INTO Roles(RoleName) VALUES(@name); SELECT last_insert_rowid();";
                using (var insertCmd = new SQLiteCommand(insertSql, con))
                {
                    insertCmd.Parameters.AddWithValue("@name", roleName);
                    object id = insertCmd.ExecuteScalar();
                    return Convert.ToInt32(id);
                }
            }
        }

        // Thêm tài khoản admin nếu chưa có
        private static void AddAdminIfNotExists(int roleId, SQLiteConnection con)
        {
            EnableForeignKeys(con);
            // Kiểm tra xem trong bảng Staff đã có user admin chưa
            string checkSql = "SELECT COUNT(*) FROM Staff WHERE UserName=@u";
            using (var cmd = new SQLiteCommand(checkSql, con))
            {
                cmd.Parameters.AddWithValue("@u", "admin");
                long count = (long)cmd.ExecuteScalar();
                if (count > 0) return; // Đã có admin

                // Thêm admin vào Staff
                string sql = @"INSERT INTO Staff(UserName, PassWord, Name, IdentityNumber, Phone, RoleId)
                       VALUES(@user, @pass, @name, @idnum, @phone, @role)";
                using (var insert = new SQLiteCommand(sql, con))
                {
                    insert.Parameters.AddWithValue("@user", "admin");
                    insert.Parameters.AddWithValue("@pass", "admin");
                    insert.Parameters.AddWithValue("@name", "TinhVu");
                    insert.Parameters.AddWithValue("@idnum", "ADMIN");
                    insert.Parameters.AddWithValue("@phone", "09");
                    insert.Parameters.AddWithValue("@role", roleId);
                    insert.ExecuteNonQuery();
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
                string sql = @"SELECT Rooms.*, RoomTypes.TypeName, RoomTypes.Price, RoomStatuses.StatusName
                       FROM Rooms
                       JOIN RoomTypes ON Rooms.RoomTypeId = RoomTypes.Id
                       JOIN RoomStatuses ON Rooms.StatusId = RoomStatuses.Id";
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

        public class RoomStatusModel
        {
            public int Id { get; set; }
            public string StatusName { get; set; }
        }
        public static List<RoomStatusModel> GetAllRoomStatuses()
        {
            var result = new List<RoomStatusModel>();
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "SELECT Id, StatusName FROM RoomStatuses";
                using (var cmd = new SQLiteCommand(sql, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new RoomStatusModel
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            StatusName = reader["StatusName"].ToString()
                        });
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
                       JOIN Customers ON Bookings.CustomerPhone = Customers.Phone";
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
                string sql = @"SELECT Invoices.*, Bookings.RoomId, Bookings.CustomerPhone
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

        public static bool AddRoomStatus(string statusName)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO RoomStatuses(StatusName) VALUES(@statusName)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@statusName", statusName);
                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddRoom(string roomNumber, int roomTypeId, int statusId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO Rooms(RoomNumber, RoomTypeId, StatusId) VALUES(@num, @typeId, @statusId)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@num", roomNumber);
                    cmd.Parameters.AddWithValue("@typeId", roomTypeId);
                    cmd.Parameters.AddWithValue("@statusId", statusId);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddStaff(string username, string password, string name, string identityNumber, string phone, int? roleId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO Staff(UserName, PassWord, Name, IdentityNumber, Phone, RoleId) VALUES(@username, @password, @name, @idnum, @phone, @roleId)";
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


        public static bool AddCustomer(string name, string birth, int? sexId, string phone)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "INSERT INTO Customers(Name, Birth, SexId, Phone) VALUES(@name, @birth, @sexId, @phone)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@birth", birth);
                    if (sexId.HasValue)
                        cmd.Parameters.AddWithValue("@sexId", sexId.Value);
                    else
                        cmd.Parameters.AddWithValue("@sexId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    try { cmd.ExecuteNonQuery(); return true; }
                    catch { return false; }
                }
            }
        }

        public static bool AddBooking(int roomId, string customerPhone, string checkIn, string checkOut)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"INSERT INTO Bookings(RoomId, CustomerPhone, CheckInDate, CheckOutDate)
                       VALUES(@room, @cust, @in, @out)";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@room", roomId);
                    cmd.Parameters.AddWithValue("@cust", customerPhone);
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

        public static bool UpdateRoom(int id, string roomNumber, int roomTypeId, int statusId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "UPDATE Rooms SET RoomNumber=@num, RoomTypeId=@typeId, StatusId=@statusId WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@num", roomNumber);
                    cmd.Parameters.AddWithValue("@typeId", roomTypeId);
                    cmd.Parameters.AddWithValue("@statusId", statusId);
                    cmd.Parameters.AddWithValue("@id", id);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool UpdateCustomer(string name, string birth, int? sexId, string phone)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "UPDATE Customers SET Name=@name, Birth=@birth, SexId=@sexId WHERE Phone=@phone";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@birth", birth);
                    if (sexId.HasValue)
                        cmd.Parameters.AddWithValue("@sexId", sexId.Value);
                    else
                        cmd.Parameters.AddWithValue("@sexId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", phone);

                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }


        public static bool UpdateStaff(string username, string password, string name, string identityNumber, string phone, int? roleId)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "UPDATE Staff SET PassWord=@password, Name=@name, IdentityNumber=@idnum, Phone=@phone, RoleId=@roleId WHERE UserName=@username";
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

        public static bool UpdateBooking(int id, int roomId, string customerPhone, string checkIn, string checkOut)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = @"UPDATE Bookings SET RoomId=@room, CustomerPhone=@cust, CheckInDate=@in, CheckOutDate=@out WHERE Id=@id";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@room", roomId);
                    cmd.Parameters.AddWithValue("@cust", customerPhone);
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

        public static bool DeleteCustomer(string phone)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM Customers WHERE Phone=@phone";
                using (var cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@phone", phone);
                    try { return cmd.ExecuteNonQuery() > 0; }
                    catch { return false; }
                }
            }
        }

        public static bool DeleteStaff(string username)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "DELETE FROM Staff WHERE UserName=@username";
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

        public static bool CheckStaffLogin(string username, string password)
        {
            using (var con = new SQLiteConnection(connString))
            {
                con.Open();
                EnableForeignKeys(con);
                string sql = "SELECT COUNT(*) FROM Staff WHERE UserName=@user AND PassWord=@pass";
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
        public static bool RegisterStaff(string username, string password, string name, string identityNumber, string phone)
        {
            return AddStaff(username, password, name, identityNumber, phone, null);
        }
    }
}