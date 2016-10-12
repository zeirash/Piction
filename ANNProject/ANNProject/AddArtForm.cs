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

            }
        }

        private void btn_SubmitArt_Click(object sender, EventArgs e)
        {

        }

        private void btn_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
