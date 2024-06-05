using FluentAssertions;
using FormulaApp.Api.Controllers;
using FormulaApp.Api.Models;
using FormulaApp.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FormulaApp.UnitTests.Systems.Controllers
{
    public class TestFansController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnStatusCode200() 
        {
            //Arrange
            var mockFanService = new Mock<IFanService>();
            mockFanService.Setup(service => service.GetAllFans())
                .ReturnsAsync(new List<Fan>());

            var fansController = new FansController(mockFanService.Object);

            //Act
            var result = (OkObjectResult) await fansController.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
