using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Utils.Constants
{
    public static class EmailTexts
    {
        public static string EMAIL_INVITE = @"Olá @nameInvited!
    Nossa querida flor @nameUser está te convidando para fazer parte do nosso time de revendedoras, caso você queira iniciar essa jornada conosco, confira abaixo se suas informações estão corretas e responda esse email com suas considerações, com isso, uma de nossas atendentes entrará em contato com você para explicar os próximos passos! 

CPF : @cpf 
Telefone : @telephone 
CEP : @cep 


Com Amor,
Potti Roma";

        public static string EMAIL_SUBJECT = @"Convite Potti Roma";
    }
}
