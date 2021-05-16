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
using MaksDipl.Models;
using MaksDipl.Services;
using MaksDipl.View;

namespace MaksDipl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BaseDataStore DataStore;

        public MainWindow()
        {
            InitializeComponent();
            DataStore=new BaseDataStore();
            CreateCanvas();
        }

        private void MainWindow_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ClearAllSelected();
            
        }

        private void Zoom_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //int dx = e.Delta / 5;
            //int dy = (int) (dx * BaseView.Height / BaseView.Width);

            //BaseView.Width += dx;
            //BaseView.Height += dy;
        }

        public void ClearAllSelected()
        {
            foreach (UIElement child in BaseCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                (child as IControlInterface)?.UnSelected();
            }
        }

        public void SearchElement(string elName)
        {
            ClearAllSelected();
            if(elName.Length<1) return;
            foreach (UIElement child in BaseCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                if (child is IControlInterface el && el.Element.Mark.ToLower().Contains(elName.ToLower())) el.Selected(); 
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchElement(SearchTextBox.Text);
        }

        private Point _locateCursor;

        private void AddElementMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            new AddElementWindow(DataStore,_locateCursor).ShowDialog();
            CreateCanvas();
        }

        private void BaseCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            _locateCursor = e.GetPosition(BaseCanvas);
        }

        public void CreateCanvas()
        {
            BaseCanvas.Children.Clear();
            if(DataStore.Elements.Count==0) return;
            foreach (Element dataStoreElement in DataStore.Elements)
            {
                switch (dataStoreElement.ElementType)
                {
                    case 1:
                    {
                        Diod d=new Diod(dataStoreElement);
                        BaseCanvas.Children.Add(d);
                        break;
                    }
                    case 2:
                    {
                        Knopka1 d = new Knopka1(dataStoreElement);
                        BaseCanvas.Children.Add(d);
                        break;
                    }
                    case 3:
                    {
                        Knopka2 d = new Knopka2(dataStoreElement);
                        BaseCanvas.Children.Add(d);
                        break;
                    }
                    case 4:
                    {
                            Knopka3 d = new Knopka3(dataStoreElement);
                            BaseCanvas.Children.Add(d);
                        break;
                    }
                }
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DataStore.SaveData();
        }
    }
}
