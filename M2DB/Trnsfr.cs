using System;
using Starcounter;

namespace M2DB
{
    // Siparis -> Irsaliye -> Fatura
    // Irsaliye Siparisi, Fatura Irsaliyeyi bilir

    // SiparisSureci TOH, TOSP
    // Siparis'in Master kaydi yoktur. Her mal icin ayri hazirlanir ve takip edilir.
    // Client IcVeDis Siparisleri bir Form da gorur, yeni giris Ic ve Dis olarak iki ayri Form da yapilir.
    // GidenSiparis:Alici=Biz, GelenSiparis:Satici=Biz
    // Alici Siparisi girer (ROS) Anlasma fiyatlari otomatik gelir, kullanici degistiremez
    // Alici Siparisi onaylar, birden cok onay gerekebilir, bitince Saticiya eMail gider
    // Satici EOS girerek siparisi kabul eder. Satici fiyatlari degistirebilir
    // Alici EOS'u ve Fiyatlari Onaylar, Saticiya eMail gider
    //   SevkIrsaliye sureci baslar

    // SevkSureci TWM, TWD
    // Satici hazir oldugunda OKlenmis siparislerden Irsaliye hazirlar (partial shipment olabilir)
    // Satici ETD, ETA, yola ciktiginda ATD belirtir.
    // Alici geldiginde ATA ve POD(KimTeslimAldi) girer.
    // Her irsaliye kalemi bir siparise baglidir. POD aldiginda ilgili Siparisin KlnMik update edilir. 
    //   Fatura sureci baslar (Eger DisSiparis ise)

    // SevkKabul
    // Irsaliyede yazilanin aynisi degil ise.
    // Eksik:   GelenMik girilir (Hic gelmemis ise 0). Uyusmazlik: Alici bilgilendirilir.
    // Fazla:   Alici istese bile alamaz, cunki siparis disina cikilmistir, Cozum?????? Oneri: GlnMik=IrsaliyeMik POD alir, FzlMik=FazlaKismi IadeDeposuna gonderilir
    // Hasarli: Hasarli olanlar, Cozum?????? Oneri: GlnMik=HasarsizMik POD alir, HsrMik=HasarliKadari IadeDeposuna gonderilir
    // Yanlis:  Istenmeyen/Yanlis bir mal gelmistir, Cozum?????? Oneri: GlnMik=0 POD almaz, FzlMik=GelenKadari IadeDeposuna gonderilir
    // Uyusmazligin cozulmesi gerek. ????????????
    // Irsaliyede farkli alanalar GlnMik, HsrMik, FzlMik, 

    // FaturaSureci
    // Satici POD almis DisIrsaliyeden Fatura hazirlar.
    // Her fatura bir irsaliyeye baglidir (Master seviyesinde, detay da degil)
    // Satici onaylar (Aliciya eMail gonderilir)
    // Alici Faturayi onaylar (Tutarsizlik varsa onaylamaz)
    //   Ilgili Irsaliyeler Update edilir
    //   Odeme sureci baslar

    // Her Transfer islemi Siparis'den baslar
    // Orada Onaylandigi icin ve digerleri otomatik hazirlandigi icin tutarsizlik olmaz.
    // Irs.Mik <= Spr.Mik (Irsaliye Siparisden otomatik hazirlanir ama partial olabilecegi icin manuel degistirilir)
    // Frt.Mik = Irs.Mik (Fatura Gerceklesmis Irsaliyelerden hazirlandigi icin Ftr.Mik degistirelemez)


