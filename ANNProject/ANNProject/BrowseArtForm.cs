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
    public partial class BrowseArtForm : Form
    {
        NeuralNet neuralNet = new NeuralNet();
        public BrowseArtForm()
        {
            InitializeComponent();
            ListViewGroup viewGroup;
            /*
            //if there is no group
            if (listView1.Groups[group.ToString()] == null)
            {
                //listviewgroup(key, teks)
                viewGroup = new ListViewGroup(group.ToString(), group.ToString());
                listView1.Groups.Add(viewGroup);
            }
            else
            {
                viewGroup = listView1.Groups[group.ToString()];
            }

            ListViewItem item = new ListViewItem(group.ToString(), i, viewGroup);
            listView1.Items.Add(item);

            Bitmap image = new Bitmap(dialog.FileNames[i]);
            imageList1.Images.Add(image);
            */
        }
    }
}
