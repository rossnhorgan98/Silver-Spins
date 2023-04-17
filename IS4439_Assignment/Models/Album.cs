using System;
using System.ComponentModel.DataAnnotations;

namespace IS4439_Assignment.Models
{
    public class Album
    {
        public Album()
        {
        }

        [Required]
        public string Title { get; set; }

        public string Artist { get; set; }

        //[Range(1900,2100)]
        public int Year { get; set; }

        public string CoverImage { get; set; }

        public Genre Genre { get; set; }

        public string SongList { get; set; }

        public bool ExplicitContent { get; set; }

        public int Length { get; set; }

        public decimal CDPrice { get; set; }

        public decimal VinylPrice { get; set; }
    }

    public enum Genre
    {
        Rock,
        Electronic,
        Alternative,
        Rap,
        Soundtrack,
        Metal,
        Funk
    }

    }
    

