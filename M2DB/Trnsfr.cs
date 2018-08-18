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
    public class TTM : BB   // Transfer, Base Master
    {
        // BB den Kd,Ad,Info,Tbl
        public TTM REF { get; set; }        // ParentTransfer null:Siparis, Siparis:Irsaliye, Irsaliye:Fatura. Link Detay'dan ??????
        public KKK ORG { get; set; }        // Kimden/Nereden/Origin (Musteri/Depo/UretimHatti)
        public KKK DST { get; set; }        // Kime/Nereye/Destination
        // Her Transferin Vrn ve Aln'i olmaz ilgili table koy
        public KKK VRN { get; set; }        // Veren Personel/FirmaContact
        public KKK ALN { get; set; }        // Alan Personel/FirmaContact

        public DateTime VrnOnyTrh { get; set; }   // Veren Onayladiginda
        public DateTime AlnOnyTrh { get; set; }   // Alan  Onayladiginda

        public string Skl { get; set; }     // DisSiparis/IcSiparis/DisIrsaliye/IcIrsaliye/Fatura
        public int Drm { get; set; }        // Durum/Statu (Acik/Kapali)
    }

    [Database]
    public class TTD : BB   // Base Detay
    {
        // BB den Kd,Ad,Info
        public TTM TTM { get; set; }        // Master
        public NNT NNT { get; set; }        // Ne
        public TTD REF { get; set; }        // Ref @Spr:null, @Irs->Spr, @Ftr->Irs
        public double Mik { get; set; }
        public double Fyt { get; set; }
        public XGT DVT { get; set; }
        public float Kur { get; set; }
        //public string Brm { get; set; }      // Birim NNT'den gelir
    }


    [Database]
    public class TOM : BB    // Order/Siparis Master
    {
        public string Drm { get; set; }     // Acik/Kapali/Pending/Bitti
        public DateTime Trh { get; set; }
        public XGT KND { get; set; }        // Kind/Tür
        public KKK ORG { get; set; }        // Kimden/Nereden/Origin (Musteri/Depo/UretimHatti)
        public KKK DST { get; set; }        // Kime/Nereye/Destination
        public DateTime ROH { get; set; }   // RequestOnHand. Alc belirtir
        public DateTime EOH { get; set; }   // ExpectedOnHand. Stc belirtir
        public DateTime ETD { get; set; }   // EstimatedTimeofDeparture. Stc
        public DateTime ETA { get; set; }   // EstimatedTimeofArrival. Stc
                                            // AlimSiparis:  ORG var DST yok, VRN yok ALN var (Siparis Kimden gelecek)
                                            // SatimSiparis: DST var ORG yok (Siparis Kime gidecek)

        // TransferDetaylari
        // Siparis  KlnSipMik = SipMik - sum(SvkMik)
        // Irsaliye KlnSvkMik = SvkMik - sum(FtrMik)     ->SprsDtyID
        // Fatura   FtrMik                  ->IrsDtyID

        // SiparisSureci
        // Client IcveDis Siparisleri bir Form da gorur, yeni giris Ic ve Dis olarak iki ayri Form da yapilir.
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
    public class TOD : BB      // Order/Siparis Detay
    {
        public TOM TOM { get; set; }        // Master
        public NNT NNT { get; set; }        // Ne
        public double Mik { get; set; }     // Gercek
        public double Fyt { get; set; }
        public XGT DVT { get; set; }

        // Alici/SiparisiVeren
        public DateTime ROH { get; set; }   // RequestOnHand
        public double rMik { get; set; }    // Requested
        public double rFyt { get; set; }
        public XGT rDVT { get; set; }
        public bool rIpt { get; set; }

        // Satici/SiparisiAlan (TTD'den)
        public bool Ipt { get; set; }

        public DateTime EOH { get; set; }   // ExpectedOnHand

        // Bu Malin gelenleri SUM(TWD.Mik)

        public static double IrsMik(TOD tod)
        {
            double irsMik = 0;
            foreach(var r in Db.SQL<TWD>("SELECT r FROM TWD r WHERE r.TOD = ?", tod))
            {
                irsMik += r.Mik;
            }
            return irsMik;
        }
    }

    /// <summary>
    /// Waybill/Irsaliye (Firma<->Sirket) ile Forward/Gonderme (Depo<->Depo) ayir
    /// Irsaliyenin bir tarafi Firma digeri Sirket(null) olur
    /// Mal sirkete(null) gelir, AnaDepoya alinir, sonra digerlerine dagitilir.
    /// ??? Ic Siparisler toplanir, birlestirilerek alinacagi Firmaya siparis hazirlanir
    /// </summary>
    [Database]
    public class TWM : BB      // Waybill/Irsaliye Master (Firma <-> Sirket)
    {
        public string Drm { get; set; }     // Acik/Kapali/Pending/Bitti
        public DateTime Trh { get; set; }
        public XGT KND { get; set; }        // Kind/Tür
        // Nakliye Araca toplu Irsaliye kesilir(Depo->Arac), Musterilere ayri(Arac->Musteri)
        // Dis
        // ORG/DST Firma, digeri Sirket(null) 
        public KKK ORG { get; set; }        // Kimden/Nereden/Origin (Musteri/Depo/UretimHatti)
        public KKK DST { get; set; }        // Kime/Nereye/Destination
        public DateTime ATD { get; set; }   // ActualTimeofDeparture
        public DateTime ATA { get; set; }   // ActualTimeofArrival
    }

    [Database]
    public class TWD : BB      // Waybill/Irsaliye Detay
    {
        public TWM TWM { get; set; }        // Master
        public TOD TOD { get; set; }        // Irs->Spr
        public NNT NNT { get; set; }        // Ne
        public double Mik { get; set; }     // Gercek Gelen Mik
        public double Fyt { get; set; }
        public XGT DVT { get; set; }

        public double HsrMik { get; set; }  // <= TOD.Mik
        public double FzlMik { get; set; }  // <= TOD.Mik

        // POD: Teslimati Yapan & Alan kisi ve Tarihi
        // Dis Sevk (Fatura olacak)
        // Geldiyse: Teslimati Yapan: Sofor, Alan: KPT Personel
        // Gittiyse: Teslimati Yapan: Sofor, Alan: KCT FirmaContact
        // Ic Sevk (Fatura yok)
        // Geldiyse: Teslimati Yapan: Personel, Alan: KPT Personel
        // Gittiyse: Teslimati Yapan: Personel, Alan: KCT FirmaContact

        public static double FtrMik(TWD twd)
        {
            double ftrMik = 0;
            foreach (var r in Db.SQL<TBD>("SELECT r FROM TBD r WHERE r.TBD = ?", twd))
            {
                ftrMik += r.Mik;
            }
            return ftrMik;
        }

    }

    [Database]
    public class TBM : BB      // Bill/Fatura Master (Firma <-> Sirket)
    {
        public KFT KFT { get; set; }        // Firma
        public bool IsFrmBA { get; set; }   // Firma Borclu mu? degilse alacakli
        public string Tur { get; set; }     // Fatura Turu: Alis/Satis vs
        public DateTime BlgTrh { get; set; }
        public string BlgNo { get; set; }
    }

    [Database]
    public class TBD : BB      // Bill/Fatura Detay
    {
        public AHP AHP { get; set; }
        public TBM TBM { get; set; }        // Master
        public NNT NNT { get; set; }        // Ne
        public TWD TWD { get; set; }        // Ftr->Irs
        public double Mik { get; set; }     // Gercek Fatura Mik
        public double Fyt { get; set; }
        public XGT DVT { get; set; }
        public float Kur { get; set; }
    }

}
