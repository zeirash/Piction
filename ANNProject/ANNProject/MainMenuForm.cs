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
        private void Preload()
        {
            //This load files
        }

        private void PreExit()
        {
            //This save files
        }

        public MainMenuForm()
        {
            InitializeComponent();
            Preload();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // I made a mistake, sorry
   
        }
        private void btn_AddArtClick(object sender, EventArgs e)
        {
            //goto add art form
        }

        private void btn_AddCategory_Click(object sender, EventArgs e)
        {
            //go to add category form
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            //go to browse art form
        }

        private void lbl_Exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PreExit();
            //This to exit

        }
    }
}
