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
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select image";
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            open.Multiselect = true;
            DialogResult result = open.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = open.FileNames;
                foreach (string image in files)
                {
                    Image img = Image.FromFile(image);
                    imageList1.Images.Add("tes", img);
                }
                imageList1.ImageSize = new Size(50, 50);
                for (int j = 0; j < this.imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView_image.Items.Add(item);
                }
            }
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
