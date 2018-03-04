using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities.Internal
{
    public class SalespersonEntity
    {
        public Guid UsuarioId { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PrimaryTelephone { get; set; }
        public string SecundaryTelephone { get; set; }
        public string Cep { get; set; }
        public int AverageTicketPoints { get; set; }
        public int RegisterClientsPoints { get; set; }
        public int SalesNumberPoints { get; set; }
        public int AverageItensPerSalePoints { get; set; }
        public int InviteAllyFlowersPoints { get; set; }
        public string MotherFlowerName { get; set; }
        public string Season { get; set; }
        public DateTime Birthday { get; set; }

        public static SalespersonEntity FromUser(UserEntity user, string motherFlowerName, string season)
        {
            return new SalespersonEntity()
            {
                AverageItensPerSalePoints = user.AverageItensPerSalePoints,
                AverageTicketPoints = user.AverageTicketPoints,
                Cep = user.Cep,
                Cpf = user.Cpf,
                Email = user.Email,
                InviteAllyFlowersPoints = user.InviteAllyFlowersPoints,
                MotherFlowerName = motherFlowerName,
                Name = user.Name,
                PrimaryTelephone = user.PrimaryTelephone,
                SecundaryTelephone = user.SecundaryTelephone,
                RegisterClientsPoints = user.RegisterClientsPoints,
                SalesNumberPoints = user.SalesNumberPoints,
                UsuarioId = user.UsuarioId,
                Season = season
            };
        }
    }    
}
