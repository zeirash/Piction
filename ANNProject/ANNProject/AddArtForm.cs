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
        public AddArtForm()
        {
            InitializeComponent();
            cmb_Category.Visible = false;
            txt_NewCategory.Visible = false;
            //btn_SubmitArt.Visible = false;
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
                cmb_Category.Visible = true;
                txt_NewCategory.Visible = true;
            }

            
        }

        private void btn_SubmitArt_Click(object sender, EventArgs e)
        {

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
    }
}
