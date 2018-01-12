using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Requests.User
{
    public class SendEmailRequest
    {
        public Dictionary<string, string> Destinatarios { get; set; }
        public Dictionary<string, string> Cc { get; set; }
        public string CorpoEmail { get; set; }
        public string Assunto { get; set; }
        public Guid UserId { get; set; }
    }
}
