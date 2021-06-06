﻿using System;
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

namespace MaksDipl.View
{
    /// <summary>
    /// Логика взаимодействия для knopka3.xaml
    /// </summary>
    public partial class Knopka3 : UserControl,IControlInterface
    {
        public Knopka3(Element el)
        {
            InitializeComponent();
            Element = el;
            NameTextBlock.Text = Element.Mark;
            this.Margin = new Thickness(Element.Location.X, Element.Location.Y, 0, 0);
            this.ToolTip = new BaseToolTip(Element);
        }

        private void Base_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Selected();
            p2 = e.GetPosition(this);
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
            //((SolidColorBrush)this.Resources["BaseColor"]).Color = Colors.Black;
            IsSelected = false;
        }

        public void Move(Point p)
        {
            this.Margin = new Thickness(p.X, p.Y, 0, 0);
            Element.Location = p;
        }

        public void Rotate(double angle)
        {
            try
            {
                ((TransformGroup)PictureGrid.RenderTransform).Children[2] = new RotateTransform(angle);
                Element.Rotate = angle;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool IsSelected { get; set; }

        public string Mark
        {
            get => NameTextBlock.Text;
            set => NameTextBlock.Text = value;
        }

        public Element Element { get; set; }

        private Point p2;
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
