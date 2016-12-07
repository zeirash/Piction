using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ANNProject
{
    public partial class BrowseArtForm : Form
    {
        NeuralNet neuralNet = new NeuralNet();
        ListViewGroup viewGroup;
        int totalCategory;
        string path = "pictures/";

        public BrowseArtForm()
        {
            InitializeComponent();
            listView_browseArt.Items.Clear();
            imageList1.Images.Clear();
            imageList1.ImageSize = new Size(60, 60);

            totalCategory = new DirectoryInfo(path).GetDirectories("*", SearchOption.AllDirectories).Count(); 
            neuralNet.getCategory();

            int index = 0;
            for (int i = 1; i <= totalCategory; i++)
            {
                
                //if there is no group
                if (listView_browseArt.Groups[i.ToString()] == null)
                {
                    //listviewgroup(key, teks)
                    viewGroup = new ListViewGroup(i.ToString(), neuralNet.dictCategory[i].ToString());
                    listView_browseArt.Groups.Add(viewGroup);
                }
                else
                {
                    viewGroup = listView_browseArt.Groups[i.ToString()];
                }
                
                var filenames = Directory.GetFiles("pictures/" + neuralNet.dictCategory[i].ToString(), "*").Select(f => Path.GetFileName(f));

                foreach(var file in filenames)
                {
                    Bitmap image = new Bitmap("pictures/" + neuralNet.dictCategory[i].ToString() + "/" + file);
                    imageList1.Images.Add(image);
                    ListViewItem item = new ListViewItem(file.ToString(), index, viewGroup);
                    listView_browseArt.Items.Add(item);
                    index++;
                }

            }
        }

        private void btn_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            mainMenuForm.Show();
            this.Dispose();
        }
    }
}
