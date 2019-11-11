using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1_Web_Design.Models 
{
    public class EmergingTechFB
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
        [Required]
        public string Heading { get; set; }
        [Range(0,5)]
        public int StarRating { get; set; }
        [Required]
        public string FeedBack { get; set; }
        public int Agree { get; set; }
        public int Disagree { get; set; }
        public string EmergingTechnologyName { get; set; }
        //id, date, username, heading, star rating, feedback, agree, disagree, and emerging technology name.


        public bool isAgreeAdded { get; set; }
        public bool isDisagreeAdded { get; set; }
    }
}
