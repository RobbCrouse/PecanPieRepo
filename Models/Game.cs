using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pecanpie.Models
{
    public class Game : BaseEntity
    {
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
        
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string TimeSpan { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }


        public List<Joiner> Joiners { get; set; } //Accts is just a variable name

        public Game ()
        {
            Joiners = new List<Joiner>(); //Accts here must match the above variable "Accts"
        }

    }
}