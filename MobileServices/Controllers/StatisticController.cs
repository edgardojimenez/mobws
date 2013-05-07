using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Controllers {
    public class StatisticController : ApiController {
        private readonly IPmdRepository _pmdRepository;

        public StatisticController(IPmdRepository pmdRepository) {
            _pmdRepository = pmdRepository;
        }

        public IEnumerable<Statistic> Get() {
            return _pmdRepository.GetStatistics();
        }
    }
}
