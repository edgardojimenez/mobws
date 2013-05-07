using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Controllers {
    public class IncidentController : ApiController {
        private readonly IPmdRepository _pmdRepository;

        public IncidentController(IPmdRepository pmdRepository) {
            _pmdRepository = pmdRepository;
        }

        public IEnumerable<History> Get() {
            return new List<History>() {
                new History() { BodyPart = "Stomach", Date = "10/01/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/02/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/03/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/04/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/05/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" },
                new History() { BodyPart = "Stomach", Date = "10/15/2012", Time = "3:30 AM", Duration = "60 Minutes", Strength = "9", Options = "Nausea, Sharp, Vomit" }
            };
        }
    }
}
