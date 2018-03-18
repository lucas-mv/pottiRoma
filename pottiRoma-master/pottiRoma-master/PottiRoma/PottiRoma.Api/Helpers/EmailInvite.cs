using PottiRoma.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PottiRoma.Api.Helpers
{
    public static class EmailInvite
    {
        public static async void Enviar(string emailInvited, string nameInvited, string nameUser, string cpf, string telephone, string cep)
        {
            //Define os dados do e-mail
            string nomeRemetente = "Administrativo Potti Roma";
            string emailRemetente = "cila@pottiroma.com.br";
            string senha = "poderosas1";

            //Host da porta SMTP
            string SMTP = "smtp.pottiroma.com.br";

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailInvited);

            objEmail.CC.Add(emailRemetente);

            //Enviar cópia oculta para.
            //objEmail.Bcc.Add(emailComCopiaOculta);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = false;

            //Define título do e-mail.
            objEmail.Subject = EmailTexts.EMAIL_SUBJECT;

            //Define o corpo do e-mail.
            objEmail.Body = GetFormattedMessage(nameInvited, nameUser, cpf, telephone, cep);


            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Caso queira enviar um arquivo anexo
            //Caminho do arquivo a ser enviado como anexo
            //string arquivo = Server.MapPath("arquivo.jpg");

            // Ou especifique o caminho manualmente
            //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

            // Cria o anexo para o e-mail
            //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

            // Anexa o arquivo a mensagem
            //objEmail.Attachments.Add(anexo);

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
            //Caso utilize conta de email do exchange da locaweb deve habilitar o SSL
            //objEmail.EnableSsl = true;

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }
        }

        public static string GetFormattedMessage(string nameInvited, string nameUser, string cpf, string telephone, string cep)
        {
            string message = EmailTexts.EMAIL_INVITE;

            message = message.Replace("@nameInvited", nameInvited);
            message = message.Replace("@nameUser", nameUser);
            message = message.Replace("@cpf", cpf);
            message = message.Replace("@telephone", telephone);
            message = message.Replace("@cep", cep);

            return message;
        }
    }
}