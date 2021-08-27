using iMessengerCoreAPI.Interfaces;
using iMessengerCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace iMessengerCoreAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationsService _operationsService;
        private RGDialogsClients RGDialogsClients = new RGDialogsClients();
        private List<RGDialogsClients> RGDialogsClientsList;

        public OperationsController(IOperationsService operationsService)
        {
            RGDialogsClientsList = RGDialogsClients.Init();
            _operationsService = operationsService;
        }

        /// <summary>
        /// Returns the dialog ID of the given clients.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /GetTheDialogIdOfTheClients
        ///     [
        ///         "userId1",
        ///         "userId2",
        ///         "userId3",
        ///         ...
        ///     ]
        ///
        /// </remarks>
        /// <param name="clientsIds"></param>
        /// <returns></returns>
        /// <response code="200">Returns the dialog id of the given cliens.</response>
        /// <response code="400">If the dialog of the clients was not found, return empty Guid.</response>
        [HttpPost]
        [Route("GetTheDialogIdOfTheClients")]
        public ActionResult<string> GetTheDialogIdOfTheClients([FromBody]string[] clientsIds)
        {
            var responseGuid = _operationsService.GetTheDialogIdOfTheClients(clientsIds, RGDialogsClientsList);

            if (responseGuid == null)
            {
                return BadRequest(new Guid());
            }

            return Ok(responseGuid);
        }

    }
}