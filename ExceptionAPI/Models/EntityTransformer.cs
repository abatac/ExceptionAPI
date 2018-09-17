using ExceptionAPI.Data;
using System;
using System.Collections.Generic;

namespace ExceptionAPI.Models
{
    public class EntityTransformer
    {
        public ExceptionModel TransformToExceptionModel(ExceptionEntity exceptionItem)
        {
            ExceptionModel exceptionItemDto = new ExceptionModel
            {
                Vin = exceptionItem.Vin,
                AccountId = exceptionItem.AccountId,
                EventType = exceptionItem.EventType,
                TransactionId = exceptionItem.TransactionId,
                DateTime = exceptionItem.DateTime,
                Address = new Address()
                {
                    Street1 = exceptionItem.Street1,
                    Street2 = exceptionItem.Street2,
                    City = exceptionItem.City,
                    ZipCode = exceptionItem.ZipCode,
                    State = exceptionItem.State,
                    Country = exceptionItem.Country,
                },
                Latitude = exceptionItem.Latitude,
                Longitude = exceptionItem.Longitude
        };
     
        if (exceptionItem.ExceptionType != null)
        {
            exceptionItemDto.ExceptionDetails = new ExceptionDetails
            {
                Type = exceptionItem.ExceptionType,
                Color = exceptionItem.ExceptionColor,
                Size = exceptionItem.ExceptionSize,
                Description = exceptionItem.ExceptionDesciption,
                Notes = exceptionItem.ExceptionNotes,
                PictureUrls = TransformExceptionUrlEnityListToArray(exceptionItem.Urls)
            };
        }
            return exceptionItemDto;
        }

        public ExceptionEntity TransformToExceptionEntity(ExceptionModel exceptionItemDto)
        {
            ExceptionEntity exceptionItem = new ExceptionEntity
            {
                Vin = exceptionItemDto.Vin,
                AccountId = exceptionItemDto.AccountId,
                EventType = exceptionItemDto.EventType,
                TransactionId = exceptionItemDto.TransactionId,
                DateTime = exceptionItemDto.DateTime,
                Street1 = exceptionItemDto.Address.Street1,
                Street2 = exceptionItemDto.Address.Street2,
                City = exceptionItemDto.Address.City,
                ZipCode = exceptionItemDto.Address.ZipCode,
                State = exceptionItemDto.Address.State,
                Country = exceptionItemDto.Address.Country,
                Latitude = exceptionItemDto.Latitude,
                Longitude = exceptionItemDto.Longitude,
                DateCreated = System.DateTime.Now
            };

            if (exceptionItemDto.ExceptionDetails != null)
            {
                exceptionItem.ExceptionType = exceptionItemDto.ExceptionDetails.Type;
                exceptionItem.ExceptionColor = exceptionItemDto.ExceptionDetails.Color;
                exceptionItem.ExceptionSize = exceptionItemDto.ExceptionDetails.Size;
                exceptionItem.ExceptionDesciption = exceptionItemDto.ExceptionDetails.Description;
                exceptionItem.ExceptionNotes = exceptionItemDto.ExceptionDetails.Notes;
                exceptionItem.Urls = TransformToExceptionUrlEntityList(exceptionItemDto.ExceptionDetails.PictureUrls);
            }
          
            return exceptionItem;
        }

        protected List<ExceptionUrlEntity> TransformToExceptionUrlEntityList(String[] pictureUrls)
        {
            List<ExceptionUrlEntity> urls = new List<ExceptionUrlEntity>();
            foreach (String pictureUrl in pictureUrls)
            {
                urls.Add(new ExceptionUrlEntity
                {
                    MediaType = ExceptionUrlEntity.IMAGE,
                    Url = pictureUrl
                });
            }
            return urls;
        }

        protected string[] TransformExceptionUrlEnityListToArray(ICollection<ExceptionUrlEntity> exceptionUrls)
        {
            List<String> urls = new List<String>();
            foreach (ExceptionUrlEntity exceptionUrl in exceptionUrls)
            {
                if (exceptionUrl.MediaType == ExceptionUrlEntity.IMAGE)
                {
                    urls.Add(exceptionUrl.Url);
                }
            }
            return urls.ToArray();
        }
    }
}
