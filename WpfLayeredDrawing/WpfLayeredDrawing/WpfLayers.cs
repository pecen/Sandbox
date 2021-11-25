using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
//using WpfLayeredDrawing.Extensions;

namespace WpfLayeredDrawing
{
    public class WpfLayers : FrameworkElement
    {
        private readonly VisualCollection _children;
        private readonly List<WpfLayerInfo> _layers;

        public WpfLayers()
        {
            _children = new VisualCollection(this);
            _layers = new List<WpfLayerInfo>();
        }

        public void AddLayer(int priority, Action<DrawingContext> draw, ChangeType notifyOnChange = ChangeType.Redraw)
        {
            var drawingVisual = new DrawingVisual();
            var layerInfo = new WpfLayerInfo(priority, draw, drawingVisual, notifyOnChange);

            _layers.Add(layerInfo);
            _layers.Sort((x, y) => x.Priority.CompareTo(y.Priority));

            _children.Clear();
            _layers.ForEach(l => _children.Add(l.Visual));
        }

        public void Draw(ChangeType changeType)
        {
            var affected = from l in _layers
                           where ((changeType & ChangeType.Redraw) != 0) || ((l.NotifyOnChange & changeType) != 0)
                           orderby l.Priority
                           select l;

            //var a = _layers.Where(l => (changeType & ChangeType.Redraw) != 0 || ((l.NotifyOnChange & changeType) != 0))
            //    .OrderBy(o => o.Priority)
            //    .Select(t => t);

            foreach (WpfLayerInfo layer in affected)
            {
                DrawingContext ctx = layer.Visual.RenderOpen();
                layer.Draw(ctx);
                ctx.Close();
            }
        }

        protected override int VisualChildrenCount => _children.Count;

        protected override Visual GetVisualChild(int index)
        {
            if(index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            //var v = base.GetVisualChild(index);

            return _children[index];
        }
    }
}
