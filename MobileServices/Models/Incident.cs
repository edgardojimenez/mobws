using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileServices.Models {

    public class Incident {
        public BodyPart BodyPart { get; set; }
        public DateTime Date { get; set; }
        public bool Nausea { get; set; }
        public bool Sharp { get; set; }
        public bool Vomit { get; set; }
        public bool Temperature { get; set; }
        public int Duration { get; set; }
        public int Strength { get; set; }
    }
}