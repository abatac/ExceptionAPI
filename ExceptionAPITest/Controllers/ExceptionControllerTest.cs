using ExceptionAPI.Controllers;
using ExceptionAPI.Data;
using ExceptionAPI.Models;
using ExceptionAPI.Validation;
using ExceptionAPITest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionAPITest.Controllers
{
    [TestClass]
    public class ExceptionControllerTest
    {

        private ExceptionController _controller;
        private TestDataCreator _testData = new TestDataCreator();
        private Mock<DbSet<ExceptionEntity>> _dbSetMock;
        private Mock<ExceptionDbContext> _dbContextMock;

        [TestInitialize]
        public void BeforeTest()
        {
            var exceptionEntityList = new List<ExceptionEntity>();
            ExceptionEntity item1 = _testData.CreateExceptionEntity();
            item1.Vin = "VIN123";
            ExceptionEntity item2 = _testData.CreateExceptionEntity();
            item2.Vin = "VIN456";

            exceptionEntityList.Add(item1);
            exceptionEntityList.Add(item2);

            var exceptionEntityQueryable = exceptionEntityList.AsQueryable();
            _dbSetMock = new Mock<DbSet<ExceptionEntity>>();
            _dbSetMock.As<IQueryable<ExceptionEntity>>().Setup(m => m.Expression).Returns(exceptionEntityQueryable.Expression);
            _dbSetMock.As<IQueryable<ExceptionEntity>>().Setup(m => m.ElementType).Returns(exceptionEntityQueryable.ElementType);
            _dbSetMock.As<IQueryable<ExceptionEntity>>().Setup(m => m.GetEnumerator()).Returns(exceptionEntityQueryable.GetEnumerator);
            _dbSetMock.As<IQueryable<ExceptionEntity>>().Setup(m => m.Provider).Returns(exceptionEntityQueryable.Provider);

            _dbContextMock = new Mock<ExceptionDbContext>();
            
            _dbContextMock.Setup(i => i.ExceptionItems).Returns(_dbSetMock.Object);

            _controller = new ExceptionController(_dbContextMock.Object);
        }

        [TestMethod]
        public void TestGet_ReturnsOK()
        {
            var vinWithRecord = "VIN123";

            var result = _controller.Get(vinWithRecord);

            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        public void TestGet_ReturnsNotFound()
        {
            var vinNoRecord = "VIN123456";

            var result = _controller.Get(vinNoRecord);

            Assert.AreEqual(typeof(NoContentResult), result.Result.GetType());
        }

        [TestMethod]
        public void TestPost_RecordAlreadyExists()
        {
            var vinWithRecord = "VIN123";
            ExceptionModel exceptionModel = _testData.CreateExceptionModel();
            exceptionModel.Vin = vinWithRecord;

            var result = _controller.Post(exceptionModel);

            Assert.AreEqual(typeof(ValidationFailedResult), result.Result.GetType());
        }

        [TestMethod]
        public void TestPost_RecordSuccessfullyCreated()
        {
            var vinNoRecord = "VIN123456";
            ExceptionModel exceptionModel = _testData.CreateExceptionModel();
            exceptionModel.Vin = vinNoRecord;

            var result = _controller.Post(exceptionModel);

            _dbSetMock.Verify(mock => mock.Add(It.IsAny<ExceptionEntity>()), Times.Once());
            _dbContextMock.Verify(mock => mock.SaveChanges(), Times.Once());
            Assert.AreEqual(typeof(CreatedResult), result.Result.GetType());
        }
    }
}
