
using MimeKit;
using System;

namespace MailApp
{
    internal class Program 
    {
        static void Main(string[] args)
        {
            Console.Write("sender : ");
            string sender = Console.ReadLine();

            Console.Write("password : ");
            string password = Console.ReadLine();

            Console.Write("receiver : ");
            string receiver = Console.ReadLine();

            string name = "me";
            string subject = "test";
            string message = "Hello my friend!";

            EmailHelper emailHelper = new EmailHelper(sender, name, receiver, subject, message);
            emailHelper.SendMail(password);

        }
    }
}
