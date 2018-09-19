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

        private EventController _controller;
        private TestDataCreator _testData = new TestDataCreator();
        private Mock<DbSet<WasteManagementEventEntity>> _dbSetMock;
        private Mock<WasteManagementDbContext> _dbContextMock;

        [TestInitialize]
        public void BeforeTest()
        {
            var exceptionEntityList = new List<WasteManagementEventEntity>();
            WasteManagementEventEntity item1 = _testData.CreateExceptionEntity();
            item1.EventId = "141ee716-7995-442c-94a6-ce4ae6e13534";
            WasteManagementEventEntity item2 = _testData.CreateExceptionEntity();
            item2.EventId = "9245f8f5-9882-4e8d-a845-b5ff08e10087";

            exceptionEntityList.Add(item1);
            exceptionEntityList.Add(item2);

            var exceptionEntityQueryable = exceptionEntityList.AsQueryable();
            _dbSetMock = new Mock<DbSet<WasteManagementEventEntity>>();
            _dbSetMock.As<IQueryable<WasteManagementEventEntity>>().Setup(m => m.Expression).Returns(exceptionEntityQueryable.Expression);
            _dbSetMock.As<IQueryable<WasteManagementEventEntity>>().Setup(m => m.ElementType).Returns(exceptionEntityQueryable.ElementType);
            _dbSetMock.As<IQueryable<WasteManagementEventEntity>>().Setup(m => m.GetEnumerator()).Returns(exceptionEntityQueryable.GetEnumerator);
            _dbSetMock.As<IQueryable<WasteManagementEventEntity>>().Setup(m => m.Provider).Returns(exceptionEntityQueryable.Provider);

            _dbContextMock = new Mock<WasteManagementDbContext>();
            
            _dbContextMock.Setup(i => i.WasteManagementEvents).Returns(_dbSetMock.Object);

            _controller = new EventController(_dbContextMock.Object);
        }

        [TestMethod]
        public void TestGet_ReturnsOK()
        {
            var eventId = "141ee716-7995-442c-94a6-ce4ae6e13534";

            var result = _controller.Get(eventId);

            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        public void TestGet_ReturnsNotFound()
        {
            var eventId = "some-event-id";

            var result = _controller.Get(eventId);

            Assert.AreEqual(typeof(NoContentResult), result.Result.GetType());
        }

        [TestMethod]
        public void TestPost_RecordSuccessfullyCreated()
        {
            var eventId = "some-event-id";
            WasteManagementEventModel exceptionModel = _testData.CreateExceptionModel();
            exceptionModel.Vin = eventId;

            var result = _controller.Create(exceptionModel);

            _dbSetMock.Verify(mock => mock.Add(It.IsAny<WasteManagementEventEntity>()), Times.Once());
            _dbContextMock.Verify(mock => mock.SaveChanges(), Times.Once());
            Assert.AreEqual(typeof(StatusCodeResult), result.GetType());
        }
    }
}
