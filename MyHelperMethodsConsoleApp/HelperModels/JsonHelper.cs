using System.Collections.Generic;

namespace MyHelperMethodsConsoleApp.HelperModels
{
    public class JsonHelper
    {
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
    }
}