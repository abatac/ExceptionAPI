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
                Longitude = entity.Longitude,
                ContainerColor = entity.ContainerColor,
                ContainerSize = entity.ContainerSize
        };


     
            if (entity.ExceptionDetails != null)
            {
               
                wasteManagementEventModel.ExceptionDetails = new ExceptionDetails
                {
                    Type = entity.ExceptionDetails.Type,
                    Description = entity.ExceptionDetails.Description,
                    Notes = entity.ExceptionDetails.Notes,
                    PictureUrls = TransformExceptionUrlEnityListToArray(entity.Images)
                };
            }

            if (entity.Videos != null)
            {
                wasteManagementEventModel.VideoUrls = TransformToVideoUrlList(entity.Videos);
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
                DateCreated = System.DateTime.Now,
                ContainerColor = model.ContainerColor,
                ContainerSize = model.ContainerSize,
            };

            if (model.ExceptionDetails != null)
            {
                wasteManagementEventEntity.ExceptionDetails = new ExceptionDetailsEntity
                {
                    Type = model.ExceptionDetails.Type,
                    Description = model.ExceptionDetails.Description,
                    Notes = model.ExceptionDetails.Notes
                };
                wasteManagementEventEntity.Images = TransformToExceptionUrlEntityList(model.ExceptionDetails.PictureUrls);
            }
             
            if (model.VideoUrls != null)
            {
                wasteManagementEventEntity.Videos = TransformToVideoUrlEntityList(model.EventId, model.VideoUrls);
            }
          
            return wasteManagementEventEntity;
        }

        protected ICollection<ImageEntity> TransformToExceptionUrlEntityList(ICollection<string> pictureUrls)
        {
            var urls = new List<ImageEntity>();
            foreach (String pictureUrl in pictureUrls)
            {
                urls.Add(new ImageEntity
                {
                    ImageURL = pictureUrl
                });
            }
            return urls;
        }

        public ICollection<VideoEntity> TransformToVideoUrlEntityList(string eventId, ICollection<VideoUrl> videoUrls)
        {
            var urls = new List<VideoEntity>();

            foreach (VideoUrl videoUrl in videoUrls)
            {
                urls.Add(new VideoEntity()
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
                    VideoURL = videoUrl.Url,
                    CameraChannel = videoUrl.Camera
                });
            }

            return urls;
        }

        public ICollection<VideoUrl> TransformToVideoUrlList(ICollection<VideoEntity> videoUrls)
        {
            var urls = new List<VideoUrl>();

            foreach (VideoEntity videoUrl in videoUrls)
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
                    Url = videoUrl.VideoURL,
                    Camera = videoUrl.CameraChannel
                });
            }

            return urls;
        }

        protected string[] TransformExceptionUrlEnityListToArray(ICollection<ImageEntity> exceptionUrls)
        {
            var urls = new List<String>();
            foreach (ImageEntity exceptionUrl in exceptionUrls)
            {
              
               urls.Add(exceptionUrl.ImageURL);
                
            }
            return urls.ToArray();
        }


    }
}
