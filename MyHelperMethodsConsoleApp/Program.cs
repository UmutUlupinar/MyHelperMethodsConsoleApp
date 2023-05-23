using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MyHelperMethodsConsoleApp.HelperModels;
using Newtonsoft.Json;

namespace MyHelperMethodsConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var itemList = HelperClasses.JsonHelper.LoadJson().FirmTable;
            var json2 = HelperClasses.JsonHelper.LoadJson2();
            var json3 = HelperClasses.JsonHelper.LoadJson3();

            var differentFirmList = new List<JsonHelper.Item3>();
            var Item3Converted = new JsonHelper.Item3();

            foreach (var item2 in json2)
            {
                if (!json3.Exists(f => f.Name == item2.Adi))
                {
                    Console.WriteLine(item2.Adi);
                    Console.WriteLine(item2.id);
                    
                }
            }

            foreach (var varItem in itemList)
            {
                if (!json3.Exists(f => f.Name == varItem.Firmaadi))
                {
                    Item3Converted.Name = varItem.Firmaadi;
                    Item3Converted.Slug = HelperClasses.StringHelper.StringToSlug(varItem.Firmaadi);
                    Item3Converted.BiletAllId = varItem.FirmaNo.ToString();
                    Item3Converted.Id = Guid.NewGuid().ToString();
                    differentFirmList.Add(Item3Converted);
                }
            }
            
            foreach (var item2 in json2)
            {
                if (!json3.Exists(f => f.Name == item2.Adi))
                {
                    Item3Converted.Name = item2.Adi;
                    Item3Converted.Slug = HelperClasses.StringHelper.StringToSlug(item2.Adi);
                    Item3Converted.MyDataId = item2.id.ToString();
                    Item3Converted.Id = Guid.NewGuid().ToString();
                    differentFirmList.Add(Item3Converted);
                }
            }
            
        }
    }
}