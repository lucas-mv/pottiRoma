using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Entities
{
    public class UserEntity
    {
        public Guid UsuarioId { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PrimaryTelephone { get; set; }
        public string SecundaryTelephone { get; set; }
        public UserType UserType { get; set; }
        public string PasswordSalt { get; set; }
        public string Password { get; set; }
        public string Cep { get; set; }
        public int AverageTicketPoints { get; set; }
        public int RegisterClientsPoints { get; set; }
        public int SalesNumberPoints { get; set; }
        public int AverageItensPerSalePoints { get; set; }
        public int InviteAllyFlowersPoints { get; set; }
        public Guid TemporadaId { get; set; }
        public Guid MotherFlowerId { get; set; }
        public DateTime Birthday { get; set; }
    }
}
