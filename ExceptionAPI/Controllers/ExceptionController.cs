using ExceptionAPI.Data;
using ExceptionAPI.Models;
using ExceptionAPI.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ExceptionAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class ExceptionController : ControllerBase
    {
        private readonly ExceptionDbContext _dbContext
            
            ;
        private readonly EntityTransformer _transformer = new EntityTransformer();

        public ExceptionController(ExceptionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Retrieves the Exception record given a VIN number.
        /// </summary>
        /// <param name="vin">The VIN number of the record to be retrieved.</param>
        /// <returns>Returns the Exception record</returns>
        /// <response code="200">Returns the Exception record.</response>
        /// <response code="204">No record found.</response>
        [HttpGet("Retrieve/{vin}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<ExceptionModel> Get(string vin)
        {
            ExceptionEntity exceptionItem = _dbContext.ExceptionItems
                .Include(ei => ei.Urls).Where(ei => ei.Vin == vin).FirstOrDefault();
            if (exceptionItem == null)
            {
                return NoContent();
            }
            return _transformer.TransformToExceptionModel(exceptionItem);
        }

        /// <summary>
        /// Creates a new Exception record.
        /// </summary>
        /// <remarks>
        /// Sample Request: ACCEPTANCE
        /// <code>
        ///     {
        ///         "vin": "3BPZH28XX8F718469",
        ///         "account_id": "12345",
        ///         "event_type": "WASTE_MANAGEMENT_ACCEPT",
        ///         "transaction_id": "3307543197",
        ///         "date_time": "2018-09-11T10:20:30",
        ///         "latitude": 33.9943428,
        ///         "longitude": -118.124878,
        ///         "address": {
        ///             "street1": "123 Main Street",
        ///             "street2": "Some Suburb",
        ///             "city": "Los Angeles",
        ///             "state": "CA",
        ///             "zipcode": "90009",
        ///             "country": "USA"
        ///             }
        ///     }
        /// </code>
        /// Sample Request: EXCEPTION
        /// 
        ///<code>
        ///     {
        ///         "vin": "3BPZH28XX8F718469", 
        ///         "account_id": "12345", 
        ///         "event_type": "WASTE_MANAGEMENT_EXCEPTION", 
        ///         "transaction_id": "3307543197",  
        ///         "date_time": "2018-09-11T10:20:30", 
        ///         "address": { 
        ///             "street1": "123 Main Street", 
        ///             "street2": "Some Suburb", 
        ///             "city": "Los Angeles", 
        ///             "state": "CA", 
        ///             "zipcode": "90009", 
        ///             "country": "USA" 
        ///             },
        ///         "latitude": 33.9943428, 
        ///         "longitude": -118.124878,
        ///         "exception_details": {
        ///         "type": "WEIGHT_EXCEEDED", 
        ///         "color": "Blue",
        ///         "size": "27L",
        ///         "description": "Weight exceeded",
        ///         "notes": "Clearly overloaded bin",
        ///         "picture_urls": [
        ///             "https://picsum.photos/200/300",
        ///             "https://picsum.photos/200/300"
        ///             ],
        ///         }
        ///     }
        ///     </code>
        /// </remarks>
        /// <param name="exceptionItemDto">Request data to be submitted.</param>
        /// <response code="201">Success. Exception record is saved.</response>
        /// <response code="422">Unprocessable entity. Validation error.</response>
        [HttpPost("Save")]
        [Produces("application/json")]
        [ProducesResponseType(201)]
        [ProducesResponseType(422, Type=typeof(ValidationResultModel))]
        public ActionResult<ExceptionModel> Post([FromBody] ExceptionModel exceptionItemDto)
        {
            ExceptionEntity exceptionItem = _transformer.TransformToExceptionEntity(exceptionItemDto);

            if (_dbContext.ExceptionItems.Any(ei => ei.Vin == exceptionItem.Vin))
            {
                return new ValidationFailedResult(new ValidationResultModel(string.Format("A record with vin number '{0}' already exists.", exceptionItem.Vin)));
            }

            _dbContext.ExceptionItems.Add(exceptionItem);
            _dbContext.SaveChanges();
            return Created("", exceptionItemDto);
        }

       
    }
}
