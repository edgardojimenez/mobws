using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using MobileServices.Controllers;
using MobileServices.Data;

namespace MobileServices.Common {
    public class Resolver : IDependencyResolver {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["mobws"].ConnectionString;

        static readonly IPmdRepository _pmdRespository = new PmdRepository(_connectionString);
        static readonly IGroceryRepository _groceryRespository = new GroceryRepository(_connectionString);

        public IDependencyScope BeginScope() {
            return this;
        }

        public object GetService(Type serviceType) {
            if (serviceType == typeof(BodyPartsController)) 
                return new BodyPartsController(_pmdRespository);

            if (serviceType == typeof(HistoryController))
                return new HistoryController(_pmdRespository);

            if (serviceType == typeof(IncidentController))
                return new IncidentController(_pmdRespository);

            if (serviceType == typeof(StatisticController))
                return new StatisticController(_pmdRespository);

            if (serviceType == typeof(ProductsController))
                return new ProductsController(_groceryRespository);

            if (serviceType == typeof(GroceriesController))
                return new GroceriesController(_groceryRespository);

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return new List<object>();
        }

        public void Dispose() {}

    }
}