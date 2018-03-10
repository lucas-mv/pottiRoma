using PottiRoma.Utils.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace PottiRoma.Api.Helpers
{
    public static class EmailBirthday
    {
        public static async void Enviar(string emailInvited, string userName)
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

            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            objEmail.IsBodyHtml = false;

            objEmail.Subject = EmailTexts.EMAIL_BIRTHDAY_SUBJECT;

            objEmail.Body = GetFormattedMessage(userName);


            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");

            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;

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
                objEmail.Dispose();
            }
        }

        public static string GetFormattedMessage(string userName)
        {
            string message = EmailTexts.BIRTHDAY_TEXT;

            message = message.Replace("@userName", userName);

            return message;
        }
    }
}