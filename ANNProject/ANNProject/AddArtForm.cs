using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace ANNProject
{
    public partial class AddArtForm : Form
    {
        NeuralNet neuralnet = new NeuralNet();
        OpenFileDialog imageFileDialog = new OpenFileDialog();
        string category;
        string path = "pictures/";
        //int index = 0;

        public AddArtForm()
        {
            InitializeComponent();
            cmb_Category.Enabled = false;
            txt_NewCategory.Visible = false;
            btn_SubmitArt.Visible = false;

            BindingSource source = new BindingSource();
            source.Add("add new category");
            var items = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories);
            foreach(DirectoryInfo dir in items)
            {
                source.Add(dir.Name);
            }
            
            cmb_Category.DataSource = source;
            cmb_Category.SelectedIndex = -1;
            neuralnet.reloadPic();
        }

        private void reloadCmb()
        {
            path = "pictures/";
            BindingSource source = new BindingSource();
            source.Add("add new category");
            var items = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories);
            foreach (DirectoryInfo dir in items)
            {
                source.Add(dir.Name);
            }
            
            cmb_Category.DataSource = source;
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            //open file dialog
            imageFileDialog.Title = "Select image";
            imageFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            imageFileDialog.Multiselect = true;
            DialogResult result = imageFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                imageList1.Images.Clear();
                listView_image.Items.Clear();
                imageList1.ImageSize = new Size(60, 60);

                for (int i = 0; i < imageFileDialog.FileNames.Count(); i++)
                {
                    Bitmap image = new Bitmap(imageFileDialog.FileNames[i]);
                    imageList1.Images.Add(image);
                    ListViewItem item = new ListViewItem(Path.GetFileNameWithoutExtension(imageFileDialog.SafeFileNames[i]), i);
                    listView_image.Items.Add(item);

                    //preprocess image
                    image = neuralnet.preprocessing(image);

                    //add to listinput
                    neuralnet.input(image);

                    //convert image to array and add to list tempdata sprtiny gk perlu
                    //neuralnet.convertImageToArray(image);
                    //index++;
                }
                cmb_Category.Enabled = true;
                cmb_Category.SelectedIndex = -1;
                btn_SubmitArt.Visible = true;

                //neuralnet.computePCA();
                //neuralnet.trainSOM(imageFileDialog.FileNames.Count());
            }

            
        }

        private void btn_SubmitArt_Click(object sender, EventArgs e)
        {
            category = "";
            if (cmb_Category.SelectedIndex == -1)
            {
                MessageBox.Show("category must be chosed");
            }
            else
            {
                if (txt_NewCategory.Visible && txt_NewCategory.Text == "")
                {
                    //if (txt_NewCategory.Text == "" | txt_NewCategory.Text == null)
                    MessageBox.Show("Category must be filled");
                }
                else
                {
                    if (txt_NewCategory.Visible)
                    {
                        category = txt_NewCategory.Text;
                        //neuralnet.listCategoryNames.Add(category);
                        path += category;
                    }
                    else
                    {
                        category = cmb_Category.SelectedItem.ToString();
                        //neuralnet.listCategoryNames.Add(category);
                        path += category;
                    }
                    //save picture to folder
                    Directory.CreateDirectory(path);
                    for (int i = 0; i < imageFileDialog.FileNames.Count(); i++)
                    {
                        try
                        {
                            File.Copy(imageFileDialog.FileNames[i], path + "/" + imageFileDialog.SafeFileNames[i]);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Picture is already exists");
                            category = "";
                            path = "pictures/";
                            return;
                        }
                    }

                    neuralnet.output();
                    Console.WriteLine(neuralnet.trainBPL());
                    Console.WriteLine(neuralnet.listInput.Count());
                    //neuralnet.trainBPL(neuralnet.listInput.ToArray(), neuralnet.listOutput.ToArray());
                    //neuralnet.computePCA();
                    //neuralnet.trainSOM(imageFileDialog.FileNames.Count());
                    MessageBox.Show("Art submitted");

                    //clear
                    imageList1.Images.Clear();
                    listView_image.Items.Clear();
                    txt_NewCategory.Text = "";
                    btn_SubmitArt.Visible = false;
                    txt_NewCategory.Visible = false;
                    reloadCmb();
                    cmb_Category.SelectedIndex = -1;
                }
            }
        }

        private void btn_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Dispose();
        }

        private void AddArtForm_Load(object sender, EventArgs e)
        {
            
        }

        private void cmb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Category.SelectedIndex == 0)
            {
                 txt_NewCategory.Visible = true;
            }
            else
                txt_NewCategory.Visible = false;
        }
    }
}
