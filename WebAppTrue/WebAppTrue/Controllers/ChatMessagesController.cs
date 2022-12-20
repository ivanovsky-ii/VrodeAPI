using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppTrue.Model;
using WebAppTrue.Models;

namespace WebAppTrue.Controllers
{
    public class ChatMessagesController : ApiController
    {
        private chatAPIEntities db = new chatAPIEntities();

        public class SimpleChatMessage
        {
            public SimpleChatMessage(int id, int? idEmplyee, int? idChatRoom, string textMessage, DateTime date)
            {
                this.id = id;
                this.idEmplyee = idEmplyee;
                this.idChatRoom = idChatRoom;
                this.textMessage = textMessage;
                this.dateTime = date;
            }

            public int id { get; set; }
            public Nullable<int> idEmplyee { get; set; }
            public Nullable<int> idChatRoom { get; set; }
            public string textMessage { get; set; }
            public Nullable<System.DateTime> dateTime { get; set; }

        }

        [HttpPost]
        [Route("api/WTMFmessage")]
        [ResponseType(typeof(ChatMessage))]
        public async Task<IHttpActionResult> WTMFmessage([FromBody] SimpleChatMessage simmesuuuuuuuuuuuuuuuuuuuuuu)
        {
            ChatMessage chat = new ChatMessage(simmesuuuuuuuuuuuuuuuuuuuuuu);
            db.ChatMessage.Add(chat);
            return Ok(await db.SaveChangesAsync());
        }

        // GET: api/ChatMessages
        public IHttpActionResult GetChatMessage()
        {
            return Ok(db.ChatMessage.ToList().ConvertAll(i => new ResponceChatMessage(i)));
        }

        // GET: api/ChatMessages/5
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult GetChatMessage(int id)
        {
            ChatMessage chatMessage = db.ChatMessage.Find(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            return Ok(chatMessage);
        }

        // PUT: api/ChatMessages/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatMessage(int id, ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatMessage.id)
            {
                return BadRequest();
            }

            db.Entry(chatMessage).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatMessageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ChatMessages
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult PostChatMessage(ChatMessage chatMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatMessage.Add(chatMessage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatMessage.id }, chatMessage);
        }

        // DELETE: api/ChatMessages/5
        [ResponseType(typeof(ChatMessage))]
        public IHttpActionResult DeleteChatMessage(int id)
        {
            ChatMessage chatMessage = db.ChatMessage.Find(id);
            if (chatMessage == null)
            {
                return NotFound();
            }

            db.ChatMessage.Remove(chatMessage);
            db.SaveChanges();

            return Ok(chatMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatMessageExists(int id)
        {
            return db.ChatMessage.Count(e => e.id == id) > 0;
        }
    }
}