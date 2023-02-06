using System;
namespace MARKET
{
	public class MARKET_URUNTEDARİKCİ
	{
        public int TedarikciId { get; set; }
        public int Id { get; set; }
        public int UrunId { get; set; }

        public MARKET_URUN Urun { get; set; }
        public MARKET_TEDARİKÇİ Tedarikci { get; set; }
    }
}

