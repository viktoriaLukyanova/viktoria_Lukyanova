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
        List<string> transacts = new List<string>();
        public List<string> masElements = new List<string>();
        public int[,] f;
        public Form1()
        {
            InitializeComponent();
        }
        //кнопка загрузить excel файл
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
                for (int i = 1; i < 7; i++)
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
        //чтение транзакций по строкам
        private void ReadDate()
        {
            for (int i = 0; i < 6; i++)
            {
                transacts.Add(dataTrans[1, i].Value.ToString());
            }

        }
        //Транспонирование матрицы
        private int[,] Transpon(int[,] matrix, int masEl, int tran)
        {
            int[,] matrixT = new int[masEl, tran];
            for (int i = 0; i < tran; i++)
            {
                for (int j = 0; j < masEl; j++)
                {
                    matrixT[j, i] = matrix[i, j];
                }
            }
            return matrixT;
        }
        //Алгоритм из статьи
        public void Algoritm()
        {
            //Формирования элементов
            for (int i = 0; i < transacts.Count; i++)
            {
                string str = transacts[i];
                string[] masStr = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < masStr.Length; j++)
                {
                    if (str.Contains(masStr[j]))
                    {
                        if (!masElements.Contains(masStr[j]))
                        {
                            masElements.Add(masStr[j]);
                        }
                    }
                }
            }
            //создание нормальной матрицы
            int[,] normalTabelTransact = new int[transacts.Count, masElements.Count];
            for (int i = 0; i < transacts.Count; i++)
            {
                for (int j = 0; j < masElements.Count; j++)
                {
                    if (transacts[i].Contains(masElements[j]))
                    {
                        normalTabelTransact[i, j] = 1;
                    }
                    else
                    {
                        normalTabelTransact[i, j] = 0;
                    }
                }
            }
            //реализация алгоритма из статьи
            int countMasElement = masElements.Count;
            int countTransacts = transacts.Count;
            int[,] matrixT = Transpon(normalTabelTransact, countMasElement, countTransacts);
            f = new int[masElements.Count, masElements.Count];
            // заполнение матрицы f
            for (int i = 0; i < masElements.Count; i++)
            {
                for (int j = 0; j < masElements.Count; j++)
                {
                    for (int k = 0; k < transacts.Count; k++)
                    {
                        f[i, j] += matrixT[i, k] * normalTabelTransact[k, j];
                    }
                }
            }
        }
        //кнопка очистки
        private void btnClean_Click(object sender, EventArgs e)
        {
            dataTrans.Rows.Clear();
            dataTrans.Columns.Clear();
        }
        //кнопка получить правила
        private void btnGetAs_Click(object sender, EventArgs e)
        {
            ReadDate();
            Algoritm();
            Form2 form2 = new Form2();
            form2.help(f, f.GetLength(0), masElements);
            form2.ShowDialog();
        }
    }
}
