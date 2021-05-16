﻿using System;
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

    public static class BaseDataStore
    {
        public const string DATA_PATH = "data\\db.xml";
        public static List<Element> Elements { get; set; }

        public static Dictionary<int, string> ElementTypes { get; set; }

        private static void CreateDictionary()
        {
            ElementTypes = new Dictionary<int, string>();
            ElementTypes.Add(1,"Диод");
            ElementTypes.Add(2, "Кнопка1");
            ElementTypes.Add(3, "Кнопка2");
            ElementTypes.Add(4, "Кнопка3");

        }

        public static void AddElement(Element el)
        {
            Elements.Add(el);
            SaveData();
        }

        public static void RemoveElement(Element el)
        {
            Elements.Remove(Elements.First(c => c.Id == el.Id));
            SaveData();
        }

        public static void SaveData()
        {

            XmlSerializer formatter = new XmlSerializer(typeof(List<Element>));

            using (FileStream fs = new FileStream(DATA_PATH, FileMode.Create))
            {
                formatter.Serialize(fs, Elements);
            }
        }

        public static void LoadData()
        {
            CreateDictionary();
            Elements = new List<Element>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Element>));

            using (FileStream fs = new FileStream(DATA_PATH, FileMode.OpenOrCreate))
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
