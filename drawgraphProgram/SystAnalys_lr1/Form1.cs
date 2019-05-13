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

namespace SystAnalys_lr1
{
    public partial class Form1 : Form
    {
        DrawGraph G;
        List<Vertex> V;
        List<Edge> E;

        float[,] AMatrix; //матрица смежности
        bool isClick = false;
        int selected1; //выбранные вершины, для соединения линиями
        int selected2;
        int numberV=-1;
        int delX = 0;
        int delY = 0; 

        public Form1()
        {
            InitializeComponent();
            V = new List<Vertex>();
            G = new DrawGraph(sheet.Width, sheet.Height);
            E = new List<Edge>();
            sheet.Image = G.GetBitmap();
        }

        //кнопка - выбрать вершину
        private void selectButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = false;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;

        }

        //кнопка - рисовать вершину
        private void drawVertexButton_Click(object sender, EventArgs e)
        {
            drawVertexButton.Enabled = false;
            selectButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
            selected1 = -1;
            selected2 = -1;
        }

        //кнопка - удалить элемент
        private void deleteButton_Click(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            // G.clearSheet();
            // G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - удалить граф
        private void deleteALLButton_Click(object sender, EventArgs e)
        {
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            drawEdgeButton.Enabled = true;
            deleteButton.Enabled = true;
            const string message = "Вы действительно хотите полностью удалить граф?";
            const string caption = "Удаление";
            var MBSave = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (MBSave == DialogResult.Yes)
            {
                V.Clear();
                E.Clear();
                G.clearSheet();
                sheet.Image = G.GetBitmap();
            }
        }

        //кнопка - матрица смежности
        private void buttonAdj_Click(object sender, EventArgs e)
        {
            createAdjAndOut();
        }

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //если нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
               /* for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        if (isClick)
                        {
                            G.drawVertex(e.X, e.Y, V[i].ToString());
                            sheet.Image = G.GetBitmap();
                            //V[i].x = e.X - V[i].x;
                            // V[i].y = e.Y - V[i].y;
                        }

                    }
                }*/
            }
            // если нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                sheet.Image = G.GetBitmap();
            }
            //если нажата кнопка "рисовать ребро"
            if (drawEdgeButton.Enabled == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    for (int i = 0; i < V.Count; i++)
                    {
                        if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                        {
                            if (selected1 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected1 = i;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                            if (selected2 == -1)
                            {
                                G.drawSelectedVertex(V[i].x, V[i].y);
                                selected2 = i;
                                E.Add(new Edge(selected1, selected2));
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1]);
                                selected1 = -1;
                                selected2 = -1;
                                sheet.Image = G.GetBitmap();
                                break;
                            }
                        }
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if ((selected1 != -1) &&
                        (Math.Pow((V[selected1].x - e.X), 2) + Math.Pow((V[selected1].y - e.Y), 2) <= G.R * G.R))
                    {
                        G.drawVertex(V[selected1].x, V[selected1].y, (selected1 + 1).ToString());
                        selected1 = -1;
                        sheet.Image = G.GetBitmap();
                    }
                }
            }
            //если нажата кнопка "удалить элемент"
            if (deleteButton.Enabled == false)
            {
                bool flag = false; //удалили ли что-нибудь по ЭТОМУ клику
                //ищем, возможно была нажата вершина
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        for (int j = 0; j < E.Count; j++)
                        {
                            if ((E[j].v1 == i) || (E[j].v2 == i))
                            {
                                E.RemoveAt(j);
                                j--;
                            }
                            else
                            {
                                if (E[j].v1 > i) E[j].v1--;
                                if (E[j].v2 > i) E[j].v2--;
                            }
                        }
                        V.RemoveAt(i);
                        flag = true;
                        break;
                    }
                }
                // ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (E[i].v1 == E[i].v2) //если это петля
                        {
                            if ((Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) <= ((G.R + 2) * (G.R + 2))) &&
                                (Math.Pow((V[E[i].v1].x - G.R - e.X), 2) + Math.Pow((V[E[i].v1].y - G.R - e.Y), 2) >= ((G.R - 2) * (G.R - 2))))
                            {
                                E.RemoveAt(i);
                                G.DelWT(i);
                                flag = true;
                                break;
                            }
                        }
                        else //не петля
                        {
                            if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                                ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                            {
                                if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                    (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                                {
                                    G.DelWT(i);
                                    E.RemoveAt(i);
                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearOne();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        //создание матрицы смежности и вывод в datagrid
        private void createAdjAndOut()
        {
            AMatrix = new float[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);

            tableEnter.Rows.Clear();
            tableEnter.Columns.Clear();

            for (int i = 1; i <= V.Count; i++)
            {
                var colum = new DataGridViewColumn();
                colum.HeaderText = i.ToString();
                colum.Width = 50;
                colum.CellTemplate = new DataGridViewTextBoxCell();
                tableEnter.Columns.Add(colum);
            }

            tableEnter.Rows.Add(V.Count - 1);
            float ch;
            for (int i = 0; i < V.Count; i++)
            {
                tableEnter.Rows[i].HeaderCell.Value = (i + 1).ToString();
                ch = 0;
                for (int j = 0; j < V.Count; j++)
                {

                    tableEnter[j, i].Value = AMatrix[i, j];
                    ch += AMatrix[i, j];
                }
                if (ch > 1)
                {
                    tableEnter.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    MessageBox.Show("Ошибка в строке");
                }

            }
        }

        //О программе
        private void about_Click(object sender, EventArgs e)
        {
            aboutForm FormAbout = new aboutForm();
            FormAbout.ShowDialog();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (sheet.Image != null)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sheet.Image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void sheet_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < V.Count; i++)
            {
                if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                {
                    isClick = true;
                    delX = e.X - V[i].x;
                    delY = e.Y - V[i].y;
                    numberV = i;              
                }
            }
        }

        private void sheet_MouseMove(object sender, MouseEventArgs e)
        {
            if (isClick)
            {
                V[numberV].x = e.X - delX;
                V[numberV].y = e.Y - delY;
                G.clearOne();
                G.drawVertex(V[numberV].x, V[numberV].y, (numberV+1).ToString());
                G.drawALLGraph(V, E);
                sheet.Image = G.GetBitmap();
            }
        }

        private void sheet_MouseUp(object sender, MouseEventArgs e)
        {           
            isClick = false;
            numberV = -1;
        }
    }
}
