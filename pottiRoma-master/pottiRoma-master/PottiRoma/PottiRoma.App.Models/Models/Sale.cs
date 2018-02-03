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
        public Guid UsuarioId { get; set; }
        public Guid ClienteId { get; set; }
        public Guid VendaId { get; set; }

        private string _clientName;
        public string ClientName
        {
            get { return _clientName; }
            set { SetProperty(ref _clientName, value); }
        }

        public DateTime _saleDate;
        public DateTime SaleDate
        {
            get { return _saleDate; }
            set { SetProperty(ref _saleDate, value); }
        }

        private float _saleValue;
        public float SaleValue
        {
            get { return _saleValue; }
            set { SetProperty(ref _saleValue, value); }
        }

        private float _salePaidValue;
        public float SalePaidValue
        {
            get { return _salePaidValue; }
            set { SetProperty(ref _salePaidValue, value); }
        }

        private int _numberSoldPieces;
        public int NumberSoldPieces
        {
            get { return _numberSoldPieces; }
            set { SetProperty(ref _numberSoldPieces, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        #region Helper Values

        private string _cardLabel;
        public string CardLabel
        {
            get { return _cardLabel; }
            set { SetProperty(ref _cardLabel, value); }
        }

        #endregion

        public Sale()
        {
        }
    }
}
