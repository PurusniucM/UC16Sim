namespace UC16_Assembler
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.rtbBinar = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stripBtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.stripBtnSaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.stripBtnAssemble = new System.Windows.Forms.ToolStripButton();
            this.stripBtnStartSimulation = new System.Windows.Forms.ToolStripButton();
            this.stripBtnRun = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.stripBtnExit = new System.Windows.Forms.ToolStripButton();
            this.stripBtnHelp = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbHexa = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbContinut = new System.Windows.Forms.RichTextBox();
            this.rtbError = new System.Windows.Forms.RichTextBox();
            this.openFileDia = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbBinar
            // 
            this.rtbBinar.BackColor = System.Drawing.Color.Black;
            this.rtbBinar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbBinar.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbBinar.Location = new System.Drawing.Point(216, 57);
            this.rtbBinar.Name = "rtbBinar";
            this.rtbBinar.ReadOnly = true;
            this.rtbBinar.Size = new System.Drawing.Size(200, 280);
            this.rtbBinar.TabIndex = 2;
            this.rtbBinar.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripBtnOpenFile,
            this.stripBtnSaveFile,
            this.toolStripSeparator2,
            this.stripBtnAssemble,
            this.stripBtnStartSimulation,
            this.stripBtnRun,
            this.toolStripSeparator1,
            this.stripBtnExit,
            this.stripBtnHelp});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(593, 41);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stripBtnOpenFile
            // 
            this.stripBtnOpenFile.AutoSize = false;
            this.stripBtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnOpenFile.Image")));
            this.stripBtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnOpenFile.Name = "stripBtnOpenFile";
            this.stripBtnOpenFile.Size = new System.Drawing.Size(38, 38);
            this.stripBtnOpenFile.Text = "Deschide";
            this.stripBtnOpenFile.Click += new System.EventHandler(this.stripBtnOpenFile_Click);
            // 
            // stripBtnSaveFile
            // 
            this.stripBtnSaveFile.AutoSize = false;
            this.stripBtnSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnSaveFile.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnSaveFile.Image")));
            this.stripBtnSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnSaveFile.Name = "stripBtnSaveFile";
            this.stripBtnSaveFile.Size = new System.Drawing.Size(38, 38);
            this.stripBtnSaveFile.Text = "Salveaza";
            this.stripBtnSaveFile.Click += new System.EventHandler(this.stripBtnSaveFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // stripBtnAssemble
            // 
            this.stripBtnAssemble.AutoSize = false;
            this.stripBtnAssemble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnAssemble.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnAssemble.Image")));
            this.stripBtnAssemble.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnAssemble.Name = "stripBtnAssemble";
            this.stripBtnAssemble.Size = new System.Drawing.Size(38, 38);
            this.stripBtnAssemble.Text = "Asambleaza";
            this.stripBtnAssemble.Click += new System.EventHandler(this.stripBtnAssemble_Click);
            // 
            // stripBtnStartSimulation
            // 
            this.stripBtnStartSimulation.AutoSize = false;
            this.stripBtnStartSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnStartSimulation.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnStartSimulation.Image")));
            this.stripBtnStartSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnStartSimulation.Name = "stripBtnStartSimulation";
            this.stripBtnStartSimulation.Size = new System.Drawing.Size(38, 38);
            this.stripBtnStartSimulation.Text = "Simulator";
            this.stripBtnStartSimulation.Click += new System.EventHandler(this.stripBtnStartSimulation_Click);
            // 
            // stripBtnRun
            // 
            this.stripBtnRun.AutoSize = false;
            this.stripBtnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnRun.Enabled = false;
            this.stripBtnRun.Image = global::UC16_Assembler.Properties.Resources.nextLine;
            this.stripBtnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnRun.Name = "stripBtnRun";
            this.stripBtnRun.Size = new System.Drawing.Size(38, 38);
            this.stripBtnRun.Text = "Executa instructiune";
            this.stripBtnRun.Click += new System.EventHandler(this.stripBtnRun_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // stripBtnExit
            // 
            this.stripBtnExit.AutoSize = false;
            this.stripBtnExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnExit.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnExit.Image")));
            this.stripBtnExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnExit.Name = "stripBtnExit";
            this.stripBtnExit.Size = new System.Drawing.Size(38, 38);
            this.stripBtnExit.Text = "Iesire";
            this.stripBtnExit.Click += new System.EventHandler(this.stripBtnExit_Click);
            // 
            // stripBtnHelp
            // 
            this.stripBtnHelp.AutoSize = false;
            this.stripBtnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stripBtnHelp.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnHelp.Image")));
            this.stripBtnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnHelp.Name = "stripBtnHelp";
            this.stripBtnHelp.Size = new System.Drawing.Size(38, 38);
            this.stripBtnHelp.Text = "Ajutor";
            this.stripBtnHelp.Click += new System.EventHandler(this.stripBtnHelp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Continut";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(213, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Instructiuni in format binar";
            // 
            // rtbHexa
            // 
            this.rtbHexa.BackColor = System.Drawing.Color.Black;
            this.rtbHexa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHexa.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbHexa.Location = new System.Drawing.Point(422, 57);
            this.rtbHexa.Name = "rtbHexa";
            this.rtbHexa.ReadOnly = true;
            this.rtbHexa.Size = new System.Drawing.Size(159, 280);
            this.rtbHexa.TabIndex = 6;
            this.rtbHexa.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(419, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Instructiuni in format hexazecimal";
            // 
            // rtbContinut
            // 
            this.rtbContinut.AcceptsTab = true;
            this.rtbContinut.BackColor = System.Drawing.Color.Black;
            this.rtbContinut.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContinut.ForeColor = System.Drawing.SystemColors.Info;
            this.rtbContinut.Location = new System.Drawing.Point(12, 57);
            this.rtbContinut.Name = "rtbContinut";
            this.rtbContinut.Size = new System.Drawing.Size(198, 280);
            this.rtbContinut.TabIndex = 8;
            this.rtbContinut.Text = "";
            // 
            // rtbError
            // 
            this.rtbError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbError.Location = new System.Drawing.Point(12, 373);
            this.rtbError.Name = "rtbError";
            this.rtbError.Size = new System.Drawing.Size(569, 66);
            this.rtbError.TabIndex = 9;
            this.rtbError.Text = "";
            // 
            // openFileDia
            // 
            this.openFileDia.FileName = "openFileDialog1";
            this.openFileDia.Filter = "Text Files (.txt)|*.txt";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(593, 446);
            this.Controls.Add(this.rtbError);
            this.Controls.Add(this.rtbContinut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbHexa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.rtbBinar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Uc16_Assembler";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbBinar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbHexa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton stripBtnOpenFile;
        private System.Windows.Forms.ToolStripButton stripBtnSaveFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton stripBtnAssemble;
        private System.Windows.Forms.ToolStripButton stripBtnStartSimulation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton stripBtnExit;
        private System.Windows.Forms.ToolStripButton stripBtnHelp;
        private System.Windows.Forms.RichTextBox rtbContinut;
        private System.Windows.Forms.RichTextBox rtbError;
        private System.Windows.Forms.OpenFileDialog openFileDia;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripButton stripBtnRun;
    }
}

