using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Models.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ChartRepository : IChartRepository
    {
        private readonly ApplicationDbContext _context;

        public ChartRepository(ApplicationDbContext context = null)
        {
            _context = context;
        }

        public IEnumerable<BloodChart> GetBloodGroup(DateTime fromDate, DateTime toDate)
        {
            var statistics = _context.Registers.Where(e => e.RegisterTime >= fromDate && e.RegisterTime <= toDate).Include(e => e.BloodGroup)
            .GroupBy(e => e.BloodGroup.Name)
            .Select(group => new BloodChart {
                BloodGroup = group.Key,
                Count = group.Count(),
                TotalCapacity = group.Sum(register => register.Capacity)
            })
            .ToList();
            return statistics;
        }

        public IEnumerable<DateChart> GetDate(DateTime fromDate, DateTime toDate)
        {
            var statistics = _context.Registers.Where(e => e.RegisterTime >= fromDate && e.RegisterTime <= toDate)
            .GroupBy(e => e.RegisterTime.Date)
            .Select(group => new DateChart
            {
                Date = group.Key,
                Count = group.Count(),
                TotalCapacity = group.Sum(register => register.Capacity)
            })
            .ToList();
            return statistics;
        }

        public IEnumerable<HospitalChart> GetHospital(DateTime fromDate, DateTime toDate)
        {
            var statistics = _context.Registers.Where(e => e.RegisterTime >= fromDate && e.RegisterTime <= toDate).Include(e => e.Hospital)
           .GroupBy(e => e.Hospital.Name)
           .Select(group => new HospitalChart
           {
               Hospital = group.Key,
               Count = group.Count(),
               TotalCapacity = group.Sum(register => register.Capacity)
           })
           .ToList();
            return statistics;
        }

        public long TotalHospital()
        {
            return _context.Hospitals.Count();
        }

        public long TotalCapacity()
        {
            return _context.Registers.Sum(r => r.Capacity);
        }

        public long TotalRegister()
        {
            return _context.Registers.Count();
        }

        public long TotalBlog()
        {
            return _context.Blogs.Count();
        }

        public long TotalEvent()
        {
            return _context.Events.Count();
        }
    }
}
