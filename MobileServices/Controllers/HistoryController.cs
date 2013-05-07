using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Controllers {
    public class HistoryController : ApiController {
        private readonly IPmdRepository _pmdRepository;

        public HistoryController(IPmdRepository pmdRepository) {
            _pmdRepository = pmdRepository;
        }

        public IEnumerable<History> Get() {
            return _pmdRepository.GetHistory();
        }
    }
}
