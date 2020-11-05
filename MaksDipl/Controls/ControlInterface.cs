using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace MaksDipl.Controls
{
    public interface IControlInterface
    {
        void Selected();
        void UnSelected();
        void Move(Point p);
    }
}
