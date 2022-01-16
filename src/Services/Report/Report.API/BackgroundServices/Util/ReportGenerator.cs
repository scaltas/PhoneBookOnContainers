using Report.API.BackgroundServices.Models;

namespace Report.API.BackgroundServices.Util
{
    public class ReportGenerator
    {
        public string GenerateReport (List<LocationStats> stats)
        {
            using var sw = new StringWriter();
            var header = $"Location;Number Of People;Number Of Phones";
            sw.WriteLine(header);
            foreach (var item in stats)
            {
                sw.WriteLine($"{item.Location};{item.Info.NumberOfPeople};{item.Info.NumberOfPhoneNumbers}");
            }
            return sw.ToString();
        }
    }
}
