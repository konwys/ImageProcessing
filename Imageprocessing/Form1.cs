using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using biblioteka;
using System.Drawing.Imaging;

namespace Imageprocessing
{
    public partial class Form1 : Form
    {
        // zmienne
        ImageProcessing image = new ImageProcessing();
        OpenFileDialog openFile = new OpenFileDialog();
        public Form1()
        {
           
            InitializeComponent();
          
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(Image.FromFile(openFile.FileName));         
            image.ToMainColors(img);
            pictureBox1.Image = img;
            pictureBox1.Refresh();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        { 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // wybor rozszerzen zdjec
            openFile.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                
             pictureBox1.Image = Image.FromFile(openFile.FileName);

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
