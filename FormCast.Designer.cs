namespace Imdb
{
    partial class FormCast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCast));
            this.pbxCastPoster = new System.Windows.Forms.PictureBox();
            this.rchbxCastDesc = new System.Windows.Forms.RichTextBox();
            this.rchbxBornInfo = new System.Windows.Forms.RichTextBox();
            this.lstbxShows = new System.Windows.Forms.ListBox();
            this.lblCastBornInfo = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblShows = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.terminateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.labelImdb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCastPoster)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxCastPoster
            // 
            this.pbxCastPoster.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxCastPoster.Image = ((System.Drawing.Image)(resources.GetObject("pbxCastPoster.Image")));
            this.pbxCastPoster.Location = new System.Drawing.Point(75, 62);
            this.pbxCastPoster.Name = "pbxCastPoster";
            this.pbxCastPoster.Size = new System.Drawing.Size(126, 149);
            this.pbxCastPoster.TabIndex = 64;
            this.pbxCastPoster.TabStop = false;
            // 
            // rchbxCastDesc
            // 
            this.rchbxCastDesc.Location = new System.Drawing.Point(33, 243);
            this.rchbxCastDesc.Name = "rchbxCastDesc";
            this.rchbxCastDesc.Size = new System.Drawing.Size(224, 175);
            this.rchbxCastDesc.TabIndex = 62;
            this.rchbxCastDesc.Text = "";
            // 
            // rchbxBornInfo
            // 
            this.rchbxBornInfo.Location = new System.Drawing.Point(322, 78);
            this.rchbxBornInfo.Name = "rchbxBornInfo";
            this.rchbxBornInfo.Size = new System.Drawing.Size(248, 28);
            this.rchbxBornInfo.TabIndex = 65;
            this.rchbxBornInfo.Text = "";
            // 
            // lstbxShows
            // 
            this.lstbxShows.FormattingEnabled = true;
            this.lstbxShows.Location = new System.Drawing.Point(322, 131);
            this.lstbxShows.Name = "lstbxShows";
            this.lstbxShows.Size = new System.Drawing.Size(248, 290);
            this.lstbxShows.TabIndex = 66;
            this.lstbxShows.SelectedIndexChanged += new System.EventHandler(this.LstbxShows_SelectedIndexChanged);
            // 
            // lblCastBornInfo
            // 
            this.lblCastBornInfo.AutoSize = true;
            this.lblCastBornInfo.Location = new System.Drawing.Point(319, 62);
            this.lblCastBornInfo.Name = "lblCastBornInfo";
            this.lblCastBornInfo.Size = new System.Drawing.Size(84, 13);
            this.lblCastBornInfo.TabIndex = 63;
            this.lblCastBornInfo.Text = "Born Information";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 228);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(34, 13);
            this.lblDescription.TabIndex = 67;
            this.lblDescription.Text = "Detail";
            // 
            // lblShows
            // 
            this.lblShows.AutoSize = true;
            this.lblShows.Location = new System.Drawing.Point(319, 115);
            this.lblShows.Name = "lblShows";
            this.lblShows.Size = new System.Drawing.Size(39, 13);
            this.lblShows.TabIndex = 68;
            this.lblShows.Text = "Shows";
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
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(633, 41);
            this.panel1.TabIndex = 69;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnX.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnX.Location = new System.Drawing.Point(579, 5);
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
            // FormCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 430);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblShows);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lstbxShows);
            this.Controls.Add(this.rchbxBornInfo);
            this.Controls.Add(this.pbxCastPoster);
            this.Controls.Add(this.lblCastBornInfo);
            this.Controls.Add(this.rchbxCastDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCast";
            this.Text = "FormCast";
            this.Load += new System.EventHandler(this.FormCast_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCastPoster)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxCastPoster;
        private System.Windows.Forms.RichTextBox rchbxCastDesc;
        private System.Windows.Forms.RichTextBox rchbxBornInfo;
        private System.Windows.Forms.ListBox lstbxShows;
        private System.Windows.Forms.Label lblCastBornInfo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblShows;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem terminateToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label labelImdb;
    }
}