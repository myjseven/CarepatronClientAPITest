using System.Net.Mail;
using CarepatronClientAPITest.Interfaces;
using CarepatronClientAPITest.Models;

namespace CarepatronClientAPITest.Classes
{
    public class SendEmail : ISendEmail
    {
        void ISendEmail.SendEmail(Client client)
        {
            // not implemented for brevity
            Console.WriteLine("Sending Email...");

        }
    }
}
