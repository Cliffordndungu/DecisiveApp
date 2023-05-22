namespace DecisiveApp.Models
{
    public class Tenant
    {

        public int id { get; set; }

        public string userid { get; set; }
        public int? storagequota { get; set; }
        public int? workstationquota { get; set; }
        public int? virtualmachinequota { get; set; }
        public int? serverquota { get; set; }

        public int? M365seats { get; set; }
        public int? GWseats { get; set; }
        public int? ABWorkstations { get; set; }
        public int? ABServers { get; set; }
        public int? ABVirtualmachines { get; set; }
        public int? ADSecurity { get; set; }
        public int? ADEmailSecurity { get; set; }
        
        public string? CloudStorage { get; set; }

    }
}
