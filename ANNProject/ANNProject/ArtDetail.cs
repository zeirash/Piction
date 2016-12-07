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
        Bitmap image;
        NeuralNet neuralNet = new NeuralNet();
        string categoryName;
        public ArtDetail(Bitmap image, String categoryName)
        {
            InitializeComponent();
            this.image = image;
            this.categoryName = categoryName;

            pictureBox1.Image = image;
            label1.Text = categoryName;

            neuralNet.reloadPic();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CheckCategoryForm CheckCategoryForm = new CheckCategoryForm();
            CheckCategoryForm.Show();
            this.Dispose();
        }
    }
}
