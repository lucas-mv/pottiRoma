using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;

namespace PottiRoma.Api.Helpers
{
    public static class EmailObsoleto
    {
        public static void Enviar(String _Assunto, String _Corpo, Dictionary<string, string> _Destinatarios, Dictionary<string, string> _Cc = null, List<Attachment> _anexos = null, String _emailFrom = null, String _nomeFrom = null, string _logoPath = null)
        {
            var msg = new MailMessage();


            if (_logoPath != null)
            {
                Attachment ImageAttachment = new Attachment(_logoPath);
                ImageAttachment.ContentId = "LogoPoweredBy";
                msg.Attachments.Add(ImageAttachment);
            }

            if (string.IsNullOrEmpty(_emailFrom))
            {
                _emailFrom = ConfigurationManager.AppSettings["Email:RemetenteEmail"].ToString();
            }

            if (string.IsNullOrEmpty(_nomeFrom))
            {
                msg.From = new MailAddress(_emailFrom);
            }
            else
            {
                msg.From = new MailAddress(_emailFrom, _nomeFrom);
            }

            if (_Cc != null && _Cc.Any())
            {
                foreach (var cc in _Cc)
                {
                    if (string.IsNullOrEmpty(cc.Value))
                    {
                        msg.CC.Add(cc.Key);
                    }
                    else
                    {
                        msg.CC.Add(new MailAddress(cc.Key, cc.Value));
                    }
                }
            }

            if (_anexos != null && _anexos.Any())
            {
                foreach (Attachment _anexo in _anexos)
                    msg.Attachments.Add(_anexo);
            }

            foreach (var destinatario in _Destinatarios)
            {
                if (string.IsNullOrEmpty(destinatario.Value))
                {
                    msg.To.Add(destinatario.Key);
                }
                else
                {
                    msg.To.Add(new MailAddress(destinatario.Key, destinatario.Value));
                }
            }

            msg.Subject = _Assunto;
            msg.IsBodyHtml = true;
            msg.Body = _Corpo;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("lucasrloliveira@gmail.com", "Qpmjvc@1704");

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            smtpClient.Send(msg);
        }

    }
}