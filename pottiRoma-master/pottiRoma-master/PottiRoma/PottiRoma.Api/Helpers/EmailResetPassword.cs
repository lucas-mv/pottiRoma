using PottiRoma.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;

namespace PottiRoma.Api.Helpers
{
    public static class EmailResetPassword
    {
        public static void Enviar(string emailUsuario, string userName, string userPassword)
        {
            var msg = new MailMessage();

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
            objEmail.To.Add(emailUsuario);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = false;

            //Define título do e-mail.
            objEmail.Subject = EmailTexts.RESET_PASSWORD_SUBJECT;

            //Define o corpo do e-mail.
            objEmail.Body = GetFormattedMessage(userPassword, userName);

            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

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

        public static string GetFormattedMessage(string userPassword, string userName)
        {
            string message = EmailTexts.RESET_PASSWORD;

            message = message.Replace("@userPassword", userPassword);
            message = message.Replace("@userName", userName);
            return message;
        }
    }
}