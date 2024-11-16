using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using EcoCharge.app.controllerk;
using EcoCharge.domain.model;
using EcoCharge.infra.exception;
using EcoCharge.adapter.input;
using EcoCharge.adapter.input.dtos;

public class UserControllerTests
{
    private readonly Mock<IUserAdapter> _mockUserAdapter;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockUserAdapter = new Mock<IUserAdapter>();
        _controller = new UserController(_mockUserAdapter.Object);
    }

    [Fact]
    public void FindById_ShouldReturnOk_WhenUserExists()
    {
        var userId = 1;
        var user = new User("Test", "test@example.com", "password", null, "2024-11-15", "Location");
        _mockUserAdapter.Setup(adapter => adapter.FindById(userId)).Returns(user);

        var result = _controller.FindById(userId);

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(user, okResult.Value);
    }

    [Fact]
    public void FindById_ShouldReturnNotFound_WhenUserDoesNotExist()
    {
        var userId = 1;
        _mockUserAdapter.Setup(adapter => adapter.FindById(userId)).Throws(new NotFoundException("User not found"));

        var result = _controller.FindById(userId);

        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
        Assert.Contains("User not found", notFoundResult.Value.ToString());
    }

    [Fact]
    public void Create_ShouldReturnCreated_WhenUserIsValid()
    {
        var user = new User("Test", "test@example.com", "password", null, "2024-11-15", "Location");
        _mockUserAdapter.Setup(adapter => adapter.Create(user));

        var result = _controller.Create(user);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal(user, createdResult.Value);
    }
}