using ExceptionAPI.Data;
using ExceptionAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionAPITest.Models
{
    class TestDataCreator
    {
        private const string Vin = "ABC123";
        private const int AccountId = 1;
        private const string EventId = "2bf1478e-f543-4354-9726-99af3820617b";
        private const string EventType = "ACCEPTED";
        private const string TransactionId = "XYZ123";
        private const double Longitude = 1.0;
        private const double Latitude = -1.0;
        private const string Street1 = "Street 1";
        private const string Street2 = "Street 2";
        private const string City = "City";
        private const string State = "State";
        private const string ZipCode = "ZipCode";
        private const string Country = "Country";
        private const string ExceptiuonType = "ExceptionType";
        private const string ContainerColor = "Color";
        private const string ContainerSize = "Size";
        private const string ExceptionDescription = "Description";
        private const string ExceptionNotes = "Notes";
        private const int MaximumWeightAllowed = 1;
        private const int ActualWeight = 1;
        private const string WeightUnits = "lbs";
        public const string Url1 = "http://yahoo.com";
        public const string Url2 = "http://google.com";
        private const int Altitude = 1;
        private const int Heading = 1;
        private const double VideoLatitude = 1.1;
        private const double VideoLongitude = 1.1;
        private const int Speed = 1;
        private DateTime VideoStartDateTime = DateTime.Parse("01/01/2017");
        private DateTime VideoEndDateTime = DateTime.Parse("01/02/2017");

        public WasteManagementEventEntity CreateWasteManagementEvent()
        {

            var urls = new List<ImageEntity>
            {
                new ImageEntity
                {
                    ImageURL = Url2
                },
                new ImageEntity
                {
                    ImageURL = Url1
                }
            };

            var videoUrls = new List<VideoEntity>
            {
                new VideoEntity()
                {
                    Altitude = Altitude,
                    StartDateTime = VideoStartDateTime,
                    EndDateTime = VideoEndDateTime,
                    Heading = Heading,
                    Latitude = VideoLatitude,
                    Longitude = VideoLongitude,
                    Speed = Speed,
                    MDTUrl = "www.yahoo.com/video1",
                    VideoURL = "www.yahoo.com/video1",
                    CameraChannel = 1
                }
            };

            var wasteManagementEventEntity = new WasteManagementEventEntity
            {
                Vin = Vin,
                EventId = EventId,
                AccountId = AccountId,
                EventType = EventType,
                TransactionId = TransactionId,
                DateTime = System.DateTime.Now.ToUniversalTime(),
                Longitude = Longitude,
                Latitude = Latitude,
                Street1 = Street1,
                Street2 = Street2,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Country = Country,
                ContainerColor = ContainerColor,
                ContainerSize = ContainerSize,

                ExceptionDetails = new ExceptionDetailsEntity()
                {
                    Type = ExceptiuonType,
                    Description = ExceptionDescription,
                    Notes = ExceptionNotes,
                },
              
                Images = urls,
                Videos = videoUrls
            };

            return wasteManagementEventEntity;
        }

        public WasteManagementEvent CreateExceptionModel()
        {

            var wasteManagementEventModel = new WasteManagementEvent
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
                        Description = ExceptionDescription,
                        Notes = ExceptionNotes,
                        PictureUrls = new string[] { Url1, Url2 }
                    },

                VideoUrls = new List<VideoUrl>
                    {
                    new VideoUrl()
                        {
                            Altitude = Altitude,
                            StartDateTime = VideoStartDateTime,
                            EndDateTime = VideoEndDateTime,
                            Heading = Heading,
                            Latitude = VideoLatitude,
                            Longitude = VideoLongitude,
                            Speed = Speed,
                            MDTUrl = "www.yahoo.com/video1",
                            Url = "www.yahoo.com/video1",
                            Camera = 1
                        }
                    },

                Vin = Vin,
                AccountId = AccountId,
                EventId = EventId,
                EventType = EventType,
                TransactionId = TransactionId,
                DateTime = System.DateTime.Now,
                Longitude = Longitude,
                Latitude = Latitude,
                ContainerColor = ContainerColor,
                ContainerSize = ContainerSize,
            };
            return wasteManagementEventModel;
        }
    }
}

