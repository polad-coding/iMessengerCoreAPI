using iMessengerCoreAPI.Models;
using System.Collections.Generic;

namespace iMessengerCoreAPI.Interfaces
{
    public interface IOperationsService
    {
        string GetTheDialogIdOfTheClients(string[] clientsIds, List<RGDialogsClients> dialogsClientsList);
    }
}
