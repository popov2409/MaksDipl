using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaksDipl.View
{
    /// <summary>
    /// Логика взаимодействия для knopka2.xaml
    /// </summary>
    public partial class Knopka2 : UserControl,IControlInterface 
    {
        public Knopka2()
        {
            InitializeComponent();
        }

        public void Selected()
        {
            ((SolidColorBrush)this.Resources["BaseColor"]).Color = Colors.Red;
        }

        public void UnSelected()
        {
            ((SolidColorBrush)this.Resources["BaseColor"]).Color = Colors.Black;
        }

        public void Move(Point p)
        {
            this.Margin = new Thickness(p.X, p.Y, 0, 0);
        }

        private void Base_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Selected();
            p2 = e.GetPosition(this);
        }

        private Point p2;
        private void Base_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            Point p1 = e.GetPosition(this.Parent as Canvas);
            Point p = new Point(p1.X - p2.X, p1.Y - p2.Y);
            this.Move(p);
        }
    }
}
