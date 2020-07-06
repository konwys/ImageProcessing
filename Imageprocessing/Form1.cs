using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using biblioteka;

namespace Imageprocessing
{
    public partial class Form1 : Form
    {
        // zmienne
        imageprocessing image = new imageprocessing();
        OpenFileDialog openFile = new OpenFileDialog();
        int counterSynch=0;
        int counterAsynch = 0;
        public Form1()
        {
           
            InitializeComponent();
          
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
       
        private void button1_Click(object sender, EventArgs e) // transform 
        {
            try
            {
                Bitmap img = new Bitmap(Image.FromFile(openFile.FileName));
                timer1.Start();
                image.ToMainColors(img);
                timer1.Stop();
                label3.Text = counterSynch.ToString();
                pictureBox1.Image = img;
              
            }
            catch (Exception a)
            { 
                MessageBox.Show(a.ToString());
            }
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

        private void button3_Click(object sender, EventArgs e) // browse
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "(*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";

            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);

            }

        }

        private async void button4_Click(object sender, EventArgs e) // transform async
        {
            //backgroundWorker1.RunWorkerAsync(); OPCJONALNIE - rozwiazanie typowe dla Win Forms 
            Bitmap img = new Bitmap(Image.FromFile(openFile.FileName));
            timer2.Start();
            await image.RunToMainColorsAsynch(img);
            timer2.Stop();
            label4.Text = counterAsynch.ToString();
            pictureBox1.Image = img;
                  
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) // OPCJONALNIE
        {
            Bitmap img = new Bitmap(Image.FromFile(openFile.FileName));
            image.ToMainColors(img);
            pictureBox1.Image = img;
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            counterSynch++;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counterAsynch++;
        }
    }
}
