using System;
namespace MARKET
{
	public class MARKET_FİS
	{
        public int Id { get; set; }
        public string Urun { get; set; }
        public double FisNo { get; set; }
        public string Brand { get; set; }
        public double Unit { get; set; }
        public double UnitPrice { get; set; }

        public List<MARKET_URUNFİSİ> UrunFisleri { get; set; }
    }
}

