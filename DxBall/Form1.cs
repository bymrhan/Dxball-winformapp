using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DxBall
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int x =3 , y=3 ;
        int point ;
        List<PictureBox> eliste = new List<PictureBox>();
        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Left += x;
            ball.Top += y;

            if (ball.Left+ball.Width>panel1.Width)
            {
                x = -x;
            }
            if (ball.Top + ball.Height > panel1.Height)
            {

                timer1.Stop();
                DialogResult dr = MessageBox.Show( "tekrar istiyore", "Game over", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes )
                {
                    Application.Restart();
                }
                else
                {
                    this.Close();
                }
               
            }

            if (ball.Left  <= 0)
            {
                x = -x;



            }
            if(ball.Top+ball.Height> wood.Top && ball.Left + ball.Width > wood.Left && ball.Left < wood.Left + wood.Width)
            {

                y = -y;
            }
            if (ball.Top<0)
            {
                y = -y;
            }

            int x2 = ball.Left + ball.Width / 2;
            int y2 = ball.Top + ball.Height / 2;
            

            foreach (PictureBox item in eliste)
            {

                int x1 = item.Left + item.Width / 2;
                int y1 = item.Top + item.Height / 2;
                double d = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

                if (d<52)
                {
                    y = -y;
                           
                    panel1.Controls.Remove(item);
                    eliste.Remove(item);
                    
                    
                    if (eliste.Count < eliste.Capacity)
                    {
                        point+=10;
                        //if (point == 10)
                        //{
                        //    x += 3;
                        //    y += 3;
                        //}
                        label1.Text = point.ToString();
                        
                    }
                    
                break;

                }
             
            }
            if (eliste.Count == 0)
            {
                timer1.Stop();
                DialogResult dr = MessageBox.Show( "tekrar istiyore", "Kazandiiin", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                wood.Left -= 30;
            }
            if (e.KeyCode == Keys.Right)
            {
                wood.Left += 30;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

            foreach (Control item in panel1.Controls)
            {
                if (item.Tag != null &&  item.Tag.ToString()=="blok"  )
                {
                    eliste.Add((PictureBox)item);


                }
            }

           

            
        }

    }
}
