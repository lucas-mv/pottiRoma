using PottiRoma.App.Utils.Enums;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Dtos
{
    public class RulesContentDto : BindableBase
    {
        public RulesTitleContentEnum ContentRulesId { get; set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _definition;
        public string Definition
        {
            get { return _definition; }
            set { SetProperty(ref _definition, value); }
        }
    }
}
