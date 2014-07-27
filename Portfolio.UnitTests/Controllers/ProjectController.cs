using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Entities;
using System.Linq;
using Portfolio.WebUI.Controllers;

namespace Portfolio.UnitTests.Controllers
{
    [TestClass]
    public class ProjectControllerTest
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            var projRepository = new Mock<IProjectRepository>();
            projRepository.Setup(x => x.Products).Returns(new Project[]
            {
                new Project {ProjectID = 1, Name = "P1"},
                new Project {ProjectID = 2, Name = "P2"},
                new Project {ProjectID = 3, Name = "P3"},
                new Project {ProjectID = 4, Name = "P4"},
                new Project {ProjectID = 5, Name = "P5"}
            }.AsQueryable());

            var projecController = new ProjectController(projRepository.Object);
            projecController.pageSize = 3;
            
            // Act
            var result = (IEnumerable<Project>)projecController.List(2).Model;
            
            // Assert
            List<Project> prodArray = result.ToList();
            Assert.IsTrue(prodArray.Count == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
