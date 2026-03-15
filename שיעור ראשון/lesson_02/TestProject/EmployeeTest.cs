using lesson_02;
using lesson_02.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    public class EmployeeTest 
    {
        private readonly EmployeesController _controller;

        public EmployeeTest()
        {
            IDataContext fake = new FakeContext();
            _controller = new EmployeesController(fake);
        }

        [Fact]
        public void Get_ReturnsListOfEmployees()
        {
            // Arrange

            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Employee>>(result);
        }

        [Fact]
        public void GetById_ReturnsOkObjectResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult()
        {
            // Arrange
            var id = 1;

            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetAll_RturnCount()
        {
            // Arrange

            // Act
            var result = _controller.Get();

            // Assert
            Assert.Equal(2, result.Count());
        }
    }
}