namespace HotelManagement
{
    partial class InvoiceManagerForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblRoom = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.lblStaff = new System.Windows.Forms.Label();
            this.txtStaff = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblIn = new System.Windows.Forms.Label();
            this.txtIn = new System.Windows.Forms.TextBox();
            this.lblOut = new System.Windows.Forms.Label();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AllowUserToResizeRows = false;
            this.dgvInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(20, 20);
            this.dgvInvoices.MultiSelect = false;
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersWidth = 51;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(860, 209);
            this.dgvInvoices.TabIndex = 0;
            this.dgvInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellClick);
            // 
            // grpDetail
            // 
            this.grpDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetail.Controls.Add(this.lblId);
            this.grpDetail.Controls.Add(this.txtId);
            this.grpDetail.Controls.Add(this.lblRoom);
            this.grpDetail.Controls.Add(this.txtRoom);
            this.grpDetail.Controls.Add(this.lblStaff);
            this.grpDetail.Controls.Add(this.txtStaff);
            this.grpDetail.Controls.Add(this.lblCustomer);
            this.grpDetail.Controls.Add(this.txtCustomer);
            this.grpDetail.Controls.Add(this.lblTotal);
            this.grpDetail.Controls.Add(this.txtTotal);
            this.grpDetail.Controls.Add(this.lblIn);
            this.grpDetail.Controls.Add(this.txtIn);
            this.grpDetail.Controls.Add(this.lblOut);
            this.grpDetail.Controls.Add(this.txtOut);
            this.grpDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.grpDetail.Location = new System.Drawing.Point(20, 233);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(860, 227);
            this.grpDetail.TabIndex = 1;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "Chi tiết hóa đơn";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblId.Location = new System.Drawing.Point(30, 40);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(107, 23);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Mã hóa đơn:";
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtId.Location = new System.Drawing.Point(207, 36);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(174, 30);
            this.txtId.TabIndex = 1;
            // 
            // lblRoom
            // 
            this.lblRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRoom.AutoSize = true;
            this.lblRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRoom.Location = new System.Drawing.Point(489, 40);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(64, 23);
            this.lblRoom.TabIndex = 2;
            this.lblRoom.Text = "Phòng:";
            // 
            // txtRoom
            // 
            this.txtRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRoom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRoom.Location = new System.Drawing.Point(637, 36);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(163, 30);
            this.txtRoom.TabIndex = 3;
            // 
            // lblStaff
            // 
            this.lblStaff.AutoSize = true;
            this.lblStaff.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStaff.Location = new System.Drawing.Point(30, 80);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(92, 23);
            this.lblStaff.TabIndex = 4;
            this.lblStaff.Text = "Nhân viên:";
            // 
            // txtStaff
            // 
            this.txtStaff.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStaff.Location = new System.Drawing.Point(207, 76);
            this.txtStaff.Name = "txtStaff";
            this.txtStaff.ReadOnly = true;
            this.txtStaff.Size = new System.Drawing.Size(174, 30);
            this.txtStaff.TabIndex = 5;
            // 
            // lblCustomer
            // 
            this.lblCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCustomer.Location = new System.Drawing.Point(489, 80);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(142, 23);
            this.lblCustomer.TabIndex = 6;
            this.lblCustomer.Text = "Khách trả phòng:";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomer.Location = new System.Drawing.Point(637, 76);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(163, 30);
            this.txtCustomer.TabIndex = 7;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotal.Location = new System.Drawing.Point(30, 120);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(87, 23);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Tổng tiền:";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTotal.Location = new System.Drawing.Point(207, 116);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(174, 30);
            this.txtTotal.TabIndex = 9;
            // 
            // lblIn
            // 
            this.lblIn.AutoSize = true;
            this.lblIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIn.Location = new System.Drawing.Point(32, 162);
            this.lblIn.Name = "lblIn";
            this.lblIn.Size = new System.Drawing.Size(153, 23);
            this.lblIn.TabIndex = 10;
            this.lblIn.Text = "Ngày nhận phòng:";
            // 
            // txtIn
            // 
            this.txtIn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIn.Location = new System.Drawing.Point(207, 158);
            this.txtIn.Name = "txtIn";
            this.txtIn.ReadOnly = true;
            this.txtIn.Size = new System.Drawing.Size(174, 30);
            this.txtIn.TabIndex = 11;
            // 
            // lblOut
            // 
            this.lblOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOut.AutoSize = true;
            this.lblOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOut.Location = new System.Drawing.Point(489, 162);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(135, 23);
            this.lblOut.TabIndex = 12;
            this.lblOut.Text = "Ngày trả phòng:";
            // 
            // txtOut
            // 
            this.txtOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOut.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOut.Location = new System.Drawing.Point(637, 158);
            this.txtOut.Name = "txtOut";
            this.txtOut.ReadOnly = true;
            this.txtOut.Size = new System.Drawing.Size(163, 30);
            this.txtOut.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnClose.Location = new System.Drawing.Point(370, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 40);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "ĐÓNG";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // InvoiceManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.grpDetail);
            this.Controls.Add(this.btnClose);
            this.Name = "InvoiceManagerForm";
            this.Size = new System.Drawing.Size(900, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblIn;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.TextBox txtStaff;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtIn;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.Button btnClose;
    }
}