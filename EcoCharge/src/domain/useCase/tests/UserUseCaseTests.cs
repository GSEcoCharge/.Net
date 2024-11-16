using Xunit;
using Moq;
using EcoCharge.domain.model;
using EcoCharge.domain.repository;
using EcoCharge.domain.useCase;
using EcoCharge.infra.exception;

public class UserUseCaseTests
{
    private readonly Mock<IUserRepository> _mockRepository;
    private readonly UserUseCase _useCase;

    public UserUseCaseTests()
    {
        _mockRepository = new Mock<IUserRepository>();
        _useCase = new UserUseCase(_mockRepository.Object);
    }

    [Fact]
    public void FindById_ShouldReturnUser_WhenUserExists()
    {
        var userId = 1;
        var user = new User("Test", "test@example.com", "password", null, "2024-11-15", "Location");
        _mockRepository.Setup(repo => repo.FindById(userId)).Returns(user);

        var result = _useCase.FindById(userId);

        Assert.Equal(user, result);
    }

    [Fact]
    public void FindById_ShouldThrowNotFoundException_WhenUserDoesNotExist()
    {
        var userId = 1;

        _mockRepository
            .Setup(repo => repo.FindById(userId))
            .Throws(new NotFoundException("User with ID 1 not found."));

        var exception = Assert.Throws<NotFoundException>(() => _useCase.FindById(userId));
        Assert.Equal($"User with ID {userId} not found.", exception.Message);
    }

}