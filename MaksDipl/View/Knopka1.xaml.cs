using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace MaksDipl.View
{
    /// <summary>
    /// Логика взаимодействия для knopka1.xaml
    /// </summary>
    public partial class Knopka1 : UserControl,IControlInterface
    {
        private Point p2;
        public Knopka1(Element el)
        {
            InitializeComponent();
            Element = el;
            NameTextBlock.Text = Element.Mark;
            this.Margin = new Thickness(el.Location.X, el.Location.Y, 0, 0);
            this.ToolTip = new BaseToolTip(Element);
        }

        public void Selected()
        {
            this.Visibility = Visibility.Visible;
            //((SolidColorBrush)this.Resources["BaseColor"]).Color = Colors.Red;
            IsSelected = true;
        }

        public void UnSelected()
        {
            this.Visibility = Visibility.Hidden;
           // ((SolidColorBrush)this.Resources["BaseColor"]).Color = Colors.Black;
            IsSelected = false;
        }

        public void Move(Point p)
        {
            this.Margin = new Thickness(p.X, p.Y, 0, 0);
            Element.Location = p;
        }

        public bool IsSelected { get; set; }

        public string Mark
        {
            get => NameTextBlock.Text;
            set => NameTextBlock.Text = value;
        }

        public Element Element { get; set; }

        private void Base_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Selected();
            p2 = e.GetPosition(this);
        }

        private void Base_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed || !IsSelected) return;
            Point p1 = e.GetPosition(this.Parent as Canvas);
            Point p = new Point(p1.X - p2.X, p1.Y - p2.Y);
            this.Move(p);
        }

        private void DeleteElement_OnClick(object sender, RoutedEventArgs e)
        {
            BasePicture.RemoveElement(this);
        }
    }
}
