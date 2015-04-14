using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiHarjoitusTyo.Models
{
    public class DigSite
    {
        public int Id { get; set; }
        public int xCoord { get; set; }
        public int yCoord { get; set; }
        public int treasureValue { get; set; }
        public Boolean isClaimed { get; set; }
        public Boolean isEmpty { get; set; }
    }
}