using DecisiveApp.Data.Enums;
using DecisiveApp.Models;
using System;

namespace DecisiveApp.Data
{
    public class AppDBIntializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();
                context.Database.EnsureCreated();

                //Services
                if (!context.Services.Any())
                {
                    context.Services.AddRange(new List<Service>()
                    {
                        new Service()
                        {
                            name = "Cloud Backup - StorageBW",
                            description = "Cloud backup to botswana storage gateways",
                            pricing = Pricing.GB,
                            Price = 4.10,
                            imageurl = "",

                        },
                        new Service()
                        {
                            name = "EndPoint Protection",
                            description = "Antimalware and antivirus solution",
                            pricing = Pricing.Device,
                            Price = 28.80,
                            imageurl = "",

                        }

                    });
                    context.SaveChanges();

               
                }
                //Downloads
                if (!context.Downloads.Any())
                {
                    context.Downloads.AddRange(new List<Downloads>()
                    {
                        new Downloads()
                        {
                            Filepath = "",
                            Name = "Decisive Cyber Protect 10.200",
                            OS = OSCategory.Windows,
                            Description = "Windows Agent"

                        },
                        new Downloads()
                        {
                            Filepath = "",
                            Name = "Decisive Cyber Protect 10.200",
                            OS = OSCategory.Apple,
                            Description = "Apple Agent"

                        }
 
                    });
                    context.SaveChanges();


                }

                //Downloads
                if (!context.Reports.Any())
                {
                    context.Reports.AddRange(new List<Reports>()
                    {
                        new Reports()
                        {
                            Filepath = "",
                            Name = "Technical Report",
                            type =ReportType.Technical,
                            Description = "IT Report",
                            userid = "",
                            email = ""

                        },
                        new Reports()
                        {
                           Filepath = "",
                            Name = "Weekly Backup Report",
                            type =ReportType.Monitoring,
                            Description = "Backup report for May 2023",
                            userid = "",
                            email = ""

                        }

                    });
                    context.SaveChanges();

    }

            }


        }
    }
}
