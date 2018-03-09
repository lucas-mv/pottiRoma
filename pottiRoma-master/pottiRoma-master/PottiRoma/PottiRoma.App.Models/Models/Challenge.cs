using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class Challenge : BindableBase
    {
        private Guid _desafioId;
        public Guid DesafioId
        {
            get { return _desafioId; }
            set { SetProperty(ref _desafioId, value); }
        }

        private Guid _temporadaId;
        public Guid TemporadaId
        {
            get { return _temporadaId; }
            set { SetProperty(ref _temporadaId, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set { SetProperty(ref _endDate, value); }
        }

        private int _parameter;
        public int Parameter
        {
            get { return _parameter; }
            set { SetProperty(ref _parameter, value); }
        }

        private int _goal;
        public int Goal
        {
            get { return _goal; }
            set { SetProperty(ref _goal, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private int _prize;
        public int Prize
        {
            get { return _prize; }
            set { SetProperty(ref _prize, value); }
        }

        #region Helper Properties

        private string _startDateFormatted;
        public string StartDateFormatted
        {
            get { return _startDateFormatted; }
            set { SetProperty(ref _startDateFormatted, value); }
        }

        private string _endDateFormatted;
        public string EndDateFormatted
        {
            get { return _endDateFormatted; }
            set { SetProperty(ref _endDateFormatted, value); }
        }

        private string _prizeFormatted;
        public string PrizeFormatted
        {
            get { return _prizeFormatted; }
            set { SetProperty(ref _prizeFormatted, value); }
        }

        private string _parameterFormatted;
        public string ParameterFormatted
        {
            get { return _parameterFormatted; }
            set { SetProperty(ref _parameterFormatted, value); }
        }

        #endregion
    }
}
