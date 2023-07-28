using CarepatronClientAPITest.Interfaces;
using CarepatronClientAPITest.Models;

namespace CarepatronClientAPITest.Classes
{
    public class SyncDocument : ISyncDocuments
    {
        void ISyncDocuments.SyncDocument(Client client)
        {
            // not implemented for brevity
            Console.WriteLine("Syncing document...");

        }
    }
}
