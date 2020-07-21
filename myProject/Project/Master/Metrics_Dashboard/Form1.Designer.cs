namespace Metrics_Dashboard
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
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cboClientNameList = new System.Windows.Forms.ComboBox();
            this.txtClientLastName = new System.Windows.Forms.TextBox();
            this.lblClientLastName = new System.Windows.Forms.Label();
            this.lblClient_SelectClient = new System.Windows.Forms.Label();
            this.btnClient_Delete = new System.Windows.Forms.Button();
            this.btnClient_Update = new System.Windows.Forms.Button();
            this.lblCustomerInformation = new System.Windows.Forms.Label();
            this.txtClientFirstName = new System.Windows.Forms.TextBox();
            this.txtClientEmail = new System.Windows.Forms.TextBox();
            this.txtClientPassword = new System.Windows.Forms.TextBox();
            this.btnClient_Save = new System.Windows.Forms.Button();
            this.lblClientFirstName = new System.Windows.Forms.Label();
            this.lblClientEmail = new System.Windows.Forms.Label();
            this.lblClientPassword = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1115, 434);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cboClientNameList);
            this.tabPage1.Controls.Add(this.txtClientLastName);
            this.tabPage1.Controls.Add(this.lblClientLastName);
            this.tabPage1.Controls.Add(this.lblClient_SelectClient);
            this.tabPage1.Controls.Add(this.btnClient_Delete);
            this.tabPage1.Controls.Add(this.btnClient_Update);
            this.tabPage1.Controls.Add(this.lblCustomerInformation);
            this.tabPage1.Controls.Add(this.txtClientFirstName);
            this.tabPage1.Controls.Add(this.txtClientEmail);
            this.tabPage1.Controls.Add(this.txtClientPassword);
            this.tabPage1.Controls.Add(this.btnClient_Save);
            this.tabPage1.Controls.Add(this.lblClientFirstName);
            this.tabPage1.Controls.Add(this.lblClientEmail);
            this.tabPage1.Controls.Add(this.lblClientPassword);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1107, 405);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cboClientNameList
            // 
            this.cboClientNameList.FormattingEnabled = true;
            this.cboClientNameList.Location = new System.Drawing.Point(594, 103);
            this.cboClientNameList.Name = "cboClientNameList";
            this.cboClientNameList.Size = new System.Drawing.Size(182, 24);
            this.cboClientNameList.TabIndex = 67;
            // 
            // txtClientLastName
            // 
            this.txtClientLastName.Location = new System.Drawing.Point(202, 139);
            this.txtClientLastName.Name = "txtClientLastName";
            this.txtClientLastName.Size = new System.Drawing.Size(168, 22);
            this.txtClientLastName.TabIndex = 65;
            // 
            // lblClientLastName
            // 
            this.lblClientLastName.AutoSize = true;
            this.lblClientLastName.Location = new System.Drawing.Point(112, 139);
            this.lblClientLastName.Name = "lblClientLastName";
            this.lblClientLastName.Size = new System.Drawing.Size(84, 17);
            this.lblClientLastName.TabIndex = 66;
            this.lblClientLastName.Text = "Last Name: ";
            // 
            // lblClient_SelectClient
            // 
            this.lblClient_SelectClient.AutoSize = true;
            this.lblClient_SelectClient.Location = new System.Drawing.Point(484, 103);
            this.lblClient_SelectClient.Name = "lblClient_SelectClient";
            this.lblClient_SelectClient.Size = new System.Drawing.Size(90, 17);
            this.lblClient_SelectClient.TabIndex = 64;
            this.lblClient_SelectClient.Text = "Select Client:";
            // 
            // btnClient_Delete
            // 
            this.btnClient_Delete.Location = new System.Drawing.Point(594, 208);
            this.btnClient_Delete.Name = "btnClient_Delete";
            this.btnClient_Delete.Size = new System.Drawing.Size(182, 23);
            this.btnClient_Delete.TabIndex = 63;
            this.btnClient_Delete.Text = "Delete";
            this.btnClient_Delete.UseVisualStyleBackColor = true;
            this.btnClient_Delete.Click += new System.EventHandler(this.btnClient_Delete_Click);
            // 
            // btnClient_Update
            // 
            this.btnClient_Update.AutoSize = true;
            this.btnClient_Update.Location = new System.Drawing.Point(594, 134);
            this.btnClient_Update.Name = "btnClient_Update";
            this.btnClient_Update.Size = new System.Drawing.Size(182, 27);
            this.btnClient_Update.TabIndex = 62;
            this.btnClient_Update.Text = "Update";
            this.btnClient_Update.UseVisualStyleBackColor = true;
            this.btnClient_Update.Click += new System.EventHandler(this.btnClient_Update_Click);
            // 
            // lblCustomerInformation
            // 
            this.lblCustomerInformation.AutoSize = true;
            this.lblCustomerInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInformation.Location = new System.Drawing.Point(340, 26);
            this.lblCustomerInformation.Name = "lblCustomerInformation";
            this.lblCustomerInformation.Size = new System.Drawing.Size(200, 29);
            this.lblCustomerInformation.TabIndex = 58;
            this.lblCustomerInformation.Text = "Client Information";
            // 
            // txtClientFirstName
            // 
            this.txtClientFirstName.Location = new System.Drawing.Point(202, 107);
            this.txtClientFirstName.Name = "txtClientFirstName";
            this.txtClientFirstName.Size = new System.Drawing.Size(168, 22);
            this.txtClientFirstName.TabIndex = 54;
            // 
            // txtClientEmail
            // 
            this.txtClientEmail.Location = new System.Drawing.Point(202, 172);
            this.txtClientEmail.Name = "txtClientEmail";
            this.txtClientEmail.Size = new System.Drawing.Size(168, 22);
            this.txtClientEmail.TabIndex = 55;
            // 
            // txtClientPassword
            // 
            this.txtClientPassword.Location = new System.Drawing.Point(202, 200);
            this.txtClientPassword.Name = "txtClientPassword";
            this.txtClientPassword.Size = new System.Drawing.Size(168, 22);
            this.txtClientPassword.TabIndex = 56;
            // 
            // btnClient_Save
            // 
            this.btnClient_Save.Location = new System.Drawing.Point(202, 245);
            this.btnClient_Save.Name = "btnClient_Save";
            this.btnClient_Save.Size = new System.Drawing.Size(168, 23);
            this.btnClient_Save.TabIndex = 57;
            this.btnClient_Save.Text = "Save ";
            this.btnClient_Save.UseVisualStyleBackColor = true;
            this.btnClient_Save.Click += new System.EventHandler(this.btnClient_Save_Click);
            // 
            // lblClientFirstName
            // 
            this.lblClientFirstName.AutoSize = true;
            this.lblClientFirstName.Location = new System.Drawing.Point(112, 107);
            this.lblClientFirstName.Name = "lblClientFirstName";
            this.lblClientFirstName.Size = new System.Drawing.Size(84, 17);
            this.lblClientFirstName.TabIndex = 59;
            this.lblClientFirstName.Text = "First Name: ";
            // 
            // lblClientEmail
            // 
            this.lblClientEmail.AutoSize = true;
            this.lblClientEmail.Location = new System.Drawing.Point(142, 177);
            this.lblClientEmail.Name = "lblClientEmail";
            this.lblClientEmail.Size = new System.Drawing.Size(54, 17);
            this.lblClientEmail.TabIndex = 60;
            this.lblClientEmail.Text = "Email:  ";
            // 
            // lblClientPassword
            // 
            this.lblClientPassword.AutoSize = true;
            this.lblClientPassword.Location = new System.Drawing.Point(115, 205);
            this.lblClientPassword.Name = "lblClientPassword";
            this.lblClientPassword.Size = new System.Drawing.Size(81, 17);
            this.lblClientPassword.TabIndex = 61;
            this.lblClientPassword.Text = "Password:  ";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1107, 405);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 653);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cboClientNameList;
        private System.Windows.Forms.TextBox txtClientLastName;
        private System.Windows.Forms.Label lblClientLastName;
        private System.Windows.Forms.Label lblClient_SelectClient;
        private System.Windows.Forms.Button btnClient_Delete;
        private System.Windows.Forms.Button btnClient_Update;
        private System.Windows.Forms.Label lblCustomerInformation;
        private System.Windows.Forms.TextBox txtClientFirstName;
        private System.Windows.Forms.TextBox txtClientEmail;
        private System.Windows.Forms.TextBox txtClientPassword;
        private System.Windows.Forms.Button btnClient_Save;
        private System.Windows.Forms.Label lblClientFirstName;
        private System.Windows.Forms.Label lblClientEmail;
        private System.Windows.Forms.Label lblClientPassword;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

