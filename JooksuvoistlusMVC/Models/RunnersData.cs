using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JooksuvoistlusMVC.Models
{
    public class RunnersData
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Staring Time")]
        public string StartingTime { get; set; } = "00.00.00";
        [Display(Name = "Finish Time")]
        public string FinishTime { get; set; }
        [Display(Name = "2. Breaks")]
        public bool Break { get; set; }
    }
}