using System.Drawing;

namespace System.Windows.Forms
{
    /// <summary>
    /// Умеет себя рисовать
    /// </summary>
    public interface IDrawable
    {
        void Paint(Graphics gr);
    }

    /// <summary>
    /// Умеет себя перемещать
    /// </summary>
    public interface IDragable
    {
        bool Hit(PointF point);
        void Drag(PointF offset);
        IDragable StartDrag(PointF p);
        void EndDrag();
    }
}
