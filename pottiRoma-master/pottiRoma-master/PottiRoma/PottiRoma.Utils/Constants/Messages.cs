using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Utils.Constants
{
    public class Messages
    {
        public const string USER_INVALID = "Email ou senha incorretos.";
        public const string INVALID_PASSWORD = "Senha inválida";
        public const string USER_REGISTRATION_ERROR = "Ocorreu um erro ao registrar o usuário, tente novamente mais tarde.";
        public const string OBRIGATORY_DATA_MISSING = "Dados obrigatórios não presentes.";
        public const string EMAIL_ALREADY_USED = "Email já registrado no sistema, por favor utilize outro endereço.";
        public const string INVALID_AUTHORIZATION = "Você não possui permissão para acessar este conteúdo.";
        public const string EXPIRED_AUTHORIZATION = "Sua sessão expirou e precisa ser revalidada.";
        public const string NO_SEASONS_REGISTERED = "Não há temporadas registradas";
        public const string NO_POINTS_REGISTERED = "Não há pontuação registrada";
    }
}
