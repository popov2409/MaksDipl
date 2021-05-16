﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MaksDipl.Models;

namespace MaksDipl.View
{
    public interface IControlInterface
    {
        void Selected();
        void UnSelected();
        void Move(Point p);
        bool IsSelected { get; set; }
        string Mark { get; set; }
        Element Element { get; set; }
    }
}
