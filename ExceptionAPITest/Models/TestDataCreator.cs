using ExceptionAPI.Data;
using ExceptionAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionAPITest.Models
{
    class TestDataCreator
    {
        private const string Vin = "123ABC";
        private const int AccountId = 123456;
        private const string EventType = "ACCEPTED";
        private const string TransactionId = "8466583";
        private const double Longitude = 111.123;
        private const double Latitude = -112.456;
        private const string Street1 = "Street 1";
        private const string Street2 = "Street 2";
        private const string City = "City";
        private const string State = "State";
        private const string ZipCode = "ZipCode";
        private const string Country = "Country";
        private const string ExceptiuonType = "ExceptionType";
        private const string ExceptionColor = "Color";
        private const string ExceptionSize = "Size";
        private const string ExceptionDescription = "Description";
        private const string ExceptionNotes = "Notes";
        public const string Url1 = "http://yahoo.com";
        public const string Url2 = "http://google.com";

        public ExceptionEntity CreateExceptionEntity()
        {

            ICollection<ExceptionUrlEntity> urls = new List<ExceptionUrlEntity>
            {
                new ExceptionUrlEntity
                {
                    MediaType = ExceptionUrlEntity.IMAGE,
                    Url = Url2
                },
                new ExceptionUrlEntity
                {
                    MediaType = ExceptionUrlEntity.IMAGE,
                    Url = Url1
                }
            };

            ExceptionEntity exceptionEntity = new ExceptionEntity
            {
                Vin = Vin,
                AccountId = AccountId,
                EventType = EventType,
                TransactionId = TransactionId,
                DateTime = System.DateTime.Now,
                Longitude = Longitude,
                Latitude = Latitude,

                Street1 = Street1,
                Street2 = Street2,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Country = Country,

                ExceptionType = ExceptiuonType,
                ExceptionColor = ExceptionColor,
                ExceptionSize = ExceptionSize,
                ExceptionDesciption = ExceptionDescription,
                ExceptionNotes = ExceptionNotes,
                Urls = urls
            };

            return exceptionEntity;
        }

        public ExceptionModel CreateExceptionModel()
        {

            ExceptionModel exceptionModel = new ExceptionModel
            {
                Address = new Address()
                {
                    Street1 = Street1,
                    Street2 = Street2,
                    City = City,
                    State = State,
                    ZipCode = ZipCode,
                    Country = Country,
                },

                ExceptionDetails = new ExceptionDetails()
                {
                    Type = ExceptiuonType,
                    Color = ExceptionColor,
                    Size = ExceptionSize,
                    Description = ExceptionDescription,
                    Notes = ExceptionNotes,
                    PictureUrls = new string[] { Url1, Url2 }
                },

                Vin = Vin,
                AccountId = AccountId,
                EventType = EventType,
                TransactionId = TransactionId,
                DateTime = System.DateTime.Now,
                Longitude = Longitude,
                Latitude = Latitude
            };
            return exceptionModel;
        }
    }
}

