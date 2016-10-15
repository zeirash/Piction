namespace ANNProject
{
    partial class CheckCategoryForm
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
            this.btn_Back = new System.Windows.Forms.LinkLabel();
            this.btn_CheckCaegory = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_CategoryHeader = new System.Windows.Forms.Label();
            this.lbl_Category = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Back
            // 
            this.btn_Back.AutoSize = true;
            this.btn_Back.Location = new System.Drawing.Point(114, 358);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(45, 20);
            this.btn_Back.TabIndex = 0;
            this.btn_Back.TabStop = true;
            this.btn_Back.Text = "Back";
            // 
            // btn_CheckCaegory
            // 
            this.btn_CheckCaegory.Location = new System.Drawing.Point(12, 228);
            this.btn_CheckCaegory.Name = "btn_CheckCaegory";
            this.btn_CheckCaegory.Size = new System.Drawing.Size(253, 36);
            this.btn_CheckCaegory.TabIndex = 1;
            this.btn_CheckCaegory.Text = "Add Art";
            this.btn_CheckCaegory.UseVisualStyleBackColor = true;
            this.btn_CheckCaegory.Click += new System.EventHandler(this.btn_AddCheckArtCategory_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(253, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_CategoryHeader
            // 
            this.lbl_CategoryHeader.AutoSize = true;
            this.lbl_CategoryHeader.Location = new System.Drawing.Point(13, 271);
            this.lbl_CategoryHeader.Name = "lbl_CategoryHeader";
            this.lbl_CategoryHeader.Size = new System.Drawing.Size(77, 20);
            this.lbl_CategoryHeader.TabIndex = 3;
            this.lbl_CategoryHeader.Text = "Category:";
            // 
            // lbl_Category
            // 
            this.lbl_Category.AutoSize = true;
            this.lbl_Category.Location = new System.Drawing.Point(12, 295);
            this.lbl_Category.Name = "lbl_Category";
            this.lbl_Category.Size = new System.Drawing.Size(104, 20);
            this.lbl_Category.TabIndex = 4;
            this.lbl_Category.Text = "The Category";
            // 
            // CheckCategoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 391);
            this.Controls.Add(this.lbl_Category);
            this.Controls.Add(this.lbl_CategoryHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_CheckCaegory);
            this.Controls.Add(this.btn_Back);
            this.Name = "CheckCategoryForm";
            this.Text = "Check Category";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel btn_Back;
        private System.Windows.Forms.Button btn_CheckCaegory;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_CategoryHeader;
        private System.Windows.Forms.Label lbl_Category;
    }
}