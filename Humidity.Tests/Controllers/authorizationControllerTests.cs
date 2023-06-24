using HumidityData.Controllers;
using HumidityData.Interfaces.IService;
using Xunit;
using Moq;
using FluentAssertions;
using AutoFixture;
using HumidityData.DTO;
using HumidityData.Models;
using Microsoft.AspNetCore.Mvc;

public class authorizationControllerTests
{
        private readonly Mock<IUserService> _userServiceMock;
        private readonly authorizationController _sut;
        private readonly Fixture _fixture;

        public authorizationControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _sut = new authorizationController(_userServiceMock.Object);
            _fixture = new Fixture();
        }

    [Fact]
    public async Task Login_ShouldReturnsOkResultWithToken_WhenUserIsExists()
    {
        // Arrange
        var request = new UserRequestDTO { };
        var user = new User { UserId = 1 };
        var response = new ResponseDTO {
            success = true,
            message = _fixture.Create<string>(),
            token = _fixture.Create<string>(), 
        };
        _userServiceMock.Setup(x => x.UserLogin(request)).ReturnsAsync(user);
        _userServiceMock.Setup(x => x.GenerateJWTToken(It.IsAny<int>())).ReturnsAsync(response);
        // Act
        var result = await _sut.Login(request);
        // Assert
        result.Should().BeOfType<OkObjectResult>().Which.Value.Should().BeEquivalentTo(response);
        _userServiceMock.Verify(x => x.UserLogin(request), Times.Once);
        _userServiceMock.Verify(x => x.GenerateJWTToken(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public async Task Login_UserDoesNotExist_ReturnsBadRequestWithErrorMessage()
    {
        // Arrange
        var request = new UserRequestDTO {};
        var user = new User { UserId = 0 };
        var response = new ResponseDTO
        {
            success = false,
            message = "user does not exist",
        };
        _userServiceMock.Setup(x => x.UserLogin(request)).ReturnsAsync(user);
        // Act
        var result = await _sut.Login(request);
        // Assert
        result.Should().BeOfType<BadRequestObjectResult>()
            .Which.Value.Should().BeEquivalentTo(response);
        _userServiceMock.Verify(x => x.UserLogin(request), Times.Once);
        _userServiceMock.Verify(x => x.GenerateJWTToken(It.IsAny<int>()), Times.Never);
    }

    [Fact]
    public async Task Login_TokenGenerationFails_ReturnsBadRequestWithErrorMessage()
    {
        // Arrange
        var request = new UserRequestDTO {};
        var user = new User { UserId = 1 };
        _userServiceMock.Setup(x => x.UserLogin(request)).ReturnsAsync(user);
        _userServiceMock.Setup(x => x.GenerateJWTToken(It.IsAny<int>())).ReturnsAsync((ResponseDTO)null);
        // Act
        var result = await _sut.Login(request);
        // Assert
        result.Should().BeOfType<BadRequestObjectResult>()
            .Which.Value.Should().Be("Token generation failure");
        _userServiceMock.Verify(x => x.UserLogin(request), Times.Once);
        _userServiceMock.Verify(x => x.GenerateJWTToken((int)user.UserId), Times.Once);
    }
}