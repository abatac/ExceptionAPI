using ExceptionAPI.Data;
using ExceptionAPI.Models;
using ExceptionAPI.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ExceptionAPI.Controllers
{
    [Route("WasteManagementEvent")]
    [ApiController]
    [ValidateModel]
    public class EventController : ControllerBase
    {
        private readonly WasteManagementDbContext _dbContext;
        private readonly EntityTransformer _transformer = new EntityTransformer();

        public EventController(WasteManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves the Event record given the EventId number.
        /// </summary>
        /// <param name="eventId">The EventId of the record to be retrieved.</param>
        /// <returns>Returns the Event record</returns>
        /// <response code="200">Success. Returns the Event record.</response>
        /// <response code="204">No record found.</response>
        [HttpGet("Retrieve/{eventId}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<WasteManagementEvent> Get(string eventId)
        {
            WasteManagementEventEntity exceptionEntity = _dbContext.WasteManagementEvents
                .Include(ei => ei.Images)
                .Include(ei => ei.Videos)
                .Include(ei => ei.ExceptionDetails)
                .Where(ei => ei.EventId == eventId).FirstOrDefault();

            if (exceptionEntity == null)
            {
                return NoContent();
            }
            return _transformer.TransformToExceptionModel(exceptionEntity);
        }

        /// <summary>
        /// Creates a new Event record.
        /// </summary>
        /// <remarks>
        /// Processes both ACCEPT and EXCEPTION events. exception_details and video_urls fields are optional.
        /// </remarks>
        /// <param name="data">Request data to be submitted. WasteManagementEvent model.</param>
        /// <response code="201">Success. Event record is saved.</response>
        /// <response code="422">Unprocessable entity. Validation error.</response>
        [HttpPost("Create")]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(422, Type=typeof(ValidationResultModel))]
        public ActionResult Create([FromBody] WasteManagementEvent data)
        {
            bool isRecordExists = _dbContext.WasteManagementEvents.Any(o => o.EventId == data.EventId);
            if (!isRecordExists)
            {
                WasteManagementEventEntity wasteManagementEvent = _transformer.TransformToExceptionEntity(data);
                _dbContext.WasteManagementEvents.Add(wasteManagementEvent);
                _dbContext.SaveChanges();
                return new StatusCodeResult(201);
            } else
            {
                return new ValidationFailedResult(new ValidationResultModel(string.Format("Record with EventId \"{0}\" already exists.", data.EventId)));
            }
          
        }

        /// <summary>
        /// Updates the video urls of the specified Event record
        /// </summary>
        /// <param name="eventId">The EventId of the record to be updated.</param>
        /// <param name="data">Request data to be submitted. Array of VideoUrl model.</param>
        /// <response code="200">Success. Event record is updated.</response>
        /// <response code="422">Unprocessable entity. Validation error.</response>
        [HttpPost("Update/{eventId}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(422, Type = typeof(ValidationResultModel))]
        public ActionResult Update(string eventId, [FromBody] ICollection<VideoUrl> data)
        {
            var isRecordExists = _dbContext.WasteManagementEvents.Any(o => o.EventId == eventId);
            if (isRecordExists) {
                ICollection<VideoEntity> videoUrls = _transformer.TransformToVideoUrlEntityList(eventId, data);
                _dbContext.Videos.AddRange(videoUrls);
                _dbContext.SaveChanges();
                return new OkResult();
            } else
            {
                return new ValidationFailedResult(new ValidationResultModel(string.Format("Record with EventId \"{0}\" doesn't exist.", eventId)));
            }
        }


    }
}
