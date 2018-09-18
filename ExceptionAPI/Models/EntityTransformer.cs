using ExceptionAPI.Data;
using System;
using System.Collections.Generic;

namespace ExceptionAPI.Models
{
    public class EntityTransformer
    {
        public ExceptionModel TransformToExceptionModel(ExceptionEntity exceptionEntity)
        {
            ExceptionModel exceptionModel = new ExceptionModel
            {
                Vin = exceptionEntity.Vin,
                AccountId = exceptionEntity.AccountId,
                EventType = exceptionEntity.EventType,
                TransactionId = exceptionEntity.TransactionId,
                DateTime = exceptionEntity.DateTime,
                Address = new Address()
                {
                    Street1 = exceptionEntity.Street1,
                    Street2 = exceptionEntity.Street2,
                    City = exceptionEntity.City,
                    ZipCode = exceptionEntity.ZipCode,
                    State = exceptionEntity.State,
                    Country = exceptionEntity.Country,
                },
                Latitude = exceptionEntity.Latitude,
                Longitude = exceptionEntity.Longitude
            };
     
            if (exceptionEntity.ExceptionType != null)
            {
                exceptionModel.ExceptionDetails = new ExceptionDetails
                {
                    Type = exceptionEntity.ExceptionType,
                    Color = exceptionEntity.ExceptionColor,
                    Size = exceptionEntity.ExceptionSize,
                    Description = exceptionEntity.ExceptionDesciption,
                    Notes = exceptionEntity.ExceptionNotes,
                    PictureUrls = TransformExceptionUrlEnityListToArray(exceptionEntity.PictureUrls)
                };
            }

            if (exceptionEntity.VideoUrls != null)
            {
                exceptionModel.VideoUrls = TransformToVideoUrlList(exceptionEntity.VideoUrls);
            }
            return exceptionModel;
        }

        public ExceptionEntity TransformToExceptionEntity(ExceptionModel exceptionModel)
        {
            ExceptionEntity exceptionEntity = new ExceptionEntity
            {
                Vin = exceptionModel.Vin,
                AccountId = exceptionModel.AccountId,
                EventType = exceptionModel.EventType,
                TransactionId = exceptionModel.TransactionId,
                DateTime = exceptionModel.DateTime,
                Street1 = exceptionModel.Address.Street1,
                Street2 = exceptionModel.Address.Street2,
                City = exceptionModel.Address.City,
                ZipCode = exceptionModel.Address.ZipCode,
                State = exceptionModel.Address.State,
                Country = exceptionModel.Address.Country,
                Latitude = exceptionModel.Latitude,
                Longitude = exceptionModel.Longitude,
                DateCreated = System.DateTime.Now
            };

            if (exceptionModel.ExceptionDetails != null)
            {
                exceptionEntity.ExceptionType = exceptionModel.ExceptionDetails.Type;
                exceptionEntity.ExceptionColor = exceptionModel.ExceptionDetails.Color;
                exceptionEntity.ExceptionSize = exceptionModel.ExceptionDetails.Size;
                exceptionEntity.ExceptionDesciption = exceptionModel.ExceptionDetails.Description;
                exceptionEntity.ExceptionNotes = exceptionModel.ExceptionDetails.Notes;
                exceptionEntity.PictureUrls = TransformToExceptionUrlEntityList(exceptionModel.ExceptionDetails.PictureUrls);
            }

            if (exceptionModel.VideoUrls != null)
            {
                exceptionEntity.VideoUrls = TransformToVideoUrlEntityList(exceptionModel.VideoUrls);
            }
          
            return exceptionEntity;
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

        protected ICollection<VideoUrlEntity> TransformToVideoUrlEntityList(ICollection<VideoUrl> videoUrls)
        {
            var urls = new List<VideoUrlEntity>();

            foreach (VideoUrl videoUrl in videoUrls)
            {
                urls.Add(new VideoUrlEntity()
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

        protected ICollection<VideoUrl> TransformToVideoUrlList(ICollection<VideoUrlEntity> videoUrls)
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
