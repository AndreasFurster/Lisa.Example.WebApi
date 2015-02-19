using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lisa.Example.WebApi.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual Catagory Catagory { get; set; }
        public virtual Location Location { get; set; }
        public virtual  Reporter Reporter { get; set; }
    }
}