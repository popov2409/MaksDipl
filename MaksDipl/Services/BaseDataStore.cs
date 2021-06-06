using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using MaksDipl.Models;
using MaksDipl.View;

namespace MaksDipl.Services
{
    /// <summary>
    /// Класс работы с данными
    /// </summary>
    public static class BaseDataStore
    {
        /// <summary>
        /// Путь к файлу с данными
        /// </summary>
        public const string DATA_FOLDER_PATH = "data\\";
        /// <summary>
        /// Список всех элементов
        /// </summary>
        public static List<Element> Elements { get; set; }
        /// <summary>
        /// Список всех типов элементов
        /// </summary>
        public static Dictionary<int, string> ElementTypes { get; set; }

        /// <summary>
        /// Создание списка типов элементов
        /// </summary>
        private static void CreateDictionary()
        {

            int i = 0;
            ElementTypes = new Dictionary<int, string>();
            StreamReader sr = new StreamReader(DATA_FOLDER_PATH + "elements.txt");
            while (!sr.EndOfStream)
            {
                i++;
                ElementTypes.Add(i, sr.ReadLine());
            }
        }
        /// <summary>
        /// Добавить элемент в базу
        /// </summary>
        /// <param name="el"></param>
        public static void AddElement(Element el)
        {
            Elements.Add(el);
            SaveData();
        }
        /// <summary>
        /// Удалить элемент из базы
        /// </summary>
        /// <param name="el"></param>
        public static void RemoveElement(Element el)
        {
            Elements.Remove(Elements.First(c => c.Id == el.Id));
            SaveData();
        }
        /// <summary>
        /// Сохранить все данные в файл
        /// </summary>
        public static void SaveData()
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Element>));

            using (FileStream fs = new FileStream(DATA_FOLDER_PATH+"db.xml", FileMode.Create))
            {
                formatter.Serialize(fs, Elements);
            }
        }
        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        public static void LoadData()
        {
            CreateDictionary();
            Elements = new List<Element>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Element>));

            using (FileStream fs = new FileStream(DATA_FOLDER_PATH+"db.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    Elements=(List<Element>)formatter.Deserialize(fs);
                }
                catch (Exception e)
                {
                    //ignore
                    MessageBox.Show(e.Message);
                }

                
            }

        }

    }
    
}
