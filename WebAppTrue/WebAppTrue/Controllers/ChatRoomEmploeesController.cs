using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppTrue.Model;
using WebAppTrue.Models;
using static WebAppTrue.Controllers.ChatRoomsController;

namespace WebAppTrue.Controllers
{
    public class ChatRoomEmploeesController : ApiController
    {
        private chatAPIEntities db = new chatAPIEntities();


        public class SimpleER
        {
            public SimpleER(int id, int? idChatRoom, int? idEmplyee)
            {
                this.id = id;
                this.idChatRoom = idChatRoom;
                this.idEmplyee = idEmplyee;
            }

            public int id { get; set; }
            public Nullable<int> idChatRoom { get; set; }
            public Nullable<int> idEmplyee { get; set; }
        }

        [HttpPost]
        [Route("api/AREC/{idUser}")]
        public async Task<IHttpActionResult> AREC([FromBody] SimpleChatroom simmmer, [FromUri] int idUser)

        {
            ChatRoom chr = new ChatRoom();
            chr.id = simmmer.id;
            chr.Topic = simmmer.Topic;
            db.ChatRoom.Add(chr);

            try
            {
                SimpleER simple = new SimpleER(1, simmmer.id, idUser);
                ChatRoomEmploee chatRoomEmploee = new ChatRoomEmploee(simple);
                db.ChatRoomEmploee.Add(chatRoomEmploee);
                return Ok(await db.SaveChangesAsync());

            }
            catch 
            {
                 return BadRequest();
            }
        }


        // GET: api/ChatRoomEmploees
        public IHttpActionResult GetChatroomEmploee()
        {
            var reuslt = db.ChatRoomEmploee.ToList();
            var result1 = reuslt.ConvertAll(i => new ResponceChatRoomEmployee(i));
            return Ok(result1);
        }

        // GET: api/ChatRoomEmploees/5
        [ResponseType(typeof(ChatRoomEmploee))]
        public IHttpActionResult GetChatRoomEmploee(int id)
        {
            ChatRoomEmploee chatRoomEmploee = db.ChatRoomEmploee.Find(id);
            if (chatRoomEmploee == null)
            {
                return NotFound();
            }

            return Ok(new ResponceChatRoomEmployee(chatRoomEmploee));
        }

        // PUT: api/ChatRoomEmploees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChatRoomEmploee(int id, ChatRoomEmploee chatRoomEmploee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chatRoomEmploee.id)
            {
                return BadRequest();
            }

            db.Entry(chatRoomEmploee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChatRoomEmploeeExists(id))
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

        // POST: api/ChatRoomEmploees
        [ResponseType(typeof(ChatRoomEmploee))]
        public IHttpActionResult PostChatRoomEmploee(ChatRoomEmploee chatRoomEmploee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChatRoomEmploee.Add(chatRoomEmploee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chatRoomEmploee.id }, chatRoomEmploee);
        }

        // DELETE: api/ChatRoomEmploees/5
        [ResponseType(typeof(ChatRoomEmploee))]
        public IHttpActionResult DeleteChatRoomEmploee(int id)
        {
            ChatRoomEmploee chatRoomEmploee = db.ChatRoomEmploee.Find(id);
            if (chatRoomEmploee == null)
            {
                return NotFound();
            }

            db.ChatRoomEmploee.Remove(chatRoomEmploee);
            db.SaveChanges();

            return Ok(chatRoomEmploee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChatRoomEmploeeExists(int id)
        {
            return db.ChatRoomEmploee.Count(e => e.id == id) > 0;
        }
    }
}