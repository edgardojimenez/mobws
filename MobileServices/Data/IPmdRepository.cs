
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MobileServices.Models;

namespace MobileServices.Data {

    public interface IPmdRepository {
        IEnumerable<BodyPart> GetBodyParts();
        IEnumerable<History> GetHistory();
        IEnumerable<Statistic> GetStatistics();

        IEnumerable<StatisticsData> GetDailyStatistics(DateTime now);
        IEnumerable<StatisticsData> GetWeeklyStatistics(DateTime now);
        IEnumerable<StatisticsData> GetMonthlyStatistics(DateTime now);
    }
}
