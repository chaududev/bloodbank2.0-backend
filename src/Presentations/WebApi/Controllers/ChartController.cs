using Data.Repos;
using Identity.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        readonly IChartRepository _repository;
        readonly IAccountService _accountService;

        public ChartController(IChartRepository repository, IAccountService accountService)
        {
            _repository = repository;
            _accountService = accountService;
        }

        [HttpGet("Total")]
        public IActionResult Get()
        {
            try
            {
                var result = new
                {
                    TotalHospital = _repository.TotalHospital(),
                    TotalUser = _accountService.TotalUser(),
                    TotalCapacity = _repository.TotalCapacity(),
                    TotalRegister = _repository.TotalRegister(),
                    TotalBlog = _repository.TotalBlog(),
                    TotalEvent = _repository.TotalEvent()
                };
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Blood")]
        public IActionResult GetBlood(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var statistics = _repository.GetBloodGroup(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);

                return Ok(statistics);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Date")]
        public IActionResult GetDate(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var statistics = _repository.GetDate(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);

                return Ok(statistics);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("Hospital")]
        public IActionResult GetHospital(DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var statistics = _repository.GetHospital(fromDate ?? DateTime.MinValue, toDate ?? DateTime.MaxValue);

                return Ok(statistics);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
