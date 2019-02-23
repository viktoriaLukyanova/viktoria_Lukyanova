using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int[,] matr = new int[,] { { 0, 1, 0, 1, 0, 0 }, { 0, 0, 0, 1, 0, 1 }, { 1, 1, 1, 1, 0, 0 } };



            for (int i = 1; i < (matr.Length / 3)+1; i++)
            {
                var colum = new DataGridViewColumn();
                colum.HeaderText = i.ToString();
                colum.CellTemplate = new DataGridViewTextBoxCell();
                table.Columns.Add(colum);
            }

          //  table.Rows.Add(matr.GetLength(1)); 
            
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                table.Rows.Add();

                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    table[j,i].Value = matr[i, j];
                   
                }
            }         



        }
    }
}
