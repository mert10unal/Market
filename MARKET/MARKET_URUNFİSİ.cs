using System;
namespace MARKET
{
	public class MARKET_URUNFİSİ
	{
        public int FisId { get; set; }
        public int Id { get; set; }
        public int UrunId { get; set; }

        public MARKET_URUN Urun { get; set; }
        public MARKET_FİS Fis { get; set; }
    }
}

