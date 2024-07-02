namespace TechPrimeLab.Models
{
    public class DashboardDataDto
    {
        public StatusCounter StatusCounters { get; set; }
        public List<DepartmentCompletionReport> DepartmentCompletionReports { get; set; }
    }
}
