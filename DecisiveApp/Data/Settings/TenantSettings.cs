using DecisiveApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace DecisiveApp.Data.Settings
{
    
    public class TenantSettings

    {
        public AppDBContext _context;

        public TenantSettings(AppDBContext context)
        {
            _context = context;
        }


        public async Task UpdateTenantByidAsync(string userid, int serviceid, int amount)
        {
            
            var tenant = _context.Tenants.FirstOrDefault(t => t.userid == userid);

            if (tenant != null)
            {
                var service = _context.Services.FirstOrDefault(t => t.id == serviceid);
                if (service.name == "Advanced Backup - Workstations") { tenant.ABWorkstations = amount; tenant.userid = userid; }
                else if (service.name == "Advanced Backup - Servers") { tenant.ABServers = amount; tenant.userid = userid; }
                else if (service.name == "Advanced Backup - Virtualmachines") { tenant.ABVirtualmachines = amount; tenant.userid = userid; }
                else if (service.name == "Endpoint Security Essentials") { tenant.workstationquota = 10; tenant.userid = userid; }
                else if (service.name == "Endpoint Security Plus") { tenant.ADSecurity = amount; tenant.userid = userid; }
                else if (service.name == "Mailbox Security") { tenant.ADEmailSecurity = amount; tenant.userid = userid; }
                else if (service.name == "Cloudbackup Essentials") { tenant.workstationquota = 10; tenant.storagequota = amount; tenant.userid = userid; }
                else if (service.name == "Cloudbackup Plus") { tenant.workstationquota = 100; tenant.storagequota = amount; tenant.serverquota = 100; tenant.virtualmachinequota = 100; tenant.M365seats = 1000; tenant.GWseats = 1000; tenant.userid = userid; }
                else if (service.name == "Cloudbackup Premuim") { tenant.workstationquota = 100; tenant.storagequota = amount; tenant.serverquota = 100; tenant.virtualmachinequota = 100; tenant.M365seats = 1000; tenant.GWseats = 1000; tenant.userid = userid; }
                else if (service.name == "Advanced Backup - Workstations") { tenant.ABWorkstations = amount; }
                await _context.SaveChangesAsync();
            }
            else if (tenant == null)
            {

                var service = _context.Services.FirstOrDefault(t => t.id == serviceid);
                if (service.name == "Advanced Backup - Workstations")
                {

                    tenant = new Tenant()
                    {
                        ABWorkstations = amount,
                        userid = userid
                    };
                 
                }
                else if (service.name == "Advanced Backup - Servers")
                {
                    tenant = new Tenant()
                    {
                        ABServers = amount,
                        userid = userid
                    };
                }
                else if (service.name == "Advanced Backup - Virtualmachines")
                {
                    tenant = new Tenant()
                    {
                        ABVirtualmachines = amount,
                        userid = userid
                    };
                }


                else if (service.name == "Endpoint Security Essentials")
                {
                    tenant = new Tenant()
                    {
                        workstationquota = 10,
                        userid = userid
                    };
                }
                else if (service.name == "Endpoint Security Plus")
                {
                    tenant = new Tenant()
                    {
                        ADSecurity = amount,
                        userid = userid
                    };
                }



                else if (service.name == "Mailbox Security")
                {
                    tenant = new Tenant()
                    {
                        ADEmailSecurity = amount,
                        userid = userid
                    };
                }

                else if (service.name == "Cloudbackup Essentials")
                {
                    tenant = new Tenant()
                    {
                        workstationquota = 10,
                        userid = userid,
                        storagequota = amount
                    };

                }

                else if (service.name == "Cloudbackup Plus")
                {
                    tenant = new Tenant()
                    {
                        workstationquota = 100,
                        userid = userid,
                        storagequota = amount,
                        serverquota = 100,
                        virtualmachinequota = 100,
                        M365seats = 1000,
                        GWseats = 1000
                    };
                }


                else if (service.name == "Cloudbackup Premuim")
                {
                    tenant = new Tenant()
                    {
                        workstationquota = 100,
                        userid = userid,
                        storagequota = amount,
                        serverquota = 100,
                        virtualmachinequota = 100,
                        M365seats = 1000,
                        GWseats = 1000
                    };
                }


                _context.Tenants.Add(tenant); // Add the new tenant to the context

                await _context.SaveChangesAsync();
              
          
            }

        }
        //{
        //    var response = await _context.Tenants.Where(n => n.userid == userid).ToListAsync();
        //    return response;
        //}
    }

}
