namespace HotelManagement
{
    partial class StaffManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lvStaff = new System.Windows.Forms.ListView();
            this.colSTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIdentityNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRole = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtIdentityNumber = new System.Windows.Forms.TextBox();
            this.lblIdentityNumber = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.linkAddRole = new System.Windows.Forms.LinkLabel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(917, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ NHÂN SỰ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAdd.Location = new System.Drawing.Point(10, 55);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnEdit.Location = new System.Drawing.Point(80, 55);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(150, 55);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtSearch.Location = new System.Drawing.Point(514, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 30);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSearch.Location = new System.Drawing.Point(680, 59);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 28);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRefresh.Location = new System.Drawing.Point(787, 59);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 28);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lvStaff
            // 
            this.lvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvStaff.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSTT,
            this.colUserName,
            this.colName,
            this.colPhone,
            this.colIdentityNumber,
            this.colRole});
            this.lvStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.lvStaff.FullRowSelect = true;
            this.lvStaff.GridLines = true;
            this.lvStaff.HideSelection = false;
            this.lvStaff.Location = new System.Drawing.Point(10, 95);
            this.lvStaff.Name = "lvStaff";
            this.lvStaff.Size = new System.Drawing.Size(877, 200);
            this.lvStaff.TabIndex = 7;
            this.lvStaff.UseCompatibleStateImageBehavior = false;
            this.lvStaff.View = System.Windows.Forms.View.Details;
            this.lvStaff.SelectedIndexChanged += new System.EventHandler(this.lvStaff_SelectedIndexChanged);
            // 
            // colSTT
            // 
            this.colSTT.Text = "STT";
            this.colSTT.Width = 45;
            // 
            // colUserName
            // 
            this.colUserName.Text = "UserName";
            this.colUserName.Width = 120;
            // 
            // colName
            // 
            this.colName.Text = "Họ và tên";
            this.colName.Width = 150;
            // 
            // colPhone
            // 
            this.colPhone.Text = "SĐT";
            this.colPhone.Width = 110;
            // 
            // colIdentityNumber
            // 
            this.colIdentityNumber.Text = "CCCD";
            this.colIdentityNumber.Width = 120;
            // 
            // colRole
            // 
            this.colRole.Text = "Vai trò";
            this.colRole.Width = 110;
            // 
            // gbDetail
            // 
            this.gbDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDetail.Controls.Add(this.txtUserName);
            this.gbDetail.Controls.Add(this.lblUserName);
            this.gbDetail.Controls.Add(this.txtPassword);
            this.gbDetail.Controls.Add(this.lblPassword);
            this.gbDetail.Controls.Add(this.txtName);
            this.gbDetail.Controls.Add(this.lblName);
            this.gbDetail.Controls.Add(this.txtPhone);
            this.gbDetail.Controls.Add(this.lblPhone);
            this.gbDetail.Controls.Add(this.txtIdentityNumber);
            this.gbDetail.Controls.Add(this.lblIdentityNumber);
            this.gbDetail.Controls.Add(this.cbRole);
            this.gbDetail.Controls.Add(this.lblRole);
            this.gbDetail.Controls.Add(this.linkAddRole);
            this.gbDetail.Controls.Add(this.btnSave);
            this.gbDetail.Controls.Add(this.btnCancel);
            this.gbDetail.Enabled = false;
            this.gbDetail.Location = new System.Drawing.Point(10, 305);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(877, 240);
            this.gbDetail.TabIndex = 8;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "Chi tiết nhân sự";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtUserName.Location = new System.Drawing.Point(120, 30);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(200, 28);
            this.txtUserName.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblUserName.Location = new System.Drawing.Point(20, 33);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(90, 21);
            this.lblUserName.TabIndex = 10;
            this.lblUserName.Text = "UserName:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtPassword.Location = new System.Drawing.Point(120, 70);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 28);
            this.txtPassword.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblPassword.Location = new System.Drawing.Point(20, 73);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(90, 21);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtName.Location = new System.Drawing.Point(120, 110);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 28);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblName.Location = new System.Drawing.Point(20, 113);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(90, 21);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Họ tên:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtPhone.Location = new System.Drawing.Point(120, 150);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(200, 28);
            this.txtPhone.TabIndex = 3;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblPhone.Location = new System.Drawing.Point(20, 153);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(90, 21);
            this.lblPhone.TabIndex = 13;
            this.lblPhone.Text = "SĐT:";
            // 
            // txtIdentityNumber
            // 
            this.txtIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.txtIdentityNumber.Location = new System.Drawing.Point(550, 33);
            this.txtIdentityNumber.Name = "txtIdentityNumber";
            this.txtIdentityNumber.Size = new System.Drawing.Size(200, 28);
            this.txtIdentityNumber.TabIndex = 4;
            // 
            // lblIdentityNumber
            // 
            this.lblIdentityNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblIdentityNumber.Location = new System.Drawing.Point(471, 36);
            this.lblIdentityNumber.Name = "lblIdentityNumber";
            this.lblIdentityNumber.Size = new System.Drawing.Size(90, 21);
            this.lblIdentityNumber.TabIndex = 14;
            this.lblIdentityNumber.Text = "CCCD:";
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.cbRole.Location = new System.Drawing.Point(550, 73);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(200, 30);
            this.cbRole.TabIndex = 5;
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.lblRole.Location = new System.Drawing.Point(470, 76);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(70, 21);
            this.lblRole.TabIndex = 15;
            this.lblRole.Text = "Vai trò:";
            // 
            // linkAddRole
            // 
            this.linkAddRole.AutoSize = true;
            this.linkAddRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.linkAddRole.Location = new System.Drawing.Point(760, 77);
            this.linkAddRole.Name = "linkAddRole";
            this.linkAddRole.Size = new System.Drawing.Size(110, 22);
            this.linkAddRole.TabIndex = 16;
            this.linkAddRole.TabStop = true;
            this.linkAddRole.Text = "Thêm vai trò";
            this.linkAddRole.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddRole_LinkClicked);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnSave.Location = new System.Drawing.Point(550, 146);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.btnCancel.Location = new System.Drawing.Point(656, 146);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // StaffManagerForm
            // 
            this.Controls.Add(this.gbDetail);
            this.Controls.Add(this.lvStaff);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTitle);
            this.Name = "StaffManagerForm";
            this.Size = new System.Drawing.Size(901, 558);
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvStaff;
        private System.Windows.Forms.ColumnHeader colSTT;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colIdentityNumber;
        private System.Windows.Forms.ColumnHeader colRole;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblIdentityNumber;
        private System.Windows.Forms.TextBox txtIdentityNumber;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.LinkLabel linkAddRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}