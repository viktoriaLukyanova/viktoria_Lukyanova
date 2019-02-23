using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace System.Windows.Forms
{
    public class AdjPanel : Panel
    {
        private IList<Node> _nodes;
        private PointF _offset;
        private PointF _mouseDown;
        private IDragable _dragged;
        private PointF Center { get => new PointF(ClientRectangle.Width / 2f, ClientRectangle.Height / 2); }

        public AdjPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
        }

        public void Build(int[,] conjMatrix)
        {
            if (conjMatrix.GetLength(0) != conjMatrix.GetLength(1))
                throw new ArgumentException("Матрица смежности должна быть квадратной");

            if (_nodes == null)
                CreateNodes(conjMatrix);
            else
                UpdateNodes(conjMatrix);

            Invalidate();
        }

        private void UpdateNodes(int[,] conjMatrix)
        {
            foreach (var item in _nodes)
                item.Linked.Clear();
            for (int i = 0; i < conjMatrix.GetLength(0); i++)
                for (int j = 0; j < conjMatrix.GetLength(1); j++)
                    if (conjMatrix[i, j] != 0)
                        _nodes[i].Linked.Add(_nodes[j]);
        }

        private void CreateNodes(int[,] conjMatrix)
        {
            _nodes = Enumerable.Range(0, conjMatrix.GetLength(0)).Select(i => new Node { Label = i.ToString() }).ToList();

            for (int i = 0; i < conjMatrix.GetLength(0); i++)
                for (int j = 0; j < conjMatrix.GetLength(1); j++)
                {
                    if (conjMatrix[i, j] != 0)
                        _nodes[i].Linked.Add(_nodes[j]);
                }
            ArrangeNodes();
        }
        //Первичная расстановка вершин в вершинах многоугольника
        private void ArrangeNodes()
        {
            int i = 0;
            var r = Math.Min(ClientRectangle.Width, ClientRectangle.Height) * 0.9 / 2f;
            int count = _nodes.Count;
            foreach (var node in _nodes.Cast<Node>())
            {
                var x = r * Math.Cos(2 * Math.PI * i / count);
                var y = r * Math.Sin(2 * Math.PI * i / count);
                node.Location = new PointF((float)x, (float)y);
                i++;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_nodes == null) return;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TranslateTransform(Center.X, Center.Y);
            e.Graphics.TranslateTransform(_offset.X, _offset.Y);

            foreach (var item in _nodes)
                item.Paint(e.Graphics);
        }

        private PointF ToClient(PointF p)
        {
            return p.Sub(_offset).Sub(Center);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _mouseDown = e.Location;
                var p = ToClient(e.Location);
                //ищем объект под мышкой
                var hitted = _nodes.FirstOrDefault(n => n.Hit(p));
                if (hitted != null)
                    _dragged = hitted.StartDrag(p);//начинаем тащить
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var shift = new PointF(e.Location.X - _mouseDown.X, e.Location.Y - _mouseDown.Y);
                _mouseDown = e.Location;
                //
                if (_dragged != null)
                    _dragged.Drag(shift);//двигаем объект
                else
                    _offset = new PointF(_offset.X + shift.X, _offset.Y + shift.Y);//сдвигаем канвас

                Invalidate();
            }
            var p = ToClient(e.Location);
            //ищем объект под мышкой
            var hitted = _nodes.FirstOrDefault(n => n.Hit(p));
            //Меняем курсор, если над вершиной 
            Cursor = hitted != null ? Cursors.Hand : Cursors.Default;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_dragged != null)
                _dragged.EndDrag();
            _dragged = null;
            Invalidate();
        }
    }
}
