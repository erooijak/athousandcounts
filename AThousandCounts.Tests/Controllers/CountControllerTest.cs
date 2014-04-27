using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AThousandCounts;
using AThousandCounts.Controllers;
using AThousandCounts.Models;

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
            var result = controller.Index() as ViewResult;
            // Assert
            Assert.IsInstanceOfType(result, typeof(int), 
                            "Counts model should be an integer");

        }

    }
}
