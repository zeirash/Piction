namespace ANNProject
{
    partial class AddArtForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.LinkLabel();
            this.btn_SubmitArt = new System.Windows.Forms.Button();
            this.txt_NewCategory = new System.Windows.Forms.TextBox();
            this.btn_AddNew = new System.Windows.Forms.Button();
            this.cmb_Category = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Art";
            // 
            // btn_Back
            // 
            this.btn_Back.AutoSize = true;
            this.btn_Back.Location = new System.Drawing.Point(488, 453);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(45, 20);
            this.btn_Back.TabIndex = 1;
            this.btn_Back.TabStop = true;
            this.btn_Back.Text = "Back";
            this.btn_Back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_Back_LinkClicked);
            // 
            // btn_SubmitArt
            // 
            this.btn_SubmitArt.Location = new System.Drawing.Point(13, 405);
            this.btn_SubmitArt.Name = "btn_SubmitArt";
            this.btn_SubmitArt.Size = new System.Drawing.Size(520, 45);
            this.btn_SubmitArt.TabIndex = 2;
            this.btn_SubmitArt.Text = "Submit Art";
            this.btn_SubmitArt.UseVisualStyleBackColor = true;
            this.btn_SubmitArt.Click += new System.EventHandler(this.btn_SubmitArt_Click);
            // 
            // txt_NewCategory
            // 
            this.txt_NewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NewCategory.Location = new System.Drawing.Point(13, 352);
            this.txt_NewCategory.Name = "txt_NewCategory";
            this.txt_NewCategory.Size = new System.Drawing.Size(520, 35);
            this.txt_NewCategory.TabIndex = 3;
            this.txt_NewCategory.Text = "New Category name";
            this.txt_NewCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_AddNew
            // 
            this.btn_AddNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddNew.Location = new System.Drawing.Point(13, 313);
            this.btn_AddNew.Name = "btn_AddNew";
            this.btn_AddNew.Size = new System.Drawing.Size(103, 33);
            this.btn_AddNew.TabIndex = 4;
            this.btn_AddNew.Text = "Add New";
            this.btn_AddNew.UseVisualStyleBackColor = true;
            this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
            // 
            // cmb_Category
            // 
            this.cmb_Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Category.FormattingEnabled = true;
            this.cmb_Category.Location = new System.Drawing.Point(122, 313);
            this.cmb_Category.Name = "cmb_Category";
            this.cmb_Category.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_Category.Size = new System.Drawing.Size(411, 33);
            this.cmb_Category.TabIndex = 5;
            this.cmb_Category.Text = "Select Category";
            // 
            // AddArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 482);
            this.Controls.Add(this.cmb_Category);
            this.Controls.Add(this.btn_AddNew);
            this.Controls.Add(this.txt_NewCategory);
            this.Controls.Add(this.btn_SubmitArt);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.label1);
            this.Name = "AddArtForm";
            this.Text = "Add Art";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel btn_Back;
        private System.Windows.Forms.Button btn_SubmitArt;
        private System.Windows.Forms.TextBox txt_NewCategory;
        private System.Windows.Forms.Button btn_AddNew;
        private System.Windows.Forms.ComboBox cmb_Category;
    }
}