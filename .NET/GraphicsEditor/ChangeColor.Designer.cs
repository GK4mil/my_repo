namespace GraphicsEditorByGawek
{
    partial class ChangeColor
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
            this.redTrack = new System.Windows.Forms.TrackBar();
            this.Red = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.greenTrack = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.blueTrack = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.redTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // redTrack
            // 
            this.redTrack.Location = new System.Drawing.Point(19, 94);
            this.redTrack.Maximum = 255;
            this.redTrack.Name = "redTrack";
            this.redTrack.Size = new System.Drawing.Size(253, 45);
            this.redTrack.TabIndex = 0;
            this.redTrack.ValueChanged += new System.EventHandler(this.redTrack_ValueChanged);
            // 
            // Red
            // 
            this.Red.AutoSize = true;
            this.Red.Location = new System.Drawing.Point(16, 78);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(27, 13);
            this.Red.TabIndex = 1;
            this.Red.Text = "Red";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Green";
            // 
            // greenTrack
            // 
            this.greenTrack.Location = new System.Drawing.Point(19, 162);
            this.greenTrack.Maximum = 255;
            this.greenTrack.Name = "greenTrack";
            this.greenTrack.Size = new System.Drawing.Size(253, 45);
            this.greenTrack.TabIndex = 3;
            this.greenTrack.ValueChanged += new System.EventHandler(this.greenTrack_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Blue";
            // 
            // blueTrack
            // 
            this.blueTrack.Location = new System.Drawing.Point(19, 226);
            this.blueTrack.Maximum = 255;
            this.blueTrack.Name = "blueTrack";
            this.blueTrack.Size = new System.Drawing.Size(253, 45);
            this.blueTrack.TabIndex = 5;
            this.blueTrack.ValueChanged += new System.EventHandler(this.blueTrack_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Preview";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(241, 314);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(19, 30);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(253, 45);
            this.trackBar1.TabIndex = 9;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Alpha";
            // 
            // ChangeColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 361);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.blueTrack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.greenTrack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.redTrack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(300, 400);
            this.MinimumSize = new System.Drawing.Size(300, 400);
            this.Name = "ChangeColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeColor";
            ((System.ComponentModel.ISupportInitialize)(this.redTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar redTrack;
        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar greenTrack;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar blueTrack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label4;
    }
}