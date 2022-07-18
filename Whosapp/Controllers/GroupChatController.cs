using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Whosapp.Entities;
using Whosapp.UOWork;

namespace Whosapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupChatController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public GroupChatController(IUnitOfWork context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Group Chat
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<GroupChat>> Get()
        {
            var aux = _context.GroupChatRepository.GetAll();
            return Ok(aux);
        }

        /// <summary>
        /// Delete Group Chat for name
        /// </summary>
        /// <param name="nombre">Name of group chat</param>
        /// <returns></returns>
        [HttpDelete("{nombre}")]
        public ActionResult<GroupChat> Delete(string nombre)
        {
            var aux = _context.GroupChatRepository.GetByName(nombre);

            if (aux == null)
            {
                return NotFound();
            }

            _context.GroupChatRepository.KickFromGroup(nombre);
            _context.Save();
            return Ok();
        }

    }
}
