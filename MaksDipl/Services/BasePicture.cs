using System;
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
            MainCanvas.Children.Add(GetControlElement(el));
        }


        public static UserControl GetControlElement(Element el)
        {
            
            switch (el.ElementType)
            {
                case 1:
                {
                    return new Diod(el);
                }
                case 2:
                {
                    return new Knopka1(el); ;
                    }
                case 3:
                {
                    return new Knopka2(el);
                    }
                case 4:
                {
                    return new Knopka3(el);
                    }
                case 5:
                {
                    return new Knopka4(el);
                }
                case 6:
                {
                    return new Connector1(el);
                    }
                case 7:
                {
                    return new Connector2(el);
                }
                case 8:
                {
                    return new Rele1(el);
                }
                case 9:
                {
                    return new Rele2(el);
                }
            }

            return null;
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
