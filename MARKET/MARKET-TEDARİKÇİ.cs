using System;
namespace MARKET
{
    public class MARKET_TEDARİKÇİ
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public double VergiNo { get; set; }
        public double Telefon { get; set; }
        public int TedarikciId { get; set; }


        public List<MARKET_FATURA> MarketFaturaları { get; set; }
        public List<MARKET_URUNTEDARİKCİ> MarketTedarikcileri { get; set; }
    }
}

