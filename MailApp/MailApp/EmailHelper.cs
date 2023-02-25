using MimeKit;
using MailKit.Net.Smtp;
using System;

namespace MailApp
{
    public class EmailHelper
    {
        public string Sender { get; set; }
        public string Name { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public TextPart Body { get; set; }

        public EmailHelper(string sender, string name, string receiver, string subject, string message)
        {
            this.Sender = sender;
            this.Name = name;
            this.Receiver = receiver;
            this.Subject = subject;
            this.Message = message;
            this.Body = new TextPart("plain")
            {
                Text = message
            };

        }

        public MimeMessage PrepareMessage()
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress mailBoxAddress = new MailboxAddress(Name, Sender);

            message.From.Add(mailBoxAddress);

            MailboxAddress temp = MailboxAddress.Parse(Receiver);
            message.To.Add(temp);

            message.Subject = Subject;

            message.Body = Body;

            return message;
        }

        public void SendMail(string password)
        {
            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate(Sender, password);
                MimeMessage mimeMessage = PrepareMessage();
                smtpClient.Send(mimeMessage);
                Console.WriteLine("email sent!");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}