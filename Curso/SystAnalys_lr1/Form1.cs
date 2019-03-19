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
        List<Vertex> V; //вершины
        List<Edge> E; //связи
        int[,] AMatrix; //матрица пересечений
        List<int> S = new List<int>(); //временный список
        List<int> Ex = new List<int>(); //список вершин, которые точно имеют пересечения
        Dictionary<int, int> Dic = new Dictionary<int, int>(); //словарь с информацией о вершине и ее слое
        public int n = 0; //текущий слой

        int selected1; //выбранные вершины, для соединения линиями
        int selected2;

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
            G.clearSheet();
            G.drawALLGraph(V, E);
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
            G.clearSheet();
            G.drawALLGraph(V, E);
            sheet.Image = G.GetBitmap();
        }

        //кнопка - рисовать ребро
        private void drawEdgeButton_Click(object sender, EventArgs e)
        {
            drawEdgeButton.Enabled = false;
            selectButton.Enabled = true;
            drawVertexButton.Enabled = true;
            deleteButton.Enabled = true;
            G.clearSheet();
            G.drawALLGraph(V, E);
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
            G.clearSheet();
            G.drawALLGraph(V, E);
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

        private void sheet_MouseClick(object sender, MouseEventArgs e)
        {
            //нажата кнопка "выбрать вершину", ищем степень вершины
            if (selectButton.Enabled == false)
            {
                for (int i = 0; i < V.Count; i++)
                {
                    if (Math.Pow((V[i].x - e.X), 2) + Math.Pow((V[i].y - e.Y), 2) <= G.R * G.R)
                    {
                        if (selected1 != -1)
                        {
                            selected1 = -1;
                            G.clearSheet();
                            G.drawALLGraph(V, E);
                            sheet.Image = G.GetBitmap();
                        }
                        if (selected1 == -1)
                        {
                            G.drawSelectedVertex(V[i].x, V[i].y);
                            selected1 = i;
                            sheet.Image = G.GetBitmap();
                            createAdjAndOut();
                            listBoxMatrix.Items.Clear();
                            int degree = 0;
                            for (int j = 0; j < V.Count; j++)
                                degree += AMatrix[selected1, j];
                            listBoxMatrix.Items.Add("Степень вершины №" + (selected1 + 1) + " равна " + degree);
                            break;
                        }
                    }
                }
            }
            //нажата кнопка "рисовать вершину"
            if (drawVertexButton.Enabled == false)
            {
                V.Add(new Vertex(e.X, e.Y));
                G.drawVertex(e.X, e.Y, V.Count.ToString());
                Ex.Add(V.Count);
                sheet.Image = G.GetBitmap();
            }
            //нажата кнопка "рисовать ребро"
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
                                G.drawEdge(V[selected1], V[selected2], E[E.Count - 1], E.Count - 1);
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
            //нажата кнопка "удалить элемент"
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
                //ищем, возможно было нажато ребро
                if (!flag)
                {
                    for (int i = 0; i < E.Count; i++)
                    {
                        if (((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) <= (e.Y + 4) &&
                            ((e.X - V[E[i].v1].x) * (V[E[i].v2].y - V[E[i].v1].y) / (V[E[i].v2].x - V[E[i].v1].x) + V[E[i].v1].y) >= (e.Y - 4))
                        {
                            if ((V[E[i].v1].x <= V[E[i].v2].x && V[E[i].v1].x <= e.X && e.X <= V[E[i].v2].x) ||
                                (V[E[i].v1].x >= V[E[i].v2].x && V[E[i].v1].x >= e.X && e.X >= V[E[i].v2].x))
                            {
                                E.RemoveAt(i);
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                //если что-то было удалено, то обновляем граф на экране
                if (flag)
                {
                    G.clearSheet();
                    G.drawALLGraph(V, E);
                    sheet.Image = G.GetBitmap();
                }
            }
        }

        private void ExeptVLockMin(int[,] AAMatrix, int n)
        {
            //Определяем вершины с лок. степенью меньше заданной
            bool log = false;
            for (int i = 0; i < V.Count; i++)
            {
                if (log == true)
                {
                    i = 0;
                }
                int loc = 0;
                for (int j = 0; j < V.Count; j++)
                {
                    if (AAMatrix[i, j] == 1)
                    {
                        loc++;
                    }
                }
                //исключаем их и добавляем в список S
                if (loc < LockS.Value - n && loc != 0)
                {
                    S.Add(i + 1);
                    Ex.Remove(i + 1);
                    for (int k = 0; k < V.Count; k++)
                    {
                        AAMatrix[i, k] = 0;
                        AAMatrix[k, i] = 0;
                    }
                    log = true;
                }
                else
                {
                    log = false;
                }
            }
            int[,] matrTest = new int[V.Count, V.Count];
            for (int i = 0; i < V.Count; i++)
            {
                for (int j = 0; j < V.Count; j++)
                {
                    matrTest[i, j] = AAMatrix[i, j];
                }
            }
            List<int> L = new List<int>();
            L.AddRange(Ex.ToArray());
            L = EMax(matrTest, L); //находим вершины с мак. связями
            if (L.Count == 0)
            {      //если все вершины исключены, то заканчиваем          
                if (S.Count == 0)
                {
                    printResult();
                }
                else
                {
                    createAdjAndOut();
                    RToSloy();
                    if (Ex.Count != 0)
                    {
                        ExRasp();
                        printResult();
                    }
                }
            }
            else
            {
                //тоже исключаем их и формируем слои
                for (int i = 0; i < V.Count; i++)
                {
                    for (int j = 0; j < V.Count; j++)
                    {
                        if (L.Contains(i + 1))
                        {
                            AAMatrix[i, j] = 0;
                            AAMatrix[j, i] = 0;
                        }
                    }
                }
                for (int i = 0; i < L.Count; i++)
                {
                    Dic.Add(L[i], n);
                    Ex.Remove(L[i]);
                }
                n++;
                //проверка на конец
                if (CheckMatrZero(AAMatrix) == true || LockS.Value - n <= 0)
                {
                    if (S.Count == 0)
                    {
                        if (Ex.Count != 0)
                        {
                            ExRasp();
                        }
                        printResult();
                    }
                    else
                    {
                        createAdjAndOut();
                        RToSloy();
                        if (Ex.Count != 0)
                        {
                            ExRasp();
                            printResult();
                        }
                    }
                }
                else
                {
                    ExeptVLockMin(AAMatrix, n);
                }

            }
        }

        private bool CheckMatrZero(int[,] m)
        {
            foreach (int el in m)
            {
                if (el != 0)
                {
                    return false;
                }
            }
            return true;
        }
        private List<int> EMax(int[,] mat, List<int> L)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < V.Count; i++)
            {

                int loc = 0;
                if (L.Contains(i + 1))
                {
                    for (int j = 0; j < V.Count; j++)
                    {

                        if (mat[i, j] == 1)
                        {
                            loc++;
                        }
                    }
                }
                if (loc > max)
                {
                    max = loc;
                    index = i;
                }
            }
            for (int j = 0; j < V.Count; j++)
            {
                mat[index, j] = 0;
                mat[j, index] = 0;
            }
            L.Remove(index + 1);
            while (CheckMatrZero(mat) == false)
            {
                EMax(mat, L);
            }
            return L;
        }

        //создание матрицы смежности и вывод в листбокс
        private void createAdjAndOut()
        {
            AMatrix = new int[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AMatrix);
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
        private int SourseP(int v)
        {
            int p = 0;
            for (int j = 0; j < V.Count; j++)
            {
                if (AMatrix[v, j] == 1)
                {
                    p++;
                }
            }
            return p;
        }

        private void RToSloy()
        {
            int v = SourseP((S.Last() - 1));
            int[] verP = new int[v];
            for (int i = 0; i < V.Count; i++)
            {
                if (AMatrix[S.Last() - 1, i] == 1)
                {
                    verP[v - 1] = i + 1;
                    v--;
                }
            }
            List<int> Zanret = new List<int>();
            for (int i = verP.Length; i > 0; i--)
            {
                if (Dic.ContainsKey(verP[i - 1]))
                {
                    Zanret.Add(Dic[verP[i - 1]]);
                }
            }
            for (int i = 0; i < LockS.Value; i++)
            {
                if (!Zanret.Contains(i))
                {
                    Dic.Add(S.Last(), i);
                    S.Remove(S.Last());
                    break;
                }
            }
            if (S.Count != 0)
            {
                RToSloy();
            }
        }

        private void ExRasp()
        {
            if (Ex.Count != 0)
            {
                int sloy = 0;
                int v = SourseP((Ex.First() - 1));
                int[] verP = new int[v];
                for (int i = 0; i < V.Count; i++)
                {
                    if (AMatrix[Ex.First() - 1, i] == 1)
                    {
                        verP[v - 1] = i + 1;
                        v--;
                    }
                }
                int[] masP = new int[Convert.ToInt32(LockS.Value)];
                while (sloy < LockS.Value)
                {
                    int p = 0;
                    for (int i = 0; i < verP.Length; i++)
                    {
                        if (Dic.Keys.Contains(verP[i]))
                        {
                            if (Dic[verP[i]] == sloy)
                            {
                                p++;
                            }
                        }
                    }
                    masP[sloy] = p;
                    sloy++;
                }
                int mini = masP.Min();
                int index = 0;
                for (int k = 0; k < masP.Length; k++)
                {
                    if (masP.Contains(mini))
                    {
                        index = k;
                        break;
                    }
                }
                Dic.Add(Ex.First(), index);
                Ex.Remove(Ex.First());
                if (Ex.Count != 0)
                {
                    ExRasp();
                }
            }
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            int[,] AAMatrix = new int[V.Count, V.Count];
            G.fillAdjacencyMatrix(V.Count, E, AAMatrix);
            listBoxMatrix.Items.Clear();
            ExeptVLockMin(AAMatrix, n);
        }

        private void printResult()
        {
            listBoxMatrix.Items.Clear();
            string sOut = " ";
            int k = 1;
            int[] mas = new int[Dic.Count];
            Dic.Keys.CopyTo(mas, 0);
            while (k <= LockS.Value)
            {
                sOut += "Слой " + k + ": ";
                for (int j = 0; j < mas.Length; j++)
                {
                    if ((Dic[mas[j]] + 1) == k)
                    {
                        sOut += mas[j] + " ";
                    }
                }
                listBoxMatrix.Items.Add(sOut);
                k++;
                sOut = " ";
            }
        }
    }
}
