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
    public partial class AddArtForm : Form
    {
        List<String> listCategoryNames;
        public AddArtForm()
        {
            InitializeComponent();
            cmb_Category.Enabled = false;
            txt_NewCategory.Visible = false;
            btn_SubmitArt.Visible = false;
           
                
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            //open file dialog
            OpenFileDialog imageFileDialog = new OpenFileDialog();
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
                    ListViewItem item = new ListViewItem(System.IO.Path.GetFileNameWithoutExtension(imageFileDialog.SafeFileNames[i]), i);
                    listView_image.Items.Add(item);
                }
                cmb_Category.Enabled = true;
                cmb_Category.SelectedIndex = 0;
                btn_SubmitArt.Visible = true;

                
            }

            
        }

        private void btn_SubmitArt_Click(object sender, EventArgs e)
        {
            if (txt_NewCategory.Visible)
            {
                if (txt_NewCategory.Text == "" | txt_NewCategory.Text == null)
                    MessageBox.Show("Category must be filled");
            }
            else
            {
                if (txt_NewCategory.Visible)
                    listCategoryNames.Add(txt_NewCategory.Text);
                else
                    listCategoryNames.Add(cmb_Category.SelectedItem.ToString());
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
