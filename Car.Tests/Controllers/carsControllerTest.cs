using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Car.Controllers;
using Car.Models;
using Moq;
using System.Linq;
using System.Collections.Generic;

namespace Car.Tests.Controllers
{
    [TestClass]
    public class carsControllerTest
    {
        //moq data
        carsController controller;
        List<car> cars;
        Mock<IMockCars> mock;

        [TestInitialize]
        public void TestInitialize()
        {
            cars = new List<car>
            {
                new car { id = 1001, Type = "Fake type one", Make = 1954, Model = "ABC"},
                new car { id = 1002, Type = "Fake type two", Make = 0000, Model = "BNA"},
                new car { id = 1003, Type = "Fake type three", Make = 1589, Model = "LOL"}
            };
            mock = new Mock<IMockCars>();
            mock.Setup(c => c.cars).Returns(cars.AsQueryable());

            controller = new carsController(mock.Object);
        }

       
        [TestMethod]
        public void IndexViewLoads()
        {
            
            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void DetailsNullId()
        {
            //act
           HttpStatusCodeResult result = controller.Details(null) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }

       [TestMethod]
       public void DetailsviewNullcardetails()
        {
            //act
            HttpNotFoundResult result = controller.Details(999) as HttpNotFoundResult;
            //assert
            Assert.AreEqual(404, result.StatusCode);
        }

              

        [TestMethod]
        public void DetailsViewLoads()
        {
            // act
            ViewResult result = controller.Details(1001) as ViewResult;

            // assert
            Assert.AreEqual("Details", result.ViewName);
        }
        //GET: Create
        [TestMethod]
        public void CreateViewLoads()
        {
            // act
            var result = controller.Create() as ViewResult;

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }


        // Post: cars/Create
        [TestMethod]
        public void CreatePostViewLoads()
        {
            // act
            var result = controller.Create() as ViewResult;

            // assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreatetRedirectViewLoads()
        {
            car car1 = new car { id = 1002, Type ="Suv", Make=1995, Model="Honda" };

            //act
            RedirectToRouteResult result = controller.Create(car1) as RedirectToRouteResult;
            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        // GET: cars/Edit/5
        [TestMethod]
        public void EditviewNullcardetails()
        {
            //act
            HttpNotFoundResult result = controller.Edit(999) as HttpNotFoundResult;
            //assert
            Assert.AreEqual(404, result.StatusCode);
        }


        [TestMethod]
        public void EditViewLoads()
        {
            // act
            ViewResult result = controller.Edit(1001) as ViewResult;

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditNullId()
        {
            //act
            HttpStatusCodeResult result = controller.Edit(999) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(404, result.StatusCode);
        }


        // POST: cars/Edit/5
        [TestMethod]
        public void EditPostViewLoads()
        {
            // act
            var result = controller.Edit(1002) as ViewResult;

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        public void EditCarDetailstViewLoads()
        {
            car car1 = new car { id = 1002, Type = "Suv", Make = 1995, Model = "Honda" };

            //act
            RedirectToRouteResult result = controller.Edit(car1) as RedirectToRouteResult;
            //assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }


        // GET: cars/Delete/5    
        [TestMethod]
        public void DeleteviewNullcardetails()
        {
            //act
            HttpNotFoundResult result = controller.Delete(999) as HttpNotFoundResult;
            //assert
            Assert.AreEqual(404, result.StatusCode);
        }


        [TestMethod]
        public void DeleteViewLoads()
        {
            // act
            ViewResult result = controller.Delete(1001) as ViewResult;

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteNullId()
        {
            //act
            HttpStatusCodeResult result = controller.Delete(null) as HttpStatusCodeResult;

            //assert
            Assert.AreEqual(400, result.StatusCode);
        }

        // POST: cars/Delete/5
        [TestMethod]
        public void DeleteConfirmedCheckVaildID()

        {
            // act
            RedirectToRouteResult result = controller.DeleteConfirmed(1001) as RedirectToRouteResult;

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void DeleteConfirmedCheckInvalidId()
        {

            // act
            RedirectToRouteResult result = controller.DeleteConfirmed(789) as RedirectToRouteResult;

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }


    }


}
