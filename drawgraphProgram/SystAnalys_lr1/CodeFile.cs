using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystAnalys_lr1
{
    class Vertex
    {
        public int x, y;

        public Vertex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Edge
    {
        public int v1, v2;

        public Edge(int v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
    }

    class DrawGraph
    {
        Bitmap bitmap;
        Pen blackPen;
        Pen redPen;
        Pen darkGoldPen;
        Pen whitePen;
        Graphics gr;
        Font fo;
        Brush br, bro;
        PointF point;
        Point p1, p2;
        public int R = 20; //радиус окружности вершины
        List<string> P = new List<string>();

        public DrawGraph(int width, int height)
        {
            bitmap = new Bitmap(width, height);
            gr = Graphics.FromImage(bitmap);
            clearSheet();
            blackPen = new Pen(Color.Black);
            blackPen.Width = 2;
            blackPen.CustomEndCap = new AdjustableArrowCap(5, 20);
            redPen = new Pen(Color.Red);
            redPen.Width = 2;
            whitePen = new Pen(Color.White);
            whitePen.Width = 2;
            whitePen.CustomEndCap = new AdjustableArrowCap(10, 10);
            darkGoldPen = new Pen(Color.DarkGoldenrod);
            darkGoldPen.Width = 2;
            darkGoldPen.CustomEndCap = new AdjustableArrowCap(10, 10);
            fo = new Font("Arial", 15);
            br = Brushes.Black;
            bro = Brushes.White;

        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        public void clearSheet()
        {
            gr.Clear(Color.White);
            P.Clear();
        }
        public void clearOne()
        {
            gr.Clear(Color.White);
        }

        public void drawVertex(int x, int y, string number)
        {
            gr.FillEllipse(Brushes.White, (x - R), (y - R), 2 * R, 2 * R);
            gr.DrawEllipse(blackPen, (x - R), (y - R), 2 * R, 2 * R);
            point = new PointF(x - 9, y - 9);  //цифры в центре вершин
            gr.DrawString(number, fo, br, point);
        }

        public void drawSelectedVertex(int x, int y)
        {
            gr.DrawEllipse(redPen, (x - R), (y - R), 2 * R, 2 * R);
        }

        public void DelWT(int i)
        {
            P.RemoveAt(i);
        }

        public void drawEdge(Vertex V1, Vertex V2, Edge E)
        {
            Request rq = new Request();
            if (E.v1 == E.v2)
            {
                rq.ShowDialog();
                string i = rq.wt.Text;
                if (!string.IsNullOrEmpty(i))
                {
                    gr.DrawArc(darkGoldPen, (V1.x - 2 * R), (V1.y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V1.x - (int)(2.75 * R), V1.y - (int)(2.75 * R)); //петля координаты                                              
                    P.Add(rq.wt.Text);
                    gr.DrawString(i, fo, br, point);
                }
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
            }
            else
            {
                rq.ShowDialog();
                string i = rq.wt.Text;
                if (!string.IsNullOrEmpty(i))
                {
                    if (V1.x > V2.x && V1.y > V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x + 20, V2.y + 5);
                    }
                    else if (V1.x > V2.x && V1.y < V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x + 20, V2.y - 5);
                    }
                    else if (V1.x < V2.x && V1.y > V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x - 20, V2.y + 5);
                    }
                    else if (V1.x < V2.x && V1.y < V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x - 20, V2.y-5);
                    }
                    else if (V1.x == V2.x && V1.y > V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y + 5);
                    }
                    else if (V1.x == V2.x && V1.y < V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x, V2.y - 5);
                    }
                    else if (V1.x > V2.x && V1.y == V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x + 20, V2.y);
                    }
                    else if (V1.x > V2.x && V1.y == V2.y)
                    {
                        gr.DrawLine(darkGoldPen, V1.x, V1.y, V2.x - 20, V2.y);
                    }
                    point = new PointF((V1.x + V2.x) / 2, (V1.y + V2.y) / 2); // координаты цифры на дуге
                    P.Add(rq.wt.Text);
                    gr.DrawString(i, fo, br, point); // ребро дуга                    
                    gr.DrawString(i, fo, br, point); // ребро дуга     

                }
                drawVertex(V1.x, V1.y, (E.v1 + 1).ToString());
                drawVertex(V2.x, V2.y, (E.v2 + 1).ToString());
            }
        }


        public void drawALLGraph(List<Vertex> V, List<Edge> E)
        {

            //рисуем ребра
            for (int i = 0; i < E.Count; i++)
            {
                if (E[i].v1 == E[i].v2)
                {
                    gr.DrawArc(darkGoldPen, (V[E[i].v1].x - 2 * R), (V[E[i].v1].y - 2 * R), 2 * R, 2 * R, 90, 270);
                    point = new PointF(V[E[i].v1].x - (int)(2.75 * R), V[E[i].v1].y - (int)(2.75 * R)); //петля                    
                    gr.DrawString(P[i], fo, br, point);
                }
                else
                {
                    if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y > V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x + 20, V[E[i].v2].y + 5);
                    }
                    else if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y < V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x + 20, V[E[i].v2].y - 5);
                    }
                    else if (V[E[i].v1].x < V[E[i].v2].x && V[E[i].v1].y > V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x - 20, V[E[i].v2].y + 5);
                    }
                    else if (V[E[i].v1].x < V[E[i].v2].x && V[E[i].v1].y < V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x - 20, V[E[i].v2].y - 5);
                    }
                    else if (V[E[i].v1].x == V[E[i].v2].x && V[E[i].v1].y > V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y + 5);
                    }
                    else if (V[E[i].v1].x == V[E[i].v2].x && V[E[i].v1].y < V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x, V[E[i].v2].y - 5);
                    }
                    else if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y == V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x + 20, V[E[i].v2].y);
                    }
                    else if (V[E[i].v1].x > V[E[i].v2].x && V[E[i].v1].y == V[E[i].v2].y)
                    {
                        gr.DrawLine(darkGoldPen, V[E[i].v1].x, V[E[i].v1].y, V[E[i].v2].x - 20, V[E[i].v2].y);
                    }
                    point = new PointF((V[E[i].v1].x + V[E[i].v2].x) / 2, (V[E[i].v1].y + V[E[i].v2].y) / 2); // ребро дуга
                    gr.DrawString(P[i], fo, br, point);
                }
            }
            //рисуем вершины
            for (int i = 0; i < V.Count; i++)
            {
                drawVertex(V[i].x, V[i].y, (i + 1).ToString());
            }
        }

        //заполняет матрицу смежности
        public void fillAdjacencyMatrix(int numberV, List<Edge> E, float[,] matrix)
        {
            for (int i = 0; i < numberV; i++)
                for (int j = 0; j < numberV; j++)
                    matrix[i, j] = 0;

            for (int i = 0; i < E.Count; i++)
            {
                matrix[E[i].v1, E[i].v2] = float.Parse(P[i]); // для симметричной матрицы!
            }
        }

    }
}