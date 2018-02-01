using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class ClientEntity
    {
        public Guid ClienteId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Name { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
