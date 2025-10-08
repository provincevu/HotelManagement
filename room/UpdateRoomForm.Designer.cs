namespace HotelManagement
{
    partial class UpdateRoomForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblRoomInfo = new System.Windows.Forms.Label();
            this.grpPerson = new System.Windows.Forms.GroupBox();
            this.rbNewPerson = new System.Windows.Forms.RadioButton();
            this.rbExistingPerson = new System.Windows.Forms.RadioButton();
            this.cbExistingPerson = new System.Windows.Forms.ComboBox();
            this.pnlNewPerson = new System.Windows.Forms.Panel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lvCustomers = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBirth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemoveCustomer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatusurf = new System.Windows.Forms.Label();
            this.cbStatusurf = new System.Windows.Forms.ComboBox();
            this.btnChangeStatusupdate = new System.Windows.Forms.Button();

            this.grpPerson.SuspendLayout();
            this.pnlNewPerson.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRoomInfo
            // 
            this.lblRoomInfo.AutoSize = true;
            this.lblRoomInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRoomInfo.Location = new System.Drawing.Point(30, 10);
            this.lblRoomInfo.Name = "lblRoomInfo";
            this.lblRoomInfo.Size = new System.Drawing.Size(107, 21);
            this.lblRoomInfo.TabIndex = 0;
            this.lblRoomInfo.Text = "Phòng: ???";
            // 
            // grpPerson
            // 
            this.grpPerson.Controls.Add(this.rbNewPerson);
            this.grpPerson.Controls.Add(this.rbExistingPerson);
            this.grpPerson.Controls.Add(this.cbExistingPerson);
            this.grpPerson.Controls.Add(this.pnlNewPerson);
            this.grpPerson.Location = new System.Drawing.Point(30, 45);
            this.grpPerson.Name = "grpPerson";
            this.grpPerson.Size = new System.Drawing.Size(400, 250);
            this.grpPerson.TabIndex = 1;
            this.grpPerson.TabStop = false;
            this.grpPerson.Text = "Thêm khách vào phòng:";
            // 
            // rbExistingPerson
            // 
            this.rbExistingPerson.AutoSize = true;
            this.rbExistingPerson.Location = new System.Drawing.Point(15, 30);
            this.rbExistingPerson.Name = "rbExistingPerson";
            this.rbExistingPerson.Size = new System.Drawing.Size(125, 19);
            this.rbExistingPerson.TabIndex = 0;
            this.rbExistingPerson.TabStop = true;
            this.rbExistingPerson.Text = "Chọn người có sẵn";
            this.rbExistingPerson.UseVisualStyleBackColor = true;
            this.rbExistingPerson.CheckedChanged += new System.EventHandler(this.rbExistingPerson_CheckedChanged);
            // 
            // cbExistingPerson
            // 
            this.cbExistingPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExistingPerson.FormattingEnabled = true;
            this.cbExistingPerson.Location = new System.Drawing.Point(150, 29);
            this.cbExistingPerson.Name = "cbExistingPerson";
            this.cbExistingPerson.Size = new System.Drawing.Size(200, 23);
            this.cbExistingPerson.TabIndex = 1;
            // 
            // rbNewPerson
            // 
            this.rbNewPerson.AutoSize = true;
            this.rbNewPerson.Location = new System.Drawing.Point(15, 65);
            this.rbNewPerson.Name = "rbNewPerson";
            this.rbNewPerson.Size = new System.Drawing.Size(104, 19);
            this.rbNewPerson.TabIndex = 2;
            this.rbNewPerson.TabStop = true;
            this.rbNewPerson.Text = "Tạo người mới";
            this.rbNewPerson.UseVisualStyleBackColor = true;
            this.rbNewPerson.CheckedChanged += new System.EventHandler(this.rbExistingPerson_CheckedChanged);
            // 
            // pnlNewPerson
            // 
            this.pnlNewPerson.Controls.Add(this.txtName);
            this.pnlNewPerson.Controls.Add(this.lblName);
            this.pnlNewPerson.Controls.Add(this.dtpDob);
            this.pnlNewPerson.Controls.Add(this.lblDob);
            this.pnlNewPerson.Controls.Add(this.lblGender);
            this.pnlNewPerson.Controls.Add(this.rbMale);
            this.pnlNewPerson.Controls.Add(this.rbFemale);
            this.pnlNewPerson.Controls.Add(this.rbOther);
            this.pnlNewPerson.Controls.Add(this.txtPhone);
            this.pnlNewPerson.Controls.Add(this.lblPhone);
            this.pnlNewPerson.Location = new System.Drawing.Point(35, 90);
            this.pnlNewPerson.Name = "pnlNewPerson";
            this.pnlNewPerson.Size = new System.Drawing.Size(340, 140);
            this.pnlNewPerson.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(10, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Họ tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 7);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(230, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Location = new System.Drawing.Point(10, 40);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(61, 15);
            this.lblDob.TabIndex = 2;
            this.lblDob.Text = "Ngày sinh:";
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(90, 37);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(120, 23);
            this.dtpDob.TabIndex = 3;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(10, 70);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(51, 15);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "Giới tính:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(90, 68);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(51, 19);
            this.rbMale.TabIndex = 5;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(150, 68);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(41, 19);
            this.rbFemale.TabIndex = 6;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(200, 68);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(49, 19);
            this.rbOther.TabIndex = 7;
            this.rbOther.TabStop = true;
            this.rbOther.Text = "Khác";
            this.rbOther.UseVisualStyleBackColor = true;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(10, 100);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(77, 15);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "Số điện thoại:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(90, 97);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(230, 23);
            this.txtPhone.TabIndex = 9;
            // 
            // lvCustomers
            // 
            this.lvCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colPhone,
            this.colGender,
            this.colBirth});
            this.lvCustomers.FullRowSelect = true;
            this.lvCustomers.GridLines = true;
            this.lvCustomers.Location = new System.Drawing.Point(30, 310);
            this.lvCustomers.Name = "lvCustomers";
            this.lvCustomers.Size = new System.Drawing.Size(400, 110);
            this.lvCustomers.TabIndex = 5;
            this.lvCustomers.UseCompatibleStateImageBehavior = false;
            this.lvCustomers.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Tên";
            this.colName.Width = 110;
            // 
            // colPhone
            // 
            this.colPhone.Text = "SĐT";
            this.colPhone.Width = 100;
            // 
            // colGender
            // 
            this.colGender.Text = "Giới tính";
            this.colGender.Width = 80;
            // 
            // colBirth
            // 
            this.colBirth.Text = "Ngày sinh";
            this.colBirth.Width = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(250, 430);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "THÊM NGƯỜI";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemoveCustomer
            // 
            this.btnRemoveCustomer.Location = new System.Drawing.Point(135, 430);
            this.btnRemoveCustomer.Name = "btnRemoveCustomer";
            this.btnRemoveCustomer.Size = new System.Drawing.Size(100, 30);
            this.btnRemoveCustomer.TabIndex = 7;
            this.btnRemoveCustomer.Text = "XÓA KHÁCH";
            this.btnRemoveCustomer.UseVisualStyleBackColor = true;
            this.btnRemoveCustomer.Click += new System.EventHandler(this.btnRemoveCustomer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "HỦY";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblStatusurf
            this.lblStatusurf = new System.Windows.Forms.Label();
            this.lblStatusurf.AutoSize = true;
            this.lblStatusurf.Location = new System.Drawing.Point(30, 470);
            this.lblStatusurf.Name = "lblStatusurf";
            this.lblStatusurf.Size = new System.Drawing.Size(100, 15);
            this.lblStatusurf.TabIndex = 20;
            this.lblStatusurf.Text = "Trạng thái phòng:";

            // cbStatusurf
            this.cbStatusurf = new System.Windows.Forms.ComboBox();
            this.cbStatusurf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatusurf.Location = new System.Drawing.Point(135, 466);
            this.cbStatusurf.Name = "cbStatusurf";
            this.cbStatusurf.Size = new System.Drawing.Size(110, 23);
            this.cbStatusurf.TabIndex = 21;

            // btnChangeStatusupdate
            this.btnChangeStatusupdate = new System.Windows.Forms.Button();
            this.btnChangeStatusupdate.Location = new System.Drawing.Point(250, 466);
            this.btnChangeStatusupdate.Name = "btnChangeStatusupdate";
            this.btnChangeStatusupdate.Size = new System.Drawing.Size(110, 23);
            this.btnChangeStatusupdate.TabIndex = 22;
            this.btnChangeStatusupdate.Text = "Đổi trạng thái";
            this.btnChangeStatusupdate.UseVisualStyleBackColor = true;
            this.btnChangeStatusupdate.Click += new System.EventHandler(this.btnChangeStatusupdate_Click);

            // 
            // UpdateRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 510);
            this.Controls.Add(this.lvCustomers);
            this.Controls.Add(this.btnRemoveCustomer);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpPerson);
            this.Controls.Add(this.lblRoomInfo);
            this.Controls.Add(this.lblStatusurf);
            this.Controls.Add(this.cbStatusurf);
            this.Controls.Add(this.btnChangeStatusupdate);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateRoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách trong phòng";
            this.grpPerson.ResumeLayout(false);
            this.grpPerson.PerformLayout();
            this.pnlNewPerson.ResumeLayout(false);
            this.pnlNewPerson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // KHÔNG KHAI BÁO LẠI lblStatusurf, cbStatusurf, btnChangeStatusupdate ở bất cứ đâu ngoài đây!
        private System.Windows.Forms.Label lblRoomInfo;
        private System.Windows.Forms.GroupBox grpPerson;
        private System.Windows.Forms.RadioButton rbExistingPerson;
        private System.Windows.Forms.ComboBox cbExistingPerson;
        private System.Windows.Forms.RadioButton rbNewPerson;
        private System.Windows.Forms.Panel pnlNewPerson;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbOther;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.ListView lvCustomers;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colGender;
        private System.Windows.Forms.ColumnHeader colBirth;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemoveCustomer;
        private System.Windows.Forms.Button btnCancel;

        private System.Windows.Forms.Label lblStatusurf;
        private System.Windows.Forms.ComboBox cbStatusurf;
        private System.Windows.Forms.Button btnChangeStatusupdate;
    }
}