using System;
namespace MARKET
{
	public class MARKET_FATURA
	{
        public int Id { get; set; }
        public double FaturaNo { get; set; }
        public int TedarikciId { get; set; }

        public MARKET_TEDARİKÇİ Tedarikci { get; set; }
    }
}

