namespace ServiceHealthDashboard.Models
{
    public class ServiceStatusViewModel
    {
        public bool IsDatabaseAvailable { get; set; }

        public bool IsWebsiteAvailable { get; set; }

        public string StatusHeader { get { return IsDatabaseAvailable && IsWebsiteAvailable ? "Green across the board" : "Degraded performance";  } }

        public string StatusSubHeader { get { return IsDatabaseAvailable && IsWebsiteAvailable ? "Everything is running smoothly" : "One or more services are experiencing issues"; } }
    }
}