using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfLayeredDrawing
{
    public class WpfLayerInfo
    {
        public WpfLayerInfo(int priority, Action<DrawingContext> draw, DrawingVisual visual, ChangeType notifyOnChange)
        {
            NotifyOnChange = notifyOnChange;
            Priority = priority;
            Visual = visual;
            Draw = draw;
        }

        public ChangeType NotifyOnChange { get; private set; }
        public int Priority { get; private set; }
        public DrawingVisual Visual { get; private set; }
        public Action<DrawingContext> Draw { get; private set; }
    }
}

