using iMessengerCoreAPI.Interfaces;
using iMessengerCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iMessengerCoreAPI.Services
{
    public class OperationsService : IOperationsService
    {
        public string GetTheDialogIdOfTheClients(string[] clientsIds, List<RGDialogsClients> dialogsClientsList)
        {
            var entriesGroupedByDialogId = dialogsClientsList.GroupBy(cl => cl.IDRGDialog);
            var currentGroupContainsAllClients = true;

            foreach (var group in entriesGroupedByDialogId)
            {
                if (group.Count() != clientsIds.Count())
                {
                    continue;
                }

                foreach (var user in group)
                {
                    if (!clientsIds.Contains(user.IDClient.ToString()))
                    {
                        currentGroupContainsAllClients = false;
                        break;
                    }
                }

                if (currentGroupContainsAllClients)
                {
                    return group.First().IDRGDialog.ToString();
                }

                currentGroupContainsAllClients = true;
            }

            return null;
        }
    }
}
