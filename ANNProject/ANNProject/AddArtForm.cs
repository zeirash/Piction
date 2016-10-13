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
        }

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            //open file dialog
            OpenFileDialog imageFileDialog = new OpenFileDialog();
            imageFileDialog.Title = "Select image";
            imageFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            imageFileDialog.Multiselect = true;
            DialogResult result = imageFileDialog.ShowDialog();
            //if (result == System.Windows.Forms.DialogResult.OK)
            //{
                string[] files = imageFileDialog.FileNames;
                foreach (string image in files)
                {
                string imagePath = image.ToString();
                string imagepath = imagePath.ToString();
                imagepath = imagepath.Substring(imagepath.LastIndexOf("\\"));
                imagepath = imagepath.Remove(0, 1);
                    Image img = Image.FromFile(image);
                    imageList1.Images.Add(img);
                }
                
                listView_image.View = View.LargeIcon;
                imageList1.ImageSize = new Size(50, 50);
                listView_image.LargeImageList = imageList1;


                for (int j = 0; j < this.imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView_image.Items.Add(item);
                }
            //}

            
        }

        private void btn_SubmitArt_Click(object sender, EventArgs e)
        {

        }

        private void btn_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void AddArtForm_Load(object sender, EventArgs e)
        {
            listView_image.View = View.LargeIcon;
        }
    }
}
