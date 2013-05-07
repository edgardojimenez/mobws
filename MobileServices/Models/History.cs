using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileServices.Models {

    public class History {
        public string BodyPart { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Strength { get; set; }
        public string Options { get; set; }
    }
}