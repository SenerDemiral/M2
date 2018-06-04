using System;
using Starcounter;

namespace M2DB
{
    /// <summary>
    /// Programa girebilmek icin UUU kaydinin olmasi gerekir
    /// </summary>

    [Database]
    public class UUU    // User
    {
        public string Ad { get; set; }
        public UYT ObjUYT { get; set; }    // User Yetkisi (tek bir yetkisi olabilir)
        public string Pwd { get; set; }
        public DateTime PwdLCD { get; set; }    // Pwd LastChangeDate

    }

    [Database]
    public class UYT    // User.YetkiTanimlari
    {
        public string Ad { get; set; }
    }

    [Database]
    public class UYH    // User.YetkiHiyerarsi M2M
    {
        public UYT ObjPrnUYT { get; set; }  // Parent
        public UYT ObjKidUYT { get; set; }  // Child
    }

}
