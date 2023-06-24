using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public partial class Form1 : Form
    {



        //for (int i = 0; i < 4; i++)
        //{
        //    for (int j = 0; j < 4; j++)
        //    {
        //        Console.Write("["+i+","+j+"]");
        //        matrix1[i, j] = int.Parse(Console.ReadLine());  
        //    }
        //}
        
//    class Program
//    {
//        static int[,]resulet;



//           Console.ReadKey();
//        }
//    }
//}






        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public static void mult(int[,] matrix1, int[,] matrix2, int[,] resulet)//////////////function multiplex
        {

            for (int i = 0; i < 4; i++)
            {

                resulet[i, 0] = 0;
                for (int j = 0; j < 4; j++)
                {
                    resulet[i, 0] += matrix1[i, j] * matrix2[j, 0];
                }
            }

        }
                  
        private void button1_Click(object sender, EventArgs e)
        {

                   
                        int[,] matrix1 = new int[4, 4];


                        matrix1[0, 0] = int.Parse(textBox5.Text);
                        matrix1[0, 1] = int.Parse(textBox6.Text);
                        matrix1[0, 2] = int.Parse(textBox7.Text);
                        matrix1[0, 3] = int.Parse(textBox8.Text);
                        matrix1[1, 0] = int.Parse(textBox9.Text);
                        matrix1[1, 1] = int.Parse(textBox10.Text);
                        matrix1[1, 2] = int.Parse(textBox11.Text);
                        matrix1[1, 3] = int.Parse(textBox12.Text);
                        matrix1[2, 0] = int.Parse(textBox13.Text);
                        matrix1[2, 1] = int.Parse(textBox14.Text);
                        matrix1[2, 2] = int.Parse(textBox15.Text);
                        matrix1[2, 3] = int.Parse(textBox16.Text);
                        matrix1[3, 0] = int.Parse(textBox17.Text);
                        matrix1[3, 1] = int.Parse(textBox18.Text);
                        matrix1[3, 2] = int.Parse(textBox19.Text);
                        matrix1[3, 3] = int.Parse(textBox20.Text);


                        int[,] matrix2=new int [4,1];

                       
                        matrix2[0, 0] = int.Parse(textBox1.Text);
                        matrix2[1, 0] = int.Parse(textBox2.Text);
                        matrix2[2, 0] = int.Parse(textBox3.Text);
                        matrix2[3, 0] = int.Parse(textBox4.Text);
                        
            
                       int[,] resulet = new int[4, 1];


                        mult(matrix1,matrix2,resulet);

                        textBox21.Text = resulet[0, 0].ToString();
                        textBox22.Text = resulet[1, 0].ToString();
                        textBox23.Text = resulet[2, 0].ToString();
                        textBox24.Text = resulet[3, 0].ToString();

        }
    }
    
}

