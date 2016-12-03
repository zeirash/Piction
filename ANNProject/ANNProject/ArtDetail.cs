using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANNProject
{
    public partial class ArtDetail : Form
    {
        string categoryName;
        Bitmap image;
        public ArtDetail(Bitmap image, String categoryName)
        {
            InitializeComponent();
            this.image = image;
            this.categoryName = categoryName;

            pictureBox1.Image = image;
            label1.Text = categoryName;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckCategoryForm CheckCategoryForm = new CheckCategoryForm();
            CheckCategoryForm.Show();
            this.Dispose();
        }
    }
}
