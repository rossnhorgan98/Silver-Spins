using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace IS4439_Assignment.Models
{
    public class DB
    {
        public DB()
        {
        }

        public List<Album> albums { get; set; }
        public List<Order> orders { get; set; }

        public string Save()
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(DB));
                FileStream s = new FileStream("/App_Data/db.xml", FileMode.Create);
                ser.Serialize(s, this);
                s.Flush();
                s.Dispose();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Ok";
        }
        public static DB Retrieve()
        {
            DB db;
            XmlSerializer ser = new XmlSerializer(typeof(DB));
            FileStream s = new FileStream("/App_Data/db.xml", FileMode.Open);
            db = (DB)ser.Deserialize(s);
            s.Dispose();
            return db;

        }
        public static string AddAlbum(Album album)
        {
            DB db = Retrieve();
            db.albums.Add(album);
            string message = db.Save();
            if (message == "Ok")
                message = string.Format("Thanksfor subscribing {0}!", album.Title);
            return message;
        }

        public Album GetAlbum(string title)
        {
            Album album = null;
            foreach (Album a in this.albums)
            {
                if (a.Title == title)
                {
                    album = a;
                }
            }
            return album;

        }

        public static string RemoveAlbum(string title)
        {
            DB db = Retrieve();
            Album a = db.GetAlbum(title);
            if (a == null)
            {
                return "Error";
            }
            db.albums.Remove(a);
            string message = db.Save();
            if (message == "Ok")
                message = string.Format("Thanks for removing {0}!", a.Title);
            return message;
        }

        public List<Album> GetAlbumsOfGenre(string genre)
        {
            List<Album> albumsList = new List<Album>();
            DB db = Retrieve();
            foreach (Album a in db.albums)
            {
                if (a.Genre.ToString() == genre)
                {
                    albumsList.Add(a);
                }
            }
            return albumsList;

        }
        public List<Album> GetAlbumsOfExplicit(bool flag)
        {
            List<Album> albumsList = new List<Album>();
            DB db = Retrieve();
            foreach (Album a in db.albums)
            {
                if (a.ExplicitContent == flag)
                {
                    albumsList.Add(a);
                }
            }
            return albumsList;

        }

        public static string AddOrder(Order order)
        {
            DB db = Retrieve();
            db.orders.Add(order);
            string message = db.Save();
            if (message == "Ok")
                message = string.Format("Thanks for ordering");
            return message;
        }

        public Order GetOrder(int id)
        {
            Order order = null;
            foreach (Order o in this.orders)
            {
                if (o.OrderID == id)
                {
                    order = o;
                }
            }
            return order;

        }

        public static string RemoveOrder(int id)
        {
            DB db = Retrieve();
            Order o = db.GetOrder(id);
            if (o == null)
            {
                return "Error";
            }
            db.orders.Remove(o);
            string message = db.Save();
            if (message == "Ok")
                message = string.Format("Thanks for removing {0}!", o.OrderID);
            return message;
        }
    }
}
