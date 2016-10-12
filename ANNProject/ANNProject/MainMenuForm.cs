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
    public partial class MainMenuForm : Form
    {
      

        public MainMenuForm()
        {
            InitializeComponent();
           
        }


        private void btn_AddArtClick(object sender, EventArgs e)
        {
            //goto add art form
            AddArtForm addArtForm = new AddArtForm();
            addArtForm.Show();
            this.Hide();
        }

        private void btn_CheckCategory_Click(object sender, EventArgs e)
        {
            //go to add category form
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            //check if there is art in the system

            //go to browse art form
        }

        private void lbl_Exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
            //This to exit

        }
    }
}
