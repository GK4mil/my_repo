namespace GraphicsEditorByGawek
{
    partial class ColorFiltrationWindow
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.redmin = new System.Windows.Forms.TrackBar();
            this.greenmin = new System.Windows.Forms.TrackBar();
            this.bluemin = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.bluemax = new System.Windows.Forms.TrackBar();
            this.redmax = new System.Windows.Forms.TrackBar();
            this.greenmax = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.redmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluemin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluemax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenmax)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue";
            // 
            // redmin
            // 
            this.redmin.Location = new System.Drawing.Point(15, 25);
            this.redmin.Maximum = 255;
            this.redmin.Name = "redmin";
            this.redmin.Size = new System.Drawing.Size(255, 45);
            this.redmin.TabIndex = 3;
            // 
            // greenmin
            // 
            this.greenmin.Location = new System.Drawing.Point(12, 137);
            this.greenmin.Maximum = 255;
            this.greenmin.Name = "greenmin";
            this.greenmin.Size = new System.Drawing.Size(255, 45);
            this.greenmin.TabIndex = 4;
            // 
            // bluemin
            // 
            this.bluemin.Location = new System.Drawing.Point(15, 241);
            this.bluemin.Maximum = 255;
            this.bluemin.Name = "bluemin";
            this.bluemin.Size = new System.Drawing.Size(255, 45);
            this.bluemin.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 332);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bluemax
            // 
            this.bluemax.Location = new System.Drawing.Point(15, 281);
            this.bluemax.Maximum = 255;
            this.bluemax.Name = "bluemax";
            this.bluemax.Size = new System.Drawing.Size(248, 45);
            this.bluemax.TabIndex = 7;
            // 
            // redmax
            // 
            this.redmax.Location = new System.Drawing.Point(15, 63);
            this.redmax.Maximum = 255;
            this.redmax.Name = "redmax";
            this.redmax.Size = new System.Drawing.Size(248, 45);
            this.redmax.TabIndex = 8;
            // 
            // greenmax
            // 
            this.greenmax.Location = new System.Drawing.Point(15, 177);
            this.greenmax.Maximum = 255;
            this.greenmax.Name = "greenmax";
            this.greenmax.Size = new System.Drawing.Size(248, 45);
            this.greenmax.TabIndex = 9;
            // 
            // ColorFiltrationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 389);
            this.Controls.Add(this.greenmax);
            this.Controls.Add(this.redmax);
            this.Controls.Add(this.bluemax);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bluemin);
            this.Controls.Add(this.greenmin);
            this.Controls.Add(this.redmin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ColorFiltrationWindow";
            this.Text = "ColorFiltrationWindow";
            ((System.ComponentModel.ISupportInitialize)(this.redmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluemin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bluemax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenmax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar redmin;
        private System.Windows.Forms.TrackBar greenmin;
        private System.Windows.Forms.TrackBar bluemin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar bluemax;
        private System.Windows.Forms.TrackBar redmax;
        private System.Windows.Forms.TrackBar greenmax;
    }
}