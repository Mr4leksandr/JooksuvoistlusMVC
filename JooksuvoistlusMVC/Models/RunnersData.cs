using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [DefaultValue(0)]
        public DateTime? StartingTime { get;  set; }
        [Display(Name = "Finish Time")]
        public DateTime? FinishTime { get; set; }
        [Display(Name = "2. Breaks")]
        public bool Break { get; set; }
    }
}