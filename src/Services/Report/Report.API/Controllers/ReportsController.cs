using Microsoft.AspNetCore.Mvc;
using Report.API.Application;
using Report.API.Domain;
using Report.API.Events;

namespace Report.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IBus _eventBus;

        public ReportsController(IReportService contactService, IBus eventBus)
        {
            _reportService = contactService;
            _eventBus = eventBus;
        }

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
            var reportRequestedEvent = new ReportRequestedEvent(report.Id, report.RequestDate);
            await _eventBus.SendAsync("ReportQueue", reportRequestedEvent);

            return CreatedAtAction(nameof(Get), new { id = report.Id }, report);
        }
    }
}
