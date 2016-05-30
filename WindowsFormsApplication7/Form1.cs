using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        double s;
        String znak;
        Bitmap rastr;        
        Graphics g ;
        private void createTable()
        {
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = 2;
            for (int i = 0; i < n; i++)
            {
                DataGridViewRow rg = dataGridView1.Rows[i];
                rg.Height = 20;
                rg.Resizable = DataGridViewTriState.False;
                for (int j = 0; j < 2; j++)
                {
                    DataGridViewColumn dg = dataGridView1.Columns[j];
                    dg.Width = 60;
                    dg.Resizable = DataGridViewTriState.False;
                    dataGridView1.Rows[i].Cells[j].Value=0;
                }
            }   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            n = Convert.ToInt32(textBox1.Text);
            createTable();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            pictureBox1.Size = new Size(1567, 706);
            rastr = new Bitmap(pictureBox1.Width,
                               pictureBox1.Height,
                               pictureBox1.CreateGraphics());
            g = Graphics.FromImage(rastr);
            s = Convert.ToDouble(textBox2.Text);
           var p = new Pen(Color.Black, 2);
            g.DrawLine(p, 776, 0, 776,706 );
            g.DrawLine(p, 0, 345,1552 , 345);
             var shrift = new Font("Arial", 6);
            for (int i = 0; i <= 100; i++)
             {
                 int X = 776 + i * 10;
                 int X1 = 776 - i * 10;
                 g.DrawString((-i).ToString(), shrift, Brushes.Black, X1, 346);  
                 g.DrawString(i.ToString(), shrift,Brushes.Black, X, 346);
             }
             for (int i = 0; i <= 34; i++)
             {
                 int Y = 345 - i * 10;
                 g.DrawString(i .ToString(), shrift,Brushes.Black, 760, Y - 10);
                 int Y1 = 345 + i * 10;
                 g.DrawString((-i).ToString(), shrift, Brushes.Black, 760, Y1 + 10);
             }
             var pero = new Pen(Color.LightGray, 1);
             for (int i = 1; i <=80; i++)
             {   
                 int Y = 706 - 10 * i;
                 g.DrawLine(pero, 0, Y, 1567, Y);
             }
             for (int i = 1; i <= 200 ; i++)
             {
                 int Y = 1567 - 10 * i;
                 g.DrawLine(pero, Y, 0, Y, 706);
             }
            for (int i = 0; i < n; i++)
            {
              int x = Int32.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
              int y = Int32.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString());
              var h = new Pen(Color.Red, 2);
                var pero1 = new Pen(Color.Black, 2);
                g.DrawEllipse(h, (x*10)+777 ,345- (y*10 ), 2, 2);
              for (int j = 0; j < n; j++)
              {
                  if (j != i)
                  {
                      int x1 = Int32.Parse(dataGridView1.Rows[j].Cells[0].Value.ToString());
                      int y1 = Int32.Parse(dataGridView1.Rows[j].Cells[1].Value.ToString());
                      double l = System.Math.Pow((System.Math.Pow((x1 - x), 2) + System.Math.Pow((y1 - y), 2)), 0.5);
                      if (l <= s)
                      { g.DrawLine(pero1, x*10+776,345 - (y*10), x1*10+776,345-(y1*10));
                      g.DrawEllipse(h, (x1*10 )+777, 345-(y1*10 ), 2, 2);
                      textBox3.Text += (i+1).ToString() + "("+x.ToString()+";"+y.ToString()+")"+" "+(j+1).ToString()+"("+x1.ToString()+";"+y1.ToString()+")"+Environment.NewLine;
                      }
                  } 
              }
              pictureBox1.Image = rastr;
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
            e.Handled = true;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            znak = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            var znakfind = false;  
            if (Char.IsDigit(e.KeyChar) == true) return;
            if (e.KeyChar == Convert.ToChar(Keys.Back)) return;
            if (textBox1.Text.IndexOf(znak) != -1)
                znakfind = true;
            if (znakfind == true) { e.Handled = true; return; }
            if (e.KeyChar.ToString() == znak) return;  
            e.Handled = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
