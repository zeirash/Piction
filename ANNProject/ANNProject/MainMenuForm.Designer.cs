namespace ANNProject
{
    partial class MainMenuForm
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
            this.btn_AddArt = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.btn_AddCategory = new System.Windows.Forms.Button();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.lbl_Exit = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btn_AddArt
            // 
            this.btn_AddArt.Location = new System.Drawing.Point(12, 63);
            this.btn_AddArt.Name = "btn_AddArt";
            this.btn_AddArt.Size = new System.Drawing.Size(172, 46);
            this.btn_AddArt.TabIndex = 0;
            this.btn_AddArt.Text = "Add Art";
            this.btn_AddArt.UseVisualStyleBackColor = true;
            this.btn_AddArt.Click += new System.EventHandler(this.btn_AddArtClick);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("MS Outlook", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(337, 35);
            this.Title.TabIndex = 1;
            this.Title.Text = "FulgurantArt Intelligence";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_AddCategory
            // 
            this.btn_AddCategory.Location = new System.Drawing.Point(190, 64);
            this.btn_AddCategory.Name = "btn_AddCategory";
            this.btn_AddCategory.Size = new System.Drawing.Size(167, 46);
            this.btn_AddCategory.TabIndex = 2;
            this.btn_AddCategory.Text = "Add Category";
            this.btn_AddCategory.UseVisualStyleBackColor = true;
            this.btn_AddCategory.Click += new System.EventHandler(this.btn_AddCategory_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(18, 116);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(331, 51);
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // lbl_Exit
            // 
            this.lbl_Exit.AutoSize = true;
            this.lbl_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Exit.Location = new System.Drawing.Point(163, 185);
            this.lbl_Exit.Name = "lbl_Exit";
            this.lbl_Exit.Size = new System.Drawing.Size(44, 25);
            this.lbl_Exit.TabIndex = 4;
            this.lbl_Exit.TabStop = true;
            this.lbl_Exit.Text = "Exit";
            this.lbl_Exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_Exit_LinkClicked);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 219);
            this.Controls.Add(this.lbl_Exit);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btn_AddCategory);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.btn_AddArt);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_AddArt;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button btn_AddCategory;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.LinkLabel lbl_Exit;
    }
}

