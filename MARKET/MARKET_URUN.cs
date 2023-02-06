using System;
namespace MARKET
{
    public class MARKET_URUN
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Barkod { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public int Miktar { get; set; }

        public List<MARKET_URUNTEDARİKCİ> UrunTedarikcileri { get; set; }
        public List<MARKET_URUNFİSİ> UrunFisleri { get; set; }



    }
   
}

