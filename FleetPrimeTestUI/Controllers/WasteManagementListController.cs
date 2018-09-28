using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ExceptionAPI.Data;
using System.Threading.Tasks;
using System;
using FleetPrimeTestUI.Util;
using Microsoft.Extensions.Options;

namespace FleetPrimeTestUI.Controllers
{
    public class WasteManagementEventListController : Controller
    {
        private readonly WasteManagementDbContext _dbContext;
        private readonly IOptions<ServiceSettings> _serviceSettings;

        public WasteManagementEventListController(IOptions<ServiceSettings> serviceSettings, WasteManagementDbContext dbContext)
        {
            _dbContext = dbContext;
            _serviceSettings = serviceSettings;
        }

        public ActionResult Details(string transactionId)
        {
            var result = _dbContext.WasteManagementEvents
                .Where(o => o.TransactionId == transactionId)
                .Include(o => o.Videos)
                .Include(o => o.Images)
                .Include(o => o.ExceptionDetails)
                .FirstOrDefault();
            return View(result);
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["FleetprimeAwareUrl"] = _serviceSettings.Value.FleetprimeAwareUrl;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "DateCreated" ? "date_desc" : "DateCreated";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var wasteManagementEvents = _dbContext.WasteManagementEvents.Include(o => o.ExceptionDetails).Select(o => o);
                           

            if (!String.IsNullOrEmpty(searchString))
            {
                wasteManagementEvents = wasteManagementEvents.Where(s => s.TransactionId.Contains(searchString));
            }

            switch (sortOrder)
            {

                case "DateCreated":
                    wasteManagementEvents = wasteManagementEvents.OrderBy(s => s.DateTime);
                    break;
                case "date_desc":
                    wasteManagementEvents = wasteManagementEvents.OrderByDescending(s => s.DateTime);
                    break;
                default:
                    wasteManagementEvents = wasteManagementEvents.OrderByDescending(s => s.DateTime);
                    break;
            }

            int pageSize = 20;
            return View(await PaginatedList<WasteManagementEventEntity>.CreateAsync(wasteManagementEvents.AsNoTracking(), page ?? 1, pageSize));
        }
    }
}