using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ANNProject
{
    public partial class CheckCategoryForm : Form
    {
        NeuralNet neuralnet = new NeuralNet();
        Bitmap image, edited;
        string path = "pictures/";
        int flag = 0;
        bool isFirst = true;

        public CheckCategoryForm()
        {
            InitializeComponent();
            lbl_Category.Visible = false;
            if (isFirst)
            {
                neuralnet.reloadPic();
                Console.WriteLine(neuralnet.listInput.Count());
                neuralnet.output();
                Console.WriteLine(neuralnet.trainBPL());
                isFirst = false;
            }
        }

        private void btn_AddCheckArtCategory_Click(object sender, EventArgs e)
        {
            int allcategory = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories).Count();
            //image = new Bitmap(pictureBox1.Image);
            if (flag == 1)
            {
                Console.WriteLine(allcategory);
                edited = new Bitmap(image);
                String CategoryName = "";
                //preprocess the image
                edited = neuralnet.preprocessing(edited);
                //compute input data to recognize the result
                //string category = neuralnet.classifying(edited);
                MessageBox.Show("Predicting category success");
                Console.WriteLine(neuralnet.computeBPL(edited));
                pictureBox1.Image = new Bitmap(edited);

                //classification
                CategoryName = neuralnet.classifying(edited);

                //Add category name from compute
                lbl_Category.Text = CategoryName;
                lbl_Category.Visible = true;
                flag = 2;
                btn_CheckCaegory.Text = "art detail";
            }
            else if(flag == 2){
                flag = 0;
                ArtDetail artDetail = new ArtDetail(image, lbl_Category.Text);
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

        private void CheckCategoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Dispose();
        }
    }
}
