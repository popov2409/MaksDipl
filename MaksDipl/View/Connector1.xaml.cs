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

namespace MaksDipl.Controls
{
    /// <summary>
    /// Логика взаимодействия для connector1.xaml
    /// </summary>
    public partial class Connector1 : UserControl,IControlInterface
    {
        public Connector1()
        {
            InitializeComponent();
            
        }

        public void Selected()
        {
            ((SolidColorBrush) this.Resources["BaseColor"]).Color = Colors.Red;
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
        }
    }
}
