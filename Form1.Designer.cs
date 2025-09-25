namespace HotelManagement
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.customerListBtn = new System.Windows.Forms.Label();
            this.customerManageBtn = new System.Windows.Forms.Label();
            this.customerListPanel = new System.Windows.Forms.Panel();
            this.customerManagePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.customerListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer1.Panel1.Controls.Add(this.customerListBtn);
            this.splitContainer1.Panel1.Controls.Add(this.customerManageBtn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.customerListPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1192, 642);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.TabIndex = 0;
            // 
            // customerListBtn
            // 
            this.customerListBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.customerListBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.customerListBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.customerListBtn.Location = new System.Drawing.Point(0, 94);
            this.customerListBtn.Name = "customerListBtn";
            this.customerListBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.customerListBtn.Size = new System.Drawing.Size(316, 94);
            this.customerListBtn.TabIndex = 0;
            this.customerListBtn.Text = "Danh sách khách hàng";
            this.customerListBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customerListBtn.Click += new System.EventHandler(this.customerListBtn_Click);
            // 
            // customerManageBtn
            // 
            this.customerManageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.customerManageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.customerManageBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.customerManageBtn.Location = new System.Drawing.Point(0, 0);
            this.customerManageBtn.Name = "customerManageBtn";
            this.customerManageBtn.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.customerManageBtn.Size = new System.Drawing.Size(316, 94);
            this.customerManageBtn.TabIndex = 1;
            this.customerManageBtn.Text = "Quản lý khách hàng";
            this.customerManageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // customerListPanel
            // 
            this.customerListPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.customerListPanel.Controls.Add(this.customerManagePanel);
            this.customerListPanel.Location = new System.Drawing.Point(2, 0);
            this.customerListPanel.Name = "customerListPanel";
            this.customerListPanel.Size = new System.Drawing.Size(870, 642);
            this.customerListPanel.TabIndex = 0;
            // 
            // customerManagePanel
            // 
            this.customerManagePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.customerManagePanel.Location = new System.Drawing.Point(0, 0);
            this.customerManagePanel.Name = "customerManagePanel";
            this.customerManagePanel.Size = new System.Drawing.Size(870, 642);
            this.customerManagePanel.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 642);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.customerListPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label customerManageBtn;
        private System.Windows.Forms.Label customerListBtn;
        private System.Windows.Forms.Panel customerListPanel;
        private System.Windows.Forms.Panel customerManagePanel;
    }
}

