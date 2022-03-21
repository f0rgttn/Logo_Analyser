
namespace Logo_Anl
{
    partial class MenuScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLogoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colourimetricsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getAllValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getUniqueValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.detectObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classifyBusinessTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.colourimetricsToolStripMenuItem,
            this.objectDetectionToolStripMenuItem,
            this.classificationToolStripMenuItem,
            this.readTextToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadLogoToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadLogoToolStripMenuItem
            // 
            this.loadLogoToolStripMenuItem.Name = "loadLogoToolStripMenuItem";
            this.loadLogoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadLogoToolStripMenuItem.Text = "Load Logo";
            this.loadLogoToolStripMenuItem.Click += new System.EventHandler(this.loadLogoToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // colourimetricsToolStripMenuItem
            // 
            this.colourimetricsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getAllValuesToolStripMenuItem,
            this.getUniqueValuesToolStripMenuItem});
            this.colourimetricsToolStripMenuItem.Name = "colourimetricsToolStripMenuItem";
            this.colourimetricsToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.colourimetricsToolStripMenuItem.Text = "Colourimetrics";
            // 
            // getAllValuesToolStripMenuItem
            // 
            this.getAllValuesToolStripMenuItem.Name = "getAllValuesToolStripMenuItem";
            this.getAllValuesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.getAllValuesToolStripMenuItem.Text = "Get all values";
            this.getAllValuesToolStripMenuItem.Click += new System.EventHandler(this.getAllValuesToolStripMenuItem_Click);
            // 
            // getUniqueValuesToolStripMenuItem
            // 
            this.getUniqueValuesToolStripMenuItem.Name = "getUniqueValuesToolStripMenuItem";
            this.getUniqueValuesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.getUniqueValuesToolStripMenuItem.Text = "Get unique values";
            this.getUniqueValuesToolStripMenuItem.Click += new System.EventHandler(this.getUniqueValuesToolStripMenuItem_Click);
            // 
            // objectDetectionToolStripMenuItem
            // 
            this.objectDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.detectObjectsToolStripMenuItem});
            this.objectDetectionToolStripMenuItem.Name = "objectDetectionToolStripMenuItem";
            this.objectDetectionToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.objectDetectionToolStripMenuItem.Text = "Object Detection";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem2.Text = "Load Model";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // detectObjectsToolStripMenuItem
            // 
            this.detectObjectsToolStripMenuItem.Name = "detectObjectsToolStripMenuItem";
            this.detectObjectsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.detectObjectsToolStripMenuItem.Text = "Detect Objects";
            this.detectObjectsToolStripMenuItem.Click += new System.EventHandler(this.detectObjectsToolStripMenuItem_Click);
            // 
            // classificationToolStripMenuItem
            // 
            this.classificationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classifyBusinessTypeToolStripMenuItem});
            this.classificationToolStripMenuItem.Name = "classificationToolStripMenuItem";
            this.classificationToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.classificationToolStripMenuItem.Text = "Classification";
            // 
            // classifyBusinessTypeToolStripMenuItem
            // 
            this.classifyBusinessTypeToolStripMenuItem.Name = "classifyBusinessTypeToolStripMenuItem";
            this.classifyBusinessTypeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.classifyBusinessTypeToolStripMenuItem.Text = "Classify Business Type";
            this.classifyBusinessTypeToolStripMenuItem.Click += new System.EventHandler(this.classifyBusinessTypeToolStripMenuItem_Click);
            // 
            // readTextToolStripMenuItem
            // 
            this.readTextToolStripMenuItem.Name = "readTextToolStripMenuItem";
            this.readTextToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.readTextToolStripMenuItem.Text = "Read Text";
            this.readTextToolStripMenuItem.Click += new System.EventHandler(this.readTextToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(13, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 413);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(126, 90);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.Location = new System.Drawing.Point(-1, 136);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 274);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuScreen";
            this.Text = "MenuScreen";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadLogoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colourimetricsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getAllValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getUniqueValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem detectObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classificationToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem classifyBusinessTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readTextToolStripMenuItem;
    }
}