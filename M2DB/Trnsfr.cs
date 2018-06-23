using System;
using Starcounter;

namespace M2DB
{
    // 5N1K: Ne, Nezaman, Nerede, Niye, Nasil, Kim 

    // Siparis -> Transfer(Irsaliye) -> Transfer(Fatura)
    /// <summary>
    /// AlisSiparisi:    Nereden(Musteri) -> null
    /// SatisSiparisi: null -> Nereye(Musteri)
    /// 
    /// CikisNakliyeIrsaliye: Depo -> Arac
    /// CikisMusteriIrsaliye: Depo-Musteri, Depo->Arac, Arac->Musteri
    /// AlisMusteriIrsaliye: Nereden(Musteri)->Nereye(Depo)
    /// 
    /// SatisFatura: AlanMusteri
    /// </summary>
    [Database]
    public class TTB    // Transfer, Baslik
    {
        public TTB ObjP { get; set; }        // ParentTransfer null:Siparis, Siparis:Irsaliye, Irsaliye:Fatura. Link Detay'dan
        public KKK ObjOrg { get; set; }        // Kimden/Nereden/Origin (Musteri/Depo/UretimHatti)
        public KKK ObjDst { get; set; }        // Kime/Nereye/Destination
        public UUU ObjVrn { get; set; }        // VerenSorumlu
        public UUU ObjAln { get; set; }        // AlanSorumlu
        public DateTime Trh { get; set; }      // Nazaman

        public XGT ObjSkl { get; set; }     // Siparis/Irsaliye/Fatura
        public XGT ObjTur { get; set; }     // Seklin Turu: Spr:?, Irs:Normal/Iade/Konsinye, Ftr:Alis/AlisIade/Satis/SatisIade
        public XGT ObjDrm { get; set; }     // Durum/Statu (Acik/Kapali)

        public string BlgNo { get; set; }
        public string Ack { get; set; }     // Aciklama/Neden

    }

    [Database]
    public class TTD    // Transfer, Detay
    {
        public TTB ObjTTB { get; set; }        // Baslik
        public NNN ObjNNN { get; set; }        // Ne
        public TTD ObjTTD { get; set; }        // Ref Spr/Irs/Ftr
        public double Mik { get; set; }        // Nekadar
        //public string Brm { get; set; }      // Birim NNN'den gelir
        public double Fyt { get; set; }
        public ulong ObjDvz { get; set; }
        public float Kur { get; set; }
    }


    public class TSB : TTB    // Transfer.Siparis.Baslik
    {
        public DateTime ROH { get; set; }   // RequestOnHand. Alc belirtir
        public DateTime EOH { get; set; }   // ExpectedOnHand. Stc belirtir
        public DateTime ETD { get; set; }   // EstimatedTimeofDelivery. Stc
        //public DateTime ATD { get; set; }   // ActualTimeofDelivery
        public string Bilgi { get; set; }   // Siparisi veren vs
                                            // AlimSiparis:  ORG var DST yok, VRN yok ALN var (Siparis Kimden gelecek)
                                            // SatimSiparis: DST var ORG yok (Siparis Kime gidecek)

        // TransferDetaylari
        // Siparis  KlnSipMik = SipMik - sum(SvkMik)
        // Irsaliye KlnSvkMik = SvkMik - sum(FtrMik)     ->SprsDtyID
        // Fatura   FtrMik                  ->IrsDtyID

        // SiparisSureci
        // GidenSiparis:Alici=Biz, GelenSiparis:Satici=Biz
        // Alici Siparisi girer (ROS) Anlasma fiyatlari otomatik gelir, kullanici degistiremez
        // Alici Siparisi onaylar, birden cok onay gerekebilir, bitince Saticiya eMail gider
        // Satici EOS girerek siparisi kabul eder. Satici fiyatlari degistirebilir
        // Alici EOS'u ve Fiyatlari Onaylar, Saticiya eMail gider
        //   SevkIrsaliye sureci baslar

        // IrsaliyeSureci
        // Satici bekleyen OKlenmis siparislerden Irsaliye hazirlar (partial shipment olabilir)
        // Her irsaliye kalemi bir siparise baglidir. 
        // Aliciya gonderilir. (Saticiya ATD ve ETA gonderilebilir)
        // Alici aldigini POD ile onaylar (POD = ATA)
        //   Ilgili siparisler Update edilir (Satici=Biz ise uretim asamasi baslar)
        //   Fatura sureci baslar

        // FaturaSureci
        // Satici POD almis Irsaliyelerden Fatura hazirlar.
        // Her fatura kalemi bir irsaliyeye baglidir 
        // Satici onaylar (Aliciya eMail gonderilir)
        // Alici Faturayi onaylar (Tutarsizlik varsa onaylamaz)
        //   Ilgili Irsaliyeler Update edilir
        //   Odeme sureci baslar

        // Her Transfer islemi Siparis'den baslar
        // Orada Onaylandigi icin ve digerleri otomatik hazirlandigi icin tutarsizlik olmaz.
        // Irs.Mik <= Spr.Mik (Irsaliye Siparisden otomatik hazirlanir ama partial olabilecegi icin manuel degistirilir)
        // Frt.Mik = Irs.Mik (Fatura Gerceklesmis Irsaliyelerden hazirlandigi icin Ftr.Mik degistirelemez)

    }

    [Database]
    public class TSD // Transfer, Siparis Detay
    {
        public TSB ObjTSB { get; set; }        // Baslik
        public NNN ObjNNN { get; set; }        // Ne
        public double Mik { get; set; }     // Nekadar
        public string Brm { get; set; }     // Birim
        public double Fyt { get; set; }     // Kaca
    }

    public class TIB : TTB    // Transfer Irsaliye Baslik
    {
        // Nakliye Araca toplu Irsaliye kesilir(Depo->Arac), Musterilere ayri(Arac->Musteri)
    }

    [Database]
    public class TID // Transfer, Irsaliye Detay
    {
        public TIB ObjTIB { get; set; }        // Baslik
        public NNN ObjNNN { get; set; }        // Ne
        public TSD ObjTSD { get; set; }        // RefSiparis
        public double Mik { get; set; }     // Nekadar
        public string Brm { get; set; }     // Birim degismez NNN'den almali

    }

    public class TFB : TTB    // Transfer Fatura Baslik
    {
    }

    [Database]
    public class TFD // Transfer, Fatura Detay
    {
        public TFB ObjTFB { get; set; }        // Baslik
        public NNN ObjNNN { get; set; }        // Ne
        public TID ObjTID { get; set; }        // RefIrsaliye
        public double Mik { get; set; }     // Nekadar
        public string Brm { get; set; }     // Birim
        public double Fyt { get; set; }
        public ulong ObjDvz { get; set; }
        public float Kur { get; set; }      
    }

}
