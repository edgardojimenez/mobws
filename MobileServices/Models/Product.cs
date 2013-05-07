using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileServices.Models {

    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductMessage {
        public string Name { get; set; }
        public bool AddToList { get; set; }
    }
}
