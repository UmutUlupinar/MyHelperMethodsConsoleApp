using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static string StringToSlug(string text)
        {
            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            string str = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            str = str.ToLowerInvariant();
            str = Regex.Replace(str, @"\s+", "-");
            str = Regex.Replace(str, @"[^\w\-\u0061-\u007a\u0100-\u024f\u0300-\u04ff\u1e00-\u1eff]", "");
            str = Regex.Replace(str, "-{2,}", "-");
            str = str.Trim('-');

            return str;
        }
        public static BaseTable LoadJson()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\umutu\\Downloads\\response_1684765708395.json"))
            {
                string json = r.ReadToEnd();
                BaseTable baseTable = JsonConvert.DeserializeObject<BaseTable>(json);
                return baseTable;
            }
        }

        public static List<Item2> LoadJson2()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\umutu\\Downloads\\response_1684765827104.json"))
            {
                string json = r.ReadToEnd();
                List<Item2> json2 = JsonConvert.DeserializeObject<List<Item2>>(json);
                return json2;
            }
        }

        public static List<Item3> LoadJson3()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\umutu\\Downloads\\response_1684771141645.json"))
            {
                string json = r.ReadToEnd();
                List<Item3> json3 = JsonConvert.DeserializeObject<List<Item3>>(json);
                return json3;
            }
        }
        public class Item3
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string MyDataId { get; set; }
            public string BiletAllId { get; set; }
            public string Slug { get; set; }
        }

        public class Item2
        {
            public int id { get; set; }
            public string Adi { get; set; }
            public string FirmLogo { get; set; }
        }
        public class BaseTable
        {
            public List<Item> FirmTable { get; set; }
        }
        public class Item
        {
            public int FirmaNo { get; set; }
            public string Firmaadi { get; set; }
            public string FirmaLogo { get; set; }
            public string BosSubeKodu { get; set; }
            public string BosKullaniciKodu { get; set; }
            public string BiletSeriNoTakip { get; set; }
            public string BiletSeriNo { get; set; }
            public string WebAdresi { get; set; }
            public string Telefon { get; set; }
            public string SatKoltukAdet { get; set; }
            public string RezKoltukAdet { get; set; }
            public string FirmaNoStr { get; set; }
            public string FirmaOtobusteMaxAyniUyeKartliIslemSayisi { get; set; }
            public string FirmaCokluCinsiyetIslemYapabilir { get; set; }
            public string SefereKadarIptalEdilebilmeSuresiDakika { get; set; }
            public int BiletIptalAktifMi { get; set; }
        }

        public static void Main(string[] args)
        {


            var itemList = LoadJson().FirmTable; 
            // foreach (var varItem in itemList)
            // {
            //     Console.WriteLine(varItem.Firmaadi);
            // }

            var json2 = LoadJson2();
            // foreach (var item2 in json2)
            // {
            //     Console.WriteLine(item2.Adi);
            // }

            var json3 = LoadJson3();
            // foreach (var item3 in json3)
            // {
            //     Console.WriteLine(item3.Name);
            // }

            var differentFirmList = new List<Item3>();
            var Item3Converted = new Item3();

            foreach (var item3 in json2)
            {
                if (!json3.Exists(f => f.Name == item3.Adi))
                {
                    Console.WriteLine(item3.Adi);
                    Console.WriteLine(item3.id);
                    
                }
            }

            // foreach (var varItem in itemList)
            // {
            //     if (!json3.Exists(f => f.Name == varItem.Firmaadi))
            //     {
            //         Item3Converted.Name = varItem.Firmaadi;
            //         Item3Converted.Slug = StringToSlug(varItem.Firmaadi);
            //         Item3Converted.BiletAllId = varItem.FirmaNo.ToString();
            //         Item3Converted.Id = Guid.NewGuid().ToString();
            //         differentFirmList.Add(Item3Converted);
            //     }
            // }
            //
            // foreach (var item2 in json2)
            // {
            //     if (!json3.Exists(f => f.Name == item2.Adi))
            //     {
            //         Item3Converted.Name = item2.Adi;
            //         Item3Converted.Slug = StringToSlug(item2.Adi);
            //         Item3Converted.MyDataId = item2.id.ToString();
            //         Item3Converted.Id = Guid.NewGuid().ToString();
            //         differentFirmList.Add(Item3Converted);
            //     }
            // }
            
        }
    }
}