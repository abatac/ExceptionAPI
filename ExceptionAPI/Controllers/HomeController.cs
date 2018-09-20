using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ExceptionAPI.Data;
using ExceptionAPI.Models;
using ExceptionAPI.Validation;
using ExceptionAPITest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace WasteManagementAPI.Controllers
{
    public class HomeController : Controller
    {

        private readonly WasteManagementDbContext _dbContext;

        public HomeController(WasteManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult List()
        {
            IEnumerable<WasteManagementEventEntity> results = _dbContext.WasteManagementEvents
                .Select(row => row)
                .Include(o => o.Images)
                .Include(o => o.Videos)
                .Include(o => o.ExceptionDetails)
                .AsEnumerable();
            return View(results);
        }

        public ActionResult Create()
        {
            WasteManagementEvent model = new TestDataCreator().CreateExceptionModel();
            model.EventId = System.Guid.NewGuid().ToString();
            return View(model);
        }


        public ActionResult Clear()
        {
            WasteManagementEvent model = new WasteManagementEvent();
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WasteManagementEvent model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("{0}://{1}/WasteManagementEvent/", Request.Scheme, Request.Host));
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var responseTask = client.PostAsJsonAsync("Create", model);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.StatusCode == System.Net.HttpStatusCode.UnprocessableEntity)
                    {
                        var readTask = result.Content.ReadAsAsync<ValidationResultModel>();
                        readTask.Wait();

                        ValidationResultModel validationResultModel = readTask.Result;
                    
                        TryValidateModel(model);

                        ViewData.Add("Error", validationResultModel.Message);

                    } else
                    {
                        ViewData.Add("Success", true);
                    }
                }
               
                return View();
               
            }
            catch
            {
                return View();
            }
        }

    }
}