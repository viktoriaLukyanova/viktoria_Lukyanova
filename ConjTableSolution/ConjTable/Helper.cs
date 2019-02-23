using System.Drawing;
using System.Drawing.Drawing2D;

namespace System.Windows.Forms
{
    internal static class Helper
    {
        private const int GapAngle = 8;//Зазор в градусах между точками входа смежных рёбер

        private static Pen LinkPen = new Pen(Color.Red) { CustomEndCap = new AdjustableArrowCap(5, 10, false) };

        public static PointF Sub(this PointF pt1, PointF pt2)
        {
            return new PointF(pt1.X - pt2.X, pt1.Y - pt2.Y);
        }

        public static PointF Add(this PointF pt1, PointF pt2)
        {
            return new PointF(pt1.X + pt2.X, pt1.Y + pt2.Y);
        }

        /// <summary>
        /// Середина отрезка между точками
        /// </summary>
        public static PointF Mid(this PointF pt1, PointF pt2)
        {
            return new PointF((pt2.X + pt1.X) / 2, (pt2.Y + pt1.Y) / 2);
        }
        /// <summary>
        /// Рисование связи между вершинами
        /// </summary>
        /// <param name="g">Где рисовать? Объект <see cref="Graphics"/>.</param>
        /// <param name="from">Центр вершины, от которой идёт связь.</param>
        /// <param name="to">Центр вершины, к которой идёт связь.</param>
        /// <param name="radius">Отступ от вершины.</param>
        /// <param name="straight">Рисовать ребро прямой или кривой Безье?</param>
        public static void DrawLink(this Graphics g, PointF from, PointF to, float radius, bool straight = false)
        {
            //Считаем точки входа ребёр графа в вершины
            var pt1 = new Vector(to.X - from.X, to.Y - from.Y); pt1.Normalize(); pt1 *= radius;
            var pt2 = new Vector(from.X - to.X, from.Y - to.Y); pt2.Normalize(); pt2 *= radius;
            pt1 = pt1.Rotate(GapAngle);
            pt2 = pt2.Rotate(-GapAngle);
            pt1 = pt1.Add(from);
            pt2 = pt2.Add(to);
            if (straight)
                DrawStraightLink(g, pt1.ToPointF(), pt2.ToPointF());
            else
                DrawBezierLink(g, pt1.ToPointF(), pt2.ToPointF());
        }

        private static void DrawStraightLink(Graphics g, PointF from, PointF to)
        {
            g.DrawLine(LinkPen, from, to);
        }

        private static void DrawBezierLink(Graphics g, PointF from, PointF to)
        {
            //Середина отрезка между крайними точками
            var mid = from.Mid(to);
            //Четверть отрезка от первой крайней точки
            var pt1 = mid.Mid(from);
            //Четверть отрезка от второй крайней точки
            var pt2 = mid.Mid(to);
            //Вектор, перпендикулярный направлению связи
            var v = new Vector(from.Y - to.Y, to.X - from.X);
            var l = v.Length * 0.08;//Кривизна
            //Нормализуем вектор
            v.Normalize();
            v *= l;
            //Опорные точки для кривой Безье
            pt1 = v.Add(pt1).ToPointF();
            pt2 = v.Add(pt2).ToPointF();

            g.DrawBezier(LinkPen, from, pt1, pt2, to);
        }

        /// <summary>
        /// Рисование окружности заданного радиуса в начале координат
        /// </summary>
        public static void DrawCircle(this Graphics g, float radius, Pen pen)
        {
            g.DrawEllipse(pen, -radius, -radius, 2 * radius, 2 * radius);
        }
        /// <summary>
        /// Рисование строки с выравниванием по центру по вертикали и по горизонтали.
        /// </summary>
        public static void DrawCenteredString(this Graphics g, string text, Font font, Brush brush, float radius)
        {
            var rect = new RectangleF(-radius, -radius, 2 * radius, 2 * radius);
            rect.Inflate(-3, -3);
            g.DrawString(text, font, brush, rect, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
        /// <summary>
        /// Преобразование вектора в точку
        /// </summary>
        private static PointF ToPointF(this Vector vector)
        {
            return new PointF((float)vector.X, (float)vector.Y);
        }
        /// <summary>
        /// Координаты отрезка между окружностями на прямой, проходящей через их центры.
        /// </summary>
        /// <param name="center1">Центр первой окружности</param>
        /// <param name="r1">Радиус первой окружности</param>
        /// <param name="center2">Центр второй окружности</param>
        /// <param name="r2">Радиус второй окружности</param>
        private static Tuple<PointF, PointF> LineBetweenCircles(PointF center1, float r1, PointF center2, float r2)
        {
            var v = new Vector(center2.X - center1.X, center2.Y - center1.Y);
            v.Normalize();
            var start = Vector.Add(new Vector(center1.X, center1.Y), v * r1);
            var end = Vector.Add(new Vector(center2.X, center2.Y), -v * r2);
            return new Tuple<PointF, PointF>(new PointF((float)start.X, (float)start.Y), new PointF((float)end.X, (float)end.Y));
        }

        private static Vector Rotate(this Vector vector, float angle)
        {
            angle *= (float)Math.PI / 180;
            return new Vector(vector.X * Math.Cos(angle) - vector.Y * Math.Sin(angle), vector.X * Math.Sin(angle) + vector.Y * Math.Cos(angle));
        }

        private static Vector Add(this Vector vector, PointF point)
        {
            return new Vector(vector.X + point.X, vector.Y + point.Y);
        }
    }
}
