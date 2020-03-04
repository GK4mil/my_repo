namespace GraphicsEditorByGawek
{
    partial class PieProperty
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startField = new System.Windows.Forms.NumericUpDown();
            this.sweepField = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.startField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sweepField)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kąt startu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kąt obrotu:";
            // 
            // startField
            // 
            this.startField.Location = new System.Drawing.Point(16, 30);
            this.startField.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.startField.Name = "startField";
            this.startField.Size = new System.Drawing.Size(203, 20);
            this.startField.TabIndex = 2;
            this.startField.ValueChanged += new System.EventHandler(this.startField_ValueChanged);
            // 
            // sweepField
            // 
            this.sweepField.Location = new System.Drawing.Point(16, 77);
            this.sweepField.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.sweepField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sweepField.Name = "sweepField";
            this.sweepField.Size = new System.Drawing.Size(203, 20);
            this.sweepField.TabIndex = 3;
            this.sweepField.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.sweepField.ValueChanged += new System.EventHandler(this.sweepField_ValueChanged);
            // 
            // PieProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 116);
            this.Controls.Add(this.sweepField);
            this.Controls.Add(this.startField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(247, 155);
            this.MinimumSize = new System.Drawing.Size(247, 155);
            this.Name = "PieProperty";
            this.Text = "PieProperty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PieProperty_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.startField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sweepField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown startField;
        private System.Windows.Forms.NumericUpDown sweepField;
    }
}