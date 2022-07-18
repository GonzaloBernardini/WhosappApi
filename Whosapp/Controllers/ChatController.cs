using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Whosapp.Entities;
using Whosapp.UOWork;

namespace Whosapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {


        private readonly IUnitOfWork context;
        public ChatController(IUnitOfWork context)
        {
            this.context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Chat>> Get()
        {
            var aux = context.ChatRepository.GetAll();
            return Ok(aux);
        }


        [HttpPost]
        public async Task<ActionResult> SendMessage(Chat message)
        {
            try
            {
                await context.ChatRepository.AddMessage(message);
                return Ok("Sent");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("{numero}")]
        public ActionResult<ChatMessage> Delete(int numero)
        {
            var aux = context.ChatRepository.GetById(numero);

            if (aux == null)
            {
                return NotFound();
            }

            context.ChatRepository.Delete(numero);
            context.Save();
            return Ok();
        }


    }
}
