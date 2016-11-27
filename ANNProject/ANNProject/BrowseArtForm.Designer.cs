namespace ANNProject
{
    partial class BrowseArtForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.listView_browseArt = new System.Windows.Forms.ListView();
            this.btn_Back = new System.Windows.Forms.LinkLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Outlook", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "FulgurantArt Intelligence - Gallery";
            // 
            // listView_browseArt
            // 
            this.listView_browseArt.LargeImageList = this.imageList1;
            this.listView_browseArt.Location = new System.Drawing.Point(9, 34);
            this.listView_browseArt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listView_browseArt.Name = "listView_browseArt";
            this.listView_browseArt.Size = new System.Drawing.Size(589, 214);
            this.listView_browseArt.TabIndex = 1;
            this.listView_browseArt.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Back
            // 
            this.btn_Back.AutoSize = true;
            this.btn_Back.Location = new System.Drawing.Point(566, 262);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(32, 13);
            this.btn_Back.TabIndex = 2;
            this.btn_Back.TabStop = true;
            this.btn_Back.Text = "Back";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // BrowseArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 281);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.listView_browseArt);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "BrowseArtForm";
            this.Text = "Browse Art";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView_browseArt;
        private System.Windows.Forms.LinkLabel btn_Back;
        private System.Windows.Forms.ImageList imageList1;
    }
}