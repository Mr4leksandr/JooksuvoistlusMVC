using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooksuvoistlusMVC.Models
{
    public class RunnersData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StartingTime { get; set; }
        public int FinishTime { get; set; }
    }
}