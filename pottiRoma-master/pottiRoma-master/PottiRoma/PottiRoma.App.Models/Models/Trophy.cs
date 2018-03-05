using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class Trophy : BindableBase
    {
        private Guid _userId;
        public Guid userId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
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

        #region Helper Properties

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        #endregion
    }
}
