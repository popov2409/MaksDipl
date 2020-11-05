using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MaksDipl.Models
{
   public class Element
   {
       public Guid Id { get; set; }
       public Point Location { get; set; }
       public string Value { get; set; }
       public UserControl UserControl { get; set; }
   }
}
