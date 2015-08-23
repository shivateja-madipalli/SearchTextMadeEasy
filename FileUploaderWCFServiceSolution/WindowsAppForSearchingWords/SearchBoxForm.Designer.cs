namespace WindowsAppForSearchingWords
{
    partial class SearchBoxForm
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
            this.txtSearchWords = new System.Windows.Forms.TextBox();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearchWords
            // 
            this.txtSearchWords.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWords.Location = new System.Drawing.Point(12, 12);
            this.txtSearchWords.Multiline = true;
            this.txtSearchWords.Name = "txtSearchWords";
            this.txtSearchWords.Size = new System.Drawing.Size(485, 82);
            this.txtSearchWords.TabIndex = 0;
            // 
            // Searchbtn
            // 
            this.Searchbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbtn.Location = new System.Drawing.Point(12, 101);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(485, 47);
            this.Searchbtn.TabIndex = 1;
            this.Searchbtn.Text = "SEARCH FOR FILES";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // SearchBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 361);
            this.Controls.Add(this.Searchbtn);
            this.Controls.Add(this.txtSearchWords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchBoxForm";
            this.Text = "SearchBox";
            this.Load += new System.EventHandler(this.SearchBoxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchWords;
        private System.Windows.Forms.Button Searchbtn;
    }
}

