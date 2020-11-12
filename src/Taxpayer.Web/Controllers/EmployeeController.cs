using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Taxpayer.Application.Interface;
using Taxpayer.Application.Model.RequestResponse;
using Taxpayer.Web.Controllers.Base;

namespace Taxpayer.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> Get()
        {
            var result = _employeeAppService.ListAsync().Result;
            return Response(result.StatusCode, result);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> Add([FromBody] EmployeeRequest employeeRequest)
        {
            var result = _employeeAppService.InsertAsync(employeeRequest).Result;
            return Response(result.StatusCode, result);
        }

        [HttpGet]
        [Route("[action]")]
        public Task<IActionResult> GetCalculationIR([FromQuery] decimal minimumWage)
        {
            var result = _employeeAppService.ListCalculationIR(minimumWage).Result;
            return Response(result.StatusCode, result);
        }
    }
}