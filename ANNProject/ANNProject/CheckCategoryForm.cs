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
        int flag = 0;
        NeuralNet neuralnet;
        public CheckCategoryForm()
        {
            InitializeComponent();
            lbl_Category.Visible = false;

        }

        private void btn_AddCheckArtCategory_Click(object sender, EventArgs e)
        {
            
            Bitmap image =new Bitmap(pictureBox1.Image);
            if (flag==1)
            {
                Bitmap edited = new Bitmap(image);
                String CategoryName = "";
                edited = neuralnet.preprocessing(edited);
                neuralnet.computeBPL(edited);
                pictureBox1.Image = new Bitmap(edited);

                lbl_Category.Text = CategoryName;
                lbl_Category.Visible = true;
                flag = 2;
            }else if(flag==2){

                ArtDetail artDetail = new ArtDetail(image);
                artDetail.Show();
                this.Dispose();
            }
            else
            {


                //open file dialog
                OpenFileDialog imageFileDialog = new OpenFileDialog();
                imageFileDialog.Title = "Select image";
                imageFileDialog.Filter = "Image File(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
                DialogResult result = imageFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    image = new Bitmap(imageFileDialog.FileName);
                    pictureBox1.Image = new Bitmap(image);
                    flag = 1;
                    btn_CheckCaegory.Text = "Check Category";
                }
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
