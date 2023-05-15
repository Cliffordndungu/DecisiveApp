using DecisiveApp.Data.Base;
using DecisiveApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DecisiveApp.Data.Services
{
    public class DownloadsService : EntityBaseRepository<Downloads>, IDownloadsService
    {
        private readonly AppDBContext _context;
        public DownloadsService(AppDBContext context) : base(context)
        {
            _context = context;
        }

 
    }
}
