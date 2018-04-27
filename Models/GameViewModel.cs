using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace pecanpie.Models
{
    public class GameViewModel : BaseEntity
    {
        [Required( ErrorMessage = "Title is required.")]
        //[RegularExpression(@"^[a-zA-Z]+$")]
        [MinLength(2)]
        [Display(Name = "Title: ")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Time: ")]
        [DataType( DataType.Time)]
        [FutureDate(ErrorMessage = "Time must be in the Future.")]
        public DateTime Time { get; set; }

        [Required]
        [Display(Name = "Date: ")]
        [DataType( DataType.Date)]
        [FutureDate(ErrorMessage = "Date must be in the Future.")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Duration: ")]
        
        public int Duration { get; set; }

        
        public string TimeSpan { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Please be a little more Descriptive, at least 10 characters.")]
        [Display(Name = "Description: ")]
        public string Description { get; set; }
        

        public class FutureDateAttribute : ValidationAttribute
        {
            public FutureDateAttribute() {}

            public override bool IsValid(object value)
            {
                var submittedDate = ( DateTime )value;
                if( submittedDate > DateTime.Today )
                {
                    return true;
                }
                return false;
            }
        }
    }
}