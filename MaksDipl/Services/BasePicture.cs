﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MaksDipl.Models;
using MaksDipl.View;

namespace MaksDipl.Services
{
    /// <summary>
    /// Класс отрисовки обектов
    /// </summary>
    public static class BasePicture
    {
        public static Canvas MainCanvas = new Canvas() {Background = Brushes.Transparent};

        public static void ClearAllSelected()
        {
            foreach (UIElement child in MainCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                (child as IControlInterface)?.UnSelected();
            }
        }

        public static void RemoveElement(UserControl element)
        {
            BaseDataStore.RemoveElement((element as IControlInterface)?.Element);
            MainCanvas.Children.Remove(element);
            //CreateCanvas();

        }

        public static void CreateCanvas()
        {
            MainCanvas.Children.Clear();
            if (BaseDataStore.Elements.Count == 0) return;
            foreach (Element dataStoreElement in BaseDataStore.Elements)
            {
                switch (dataStoreElement.ElementType)
                {
                    case 1:
                    {
                        Diod d = new Diod(dataStoreElement);
                        MainCanvas.Children.Add(d);
                        break;
                    }
                    case 2:
                    {
                        Knopka1 d = new Knopka1(dataStoreElement);
                        MainCanvas.Children.Add(d);
                        break;
                    }
                    case 3:
                    {
                        Knopka2 d = new Knopka2(dataStoreElement);
                        MainCanvas.Children.Add(d);
                        break;
                    }
                    case 4:
                    {
                        Knopka3 d = new Knopka3(dataStoreElement);
                        MainCanvas.Children.Add(d);
                        break;
                    }
                }
            }

        }

        public static void SearchElement(string elName)
        {
            ClearAllSelected();
            if (elName.Length < 1) return;
            foreach (UIElement child in MainCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                if (child is IControlInterface el && (el.Element.Mark.ToLower().Contains(elName.ToLower())||el.Element.Purpose.ToLower().Contains(elName.ToLower()))) el.Selected();
            }
        }

        public static void ShowAllElements()
        {
            foreach (UIElement child in MainCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                (child as IControlInterface)?.Selected();
            }
        }

        public static void AddElement(Point locateCursor)
        {
            Element el = new AddElementWindow().NewElement(locateCursor);
            switch (el.ElementType)
            {
                case 1:
                {
                    Diod d = new Diod(el);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 2:
                {
                    Knopka1 d = new Knopka1(el);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 3:
                {
                    Knopka2 d = new Knopka2(el);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 4:
                {
                    Knopka3 d = new Knopka3(el);
                    MainCanvas.Children.Add(d);
                    break;
                }
            }
        }
    }
}