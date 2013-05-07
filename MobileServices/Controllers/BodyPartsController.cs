using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Controllers {
    public class BodyPartsController : ApiController {
        private readonly IPmdRepository _pmdRepository;

        public BodyPartsController(IPmdRepository pmdRepository) {
            _pmdRepository = pmdRepository;
        }

        public IEnumerable<BodyPart> Get() {
            return _pmdRepository.GetBodyParts();
        }
    }
}
