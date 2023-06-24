using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        public static void mult(double[,] matrix1, double[,] matrix2, double[,] resulet)//////////////function multiplex
        {

            for (int i = 0; i < 4; i++)
            {
                for (int k = 0; k < 4; k++)
                {


                    resulet[i, k] = 0;
                    for (int j = 0; j < 4; j++)

                        resulet[i, k] += matrix1[i, j] * matrix2[j, k];
                }
            }

        }


        private  double convert(double an)
        {
            return (Math.PI / 180) * an;

          
  

        }
        private  void mainfunction()
        {


            double[,] matrix1 = new double[4, 4];



            matrix1[0, 0] = Math.Round(Math.Cos(convert(trackBar1.Value)));
            matrix1[0, 1] = Math.Round(Math.Cos(convert(int.Parse(textBox4.Text))) * Math.Sin(convert(trackBar1.Value)) * -1);
            matrix1[0, 2] = Math.Round(Math.Sin(convert(trackBar1.Value)) * Math.Sin(convert(int.Parse(textBox4.Text))));
            matrix1[0, 3] = Math.Round((int.Parse(textBox3.Text)) * Math.Cos(convert(trackBar1.Value)));


            matrix1[1, 0] = Math.Round(Math.Sin(convert(trackBar1.Value)));
            matrix1[1, 1] = Math.Round(Math.Cos(convert(trackBar1.Value)));
            matrix1[1, 2] = Math.Round(Math.Sin(convert(int.Parse(textBox4.Text))) * Math.Cos(convert(trackBar1.Value)) * -1);
            matrix1[1, 3] = Math.Round((int.Parse(textBox3.Text)) * Math.Sin(convert(trackBar1.Value)));




            matrix1[2, 0] = 0;
            matrix1[2, 1] =Math.Round( Math.Sin(convert(int.Parse(textBox4.Text))));
            matrix1[2, 2] =Math.Round( Math.Cos(convert(int.Parse(textBox4.Text))));
            matrix1[2, 3] = int.Parse(textBox2.Text);


            matrix1[3, 0] = 0;
            matrix1[3, 1] = 0;
            matrix1[3, 2] = 0;
            matrix1[3, 3] = 1;




            double[,] matrix2 = new double[4, 4];

            matrix2[0, 0] = Math.Round(Math.Cos(convert(trackBar2.Value)));
            matrix2[0, 1] = Math.Round(Math.Cos(convert(int.Parse(textBox8.Text))) * Math.Sin(convert(int.Parse(textBox5.Text))) * -1);
            matrix2[0, 2] = Math.Round(Math.Sin(convert(trackBar2.Value)) * Math.Sin(convert(int.Parse(textBox8.Text))));
            matrix2[0, 3] = Math.Round(int.Parse(textBox7.Text) * Math.Cos(convert(trackBar2.Value)));


            matrix2[1, 0] = Math.Round(Math.Sin(convert(trackBar2.Value)));
            matrix2[1, 1] =Math.Round( Math.Cos(convert(int.Parse(textBox5.Text))));
            matrix2[1, 2] =Math.Round( Math.Sin(convert(int.Parse(textBox8.Text))) * Math.Cos(convert(trackBar2.Value)) * -1);
            matrix2[1, 3] =Math.Round( int.Parse((textBox7.Text)) * Math.Sin(convert(int.Parse(textBox5.Text))));

            matrix2[2, 0] = 0;
            matrix2[2, 1] = Math.Round(Math.Sin(convert(int.Parse(textBox8.Text))));
            matrix2[2, 2] = Math.Round(Math.Cos(convert(int.Parse(textBox8.Text))));
            matrix2[2, 3] = int.Parse(textBox6.Text);

            matrix2[3, 0] = 0;
            matrix2[3, 1] = 0;
            matrix2[3, 2] = 0;
            matrix2[3, 3] = 1;


            double[,] resulet = new double[4, 4];


            mult(matrix1, matrix2, resulet);

            double[,] matrix3 = new double[4, 4];



            matrix3[0, 0] = Math.Round(Math.Cos(convert(trackBar3.Value)));
            matrix3[0, 1] = Math.Round(Math.Cos(convert(int.Parse(textBox12.Text))) * Math.Sin(convert(trackBar3.Value)) * -1);
            matrix3[0, 2] = Math.Round(Math.Sin(convert(trackBar3.Value)) * Math.Sin(convert(int.Parse(textBox12.Text))));
            matrix3[0, 3] = Math.Round(int.Parse(textBox11.Text) * Math.Cos(convert(trackBar3.Value)));


            matrix3[1, 0] = Math.Round(Math.Sin(convert(trackBar3.Value)));
            matrix3[1, 1] = Math.Round(Math.Cos(convert(trackBar3.Value)));
            matrix3[1, 2] =Math.Round( Math.Sin(convert(int.Parse(textBox12.Text))) * -1 * Math.Cos(convert(trackBar3.Value)));
            matrix3[1, 3] = Math.Round(int.Parse(textBox11.Text) * Math.Sin(convert(trackBar3.Value)));


            matrix3[2, 0] = 0;
            matrix3[2, 1] =Math.Round( Math.Sin(convert(int.Parse(textBox12.Text))));
            matrix3[2, 2] = Math.Round(Math.Cos(convert(int.Parse(textBox12.Text))));
            matrix3[2, 3] = int.Parse(textBox10.Text);


            matrix3[3, 0] = 0;
            matrix3[3, 1] = 0;
            matrix3[3, 2] = 0;
            matrix3[3, 3] = 1;


            double[,] resulet1 = new double[4, 4];


            mult(resulet, matrix3, resulet1);



            textBox17.Text = resulet1[0, 0].ToString();
            textBox18.Text = resulet1[0, 1].ToString();
            textBox19.Text = resulet1[0, 2].ToString();
            textBox20.Text = resulet1[0, 3].ToString();

            textBox21.Text = resulet1[1, 0].ToString();
            textBox22.Text = resulet1[1, 1].ToString();
            textBox23.Text = resulet1[1, 2].ToString();
            textBox24.Text = resulet1[1, 3].ToString();

            textBox25.Text = resulet1[2, 0].ToString();
            textBox26.Text = resulet1[2, 1].ToString();
            textBox27.Text = resulet1[2, 2].ToString();
            textBox28.Text = resulet1[2, 3].ToString();

            textBox29.Text = resulet1[3, 0].ToString();
            textBox30.Text = resulet1[3, 1].ToString();
            textBox31.Text = resulet1[3, 2].ToString();
            textBox32.Text = resulet1[3, 3].ToString();


            textBox33.Text = textBox20.Text;
            textBox34.Text = textBox24.Text;
            textBox35.Text = textBox28.Text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            textBox15.Text = trackBar2.Value.ToString();
            textBox5.Text = trackBar2.Value.ToString();
            mainfunction();


        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            textBox13.Text = trackBar3.Value.ToString();
            textBox9.Text = trackBar3.Value.ToString();
            mainfunction();


        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            textBox14.Text = trackBar1.Value.ToString();
            textBox1.Text = trackBar1.Value.ToString();
            mainfunction();

        }
        

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
                double[,] matrix3 = new double[4, 4];

                matrix3[0, 0] = Math.Cos(convert(trackBar3.Value));
                matrix3[0, 1] = Math.Cos(convert(int.Parse(textBox12.Text))) * Math.Sin(convert(trackBar3.Value))*-1;
                matrix3[0, 2] = Math.Sin(convert(trackBar3.Value)) * Math.Sin(convert(int.Parse(textBox12.Text)));
                matrix3[0, 3] = int.Parse(textBox11.Text) * Math.Cos(convert(trackBar3.Value));


                matrix3[1, 0] = Math.Sin(convert(trackBar3.Value));
                matrix3[1, 1] = Math.Cos( convert(trackBar3.Value));
                matrix3[1, 2] = Math.Sin(convert(int.Parse(textBox12.Text))) * -1 * Math.Cos(convert(trackBar3.Value));
                matrix3[1, 3] = int.Parse(textBox11.Text) * Math.Sin(convert(trackBar3.Value));


                matrix3[2, 0] = 0;
                matrix3[2, 1] = Math.Sin( convert(int.Parse(textBox12.Text)));
                matrix3[2, 2] = Math.Cos(convert(double.Parse(textBox12.Text)));
                matrix3[2, 3] = int.Parse(textBox10.Text);


                matrix3[3, 0] = 0;
                matrix3[3, 1] = 0;
                matrix3[3, 2] = 0;
                matrix3[3, 3] = 1;

                textBox17.Text = matrix3[0, 0].ToString();
                textBox18.Text = matrix3[0, 1].ToString();
                textBox19.Text = matrix3[0, 2].ToString();
                textBox20.Text = matrix3[0, 3].ToString();

                textBox21.Text = matrix3[1, 0].ToString();
                textBox22.Text = matrix3[1, 1].ToString();
                textBox23.Text = matrix3[1, 2].ToString();
                textBox24.Text = matrix3[1, 3].ToString();

                textBox25.Text = matrix3[2, 0].ToString();
                textBox26.Text = matrix3[2, 1].ToString();
                textBox27.Text = matrix3[2, 2].ToString();
                textBox28.Text = matrix3[2, 3].ToString();

                textBox29.Text = matrix3[3, 0].ToString();
                textBox30.Text = matrix3[3, 1].ToString();
                textBox31.Text = matrix3[3, 2].ToString();
                textBox32.Text = matrix3[3, 3].ToString();

           
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

    }
}