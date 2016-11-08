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
    public partial class CheckCategoryForm : Form
    {

        NeuralNet neuralnet;
        public CheckCategoryForm()
        {
            InitializeComponent();
            lbl_Category.Visible = false;
        }

        private void btn_AddCheckArtCategory_Click(object sender, EventArgs e)
        {
            String CategoryName = "";

            //open file dialog
            OpenFileDialog imageFileDialog = new OpenFileDialog();
            imageFileDialog.Title = "Select image";
            imageFileDialog.Filter = "Image File(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            DialogResult result = imageFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Bitmap image = new Bitmap(imageFileDialog.FileName);
                neuralnet.computeBPL(image);
                image = neuralnet.preprocessing(image);
                pictureBox1.Image = new Bitmap(image);

                


                lbl_Category.Text = CategoryName;
                lbl_Category.Visible = true;
            }
        }

        private void btn_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Dispose();
        }
    }
}