    [Database] // IPTAL
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

    }

    [Database]
    public class TOH : BB
    {
        public TOH P   { get; set; }    // Parent, Null for Request
        public TOH REF { get; set; }    // Bagli oldugu Siparis 
        public BB  ORG { get; set; }    // Aici
        public BB  DST { get; set; }    // Satici
        public NNT NNT { get; set; }    // Ne

        public double   Mik { get; set; }
        public double   Fyt { get; set; }
        public XGT      DVT { get; set; }
        public DateTime EOS { get; set; }    // EstimatedOnSite

        // Alc Request yapar (Req kaydi P=null)
        // Req Yetkili tarafindan onaylanir Kbl/Red
        // Kbl ise bu kayit duplicate edilerek Response kaydi (Child P=Req) acilir.
        // Stc yetkilisi Red/Kbl/Mdf ederek onaylar
        // Mdf etmis ise Alc bu degisikligi de onaylar Kbl/Red
        //   Alc kismi sevkiyati kabul etmis ise Alc Response kaydini duplicate ederek degisiklik yapabilir 

        // Kabul edilen Response kayitlari sevki beklenen gercek siparislerdir.
        // Siparis Baz siparisden de yaratilabilir. (Satis siparisinden Alis/Transfer siparisi verilmesi gibi)
        // Req1:REF=null, P=null A firmasi n1 den m1 kadar ister
        //   Req2:REF=Req1, P=null Sirket bu istegi D1'e iletir
        //     ...
        // Gelen bilgilere gore EOS ve diger bilgiler Req1'in Response kaydi ile onaylanir Aliciya bildirilir.
        // Malzeme  akisinda gosterildigi gibi hersey Satis siparisi (Alici istegiyle) ile baslar. Alici ister uretilir/tedarik edilir ve Aliciya satilir.

    }

    /// <summary>
    /// ALICI->
    ///   TOQ ile istek hazirlanir
    ///   Request/Istek/Alici yetkilisi Kabul/Red edip imzalar.
    ///   Red:
    ///     Siparis Red olarak baslamadan bitmistir -X
    ///   Kabul:
    ///     Bagli TOP kaydi acilir.
    ///     Satici bilgilendirilir.
    ///     
    ///     SATICI->
    ///       Respond/Yanit/Satici yetkilisi Kabul/Red edip imzalar.
    ///       Red:
    ///         Siparis Red olarak bitmistir -X
    ///         Alici bilgilendirilir.
    ///       Kabul:
    ///         Istenenin tamamini karsiliyamiyorsa
    ///           KismiSevk'e izin verilmis ise
    ///             Respons kaydini duplicate ederek parcalayablir.
    ///           Else
    ///             Verebilecegi kadarini girer (tam/eksik)
    ///         Alici bilgilendirilir.
    ///     
    ///         ALICI->
    ///           Satici Aynen kabul etmisse:
    ///             Siparis Kabul olarak bitmistir ->
    ///           Degisiklik yapmissa:
    ///             Alici yetkilisi Kabul/Red edip imzalar.
    ///             Red:
    ///               Siparis Red olarak bitmistir -X
    ///             Kabul:
    ///               Siparis Kabul olarak bitmistir ->
    ///             Satici bilgilendirilir
    ///             
    /// </summary>
    [Database]
    public class TOO : BB   // Transfer Orders
    {
        public TOO P   { get; set; }    // Parent (Baska siparisden uretildiyse)
        public BB  ORG { get; set; }    // SiparisiVeren/Alici/Request
        public BB  DST { get; set; }    // SiparisiAlan/Satici/Respond
        public NNT NNT { get; set; }    // Ne

        public DateTime DrmTrh { get; set; }   // Durumun degistigi tarih (Diger tarihler Onaylarda XOT)
        public string   Drm    { get; set; }   // Pending, Red, Kabul
        public string   Src    { get; set; }   // Surec
        // 1.Siparis hazirlanir, onaylanir (Kabul/Red)
        // 2.Alici siparisi onayladiysa, Satici onaylar (Kabul/Degisiklik/Red)
        // 3.Satici degisiklik yaptiysa Alici degisikligi onaylar (Kabul/Red)

        // 1.AlcHazirliyor, Drm:Pnd
        // 1.AlcReqOnyBekleniyor,
        // 1.AlcReqRed. Drm:Red
        // 2.AlcReqKbl + StcRspBekleniyor, 
        // 2.StcRspRed. Drm:Red
        // 2.StcRspKbl + MalBekleniyor. Drm:Kbl
        // 3.StcRspMdf + AlcMdfOnyBekleniyor, (Satici Mik,Fyt ve EOS degistirebilir, Client da degisenleri goster)
        // 3.AlcMdfRed. Drm:Red
        // 3.AlcMdfKbl + MalBekleniyor. Drm:Kbl

        public bool IsPrtSvk { get; set; }  // Partial Sevkiyat yapilabilir

        // BuyerRequest (Alicinin istegi)
        public double   MikReq { get; set; }
        public double   FytReq { get; set; }
        public XGT      DVTReq { get; set; }
        public DateTime ROS    { get; set; }   // RequestOnSite

        // SellerResponse (Gerceklesen) (Saticinin yaniti)
        public double   Mik { get; set; }
        public double   Fyt { get; set; }
        public XGT      DVT { get; set; }
        public DateTime EOS { get; set; }    // EstimatedOnSite

        public double KlnMik  { get; set; }  // Mik - TopSevkMik(Gelmis)
        public string TrnPlan { get; set; }  // TransferPlanindan: Mik@Trh, Mik@Trh, ...

    }

    // Satici siparisi bolmus ise nezaman nekadar gonderecegini belirtir.
    [Database]
    public class TTP : BB   // Transfer Plani (Kismi sevk ise, ilk sevk Mik TOO da)
    {
        public TOO      TOO { get; set; }   // Siparis
        public double   Mik { get; set; }   // TOO.Mik = sum(Mik)
        public DateTime EOS { get; set; }   // EstimatedOnSite
    }

    [Database]
    public class TTM : BB   // TransferMaster
    {
        public BB  ORG { get; set; }    // Gonderen
        public BB  DST { get; set; }    // Alan

        public DateTime Trh { get; set; }   // Execution
        public DateTime ETD { get; set; }
        public DateTime ATD { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ATA { get; set; }

        public string Drm { get; set; }     // Pending, Bitti, Confilict???
        // Detayindakilerin hepsi POD aldiginda Bitti.
        // Bu sevkde Istenenden farkli bir mal olursa ne yapilacak???? Iade edilmesi gerek, Detayda kaydi yok.
    }

    [Database]
    public class TTD : BB   // TransferDetay
    {
        public TTM TTM { get; set; }   // Master
        public TOO TOO { get; set; }   // Siparisi
        public NNT NNT { get; set; }   // Ne

        public string Drm { get; set; }     // Pending, Red, Kabul
        public double Mik { get; set; }     // Gelen <= TOO.Mik
        public double Fyt { get; set; }
        public XGT DVT { get; set; }

        public double MikHsr { get; set; }  // Hasarli
        public double MikFzl { get; set; }  // Fazla

        // POD: Onay Kbl/Red
        // Confilict: 
        // Fazla
        // Eksik 
        // Eksik Hasarli
        // Belirtilenden farkli mal gelmis, yani irsaliyede zaten yok, burada gozukmeyecek. Yani boyle bir secenek yok.

        // POD almis ise TOO.KlnMik update edilebilir.
    }




    [Database]
    public class TOQ : BB      // Siparis reQuest
    {
        public BB ORG { get; set; }        // Isteyen/SiparisiVeren/Alici
        public BB DST { get; set; }        // Yanitlayan/SiparisiAlan/Satici
        public NNT NNT { get; set; }       // Ne

        public bool IsPrtSvk { get; set; }  // Partila Sevkiyat yapilabilir
        
        // Request (Alicinin istegi)
        public double MikReq { get; set; } 
        public double FytReq { get; set; } 
        public XGT DVTReq { get; set; }
        public DateTime ROS { get; set; }   // RequestOnSite

        // Gerceklesen (Saticinin yaniti)
        public double Mik { get; set; }
        public double Fyt { get; set; }
        public XGT DVT { get; set; }
        public DateTime EOS { get; set; }   // EstimatedOnSite

        public double KlnMik { get; set; }  // Mik - TopIrsMik(Gelmis)
        public string SvkPlan { get; set; } // SevkPlanindan: Mik@Trh, Mik@Trh, ...

        // Alici Siparisin verilmesini onaylar(Red/Kabul)
        public BB AlcOnyYtk { get; set; }
        public BB AlcOnyUsr { get; set; }
        public DateTime AlcOnyTrh { get; set; }

        // Satici Siparisi aldigini onaylar(Red/Kabul/Mdf)
        public BB StcOnyYtk { get; set; }
        public BB StcOnyUsr { get; set; }
        public DateTime StcOnyTrh { get; set; }

        // Alici, Satici degisiklik yapmis ise onaylar(Red/Kabul)
        public BB AlcMdfOnyYtk { get; set; }
        public BB AlcMdfOnyUsr { get; set; }
        public DateTime AlcMdfOnyTrh { get; set; }

        public string Drm { get; set; }
        // AlcHazirliyor, 
        // AlcReqOnyBekleniyor,
        // AlcReqRed.
        // AlcReqKbl + StcRspBekleniyor, 
        // StcRspRed. 
        // StcRspKbl + MalBekleniyor.
        // StcRspMdf + AlcMdfOnyBekleniyor, (Satici Mik,Fyt ve EOS degistirebilir, Client da degisenleri goster)
        // AlcMdfRed. 
        // AlcMdfKbl + MalBekleniyor.
    }

    /// <summary>
    /// Order Sevk Plani
    /// Eger Partial Sevkiyata izin verilmis ise
    /// Satici malin nekadarini nezaman gonderecek.
    /// TOP.sum(Mik) == TOQ.Mik olmali 
    /// </summary>
    [Database]
    public class TOSP : BB   // OrderSevkPlani
    {
        public TOQ TOQ { get; set; }        // Request
        public double Mik { get; set; }
        public DateTime EOS { get; set; }   // EstimatedOnSite
    }

    [Database]
    public class TOP : BB      // Siparis Yanit
    {
        public TOQ TOQ { get; set; }        // Request
        // Satici Pending, Red, Degisiklik, AynenKabul
        // Alici 
        public string Drm { get; set; }     // Satici Pending/Kabul/Red, Alici Pending/Kabul/Red

        public double Mik { get; set; }     // Nekadar
        public double Fyt { get; set; }     // Kaca
        public XGT DVT { get; set; }

        public DateTime EOS { get; set; }     // TahminiTedarikZamani
        public BB RspYtk { get; set; }
        public BB RspOny { get; set; }
        public DateTime RspTrh { get; set; }
        public string RspSnc { get; set; }   // Bos/Kabul/Red

        public BB ReqOny { get; set; }
        public DateTime ReqTrh { get; set; }
        public string ReqSnc { get; set; }   // Bos/Kabul/Red
    }

    /// <summary>
    /// 1 Alici Siparisi(Request) Hazirlar (Alici ve satici mutabik oluncaya kadar devam eder)
    /// 2 OnyDpt personeli tarafindan onaylanir (veya OnyDptlerdeki biri tarafindan iptal edilebilir)
    /// 3 Alici iptal ettiyse islem durur, Aliciya mail gonderilir. (Eger 8'den gelmis ise Saticiya bilgilendirme maili gonderilir)
    /// 4 Onaylar tamamlaninca Saticiya mail gider
    /// 5 Satici yapabileceklerini girer veya iptal eder
    /// 6 Satici onayladiginda Aliciya Mail gider
    /// 7 Satici iptal etmis ise Siparis iptal edilmistir, bu kayit uzerinde baska bir islem yapilamaz.
    /// 8 Satici iptal disinda herhangi bir deger degistirmis ise Alici onaylari sifirlanir 2'den devam eder. 
    /// 9 Alici onay(lar)i ve Satici onayi tamam ise siparis islemi bitmistir. Herhangi birinde Iptal varsa Iptal olarak, degilse basariyla bitmistir.
    /// </summary>
    [Database]
    public class TxD : BB      // Siparis Calisma
    {
        public BB ORG { get; set; }        // Isteyen/SiparisiVeren/Alici
        public BB DST { get; set; }        // Yanitlayan/SiparisiAlan/Satici

        public string Drm { get; set; }         // ??? Pending/Hazirlaniyor, Acik/Kapali/Pending/Bitti
        public DateTime DrmTrh { get; set; }    // Durumun gerceklestigi tarih, son haline nezaman gecti (History gerekir)

        // OrgRequest/Istenen
        public NNT ReqNNT { get; set; }       // Ne
        public double ReqMik { get; set; }    // Gercek
        public double ReqFyt { get; set; }
        public XGT ReqDVT { get; set; }
        public DateTime ROH { get; set; }   // RequestOnHand
        public bool IsReqIpt { get; set; }  // Org/Alici Iptal etti mi? Kim Yapabilir ??????

        // UstDept Onaylayabilir mi?
        // Onay vermesi gereken deptler belirlenir (Max 3adet), Dept personeli tarafindan onay velirlir

        public bool IsReqOnyOrdered { get; set; }   // Onay sirayla mi verilir? (Birden cok onay gerekiyorsa)
        public KDT ReqOnyDpt1 { get; set; }         // Onaylayacak Departman (Yetkili)  (Doluysa Update edilemez)
        public KPT ReqOnyPrs1 { get; set; }         // Onaylayan Dept Personeli (ReqKDT doluysa) (Doluysa Update edilemez)
        public DateTime ReqOnyTrh1 { get; set; }    // Onaylandigi Tarih
        public KDT ReqKDT2 { get; set; }
        public KPT ReqKPT2 { get; set; }
        public KDT ReqKDT3 { get; set; }
        public KPT ReqKPT3 { get; set; }


        // Istenen MinMiktar, Mik > MinMik : Partial, Mik saglanincaya kadar her gonderimde MinMik gonderilmeli
        // Bu sefer nekadar araliklarla gonderilmesi gerektigi sorusu olur. Is karisir
        //public bool IsPrt { get; set; }     // Kismi gonderilebilir mi?
        //public double MinMik { get; set; }  

        // DstResponse/Sunulan
        // Saticidaki Hangi Contactlar bu isleme onay vermeye yetkili?
        public NNT NNT { get; set; }        // Ne
        public double Mik { get; set; }     // Gercek
        public double Fyt { get; set; }
        public XGT DVT { get; set; }
        public DateTime EOH { get; set; }   // ExpectedOnHand
        public bool IsRspIpt { get; set; }  // DstResponse/Satici Iptal etti mi?

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
