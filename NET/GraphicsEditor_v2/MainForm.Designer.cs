namespace GraphicsEditorByGawek
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otwórzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ekranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czyśćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.przetwarzajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skalaSzarościToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skalaSzarościToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.skalaSzarościLightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.czarnoBiałeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inversjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negatywToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detekcjaKrawedziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oilpaintingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wyrównanieHistogramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ącyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inneOpcjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.narzedzie_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.kolor_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.wspolrzedne_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.thickness_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.zoomIn_button = new System.Windows.Forms.Button();
            this.zoomOut_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.moreheight_button = new System.Windows.Forms.Button();
            this.lessheight_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.morewidth_button = new System.Windows.Forms.Button();
            this.lesswidth_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fill_button = new System.Windows.Forms.Button();
            this.kolor_button = new System.Windows.Forms.Button();
            this.gumka_button = new System.Windows.Forms.Button();
            this.bezier_button = new System.Windows.Forms.Button();
            this.wielokat_button = new System.Windows.Forms.Button();
            this.wycinek_button = new System.Windows.Forms.Button();
            this.luk_button = new System.Windows.Forms.Button();
            this.elipsa_button = new System.Windows.Forms.Button();
            this.kwadrat_button = new System.Windows.Forms.Button();
            this.kolo_button = new System.Windows.Forms.Button();
            this.punkt_button = new System.Windows.Forms.Button();
            this.imagepanel = new System.Windows.Forms.Panel();
            this.medianFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kuwaharaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtracjaKolorówToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.imagepanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(654, 359);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.ekranToolStripMenuItem,
            this.przetwarzajToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.otwórzToolStripMenuItem,
            this.zapiszToolStripMenuItem,
            this.zamknijToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // otwórzToolStripMenuItem
            // 
            this.otwórzToolStripMenuItem.Name = "otwórzToolStripMenuItem";
            this.otwórzToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.otwórzToolStripMenuItem.Text = "Otwórz";
            this.otwórzToolStripMenuItem.Click += new System.EventHandler(this.otwórzToolStripMenuItem_Click);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.zapiszToolStripMenuItem_Click);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.zamknijToolStripMenuItem_Click);
            // 
            // ekranToolStripMenuItem
            // 
            this.ekranToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.czyśćToolStripMenuItem});
            this.ekranToolStripMenuItem.Name = "ekranToolStripMenuItem";
            this.ekranToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.ekranToolStripMenuItem.Text = "Ekran";
            // 
            // czyśćToolStripMenuItem
            // 
            this.czyśćToolStripMenuItem.Name = "czyśćToolStripMenuItem";
            this.czyśćToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.czyśćToolStripMenuItem.Text = "Czyść";
            this.czyśćToolStripMenuItem.Click += new System.EventHandler(this.czyśćToolStripMenuItem_Click);
            // 
            // przetwarzajToolStripMenuItem
            // 
            this.przetwarzajToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.skalaSzarościToolStripMenuItem,
            this.skalaSzarościToolStripMenuItem1,
            this.skalaSzarościLightnessToolStripMenuItem,
            this.czarnoBiałeToolStripMenuItem,
            this.inversjaToolStripMenuItem,
            this.negatywToolStripMenuItem,
            this.detekcjaKrawedziToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.oilpaintingToolStripMenuItem,
            this.pixelizeToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.wyrównanieHistogramuToolStripMenuItem,
            this.ącyToolStripMenuItem,
            this.medianFilterToolStripMenuItem,
            this.erosionToolStripMenuItem,
            this.kuwaharaToolStripMenuItem,
            this.filtracjaKolorówToolStripMenuItem,
            this.inneOpcjeToolStripMenuItem});
            this.przetwarzajToolStripMenuItem.Name = "przetwarzajToolStripMenuItem";
            this.przetwarzajToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.przetwarzajToolStripMenuItem.Text = "Przetwarzaj";
            // 
            // skalaSzarościToolStripMenuItem
            // 
            this.skalaSzarościToolStripMenuItem.Name = "skalaSzarościToolStripMenuItem";
            this.skalaSzarościToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.skalaSzarościToolStripMenuItem.Text = "Skala szarości";
            this.skalaSzarościToolStripMenuItem.Click += new System.EventHandler(this.skalaSzarościToolStripMenuItem_Click);
            // 
            // skalaSzarościToolStripMenuItem1
            // 
            this.skalaSzarościToolStripMenuItem1.Name = "skalaSzarościToolStripMenuItem1";
            this.skalaSzarościToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.skalaSzarościToolStripMenuItem1.Text = "Skala szarości - AVG";
            this.skalaSzarościToolStripMenuItem1.Click += new System.EventHandler(this.skalaSzarościToolStripMenuItem1_Click);
            // 
            // skalaSzarościLightnessToolStripMenuItem
            // 
            this.skalaSzarościLightnessToolStripMenuItem.Name = "skalaSzarościLightnessToolStripMenuItem";
            this.skalaSzarościLightnessToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.skalaSzarościLightnessToolStripMenuItem.Text = "Skala szarości - Lightness";
            this.skalaSzarościLightnessToolStripMenuItem.Click += new System.EventHandler(this.skalaSzarościLightnessToolStripMenuItem_Click);
            // 
            // czarnoBiałeToolStripMenuItem
            // 
            this.czarnoBiałeToolStripMenuItem.Name = "czarnoBiałeToolStripMenuItem";
            this.czarnoBiałeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.czarnoBiałeToolStripMenuItem.Text = "Czarno - białe";
            this.czarnoBiałeToolStripMenuItem.Click += new System.EventHandler(this.czarnoBiałeToolStripMenuItem_Click);
            // 
            // inversjaToolStripMenuItem
            // 
            this.inversjaToolStripMenuItem.Name = "inversjaToolStripMenuItem";
            this.inversjaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.inversjaToolStripMenuItem.Text = "Inversja";
            this.inversjaToolStripMenuItem.Click += new System.EventHandler(this.inversjaToolStripMenuItem_Click);
            // 
            // negatywToolStripMenuItem
            // 
            this.negatywToolStripMenuItem.Name = "negatywToolStripMenuItem";
            this.negatywToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.negatywToolStripMenuItem.Text = "Negatyw";
            this.negatywToolStripMenuItem.Click += new System.EventHandler(this.negatywToolStripMenuItem_Click);
            // 
            // detekcjaKrawedziToolStripMenuItem
            // 
            this.detekcjaKrawedziToolStripMenuItem.Name = "detekcjaKrawedziToolStripMenuItem";
            this.detekcjaKrawedziToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.detekcjaKrawedziToolStripMenuItem.Text = "Detekcja krawedzi";
            this.detekcjaKrawedziToolStripMenuItem.Click += new System.EventHandler(this.detekcjaKrawedziToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // oilpaintingToolStripMenuItem
            // 
            this.oilpaintingToolStripMenuItem.Name = "oilpaintingToolStripMenuItem";
            this.oilpaintingToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.oilpaintingToolStripMenuItem.Text = "Oilpainting";
            this.oilpaintingToolStripMenuItem.Click += new System.EventHandler(this.oilpaintingToolStripMenuItem_Click);
            // 
            // pixelizeToolStripMenuItem
            // 
            this.pixelizeToolStripMenuItem.Name = "pixelizeToolStripMenuItem";
            this.pixelizeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.pixelizeToolStripMenuItem.Text = "SketchCharcoal";
            this.pixelizeToolStripMenuItem.Click += new System.EventHandler(this.pixelizeToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // wyrównanieHistogramuToolStripMenuItem
            // 
            this.wyrównanieHistogramuToolStripMenuItem.Name = "wyrównanieHistogramuToolStripMenuItem";
            this.wyrównanieHistogramuToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.wyrównanieHistogramuToolStripMenuItem.Text = "Wyrównanie histogramu";
            this.wyrównanieHistogramuToolStripMenuItem.Click += new System.EventHandler(this.wyrównanieHistogramuToolStripMenuItem_Click);
            // 
            // ącyToolStripMenuItem
            // 
            this.ącyToolStripMenuItem.Name = "ącyToolStripMenuItem";
            this.ącyToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ącyToolStripMenuItem.Text = "Average 3x3";
            this.ącyToolStripMenuItem.Click += new System.EventHandler(this.ącyToolStripMenuItem_Click);
            // 
            // inneOpcjeToolStripMenuItem
            // 
            this.inneOpcjeToolStripMenuItem.Name = "inneOpcjeToolStripMenuItem";
            this.inneOpcjeToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.inneOpcjeToolStripMenuItem.Text = "Inne opcje";
            this.inneOpcjeToolStripMenuItem.Click += new System.EventHandler(this.inneOpcjeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.narzedzie_label,
            this.kolor_label,
            this.wspolrzedne_label,
            this.thickness_label});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // narzedzie_label
            // 
            this.narzedzie_label.Name = "narzedzie_label";
            this.narzedzie_label.Size = new System.Drawing.Size(118, 17);
            this.narzedzie_label.Text = "toolStripStatusLabel1";
            // 
            // kolor_label
            // 
            this.kolor_label.Name = "kolor_label";
            this.kolor_label.Size = new System.Drawing.Size(118, 17);
            this.kolor_label.Text = "toolStripStatusLabel1";
            // 
            // wspolrzedne_label
            // 
            this.wspolrzedne_label.Name = "wspolrzedne_label";
            this.wspolrzedne_label.Size = new System.Drawing.Size(118, 17);
            this.wspolrzedne_label.Text = "toolStripStatusLabel1";
            // 
            // thickness_label
            // 
            this.thickness_label.Name = "thickness_label";
            this.thickness_label.Size = new System.Drawing.Size(118, 17);
            this.thickness_label.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.zoomIn_button);
            this.panel1.Controls.Add(this.zoomOut_button);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.moreheight_button);
            this.panel1.Controls.Add(this.lessheight_button);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.morewidth_button);
            this.panel1.Controls.Add(this.lesswidth_button);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.fill_button);
            this.panel1.Controls.Add(this.kolor_button);
            this.panel1.Controls.Add(this.gumka_button);
            this.panel1.Controls.Add(this.bezier_button);
            this.panel1.Controls.Add(this.wielokat_button);
            this.panel1.Controls.Add(this.wycinek_button);
            this.panel1.Controls.Add(this.luk_button);
            this.panel1.Controls.Add(this.elipsa_button);
            this.panel1.Controls.Add(this.kwadrat_button);
            this.panel1.Controls.Add(this.kolo_button);
            this.panel1.Controls.Add(this.punkt_button);
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(60, 514);
            this.panel1.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 480);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 464);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Thickness";
            // 
            // zoomIn_button
            // 
            this.zoomIn_button.Location = new System.Drawing.Point(33, 438);
            this.zoomIn_button.Name = "zoomIn_button";
            this.zoomIn_button.Size = new System.Drawing.Size(24, 23);
            this.zoomIn_button.TabIndex = 17;
            this.zoomIn_button.Text = "+";
            this.zoomIn_button.UseVisualStyleBackColor = true;
            this.zoomIn_button.Click += new System.EventHandler(this.zoomIn_button_Click);
            // 
            // zoomOut_button
            // 
            this.zoomOut_button.Location = new System.Drawing.Point(4, 438);
            this.zoomOut_button.Name = "zoomOut_button";
            this.zoomOut_button.Size = new System.Drawing.Size(24, 23);
            this.zoomOut_button.TabIndex = 16;
            this.zoomOut_button.Text = "-";
            this.zoomOut_button.UseVisualStyleBackColor = true;
            this.zoomOut_button.Click += new System.EventHandler(this.zoomOut_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 422);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Zoom";
            // 
            // moreheight_button
            // 
            this.moreheight_button.Location = new System.Drawing.Point(33, 396);
            this.moreheight_button.Name = "moreheight_button";
            this.moreheight_button.Size = new System.Drawing.Size(24, 23);
            this.moreheight_button.TabIndex = 14;
            this.moreheight_button.Text = "+";
            this.moreheight_button.UseVisualStyleBackColor = true;
            this.moreheight_button.Click += new System.EventHandler(this.moreheight_button_Click);
            // 
            // lessheight_button
            // 
            this.lessheight_button.Location = new System.Drawing.Point(4, 396);
            this.lessheight_button.Name = "lessheight_button";
            this.lessheight_button.Size = new System.Drawing.Size(24, 23);
            this.lessheight_button.TabIndex = 13;
            this.lessheight_button.Text = "-";
            this.lessheight_button.UseVisualStyleBackColor = true;
            this.lessheight_button.Click += new System.EventHandler(this.lessheight_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Height";
            // 
            // morewidth_button
            // 
            this.morewidth_button.Location = new System.Drawing.Point(33, 353);
            this.morewidth_button.Name = "morewidth_button";
            this.morewidth_button.Size = new System.Drawing.Size(24, 23);
            this.morewidth_button.TabIndex = 11;
            this.morewidth_button.Text = "+";
            this.morewidth_button.UseVisualStyleBackColor = true;
            this.morewidth_button.Click += new System.EventHandler(this.morewidth_button_Click);
            // 
            // lesswidth_button
            // 
            this.lesswidth_button.Location = new System.Drawing.Point(4, 353);
            this.lesswidth_button.Name = "lesswidth_button";
            this.lesswidth_button.Size = new System.Drawing.Size(24, 23);
            this.lesswidth_button.TabIndex = 10;
            this.lesswidth_button.Text = "-";
            this.lesswidth_button.UseVisualStyleBackColor = true;
            this.lesswidth_button.Click += new System.EventHandler(this.lesswidth_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 336);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width";
            // 
            // fill_button
            // 
            this.fill_button.Location = new System.Drawing.Point(4, 310);
            this.fill_button.Name = "fill_button";
            this.fill_button.Size = new System.Drawing.Size(53, 23);
            this.fill_button.TabIndex = 8;
            this.fill_button.Text = "Fill";
            this.fill_button.UseVisualStyleBackColor = true;
            this.fill_button.Click += new System.EventHandler(this.fill_button_Click);
            // 
            // kolor_button
            // 
            this.kolor_button.Location = new System.Drawing.Point(4, 281);
            this.kolor_button.Name = "kolor_button";
            this.kolor_button.Size = new System.Drawing.Size(53, 23);
            this.kolor_button.TabIndex = 2;
            this.kolor_button.Text = "Kolor";
            this.kolor_button.UseVisualStyleBackColor = true;
            this.kolor_button.Click += new System.EventHandler(this.kolor_button_Click);
            // 
            // gumka_button
            // 
            this.gumka_button.Location = new System.Drawing.Point(4, 252);
            this.gumka_button.Name = "gumka_button";
            this.gumka_button.Size = new System.Drawing.Size(53, 23);
            this.gumka_button.TabIndex = 2;
            this.gumka_button.Text = "Gumka";
            this.gumka_button.UseVisualStyleBackColor = true;
            this.gumka_button.Click += new System.EventHandler(this.gumka_button_Click);
            // 
            // bezier_button
            // 
            this.bezier_button.Location = new System.Drawing.Point(4, 223);
            this.bezier_button.Name = "bezier_button";
            this.bezier_button.Size = new System.Drawing.Size(53, 23);
            this.bezier_button.TabIndex = 7;
            this.bezier_button.Text = "Bezier";
            this.bezier_button.UseVisualStyleBackColor = true;
            this.bezier_button.Click += new System.EventHandler(this.bezier_button_Click);
            // 
            // wielokat_button
            // 
            this.wielokat_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.wielokat_button.Location = new System.Drawing.Point(4, 194);
            this.wielokat_button.Name = "wielokat_button";
            this.wielokat_button.Size = new System.Drawing.Size(53, 23);
            this.wielokat_button.TabIndex = 6;
            this.wielokat_button.Text = "Wielokąt";
            this.wielokat_button.UseVisualStyleBackColor = true;
            this.wielokat_button.Click += new System.EventHandler(this.wielokat_button_Click);
            // 
            // wycinek_button
            // 
            this.wycinek_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wycinek_button.Location = new System.Drawing.Point(4, 153);
            this.wycinek_button.Name = "wycinek_button";
            this.wycinek_button.Size = new System.Drawing.Size(53, 35);
            this.wycinek_button.TabIndex = 5;
            this.wycinek_button.Text = "Wycinek koła";
            this.wycinek_button.UseVisualStyleBackColor = true;
            this.wycinek_button.Click += new System.EventHandler(this.wycinek_button_Click);
            // 
            // luk_button
            // 
            this.luk_button.Location = new System.Drawing.Point(4, 123);
            this.luk_button.Name = "luk_button";
            this.luk_button.Size = new System.Drawing.Size(53, 23);
            this.luk_button.TabIndex = 4;
            this.luk_button.Text = "Łuk";
            this.luk_button.UseVisualStyleBackColor = true;
            this.luk_button.Click += new System.EventHandler(this.luk_button_Click);
            // 
            // elipsa_button
            // 
            this.elipsa_button.Location = new System.Drawing.Point(4, 93);
            this.elipsa_button.Name = "elipsa_button";
            this.elipsa_button.Size = new System.Drawing.Size(53, 23);
            this.elipsa_button.TabIndex = 3;
            this.elipsa_button.Text = "Elipsa";
            this.elipsa_button.UseVisualStyleBackColor = true;
            this.elipsa_button.Click += new System.EventHandler(this.elipsa_button_Click);
            // 
            // kwadrat_button
            // 
            this.kwadrat_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kwadrat_button.Location = new System.Drawing.Point(4, 63);
            this.kwadrat_button.Name = "kwadrat_button";
            this.kwadrat_button.Size = new System.Drawing.Size(53, 23);
            this.kwadrat_button.TabIndex = 2;
            this.kwadrat_button.Text = "Kwadrat";
            this.kwadrat_button.UseVisualStyleBackColor = true;
            this.kwadrat_button.Click += new System.EventHandler(this.kwadrat_button_Click);
            // 
            // kolo_button
            // 
            this.kolo_button.Location = new System.Drawing.Point(4, 33);
            this.kolo_button.Name = "kolo_button";
            this.kolo_button.Size = new System.Drawing.Size(53, 23);
            this.kolo_button.TabIndex = 1;
            this.kolo_button.Text = "Koło";
            this.kolo_button.UseVisualStyleBackColor = true;
            this.kolo_button.Click += new System.EventHandler(this.kolo_button_Click);
            // 
            // punkt_button
            // 
            this.punkt_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.punkt_button.Location = new System.Drawing.Point(3, 3);
            this.punkt_button.Name = "punkt_button";
            this.punkt_button.Size = new System.Drawing.Size(54, 23);
            this.punkt_button.TabIndex = 1;
            this.punkt_button.Text = "Punkt";
            this.punkt_button.UseVisualStyleBackColor = true;
            this.punkt_button.Click += new System.EventHandler(this.punkt_button_Click);
            // 
            // imagepanel
            // 
            this.imagepanel.AutoScroll = true;
            this.imagepanel.Controls.Add(this.pictureBox);
            this.imagepanel.Location = new System.Drawing.Point(66, 28);
            this.imagepanel.Name = "imagepanel";
            this.imagepanel.Size = new System.Drawing.Size(718, 515);
            this.imagepanel.TabIndex = 0;
            // 
            // medianFilterToolStripMenuItem
            // 
            this.medianFilterToolStripMenuItem.Name = "medianFilterToolStripMenuItem";
            this.medianFilterToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.medianFilterToolStripMenuItem.Text = "MedianFilter";
            this.medianFilterToolStripMenuItem.Click += new System.EventHandler(this.medianFilterToolStripMenuItem_Click);
            // 
            // kuwaharaToolStripMenuItem
            // 
            this.kuwaharaToolStripMenuItem.Name = "kuwaharaToolStripMenuItem";
            this.kuwaharaToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.kuwaharaToolStripMenuItem.Text = "Kuwahara";
            this.kuwaharaToolStripMenuItem.Click += new System.EventHandler(this.kuwaharaToolStripMenuItem_Click);
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // filtracjaKolorówToolStripMenuItem
            // 
            this.filtracjaKolorówToolStripMenuItem.Name = "filtracjaKolorówToolStripMenuItem";
            this.filtracjaKolorówToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.filtracjaKolorówToolStripMenuItem.Text = "Filtracja kolorów";
            this.filtracjaKolorówToolStripMenuItem.Click += new System.EventHandler(this.filtracjaKolorówToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 567);
            this.Controls.Add(this.imagepanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 606);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GraphicsEditorByGawek";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.imagepanel.ResumeLayout(false);
            this.imagepanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otwórzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ekranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czyśćToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bezier_button;
        private System.Windows.Forms.Button wielokat_button;
        private System.Windows.Forms.Button wycinek_button;
        private System.Windows.Forms.Button luk_button;
        private System.Windows.Forms.Button elipsa_button;
        private System.Windows.Forms.Button kwadrat_button;
        private System.Windows.Forms.Button kolo_button;
        private System.Windows.Forms.Button punkt_button;
        private System.Windows.Forms.Button gumka_button;
        private System.Windows.Forms.Button kolor_button;
        private System.Windows.Forms.ToolStripStatusLabel narzedzie_label;
        private System.Windows.Forms.ToolStripStatusLabel kolor_label;
        private System.Windows.Forms.ToolStripStatusLabel wspolrzedne_label;
        private System.Windows.Forms.ToolStripStatusLabel thickness_label;
        private System.Windows.Forms.Button fill_button;
        private System.Windows.Forms.Panel imagepanel;
        private System.Windows.Forms.Button morewidth_button;
        private System.Windows.Forms.Button lesswidth_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button moreheight_button;
        private System.Windows.Forms.Button lessheight_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button zoomIn_button;
        private System.Windows.Forms.Button zoomOut_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem przetwarzajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skalaSzarościToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem skalaSzarościToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem skalaSzarościLightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem czarnoBiałeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inversjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negatywToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detekcjaKrawedziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oilpaintingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wyrównanieHistogramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inneOpcjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ącyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medianFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kuwaharaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtracjaKolorówToolStripMenuItem;
    }
}

