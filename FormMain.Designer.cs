using System;

namespace Imdb
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.btnClear = new System.Windows.Forms.Button();
            this.labelImdb = new System.Windows.Forms.Label();
            this.lstbxMovie = new System.Windows.Forms.ListBox();
            this.txtbx = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnX = new System.Windows.Forms.Button();
            this.pbxImdb = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImdb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(141, 217);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 27);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.Btn_clear_Click);
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
            // lstbxMovie
            // 
            this.lstbxMovie.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lstbxMovie.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxMovie.FormattingEnabled = true;
            this.lstbxMovie.ItemHeight = 14;
            this.lstbxMovie.Location = new System.Drawing.Point(286, 93);
            this.lstbxMovie.Name = "lstbxMovie";
            this.lstbxMovie.Size = new System.Drawing.Size(214, 200);
            this.lstbxMovie.TabIndex = 21;
            this.lstbxMovie.SelectedIndexChanged += new System.EventHandler(this.Lstbx_SelectedIndexChanged);
            // 
            // txtbx
            // 
            this.txtbx.Location = new System.Drawing.Point(38, 177);
            this.txtbx.Name = "txtbx";
            this.txtbx.Size = new System.Drawing.Size(189, 20);
            this.txtbx.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(49, 217);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.Btn_search_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnX);
            this.panel1.Controls.Add(this.labelImdb);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 41);
            this.panel1.TabIndex = 34;
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnX.Font = new System.Drawing.Font("Ravie", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnX.Location = new System.Drawing.Point(500, 4);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(38, 30);
            this.btnX.TabIndex = 27;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.BtnX_Click);
            // 
            // pbxImdb
            // 
            this.pbxImdb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxImdb.BackgroundImage")));
            this.pbxImdb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxImdb.Location = new System.Drawing.Point(76, 96);
            this.pbxImdb.Name = "pbxImdb";
            this.pbxImdb.Size = new System.Drawing.Size(100, 50);
            this.pbxImdb.TabIndex = 35;
            this.pbxImdb.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(550, 350);
            this.Controls.Add(this.pbxImdb);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lstbxMovie);
            this.Controls.Add(this.txtbx);
            this.Controls.Add(this.btnSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imdb";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImdb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label labelImdb;
        private System.Windows.Forms.ListBox lstbxMovie;
        private System.Windows.Forms.TextBox txtbx;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.PictureBox pbxImdb;
    }
}