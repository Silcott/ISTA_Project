namespace TrackITManagementSystem
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.lblDevTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTicketTotalCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTicketTodayCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTicketOpenCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.ticketSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.menuStripTop.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.adminToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Padding = new System.Windows.Forms.Padding(6, 10, 0, 10);
            this.menuStripTop.Size = new System.Drawing.Size(1135, 41);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.SystemColors.Control;
            this.panelFooter.Controls.Add(this.lblDeveloper);
            this.panelFooter.Controls.Add(this.lblDevTitle);
            this.panelFooter.Controls.Add(this.label1);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 546);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1135, 64);
            this.panelFooter.TabIndex = 1;
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.BackColor = System.Drawing.SystemColors.Control;
            this.lblDeveloper.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloper.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDeveloper.Location = new System.Drawing.Point(734, 14);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(194, 30);
            this.lblDeveloper.TabIndex = 2;
            this.lblDeveloper.Text = "JAMES B. SILCOTT";
            // 
            // lblDevTitle
            // 
            this.lblDevTitle.AutoSize = true;
            this.lblDevTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblDevTitle.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDevTitle.Location = new System.Drawing.Point(587, 14);
            this.lblDevTitle.Name = "lblDevTitle";
            this.lblDevTitle.Size = new System.Drawing.Size(154, 30);
            this.lblDevTitle.TabIndex = 1;
            this.lblDevTitle.Text = "Developed By -";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Ebrima", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(76)))), ((int)(((byte)(58)))));
            this.label1.Location = new System.Drawing.Point(271, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tracking!T Management System";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTicketTotalCount);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(344, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 2;
            // 
            // lblTicketTotalCount
            // 
            this.lblTicketTotalCount.AutoSize = true;
            this.lblTicketTotalCount.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(76)))), ((int)(((byte)(58)))));
            this.lblTicketTotalCount.Location = new System.Drawing.Point(73, 25);
            this.lblTicketTotalCount.Name = "lblTicketTotalCount";
            this.lblTicketTotalCount.Size = new System.Drawing.Size(51, 58);
            this.lblTicketTotalCount.TabIndex = 1;
            this.lblTicketTotalCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(76)))), ((int)(((byte)(58)))));
            this.label2.Location = new System.Drawing.Point(38, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Total Tickets";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTicketTodayCount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(573, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 3;
            // 
            // lblTicketTodayCount
            // 
            this.lblTicketTodayCount.AutoSize = true;
            this.lblTicketTodayCount.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketTodayCount.ForeColor = System.Drawing.Color.Goldenrod;
            this.lblTicketTodayCount.Location = new System.Drawing.Point(74, 25);
            this.lblTicketTodayCount.Name = "lblTicketTodayCount";
            this.lblTicketTodayCount.Size = new System.Drawing.Size(51, 58);
            this.lblTicketTodayCount.TabIndex = 1;
            this.lblTicketTodayCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Goldenrod;
            this.label4.Location = new System.Drawing.Point(14, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tickets Reported Today";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblTicketOpenCount);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(804, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 4;
            // 
            // lblTicketOpenCount
            // 
            this.lblTicketOpenCount.AutoSize = true;
            this.lblTicketOpenCount.Font = new System.Drawing.Font("Bahnschrift", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketOpenCount.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblTicketOpenCount.Location = new System.Drawing.Point(72, 25);
            this.lblTicketOpenCount.Name = "lblTicketOpenCount";
            this.lblTicketOpenCount.Size = new System.Drawing.Size(51, 58);
            this.lblTicketOpenCount.TabIndex = 1;
            this.lblTicketOpenCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label6.Location = new System.Drawing.Point(36, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Open Tickets";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dgvTickets
            // 
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(344, 224);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.Size = new System.Drawing.Size(660, 301);
            this.dgvTickets.TabIndex = 5;
            // 
            // ticketSearch
            // 
            this.ticketSearch.AutoSize = true;
            this.ticketSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketSearch.Location = new System.Drawing.Point(340, 188);
            this.ticketSearch.Name = "ticketSearch";
            this.ticketSearch.Size = new System.Drawing.Size(111, 21);
            this.ticketSearch.TabIndex = 6;
            this.ticketSearch.Text = "Ticket Search";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(458, 188);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(546, 29);
            this.txtSearch.TabIndex = 7;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(1089, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 8;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1135, 610);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.ticketSearch);
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.menuStripTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "frmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Label lblDevTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTicketTotalCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTicketTodayCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTicketOpenCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Label ticketSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.PictureBox pictureBoxClose;
    }
}

