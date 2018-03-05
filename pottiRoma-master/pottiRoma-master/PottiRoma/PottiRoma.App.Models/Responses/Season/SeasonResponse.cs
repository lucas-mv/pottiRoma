using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Responses.Season
{
    public class SeasonResponse
    {
        public Models.Season Entity { get; set; }

        public SeasonResponse()
        {
            Entity = new Models.Season();
        }
    }
}
