using Microsoft.AspNetCore.Mvc;
using Report.API.Application;
using Report.API.Domain;

namespace Report.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService contactService) =>
            _reportService = contactService;

        [HttpGet]
        public async Task<List<ReportEntry>> Get() =>
            await _reportService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ReportEntry>> Get(string id)
        {
            var report = await _reportService.GetAsync(id);

            if (report is null)
            {
                return NotFound();
            }

            return report;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var report = await _reportService.CreateAsync();

            return CreatedAtAction(nameof(Get), new { id = report.Id }, report);
        }
    }
}
