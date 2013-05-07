using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileServices.Data;
using MobileServices.Models;

namespace MobileServices.Tests {
    [TestClass]
    public class PmdRepositoryIntegrationTest {

    // Only run the integration test in development; prevents appharbor from running
#if DEBUG
        private string _connection = ConfigurationManager.ConnectionStrings["mobws"].ConnectionString;

        [TestMethod]
        public void Should_return_all_BodyParts() {
            var repo = new PmdRepository(_connection);

            var parts = repo.GetBodyParts().ToList();

            Assert.IsNotNull(parts);
            Assert.IsTrue(parts.Count > 0);
            Assert.IsNotNull(parts.FirstOrDefault());
            Assert.IsFalse(string.IsNullOrWhiteSpace(parts.FirstOrDefault().Description));
        }

        [TestMethod]
        public void Should_return_all_statistics() {
            var repo = new PmdRepository(_connection);

            var stats = repo.GetStatistics().ToList();

            Assert.IsNotNull(stats);
            Assert.IsTrue(stats.Any());
            Assert.IsNotNull(stats.FirstOrDefault());
            Assert.IsFalse(string.IsNullOrWhiteSpace(stats.FirstOrDefault().Description));
        }

        [TestMethod]
        public void Should_return_all_History() {
            var repo = new PmdRepository(_connection);

            var history = repo.GetHistory().ToList();

            Assert.IsNotNull(history);
            Assert.IsTrue(history.Any());
            Assert.IsNotNull(history.FirstOrDefault());
            Assert.IsFalse(string.IsNullOrWhiteSpace(history.FirstOrDefault().Date));
        }
#endif
    }
}
