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
    public partial class ArtDetail : Form
    {
        Bitmap image;
        public ArtDetail(Bitmap image)
        {
            InitializeComponent();
            this.image = image;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
