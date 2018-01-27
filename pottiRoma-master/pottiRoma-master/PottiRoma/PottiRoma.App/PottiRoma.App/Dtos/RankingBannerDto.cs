using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Dtos
{
    public class RankingBannerDto : BindableBase
    {
        private string _image;
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public RankingBannerDto()
        {
        }
    }
}
