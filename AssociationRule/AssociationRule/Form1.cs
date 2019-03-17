using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AssociationRule
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openExcel.ShowDialog() == DialogResult.OK)
            {
                //Создаём приложение.
                Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
                //Открываем книгу.                                                                                                                                                        
                Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(openExcel.FileName, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //Выбираем таблицу(лист).
                Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
                ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];
                //Очищаем от старого текста окно вывода.
                dataTrans.Rows.Clear();
                dataTrans.Columns.Clear();
                for (int i = 1; i < 3; i++)
                {
                    var colum = new DataGridViewColumn();

                    colum.CellTemplate = new DataGridViewTextBoxCell();
                    if (i == 1)
                    {
                        colum.HeaderText = "ID_поля";
                        colum.Width = 50;
                        dataTrans.Columns.Add(colum);
                    }
                    else
                    {
                        colum.HeaderText = "Транзакты";
                        colum.Width = 250;
                        dataTrans.Columns.Add(colum);
                    }
                }
                dataTrans.Rows.Add(7);
                for (int i = 1; i < 6; i++)
                {
                    string a = "A";
                    //Выбираем область таблицы. (в нашем случае просто ячейку)
                    Microsoft.Office.Interop.Excel.Range range = ObjWorkSheet.get_Range(a + i.ToString(), a + i.ToString());
                    // dataTrans.Rows[j].HeaderCell.Value = (i).ToString();
                    for (int j = 0; j < 2; j++)
                    {
                        if (j == 1)
                        {
                            string b = "B";
                            Microsoft.Office.Interop.Excel.Range range1 = ObjWorkSheet.get_Range(b + i.ToString(), b + i.ToString());
                            dataTrans[j, i - 1].Value = range1.Text;
                        }
                        else
                        {
                            dataTrans[j, i - 1].Value = range.Text;
                        }
                        Application.DoEvents();
                    }
                }
                //Удаляем приложение (выходим из экселя) - ато будет висеть в процессах!
                ObjExcel.Quit();
            }

        }
        private void ReadDate()
        {
            List<string> Tran = new List<string>();
            for (int i = 0; i < 7; i++)
            {
                Tran.Add(dataTrans[i, 1].ToString());
            }

        }
    }
}
