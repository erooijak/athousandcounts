using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AThousandCounts;
using AThousandCounts.Controllers;

namespace AThousandCounts.Tests.Controllers
{
    [TestClass]
    public class CountControllerTest
    {
        [TestMethod]
        public void IndexTest()
        {
            // Arrange
            CountController controller = new CountController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateVideoTest()
        {
            CountController controller = new CountController();
            //mock httprequestbase
            //controller.CreateVideo();


        }

    }
}
