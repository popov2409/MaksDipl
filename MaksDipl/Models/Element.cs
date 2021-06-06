using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MaksDipl.Models
{
    /// <summary>
    /// Элемент на схеме для хранения в базе
    /// </summary>
   [Serializable]
   public class Element
   {
       public Guid Id { get; set; } //ИД элемента
       public int ElementType { get; set; }//Тип, указаны в словаре в классе базы
       public Point Location { get; set; }//Позиция
       public string Mark { get; set; }//Маркировка
       public string Purpose { get; set; }//Назначение
       public double Rotate { get; set; }//Поворот, если допускается
       public string ImageSource { get; set; }//Картинка, если имеется
   }
}
