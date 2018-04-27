using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pecanpie.Models
{
    public class Joiner : BaseEntity
    {
        [Key]
        public int JoinerId { get; set; }

        [ForeignKey("User")]
        public int Users_UserId { get; set; }

        [ForeignKey("Game")]
        public int Games_GameId { get; set; }
        
        public User User { get; set; }
        public Game Game { get; set; }
    }
}