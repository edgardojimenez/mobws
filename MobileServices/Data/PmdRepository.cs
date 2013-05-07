using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using MobileServices.Models;
using Dapper;


namespace MobileServices.Data {
    public class PmdRepository : IPmdRepository {
        private string _connection;

        public PmdRepository(string connection) {
            _connection = connection;
        }

        public IEnumerable<BodyPart> GetBodyParts() {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<BodyPart>("select * from [dbo].[BodyParts]");
            }
        }

        public IEnumerable<History> GetHistory() {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<History>("GetHistory", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Statistic> GetStatistics() {
            using (var conn = new SqlConnection(_connection)) {
                conn.Open();
                return conn.Query<Statistic>("select * from [dbo].[Statistics]");
            }
        }

        public IEnumerable<StatisticsData> GetDailyStatistics(DateTime now) {
            throw new NotImplementedException();
        }

        public IEnumerable<StatisticsData> GetWeeklyStatistics(DateTime now) {
            throw new NotImplementedException();
        }

        public IEnumerable<StatisticsData> GetMonthlyStatistics(DateTime now) {
            throw new NotImplementedException();
        }
    }
}