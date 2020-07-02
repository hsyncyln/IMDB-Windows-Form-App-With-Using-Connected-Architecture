namespace Imdb
{
    partial class FormMovie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMovie));
            this.pbxPoster = new System.Windows.Forms.PictureBox();
            this.lstbxWriter = new System.Windows.Forms.ListBox();
            this.lstbxDirector = new System.Windows.Forms.ListBox();
            this.lblWriter = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.rchbxDate = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblDirector = new System.Windows.Forms.Label();
            this.rchbxRate = new System.Windows.Forms.RichTextBox();
            this.rchbxDescription = new System.Windows.Forms.RichTextBox();
            this.lstbxStar = new System.Windows.Forms.ListBox();
            this.lblStar = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.labelImdb = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.lstbxGenre = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPoster)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxPoster
            // 
            this.pbxPoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPoster.Image = ((System.Drawing.Image)(resources.GetObject("pbxPoster.Image")));
            this.pbxPoster.Location = new System.Drawing.Point(25, 67);
            this.pbxPoster.Name = "pbxPoster";
            this.pbxPoster.Size = new System.Drawing.Size(162, 199);
            this.pbxPoster.TabIndex = 69;
            this.pbxPoster.TabStop = false;
            // 
            // lstbxWriter
            // 
            this.lstbxWriter.FormattingEnabled = true;
            this.lstbxWriter.Location = new System.Drawing.Point(345, 82);
            this.lstbxWriter.Name = "lstbxWriter";
            this.lstbxWriter.Size = new System.Drawing.Size(120, 134);
            this.lstbxWriter.TabIndex = 68;
            this.lstbxWriter.SelectedIndexChanged += new System.EventHandler(this.LstbxWriter_SelectedIndexChanged_1);
            // 
            // lstbxDirector
            // 
            this.lstbxDirector.FormattingEnabled = true;
            this.lstbxDirector.Location = new System.Drawing.Point(214, 82);
            this.lstbxDirector.Name = "lstbxDirector";
            this.lstbxDirector.Size = new System.Drawing.Size(110, 134);
            this.lstbxDirector.TabIndex = 67;
            this.lstbxDirector.SelectedIndexChanged += new System.EventHandler(this.LstbxDirector_SelectedIndexChanged);
            // 
            // lblWriter
            // 
            this.lblWriter.AutoSize = true;
            this.lblWriter.Location = new System.Drawing.Point(342, 66);
            this.lblWriter.Name = "lblWriter";
            this.lblWriter.Size = new System.Drawing.Size(40, 13);
            this.lblWriter.TabIndex = 66;
            this.lblWriter.Text = "Writers";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(126, 276);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 65;
            this.lblDate.Text = "Date";
            // 
            // rchbxDate
            // 
            this.rchbxDate.Location = new System.Drawing.Point(98, 292);
            this.rchbxDate.Name = "rchbxDate";
            this.rchbxDate.Size = new System.Drawing.Size(89, 25);
            this.rchbxDate.TabIndex = 64;
            this.rchbxDate.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(211, 242);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 63;
            this.lblDescription.Text = "Description";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Location = new System.Drawing.Point(45, 276);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(30, 13);
            this.lblRate.TabIndex = 62;
            this.lblRate.Text = "Rate";
            // 
            // lblDirector
            // 
            this.lblDirector.AutoSize = true;
            this.lblDirector.Location = new System.Drawing.Point(211, 67);
            this.lblDirector.Name = "lblDirector";
            this.lblDirector.Size = new System.Drawing.Size(49, 13);
            this.lblDirector.TabIndex = 61;
            this.lblDirector.Text = "Directors";
            // 
            // rchbxRate
            // 
            this.rchbxRate.Location = new System.Drawing.Point(25, 292);
            this.rchbxRate.Name = "rchbxRate";
            this.rchbxRate.Size = new System.Drawing.Size(67, 25);
            this.rchbxRate.TabIndex = 60;
            this.rchbxRate.Text = "";
            // 
            // rchbxDescription
            // 
            this.rchbxDescription.Location = new System.Drawing.Point(214, 258);
            this.rchbxDescription.Name = "rchbxDescription";
            this.rchbxDescription.Size = new System.Drawing.Size(393, 145);
            this.rchbxDescription.TabIndex = 59;
            this.rchbxDescription.Text = "";
            // 
            // lstbxStar
            // 
            this.lstbxStar.FormattingEnabled = true;
            this.lstbxStar.Location = new System.Drawing.Point(486, 82);
            this.lstbxStar.Name = "lstbxStar";
            this.lstbxStar.Size = new System.Drawing.Size(121, 134);
            this.lstbxStar.TabIndex = 71;
            this.lstbxStar.SelectedIndexChanged += new System.EventHandler(this.LstbxStar_SelectedIndexChanged_1);
            // 
            // lblStar
            // 
            this.lblStar.AutoSize = true;
            this.lblStar.Location = new System.Drawing.Point(483, 66);
            this.lblStar.Name = "lblStar";
            this.lblStar.Size = new System.Drawing.Size(31, 13);
            this.lblStar.TabIndex = 70;
            this.lblStar.Text = "Stars";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // terminateToolStripMenuItem
            // 
            this.terminateToolStripMenuItem.Name = "terminateToolStripMenuItem";
            this.terminateToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.terminateToolStripMenuItem.Text = "Terminate";
            this.terminateToolStripMenuItem.Click += new System.EventHandler(this.TerminateToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnX);
            this.panel1.Controls.Add(this.labelImdb);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 41);
            this.panel1.TabIndex = 72;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnX.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnX.Location = new System.Drawing.Point(580, 5);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(38, 30);
            this.btnX.TabIndex = 27;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.BtnX_Click);
            // 
            // labelImdb
            // 
            this.labelImdb.AutoSize = true;
            this.labelImdb.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImdb.ForeColor = System.Drawing.SystemColors.Control;
            this.labelImdb.Location = new System.Drawing.Point(12, 8);
            this.labelImdb.Name = "labelImdb";
            this.labelImdb.Size = new System.Drawing.Size(67, 23);
            this.labelImdb.TabIndex = 26;
            this.labelImdb.Text = "IMDB";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(81, 320);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(36, 13);
            this.lblGenre.TabIndex = 73;
            this.lblGenre.Text = "Genre";
            // 
            // lstbxGenre
            // 
            this.lstbxGenre.FormattingEnabled = true;
            this.lstbxGenre.Location = new System.Drawing.Point(25, 334);
            this.lstbxGenre.Name = "lstbxGenre";
            this.lstbxGenre.Size = new System.Drawing.Size(162, 69);
            this.lstbxGenre.TabIndex = 74;
            // 
            // FormMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 430);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lstbxGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstbxStar);
            this.Controls.Add(this.lblStar);
            this.Controls.Add(this.pbxPoster);
            this.Controls.Add(this.lstbxWriter);
            this.Controls.Add(this.lstbxDirector);
            this.Controls.Add(this.lblWriter);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.rchbxDate);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblRate);
            this.Controls.Add(this.lblDirector);
            this.Controls.Add(this.rchbxRate);
            this.Controls.Add(this.rchbxDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMovie";
            this.Text = "FormMovie";
            this.Load += new System.EventHandler(this.FormMovie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPoster)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxPoster;
        private System.Windows.Forms.ListBox lstbxWriter;
        private System.Windows.Forms.ListBox lstbxDirector;
        private System.Windows.Forms.Label lblWriter;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.RichTextBox rchbxDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblDirector;
        private System.Windows.Forms.RichTextBox rchbxRate;
        private System.Windows.Forms.RichTextBox rchbxDescription;
        private System.Windows.Forms.ListBox lstbxStar;
        private System.Windows.Forms.Label lblStar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label labelImdb;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ListBox lstbxGenre;
    }
}