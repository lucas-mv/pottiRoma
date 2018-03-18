using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Utils.Constants
{
    public static class EmailTexts
    {
        public static string EMAIL_INVITE = @"Hey, @nameInvited!
    Você é a nossa Flor Aliada e Queremos muito te ver fazendo ainda mais parte desse time. 
    Criamos um aplicativo com desafios e premiações que vão otimizar suas vendas e te auxiliar a criar estratégias para sua jornada na Potti Romã.
Confira abaixo se suas informações estão corretas e dentro de 2 dias faça login com seu e-mail e CPF no aplicativo. 

Nos vemos lá! Vamos caminhar juntas!

CPF : @cpf 
Telefone : @telephone 
CEP : @cep 


Com Amor,
Potti Roma";

        public static string EMAIL_SUBJECT = @"Convite Potti Roma";

        public static string RESET_PASSWORD = @"
Olá @userName !
A sua senha do App Potti Roma foi redefinida com sucesso para a senha temporária indicada abaixo:
@userPassword


Com Amor, Potti Roma";

        public static string EMAIL_BIRTHDAY_SUBJECT = @"Feliz novo ano! Feliz vida!";

        public static string RESET_PASSWORD_SUBJECT = @"Alteração de Senha";

        public static string BIRTHDAY_TEXT = @"Aos ciclos que se iniciam, às energias que se renovam, às surpresas que estão por vir...
Que no seu ano novo particular tenha abraços apertados, sentimentos leves e sorrisos no rosto. 
Feliz vida!
Com amor,
Sua Flor de Potti Romã, @userName!!";
    }
}
