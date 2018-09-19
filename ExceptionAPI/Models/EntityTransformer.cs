using ExceptionAPI.Data;
using System;
using System.Collections.Generic;

namespace ExceptionAPI.Models
{
    public class EntityTransformer
    {
        public WasteManagementEvent TransformToExceptionModel(WasteManagementEventEntity entity)
        {
            WasteManagementEvent wasteManagementEventModel = new WasteManagementEvent
            {
                Vin = entity.Vin,
                AccountId = entity.AccountId,
                EventId = entity.EventId,
                EventType = entity.EventType,
                TransactionId = entity.TransactionId,
                DateTime = entity.DateTime,
                Address = new Address()
                {
                    Street1 = entity.Street1,
                    Street2 = entity.Street2,
                    City = entity.City,
                    ZipCode = entity.ZipCode,
                    State = entity.State,
                    Country = entity.Country,
                },
                Latitude = entity.Latitude,
                Longitude = entity.Longitude
            };
     
            if (entity.ExceptionDetailsEntity != null)
            {
                wasteManagementEventModel.ExceptionDetails = new ExceptionDetails
                {
                    Type = entity.ExceptionDetailsEntity.Type,
                    Color = entity.ExceptionDetailsEntity.Color,
                    Size = entity.ExceptionDetailsEntity.Size,
                    Description = entity.ExceptionDetailsEntity.Description,
                    Notes = entity.ExceptionDetailsEntity.Notes,
                    PictureUrls = TransformExceptionUrlEnityListToArray(entity.PictureUrls)
                };
            }

            if (entity.VideoUrls != null)
            {
                wasteManagementEventModel.VideoUrls = TransformToVideoUrlList(entity.VideoUrls);
            }
            return wasteManagementEventModel;
        }

        public WasteManagementEventEntity TransformToExceptionEntity(WasteManagementEvent model)
        {
            WasteManagementEventEntity wasteManagementEventEntity = new WasteManagementEventEntity
            {
                Vin = model.Vin,
                AccountId = model.AccountId,
                EventId = model.EventId,
                EventType = model.EventType,
                TransactionId = model.TransactionId,
                DateTime = model.DateTime,
                Street1 = model.Address.Street1,
                Street2 = model.Address.Street2,
                City = model.Address.City,
                ZipCode = model.Address.ZipCode,
                State = model.Address.State,
                Country = model.Address.Country,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                DateCreated = System.DateTime.Now
            };

            if (model.ExceptionDetails != null)
            {
                wasteManagementEventEntity.ExceptionDetailsEntity = new ExceptionDetailsEntity
                {
                    Type = model.ExceptionDetails.Type,
                    Color = model.ExceptionDetails.Color,
                    Size = model.ExceptionDetails.Size,
                    Description = model.ExceptionDetails.Description,
                    Notes = model.ExceptionDetails.Notes
                };
                wasteManagementEventEntity.PictureUrls = TransformToExceptionUrlEntityList(model.ExceptionDetails.PictureUrls);
            }
             
            if (model.VideoUrls != null)
            {
                wasteManagementEventEntity.VideoUrls = TransformToVideoUrlEntityList(model.EventId, model.VideoUrls);
            }
          
            return wasteManagementEventEntity;
        }

        protected ICollection<PictureUrlEntity> TransformToExceptionUrlEntityList(String[] pictureUrls)
        {
            var urls = new List<PictureUrlEntity>();
            foreach (String pictureUrl in pictureUrls)
            {
                urls.Add(new PictureUrlEntity
                {
                    Url = pictureUrl
                });
            }
            return urls;
        }

        public ICollection<VideoUrlEntity> TransformToVideoUrlEntityList(string eventId, ICollection<VideoUrl> videoUrls)
        {
            var urls = new List<VideoUrlEntity>();

            foreach (VideoUrl videoUrl in videoUrls)
            {
                urls.Add(new VideoUrlEntity()
                {
                    EventId = eventId,
                    Speed = videoUrl.Speed,
                    Heading = videoUrl.Heading,
                    StartDateTime = videoUrl.StartDateTime,
                    EndDateTime = videoUrl.EndDateTime,
                    Latitude = videoUrl.Latitude,
                    Longitude = videoUrl.Longitude,
                    Altitude = videoUrl.Altitude,
                    MDTUrl = videoUrl.MDTUrl,
                    Url = videoUrl.Url,
                    Camera = videoUrl.Camera
                });
            }

            return urls;
        }

        public ICollection<VideoUrl> TransformToVideoUrlList(ICollection<VideoUrlEntity> videoUrls)
        {
            var urls = new List<VideoUrl>();

            foreach (VideoUrlEntity videoUrl in videoUrls)
            {
                urls.Add(new VideoUrl()
                {
                    Speed = videoUrl.Speed,
                    Heading = videoUrl.Heading,
                    StartDateTime = videoUrl.StartDateTime,
                    EndDateTime = videoUrl.EndDateTime,
                    Latitude = videoUrl.Latitude,
                    Longitude = videoUrl.Longitude, 
                    Altitude = videoUrl.Altitude,
                    MDTUrl = videoUrl.MDTUrl,
                    Url = videoUrl.Url,
                    Camera = videoUrl.Camera
                });
            }

            return urls;
        }

        protected string[] TransformExceptionUrlEnityListToArray(ICollection<PictureUrlEntity> exceptionUrls)
        {
            var urls = new List<String>();
            foreach (PictureUrlEntity exceptionUrl in exceptionUrls)
            {
              
               urls.Add(exceptionUrl.Url);
                
            }
            return urls.ToArray();
        }


    }
}
