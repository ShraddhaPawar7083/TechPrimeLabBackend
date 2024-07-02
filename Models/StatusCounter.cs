namespace TechPrimeLab.Models
{
    public class StatusCounter
    {
        public int TotalProjects { get; set; }
        public int RunningProjects { get; set; }
        public int ClosedProjects { get; set; }
        public int CancelledProjects { get; set; }
        // Add other counters as needed
    }

    public class DepartmentCompletionReport
    {
        public string Department { get; set; }
        public int CompletedProjects { get; set; }
    }

}
