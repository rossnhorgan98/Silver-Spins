using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IS4439_Assignment.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IS4439_Assignment.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        //Albums API calls

        // GET: api/albums/all
        [Route("albums/all")]
        [HttpGet]
        public IEnumerable<Album> GetAll()
        {
            DB db = DB.Retrieve();
            return db.albums;
        }

        // GET api/albums/{title}
        [Route("albums/{title}")]
        [HttpGet]
        public IActionResult GetAlbum(string title)
        {
            DB db = DB.Retrieve();
            Album a = db.GetAlbum(title);
            if (a == null)
                return NotFound();
            return new ObjectResult(a);
        }

        // POST api/albums
        [Route("albums")]
        [HttpPost]
        public IActionResult PostAlbum([FromBody] Album album)
        {
            if (album == null)
            {
                return BadRequest();
            }
            string message = DB.AddAlbum(album);
            if (message == "Error")
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetAlbum), new { name = album.Title }, album);
        }

        // PUT api/albums
        [Route("albums")]
        [HttpPut]
        public IActionResult PutAlbum([FromBody] Album album)
        {
            string message = DB.RemoveAlbum(album.Title);
            if (album == null)
            {
                return BadRequest();
            }
            DB.AddAlbum(album);
            return CreatedAtAction(nameof(GetAlbum), new { name = album.Title }, album);
        }

        // DELETE api/albums/{title}
        [HttpDelete("albums/{title}")]
        public IActionResult DeleteAlbum(string title)
        {
            string message = DB.RemoveAlbum(title);
            if (message == "Error")
            {
                return NotFound();
            }
            return new NoContentResult();
        }

        // GET: api/genre/{genre}
        [Route("genre/{genre}")]
        [HttpGet]
        public IActionResult GetAlbumsOfGenre(string genre)
        {
            DB db = DB.Retrieve();
            List<Album> albums_of_genre = db.GetAlbumsOfGenre(genre.ToString());
            if (albums_of_genre.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(albums_of_genre);
        }

        // GET: api/explicit/{flag}
        [Route("explicit/{flag}")]
        [HttpGet]
        public IActionResult GetAlbumsOfExplicit(bool flag)
        {
            DB db = DB.Retrieve();
            List<Album> albums_of_explicit = db.GetAlbumsOfExplicit(flag);
            if (albums_of_explicit.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(albums_of_explicit);
        }


        //Orders API calls

        // GET: api/orders/all
        [Route("orders/all")]
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            DB db = DB.Retrieve();
            return db.orders;
        }

        // GET api/orders/{id}
        [Route("orders/{id}")]
        [HttpGet]
        public IActionResult GetOrder(int id)
        {
            DB db = DB.Retrieve();
            Order o = db.GetOrder(id);
            if (o == null)
                return NotFound();
            return new ObjectResult(o);
        }

        // POST api/orders
        [Route("orders")]
        [HttpPost]
        public IActionResult PostOrder([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            string message = DB.AddOrder(order);
            if (message == "Error")
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetAlbum), new { name = order.OrderID }, order);
        }

        // PUT api/orders
        [Route("orders")]
        [HttpPut]
        public IActionResult PutOrder([FromBody] Order order)
        {
            string message = DB.RemoveOrder(order.OrderID);
            if (order == null)
            {
                return BadRequest();
            }
            DB.AddOrder(order);
            return CreatedAtAction(nameof(GetAlbum), new { name = order.OrderID }, order);
        }

        // DELETE api/orders/{id}
        [HttpDelete("orders/{id}")]
        public IActionResult DeleteOrder(int id)
        {
            string message = DB.RemoveOrder(id);
            if (message == "Error")
            {
                return NotFound();
            }
            return new NoContentResult();
        }
    }
}
