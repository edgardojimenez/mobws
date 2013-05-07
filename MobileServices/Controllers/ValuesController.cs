using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using TraceLevel = System.Web.Http.Tracing.TraceLevel;

namespace MobileServices.Controllers {
    public class Person {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class ValuesController : ApiController {

        public List<Person> Get() {
            return new List<Person>() { new Person() {Age = 45, Name = "Mike"}, new Person() {Age = 45, Name = "Smith"}};
        }

        public string Get(int id) {
            return "value";
        }
    }
}