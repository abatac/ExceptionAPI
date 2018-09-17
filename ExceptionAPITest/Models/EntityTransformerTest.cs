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

            ExceptionModel exceptionModel = _testData.CreateExceptionModel();
            ExceptionEntity result = _transformer.TransformToExceptionEntity(exceptionModel);

            Assert.AreEqual(exceptionModel.Vin, result.Vin);
            Assert.AreEqual(exceptionModel.AccountId, result.AccountId);
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

            Assert.AreEqual(exceptionModel.ExceptionDetails.Type, result.ExceptionType);
            Assert.AreEqual(exceptionModel.ExceptionDetails.Color, result.ExceptionColor);
            Assert.AreEqual(exceptionModel.ExceptionDetails.Size, result.ExceptionSize);
            Assert.AreEqual(exceptionModel.ExceptionDetails.Description, result.ExceptionDesciption);
            Assert.AreEqual(exceptionModel.ExceptionDetails.Notes, result.ExceptionNotes);
            Assert.IsTrue(result.Urls.Any(item => item.MediaType == ExceptionUrlEntity.IMAGE && item.Url == TestDataCreator.Url1));
            Assert.IsTrue(result.Urls.Any(item => item.MediaType == ExceptionUrlEntity.IMAGE && item.Url == TestDataCreator.Url2));
        }

        [TestMethod]
        public void TestTransformToExceptionModel()
        {

            ExceptionEntity exceptionEntity = _testData.CreateExceptionEntity();

            ExceptionModel result = _transformer.TransformToExceptionModel(exceptionEntity);

            Assert.AreEqual(exceptionEntity.Vin, result.Vin);
            Assert.AreEqual(exceptionEntity.AccountId, result.AccountId);
            Assert.AreEqual(exceptionEntity.EventType, result.EventType);
            Assert.AreEqual(exceptionEntity.TransactionId, result.TransactionId);
            Assert.AreEqual(exceptionEntity.DateTime, result.DateTime);
            Assert.AreEqual(exceptionEntity.Longitude, result.Longitude);
            Assert.AreEqual(exceptionEntity.Latitude, result.Latitude);

            Assert.AreEqual(exceptionEntity.Street1, result.Address.Street1);
            Assert.AreEqual(exceptionEntity.Street2, result.Address.Street2);
            Assert.AreEqual(exceptionEntity.City, result.Address.City);
            Assert.AreEqual(exceptionEntity.State, result.Address.State);
            Assert.AreEqual(exceptionEntity.ZipCode, result.Address.ZipCode);
            Assert.AreEqual(exceptionEntity.Country, result.Address.Country);

            Assert.AreEqual(exceptionEntity.ExceptionType, result.ExceptionDetails.Type);
            Assert.AreEqual(exceptionEntity.ExceptionColor, result.ExceptionDetails.Color);
            Assert.AreEqual(exceptionEntity.ExceptionSize, result.ExceptionDetails.Size);
            Assert.AreEqual(exceptionEntity.ExceptionDesciption, result.ExceptionDetails.Description);
            Assert.AreEqual(exceptionEntity.ExceptionNotes, result.ExceptionDetails.Notes);

            List<string> urls = new List<string>(result.ExceptionDetails.PictureUrls);
            Assert.IsTrue(urls.Any(item => item == TestDataCreator.Url1));
            Assert.IsTrue(urls.Any(item => item == TestDataCreator.Url2));
        }

    }
}
