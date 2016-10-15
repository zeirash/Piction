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
    public partial class CheckCategoryForm : Form
    {
        public CheckCategoryForm()
        {
            InitializeComponent();
            lbl_Category.Visible = false;
        }

        private void btn_AddCheckArtCategory_Click(object sender, EventArgs e)
        {
            String CategoryName = "";

            lbl_Category.Text = CategoryName;
            lbl_Category.Visible = true;
        }
    }
}
