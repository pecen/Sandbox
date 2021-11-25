using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLayeredDrawing
{
    [Flags]
    public enum ChangeType
    {
        Redraw = 1,
        Resize = 2,
        Scroll = 4,
    }
}
