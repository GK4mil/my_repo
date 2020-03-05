﻿namespace WindowsFormsApplication2
{
    partial class LoginPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passBox = new System.Windows.Forms.TextBox();
            this.login = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.U = new System.Windows.Forms.Button();
            this.A = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login:";
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(18, 29);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(208, 20);
            this.loginBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.MaximumSize = new System.Drawing.Size(39, 13);
            this.label2.MinimumSize = new System.Drawing.Size(39, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pass:";
            // 
            // passBox
            // 
            this.passBox.Location = new System.Drawing.Point(18, 68);
            this.passBox.Name = "passBox";
            this.passBox.PasswordChar = '*';
            this.passBox.Size = new System.Drawing.Size(208, 20);
            this.passBox.TabIndex = 3;
            // 
            // login
            // 
            this.login.Location = new System.Drawing.Point(18, 94);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(75, 23);
            this.login.TabIndex = 4;
            this.login.Text = "Login";
            this.login.UseVisualStyleBackColor = true;
            this.login.Click += new System.EventHandler(this.login_Click);
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(151, 94);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 5;
            this.close.Text = "Exit";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // U
            // 
            this.U.Location = new System.Drawing.Point(90, 123);
            this.U.Name = "U";
            this.U.Size = new System.Drawing.Size(27, 23);
            this.U.TabIndex = 6;
            this.U.Text = "U";
            this.U.UseVisualStyleBackColor = true;
            this.U.Click += new System.EventHandler(this.U_Click);
            // 
            // A
            // 
            this.A.Location = new System.Drawing.Point(123, 123);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(27, 23);
            this.A.TabIndex = 7;
            this.A.Text = "A";
            this.A.UseVisualStyleBackColor = true;
            this.A.Click += new System.EventHandler(this.A_Click);
            // 
            // LoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 144);
            this.Controls.Add(this.A);
            this.Controls.Add(this.U);
            this.Controls.Add(this.close);
            this.Controls.Add(this.login);
            this.Controls.Add(this.passBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(253, 183);
            this.MinimumSize = new System.Drawing.Size(253, 183);
            this.Name = "LoginPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passBox;
        private System.Windows.Forms.Button login;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button U;
        private System.Windows.Forms.Button A;
    }
}

