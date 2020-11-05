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
using MaksDipl.View;

namespace MaksDipl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            foreach (UIElement child in BaseCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                (child as IControlInterface)?.UnSelected();
            }
        }

        private void Zoom_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //int dx = e.Delta / 5;
            //int dy = (int) (dx * BaseView.Height / BaseView.Width);

            //BaseView.Width += dx;
            //BaseView.Height += dy;
        }
        
    }
}
