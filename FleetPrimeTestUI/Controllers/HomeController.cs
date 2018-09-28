using FleetPrimeTestUI.Models;
using FleetPrimeTestUI.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ExceptionAPI.Data;
using Newtonsoft.Json;
using System.Text;

namespace FleetPrimeTestUI.Controllers
{
    public class HomeController : Controller
    {

        private const string EventTypeAccept = "WASTE_MANAGEMENT_ACCEPT";
        private const string EventTypeReject = "WASTE_MANAGEMENT_EXCEPTION";

        private readonly WasteManagementDbContext _wasteManagementDbContext;
        private readonly IOptions<ServiceSettings> _serviceSettings;
        private TestDataGenerator _testData = new TestDataGenerator();

        public HomeController(IOptions<ServiceSettings> serviceSettings, WasteManagementDbContext wasteManagementDbContext)
        {
            _serviceSettings = serviceSettings;
            _wasteManagementDbContext = wasteManagementDbContext;
        }

        public IActionResult Index()
        {
            var model = _testData.CreateEventViewData(); 
           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(IFormCollection form, EventViewData model)
        {
          
            bool isSuccessful = false;
            string errorMessage = "";
            Event postData = null;
            try
            {

                postData = CreateEvent(form);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_serviceSettings.Value.MainUrl);

                    var jsonInString = JsonConvert.SerializeObject(postData);
                    var responseTask = client.PostAsync("wm-iot", new StringContent(jsonInString, Encoding.UTF8, "application/json"));
                    responseTask.Wait();
                    var result = responseTask.Result;
                    isSuccessful = result.IsSuccessStatusCode;

                    if (result.IsSuccessStatusCode)
                    {
                        ViewData.Add("Success", string.Format("The data with transactionId: \"{0}\" has been pushed to the server.", postData.TransactionId));
                    } else 
                    {
                        var readTask = result.Content.ReadAsAsync<ErrorModel>();
                        readTask.Wait();
                        var modelResult = readTask.Result;

                        string errorMessages = "";
                        if (modelResult.Messages != null)
                        {
                            errorMessages = String.Join(",", modelResult.Messages.Select(i => i.ToString()).ToArray());
                        }
                        
                        errorMessage = string.Format("The api server ( {0} ) returned an error: {1} , {2}", _serviceSettings.Value.MainUrl.ToString(), modelResult.Status, errorMessages);
                        ViewData.Add("Error", errorMessage);
                    }
                }
                return View("Index", _testData.CreateEventViewData());
            } catch (Exception e)
            {
                errorMessage = string.Format("Cannot connect to the api server ( {0} ). {1}", _serviceSettings.Value.MainUrl.ToString(), e.Message);
                ViewData.Add("Error", errorMessage);
                return View("Index", _testData.CreateEventViewData());
            } finally
            {
                if (postData != null)
                {
                    var eventLog = TransformEventToEventLog(isSuccessful, errorMessage, postData);
                    _wasteManagementDbContext.EventLogs.Add(eventLog);
                    _wasteManagementDbContext.SaveChanges();
                }
            }
                
        }


        private Event CreateEvent(IFormCollection form)
        {
            EventViewData viewData = _testData.CreateEventViewData();

            var addresses = viewData.Addresses;
            var rejectReasons = viewData.RejectReasons;
            string transactionId = Guid.NewGuid().ToString();

            int addressIndex = int.Parse(form["Address"]);
            var address = addresses[addressIndex];

            return new Event()
            {
                Vin = form["Vin"],
                AccountId = form["AccountId"],
                EventType = form["EventType"],
                TransactionId = transactionId,
                DateTime = DateTime.Now.ToUniversalTime(),
                Latitude = address.Latitude,
                Longitude = address.Longitude,
                ContainerColor = form["ContainerColor"],
                ContainerSize = form["ContainerSize"],
                Address = new Address
                {
                    Street1 = address.Street1,
                    Street2 = address.Street2,
                    City = address.City,
                    State = address.State,
                    ZipCode = address.ZipCode,
                    Country = address.Country
                },

                ExceptionDetails = CreateExceptionDetails(form, rejectReasons)
            };
        }

        private ExceptionDetails CreateExceptionDetails(IFormCollection form, Dictionary<string, string> rejectReasons)
        {
            string eventType = form["EventType"];
            string rejectReason = form["RejectReason"];
            string rejectDescription = rejectReasons[form["RejectReason"]];
            string notes = form["Notes"];
            string[] pictureUrls = form["PictureURL"];

            var urlList = new List<String>();
            foreach (string url in pictureUrls)
            {
                if (!String.IsNullOrWhiteSpace(url))
                {
                    urlList.Add(url);
                }
            }
             
            if (EventTypeReject.Equals(eventType))
            {
                return new ExceptionDetails()
                {
                    Type = rejectReason,
                    Description = rejectDescription,
                    Notes = notes,
                    PictureUrls = urlList
                };
            } else
            {
                return null;
            }
        }

        private FleetPrimeTestEvent TransformEventToEventLog(bool isSuccessful, string errorMessage, Event postData)
        {
            var eventLog = new FleetPrimeTestEvent()
            {
                Success = isSuccessful,
                ErrorMessage = errorMessage,
                AccountId = postData.AccountId,
                EventType = postData.EventType,
                Vin = postData.Vin,
                TransactionId = postData.TransactionId,
                DateCreated = DateTime.UtcNow,
                DateTime = postData.DateTime,
                Latitude = postData.Latitude,
                Longitude = postData.Longitude,
                Street1 = postData.Address.Street1,
                Street2 = postData.Address.Street2,
                City = postData.Address.City,
                State = postData.Address.State,
                ZipCode = postData.Address.ZipCode,
                Country = postData.Address.Country,
                ContainerColor = postData.ContainerColor,
                ContainerSize = postData.ContainerSize,
            };

            if (postData.ExceptionDetails != null)
            {
                eventLog.Type = postData.ExceptionDetails.Type;
                eventLog.Description = postData.ExceptionDetails.Description;
                eventLog.Notes = postData.ExceptionDetails.Notes;

                for (int i = 0; i < postData.ExceptionDetails.PictureUrls.Count; i++)
                {
                    if (i == 0)
                    {
                        eventLog.ImageURL1 = postData.ExceptionDetails.PictureUrls.ElementAt(i);
                    }
                    if (i == 1)
                    {
                        eventLog.ImageURL2 = postData.ExceptionDetails.PictureUrls.ElementAt(i);
                    }
                    if (i == 2)
                    {
                        eventLog.ImageURL3 = postData.ExceptionDetails.PictureUrls.ElementAt(i);
                    }
                }
            }
            return eventLog;
        }
    }
}
