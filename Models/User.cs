using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pecanpie.Models
{
    public class User : BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Game> Games { get; set; }
        public List<Joiner> Joiners { get; set; } //Accts is just a variable name

        public User ()
        {
            Games = new List<Game>();
            Joiners = new List<Joiner>(); //Accts here must match the above variable "Accts"
        }
    }
}