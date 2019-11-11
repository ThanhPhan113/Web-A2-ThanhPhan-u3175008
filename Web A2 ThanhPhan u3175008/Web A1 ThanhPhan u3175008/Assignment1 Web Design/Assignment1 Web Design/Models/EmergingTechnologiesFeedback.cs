using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1WebDesign.Models
{
    public class EmergingTechnologiesFeedback
    {
    public int Id { get; set; }
    public  DateTime Date { get; set;}
    public string Username { get; set; }
    [Required]
    public string Heading { get; set; }
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
