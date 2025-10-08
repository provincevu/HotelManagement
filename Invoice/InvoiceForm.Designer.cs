namespace HotelManagement
{
    partial class InvoiceForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblRoomId = new System.Windows.Forms.Label();
            this.lblStaffCheckOut = new System.Windows.Forms.Label();
            this.lblCustomerCheckOut = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblCheckInDate = new System.Windows.Forms.Label();
            this.lblCheckOutDate = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtRoomId = new System.Windows.Forms.TextBox();
            this.txtStaffCheckOut = new System.Windows.Forms.TextBox();
            this.txtCustomerCheckOut = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtCheckInDate = new System.Windows.Forms.TextBox();
            this.txtCheckOutDate = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(346, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HÓA ĐƠN TRẢ PHÒNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(40, 80);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(110, 23);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "Mã hóa đơn:";
            // 
            // lblRoomId
            // 
            this.lblRoomId.Location = new System.Drawing.Point(346, 80);
            this.lblRoomId.Name = "lblRoomId";
            this.lblRoomId.Size = new System.Drawing.Size(80, 23);
            this.lblRoomId.TabIndex = 3;
            this.lblRoomId.Text = "Phòng:";
            // 
            // lblStaffCheckOut
            // 
            this.lblStaffCheckOut.Location = new System.Drawing.Point(40, 120);
            this.lblStaffCheckOut.Name = "lblStaffCheckOut";
            this.lblStaffCheckOut.Size = new System.Drawing.Size(110, 23);
            this.lblStaffCheckOut.TabIndex = 5;
            this.lblStaffCheckOut.Text = "Nhân viên:";
            // 
            // lblCustomerCheckOut
            // 
            this.lblCustomerCheckOut.Location = new System.Drawing.Point(346, 120);
            this.lblCustomerCheckOut.Name = "lblCustomerCheckOut";
            this.lblCustomerCheckOut.Size = new System.Drawing.Size(80, 23);
            this.lblCustomerCheckOut.TabIndex = 7;
            this.lblCustomerCheckOut.Text = "Sđt khách:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Location = new System.Drawing.Point(40, 160);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(110, 23);
            this.lblTotalPrice.TabIndex = 9;
            this.lblTotalPrice.Text = "Tổng tiền:";
            // 
            // lblCheckInDate
            // 
            this.lblCheckInDate.Location = new System.Drawing.Point(40, 200);
            this.lblCheckInDate.Name = "lblCheckInDate";
            this.lblCheckInDate.Size = new System.Drawing.Size(110, 23);
            this.lblCheckInDate.TabIndex = 11;
            this.lblCheckInDate.Text = "Ngày nhận:";
            // 
            // lblCheckOutDate
            // 
            this.lblCheckOutDate.Location = new System.Drawing.Point(346, 200);
            this.lblCheckOutDate.Name = "lblCheckOutDate";
            this.lblCheckOutDate.Size = new System.Drawing.Size(80, 23);
            this.lblCheckOutDate.TabIndex = 13;
            this.lblCheckOutDate.Text = "Ngày trả:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(160, 80);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(135, 22);
            this.txtId.TabIndex = 2;
            // 
            // txtRoomId
            // 
            this.txtRoomId.Location = new System.Drawing.Point(440, 80);
            this.txtRoomId.Name = "txtRoomId";
            this.txtRoomId.ReadOnly = true;
            this.txtRoomId.Size = new System.Drawing.Size(80, 22);
            this.txtRoomId.TabIndex = 4;
            // 
            // txtStaffCheckOut
            // 
            this.txtStaffCheckOut.Location = new System.Drawing.Point(160, 120);
            this.txtStaffCheckOut.Name = "txtStaffCheckOut";
            this.txtStaffCheckOut.ReadOnly = true;
            this.txtStaffCheckOut.Size = new System.Drawing.Size(135, 22);
            this.txtStaffCheckOut.TabIndex = 6;
            // 
            // txtCustomerCheckOut
            // 
            this.txtCustomerCheckOut.Location = new System.Drawing.Point(440, 120);
            this.txtCustomerCheckOut.Name = "txtCustomerCheckOut";
            this.txtCustomerCheckOut.ReadOnly = true;
            this.txtCustomerCheckOut.Size = new System.Drawing.Size(160, 22);
            this.txtCustomerCheckOut.TabIndex = 8;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(160, 160);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(135, 22);
            this.txtTotalPrice.TabIndex = 10;
            // 
            // txtCheckInDate
            // 
            this.txtCheckInDate.Location = new System.Drawing.Point(160, 200);
            this.txtCheckInDate.Name = "txtCheckInDate";
            this.txtCheckInDate.ReadOnly = true;
            this.txtCheckInDate.Size = new System.Drawing.Size(135, 22);
            this.txtCheckInDate.TabIndex = 12;
            // 
            // txtCheckOutDate
            // 
            this.txtCheckOutDate.Location = new System.Drawing.Point(440, 200);
            this.txtCheckOutDate.Name = "txtCheckOutDate";
            this.txtCheckOutDate.ReadOnly = true;
            this.txtCheckOutDate.Size = new System.Drawing.Size(160, 22);
            this.txtCheckOutDate.TabIndex = 14;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnClose.Location = new System.Drawing.Point(240, 250);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "ĐÓNG";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // InvoiceForm
            // 
            this.ClientSize = new System.Drawing.Size(620, 320);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblRoomId);
            this.Controls.Add(this.txtRoomId);
            this.Controls.Add(this.lblStaffCheckOut);
            this.Controls.Add(this.txtStaffCheckOut);
            this.Controls.Add(this.lblCustomerCheckOut);
            this.Controls.Add(this.txtCustomerCheckOut);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblCheckInDate);
            this.Controls.Add(this.txtCheckInDate);
            this.Controls.Add(this.lblCheckOutDate);
            this.Controls.Add(this.txtCheckOutDate);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận hóa đơn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblRoomId;
        private System.Windows.Forms.Label lblStaffCheckOut;
        private System.Windows.Forms.Label lblCustomerCheckOut;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lblCheckInDate;
        private System.Windows.Forms.Label lblCheckOutDate;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtRoomId;
        private System.Windows.Forms.TextBox txtStaffCheckOut;
        private System.Windows.Forms.TextBox txtCustomerCheckOut;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtCheckInDate;
        private System.Windows.Forms.TextBox txtCheckOutDate;

        private System.Windows.Forms.Button btnClose;
    }
}