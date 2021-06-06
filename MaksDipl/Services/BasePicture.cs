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

        /// <summary>
        /// Убрать выделение со всех объектов
        /// </summary>
        public static void ClearAllSelected()
        {
            foreach (UIElement child in MainCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                (child as IControlInterface)?.UnSelected();
            }
        }

        /// <summary>
        /// Удалить элемент с канваса
        /// </summary>
        /// <param name="element"></param>
        public static void RemoveElement(UserControl element)
        {
            BaseDataStore.RemoveElement((element as IControlInterface)?.Element);
            MainCanvas.Children.Remove(element);
        }

        /// <summary>
        /// Нарисовать элемент на канвасе
        /// </summary>
        /// <param name="el"></param>
        private static void PictureElement(Element el)
        {
            if (el == null) return;
            switch (el.ElementType)
            {
                case 1:
                {
                    Diod d = new Diod(el);
                    d.Rotate(el.Rotate);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 2:
                {
                    Knopka1 d = new Knopka1(el);
                    d.Rotate(el.Rotate);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 3:
                {
                    Knopka2 d = new Knopka2(el);
                    d.Rotate(el.Rotate);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 4:
                {
                    Knopka3 d = new Knopka3(el);
                    d.Rotate(el.Rotate);
                    MainCanvas.Children.Add(d);
                    break;
                }
                case 5:
                {
                    Connector1 d = new Connector1(el);
                    d.Rotate(el.Rotate);
                    MainCanvas.Children.Add(d);
                    break;
                }
            }
        }

        /// <summary>
        /// Отрисовка всех объектов на канвасе при загрузке программы
        /// </summary>
        public static void CreateCanvas()
        {
            MainCanvas.Children.Clear();
            if (BaseDataStore.Elements.Count == 0) return;
            foreach (Element dataStoreElement in BaseDataStore.Elements)
            {
                PictureElement(dataStoreElement);
            }

        }

        /// <summary>
        /// Поиск элемента на канвасе по имени или содержанию
        /// </summary>
        /// <param name="elName"></param>
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

        /// <summary>
        /// Отобразить все элементы
        /// </summary>
        public static void ShowAllElements()
        {
            foreach (UIElement child in MainCanvas.Children)
            {
                if (!(child is UserControl)) continue;
                (child as IControlInterface)?.Selected();
            }
        }

        /// <summary>
        /// Создать новый элемент
        /// </summary>
        /// <param name="locateCursor"></param>
        public static void AddElement(Point locateCursor)
        {
            Element el = new AddElementWindow().NewElement(locateCursor);
            PictureElement(el);
        }
    }
}
