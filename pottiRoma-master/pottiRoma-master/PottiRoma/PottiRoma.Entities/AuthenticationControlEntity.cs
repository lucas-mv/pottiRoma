using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class AuthenticationControlEntity
    {
        public Guid UserId { get; set; }
        public Guid Token { get; set; }
        public DateTime RegisterDate { get; set; }
        public AuthOrigin AuthOrigin { get; set; }
        public bool KeepAlive { get; set; }
    }
}
