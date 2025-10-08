namespace HotelManagement
{
    partial class RoomCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblStatusurf;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblStatusurf = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRoomName.Location = new System.Drawing.Point(20, 10);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(0, 32);
            this.lblRoomName.TabIndex = 0;
            // 
            // lblStatusurf
            // 
            this.lblStatusurf.AutoSize = true;
            this.lblStatusurf.Location = new System.Drawing.Point(20, 40);
            this.lblStatusurf.Name = "lblStatusurf";
            this.lblStatusurf.Size = new System.Drawing.Size(0, 22);
            this.lblStatusurf.TabIndex = 1;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Location = new System.Drawing.Point(20, 60);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(0, 22);
            this.lblRoomType.TabIndex = 4;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(20, 80);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 22);
            this.lblPrice.TabIndex = 5;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnEdit.Location = new System.Drawing.Point(19, 113);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDelete.Location = new System.Drawing.Point(109, 113);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RoomCardControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblRoomName);
            this.Controls.Add(this.lblStatusurf);
            this.Controls.Add(this.lblRoomType);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(29);
            this.Name = "RoomCardControl";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.Size = new System.Drawing.Size(200, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}