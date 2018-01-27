using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class Sale : BindableBase
    {
        private string _buyerName;
        public string BuyerName
        {
            get { return _buyerName; }
            set { SetProperty(ref _buyerName, value); }
        }

        public DateTime _saleDate;
        public DateTime SaleDate
        {
            get { return _saleDate; }
            set { SetProperty(ref _saleDate, value); }
        }

        private string _saleValue;
        public string SaleValue
        {
            get { return _saleValue; }
            set { SetProperty(ref _saleValue, value); }
        }

        private string _cardLabel;
        public string CardLabel
        {
            get { return _cardLabel; }
            set { SetProperty(ref _cardLabel, value); }
        }
    }
}
