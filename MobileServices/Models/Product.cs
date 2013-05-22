using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MobileServices.Common.Attributes;

namespace MobileServices.Models {

    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductMessage {
        [Required]
        [StringLength(32)]
        [InjectionValidator]
        public string Name { get; set; }
        [Required]
        public bool? AddToList { get; set; }
    }
}
