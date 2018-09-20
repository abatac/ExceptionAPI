using ExceptionAPI.Data;
using ExceptionAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace ExceptionAPITest.Models
{
    [TestClass]
    public class EntityTransformerTest
    {

        private readonly EntityTransformer _transformer = new EntityTransformer();
        private readonly TestDataCreator _testData = new TestDataCreator();

        [TestMethod]
        public void TestTransformToExceptionEntity()
        {

            WasteManagementEvent exceptionModel = _testData.CreateExceptionModel();
            WasteManagementEventEntity result = _transformer.TransformToExceptionEntity(exceptionModel);

            Assert.AreEqual(exceptionModel.Vin, result.Vin);
            Assert.AreEqual(exceptionModel.AccountId, result.AccountId);
            Assert.AreEqual(exceptionModel.EventId, result.EventId);
            Assert.AreEqual(exceptionModel.EventType, result.EventType);
            Assert.AreEqual(exceptionModel.TransactionId, result.TransactionId);
            Assert.AreEqual(exceptionModel.DateTime, result.DateTime);
            Assert.AreEqual(exceptionModel.Longitude, result.Longitude);
            Assert.AreEqual(exceptionModel.Latitude, result.Latitude);

            Assert.AreEqual(exceptionModel.Address.Street1, result.Street1);
            Assert.AreEqual(exceptionModel.Address.Street2, result.Street2);
            Assert.AreEqual(exceptionModel.Address.City, result.City);
            Assert.AreEqual(exceptionModel.Address.State, result.State);
            Assert.AreEqual(exceptionModel.Address.ZipCode, result.ZipCode);
            Assert.AreEqual(exceptionModel.Address.Country, result.Country);

            Assert.AreEqual(exceptionModel.ExceptionDetails.Type, result.ExceptionDetails.Type);
            Assert.AreEqual(exceptionModel.ContainerColor, result.ContainerColor);
            Assert.AreEqual(exceptionModel.ContainerSize, result.ContainerSize);
            Assert.AreEqual(exceptionModel.ExceptionDetails.Description, result.ExceptionDetails.Description);
            Assert.AreEqual(exceptionModel.ExceptionDetails.Notes, result.ExceptionDetails.Notes);
            Assert.AreEqual(exceptionModel.ExceptionDetails.MaximumWeightAllowed, result.ExceptionDetails.MaximumWeightAllowed);
            Assert.AreEqual(exceptionModel.ExceptionDetails.ActualWeight, result.ExceptionDetails.ActualWeight);
            Assert.AreEqual(exceptionModel.ExceptionDetails.WeightUnits, result.ExceptionDetails.WeightUnits);
            Assert.IsTrue(result.Images.Any(item => item.ImageURL == TestDataCreator.Url1));
            Assert.IsTrue(result.Images.Any(item => item.ImageURL == TestDataCreator.Url2));


            VideoUrl videoUrl = exceptionModel.VideoUrls.First();
            VideoEntity videoUrlEntity = result.Videos.First();

            Assert.AreEqual(videoUrl.Heading, videoUrlEntity.Heading);
            Assert.AreEqual(videoUrl.Latitude, videoUrlEntity.Latitude);
            Assert.AreEqual(videoUrl.Longitude, videoUrlEntity.Longitude);
            Assert.AreEqual(videoUrl.MDTUrl, videoUrlEntity.MDTUrl);
            Assert.AreEqual(videoUrl.Url, videoUrlEntity.VideoURL);
            Assert.AreEqual(videoUrl.Speed, videoUrlEntity.Speed);
            Assert.AreEqual(videoUrl.EndDateTime, videoUrlEntity.EndDateTime);
            Assert.AreEqual(videoUrl.StartDateTime, videoUrlEntity.StartDateTime);
            Assert.AreEqual(videoUrl.Camera, videoUrlEntity.CameraChannel);


        }

        [TestMethod]
        public void TestTransformToExceptionModel()
        {

            WasteManagementEventEntity wasteManagementEventEntity = _testData.CreateWasteManagementEvent();

            WasteManagementEvent result = _transformer.TransformToExceptionModel(wasteManagementEventEntity);

            Assert.AreEqual(wasteManagementEventEntity.Vin, result.Vin);
            Assert.AreEqual(wasteManagementEventEntity.AccountId, result.AccountId);
            Assert.AreEqual(wasteManagementEventEntity.EventId, result.EventId);
            Assert.AreEqual(wasteManagementEventEntity.EventType, result.EventType);
            Assert.AreEqual(wasteManagementEventEntity.TransactionId, result.TransactionId);
            Assert.AreEqual(wasteManagementEventEntity.DateTime, result.DateTime);
            Assert.AreEqual(wasteManagementEventEntity.Longitude, result.Longitude);
            Assert.AreEqual(wasteManagementEventEntity.Latitude, result.Latitude);

            Assert.AreEqual(wasteManagementEventEntity.Street1, result.Address.Street1);
            Assert.AreEqual(wasteManagementEventEntity.Street2, result.Address.Street2);
            Assert.AreEqual(wasteManagementEventEntity.City, result.Address.City);
            Assert.AreEqual(wasteManagementEventEntity.State, result.Address.State);
            Assert.AreEqual(wasteManagementEventEntity.ZipCode, result.Address.ZipCode);
            Assert.AreEqual(wasteManagementEventEntity.Country, result.Address.Country);

            Assert.AreEqual(wasteManagementEventEntity.ExceptionDetails.Type, result.ExceptionDetails.Type);
            Assert.AreEqual(wasteManagementEventEntity.ContainerColor, result.ContainerColor);
            Assert.AreEqual(wasteManagementEventEntity.ContainerSize, result.ContainerSize);
            Assert.AreEqual(wasteManagementEventEntity.ExceptionDetails.Description, result.ExceptionDetails.Description);
            Assert.AreEqual(wasteManagementEventEntity.ExceptionDetails.Notes, result.ExceptionDetails.Notes);
            Assert.AreEqual(wasteManagementEventEntity.ExceptionDetails.MaximumWeightAllowed, result.ExceptionDetails.MaximumWeightAllowed);
            Assert.AreEqual(wasteManagementEventEntity.ExceptionDetails.ActualWeight, result.ExceptionDetails.ActualWeight);
            Assert.AreEqual(wasteManagementEventEntity.ExceptionDetails.WeightUnits, result.ExceptionDetails.WeightUnits);

            List<string> urls = new List<string>(result.ExceptionDetails.PictureUrls);
            Assert.IsTrue(urls.Any(item => item == TestDataCreator.Url1));
            Assert.IsTrue(urls.Any(item => item == TestDataCreator.Url2));

            VideoUrl videoUrl = result.VideoUrls.First();
            VideoEntity videoUrlEntity = wasteManagementEventEntity.Videos.First();

            Assert.AreEqual(videoUrl.Heading, videoUrlEntity.Heading);
            Assert.AreEqual(videoUrl.Latitude, videoUrlEntity.Latitude);
            Assert.AreEqual(videoUrl.Longitude, videoUrlEntity.Longitude);
            Assert.AreEqual(videoUrl.MDTUrl, videoUrlEntity.MDTUrl);
            Assert.AreEqual(videoUrl.Url, videoUrlEntity.VideoURL);
            Assert.AreEqual(videoUrl.Speed, videoUrlEntity.Speed);
            Assert.AreEqual(videoUrl.EndDateTime, videoUrlEntity.EndDateTime);
            Assert.AreEqual(videoUrl.StartDateTime, videoUrlEntity.StartDateTime);
            Assert.AreEqual(videoUrl.Camera, videoUrlEntity.CameraChannel);
        }

    }
}
