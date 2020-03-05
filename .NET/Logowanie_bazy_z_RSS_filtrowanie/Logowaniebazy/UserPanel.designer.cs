namespace WindowsFormsApplication2
{
    partial class UserPanel
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
            this.components = new System.ComponentModel.Container();
            this.usertabcontrol = new System.Windows.Forms.TabControl();
            this.adding = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.savebutton = new System.Windows.Forms.Button();
            this.urlbox = new System.Windows.Forms.TextBox();
            this.displaying = new System.Windows.Forms.TabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.usunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dg = new System.Windows.Forms.DataGridView();
            this.usertabcontrol.SuspendLayout();
            this.adding.SuspendLayout();
            this.displaying.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            this.SuspendLayout();
            // 
            // usertabcontrol
            // 
            this.usertabcontrol.Controls.Add(this.adding);
            this.usertabcontrol.Controls.Add(this.displaying);
            this.usertabcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usertabcontrol.Location = new System.Drawing.Point(0, 0);
            this.usertabcontrol.Name = "usertabcontrol";
            this.usertabcontrol.SelectedIndex = 0;
            this.usertabcontrol.Size = new System.Drawing.Size(582, 261);
            this.usertabcontrol.TabIndex = 0;
            // 
            // adding
            // 
            this.adding.Controls.Add(this.label1);
            this.adding.Controls.Add(this.savebutton);
            this.adding.Controls.Add(this.urlbox);
            this.adding.Location = new System.Drawing.Point(4, 22);
            this.adding.Name = "adding";
            this.adding.Padding = new System.Windows.Forms.Padding(3);
            this.adding.Size = new System.Drawing.Size(574, 235);
            this.adding.TabIndex = 0;
            this.adding.Text = "Channel adding";
            this.adding.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter the address of the RSS channel below:";
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(8, 77);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 1;
            this.savebutton.Text = "Save";
            this.savebutton.UseVisualStyleBackColor = true;
            // 
            // urlbox
            // 
            this.urlbox.Location = new System.Drawing.Point(8, 51);
            this.urlbox.Name = "urlbox";
            this.urlbox.Size = new System.Drawing.Size(558, 20);
            this.urlbox.TabIndex = 0;
            // 
            // displaying
            // 
            this.displaying.Controls.Add(this.filterbox);
            this.displaying.Controls.Add(this.label2);
            this.displaying.Controls.Add(this.dg);
            this.displaying.Location = new System.Drawing.Point(4, 22);
            this.displaying.Name = "displaying";
            this.displaying.Padding = new System.Windows.Forms.Padding(3);
            this.displaying.Size = new System.Drawing.Size(574, 235);
            this.displaying.TabIndex = 1;
            this.displaying.Text = "Channels displaying";
            this.displaying.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usunToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // usunToolStripMenuItem
            // 
            this.usunToolStripMenuItem.Name = "usunToolStripMenuItem";
            this.usunToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usunToolStripMenuItem.Text = "Usun";
            this.usunToolStripMenuItem.Click += new System.EventHandler(this.usunToolStripMenuItem_Click);
            // 
            // filterbox
            // 
            this.filterbox.Location = new System.Drawing.Point(75, 201);
            this.filterbox.Name = "filterbox";
            this.filterbox.Size = new System.Drawing.Size(493, 20);
            this.filterbox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add a filter:";
            // 
            // dg
            // 
            this.dg.AllowUserToAddRows = false;
            this.dg.AllowUserToDeleteRows = false;
            this.dg.AllowUserToOrderColumns = true;
            this.dg.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.ContextMenuStrip = this.contextMenuStrip1;
            this.dg.Location = new System.Drawing.Point(8, 6);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg.Size = new System.Drawing.Size(560, 192);
            this.dg.TabIndex = 0;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 261);
            this.Controls.Add(this.usertabcontrol);
            this.Name = "UserPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserPanel";
            this.Load += new System.EventHandler(this.UserPanel_Load);
            this.Resize += new System.EventHandler(this.UserPanel_Resize);
            this.usertabcontrol.ResumeLayout(false);
            this.adding.ResumeLayout(false);
            this.adding.PerformLayout();
            this.displaying.ResumeLayout(false);
            this.displaying.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl usertabcontrol;
        private System.Windows.Forms.TabPage adding;
        private System.Windows.Forms.TabPage displaying;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button savebutton;
        private System.Windows.Forms.TextBox urlbox;
        private System.Windows.Forms.TextBox filterbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usunToolStripMenuItem;
    }
}