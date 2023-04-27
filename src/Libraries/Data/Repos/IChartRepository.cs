using Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public interface IChartRepository
    {

        IEnumerable<BloodChart> GetBloodGroup(DateTime fromDate, DateTime toDate);
        IEnumerable<DateChart> GetDate(DateTime fromDate, DateTime toDate);
        IEnumerable<HospitalChart> GetHospital(DateTime fromDate, DateTime toDate);
        long TotalRegister();
        long TotalCapacity();
        long TotalHospital();
        long TotalBlog();
        long TotalEvent();

    }
}
