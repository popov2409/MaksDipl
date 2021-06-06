using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using MaksDipl.Models;

namespace MaksDipl.View
{
    /// <summary>
    /// Перечень интерфесов для элементов
    /// </summary>
    public interface IControlInterface
    {
        /// <summary>
        /// Выделить
        /// </summary>
        void Selected();
        /// <summary>
        /// Снять выделение
        /// </summary>
        void UnSelected();
        void Move(Point p);

        /// <summary>
        /// Поворот
        /// </summary>
        /// <param name="angle"></param>
        void Rotate(double angle);


        bool IsSelected { get; set; }
        /// <summary>
        /// Елемент
        /// </summary>
        Element Element { get; set; }


    }
}
