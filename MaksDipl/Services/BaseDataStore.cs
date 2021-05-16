using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MaksDipl.Models;

namespace MaksDipl.Services
{
    public class BaseDataStore
    {
        public List<Element> Elements { get; set; }

        public BaseDataStore()
        {
            Elements=new List<Element>();
        }


    }
    
}
