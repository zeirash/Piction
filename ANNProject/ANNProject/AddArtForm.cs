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
        int index = 0;

        public AddArtForm()
        {
            InitializeComponent();
            cmb_Category.Enabled = false;
            txt_NewCategory.Visible = false;
            btn_SubmitArt.Visible = false;

            BindingSource source = new BindingSource();
            //cmb_Category.DisplayMember = "Text";
            //cmb_Category.ValueMember = "Value";
            source.Add("add new category");
            var items = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories);
            foreach(DirectoryInfo dir in items)
            {
                source.Add(dir.Name);
            }
            //var items = new DirectoryInfo(Path.GetDirectoryName(path)).Name.ToList();
            //var items = Directory.GetDirectories("pictures").ToList();
            //items = items.Select(paths => new DirectoryInfo(paths).Name).ToList();
            //items = new[] {
            //    new { Text = "add new category", Value = "" }
            //};
            //for (int i = 0; i < neuralnet.listCategoryNames.Count; i++) {
            //    items = new[] {
            //        new { Text = neuralnet.listCategoryNames[i], Value = i }
            //    };
            //}
            
            //string[] subdir = Directory.GetDirectories(path);
            //Console.WriteLine(subdir[6]);
            cmb_Category.DataSource = source;
            neuralnet.reloadPic();
        }

        private void reloadCmb()
        {
            BindingSource source = new BindingSource();
            //cmb_Category.DisplayMember = "Text";
            //cmb_Category.ValueMember = "Value";
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

                    //convert image to array and add to list tempdata
                    neuralnet.convertImageToArray(image);
                    index++;
                }
                cmb_Category.Enabled = true;
                cmb_Category.SelectedIndex = 0;
                btn_SubmitArt.Visible = true;

                //neuralnet.computePCA();
                //neuralnet.trainSOM(imageFileDialog.FileNames.Count());
            }

            
        }

        private void btn_SubmitArt_Click(object sender, EventArgs e)
        {
            category = "";
            if (txt_NewCategory.Visible && txt_NewCategory.Text == "" || txt_NewCategory.Text == null)
            {
                //if (txt_NewCategory.Text == "" | txt_NewCategory.Text == null)
                    MessageBox.Show("Category must be filled");
            }
            else
            {
                if (txt_NewCategory.Visible)
                {
                    category = txt_NewCategory.Text;
                    neuralnet.listCategoryNames.Add(category);
                    path += category;
                }
                else
                {
                    category = cmb_Category.SelectedItem.ToString();
                    neuralnet.listCategoryNames.Add(category);
                    path += category;
                }
                //save picture to folder
                //masih ada bug, ke double tulisannya
                Directory.CreateDirectory(path);
                for (int i = 0; i < imageFileDialog.FileNames.Count(); i++) {
                    try
                    {
                        File.Copy(imageFileDialog.FileNames[i], path + "/" + imageFileDialog.SafeFileNames[i]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Picture is already exists");
                        //category = null;
                        return;
                    }
                }
                

                //ini yg outputnormalization taro disini atau didalam loop image
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
                cmb_Category.SelectedIndex = 0;
                reloadCmb();
                btn_SubmitArt.Visible = false;
                txt_NewCategory.Visible = false;
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
