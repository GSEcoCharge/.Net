using Xunit;
using Moq;
using FluentValidation;
using FluentValidation.Results;
using EcoCharge.domain.model;
using EcoCharge.adapter.input;
using EcoCharge.domain.useCase;
using EcoCharge.domain.useCase.dtos;
using EcoCharge.infra.exception;

public class UserAdapterTests
{
    private readonly Mock<IUserUseCase> _mockUseCase;
    private readonly Mock<IValidator<User>> _mockValidator;
    private readonly UserAdapter _adapter;

    public UserAdapterTests()
    {
        _mockUseCase = new Mock<IUserUseCase>();
        _mockValidator = new Mock<IValidator<User>>();
        _adapter = new UserAdapter(_mockUseCase.Object, _mockValidator.Object);
    }

    [Fact]
    public void Create_ShouldCallUseCase_WhenUserIsValid()
    {
        var user = new User("Test", "test@example.com", "password", null, "2024-11-15", "Location");
        _mockValidator.Setup(v => v.Validate(user)).Returns(new ValidationResult());

        _adapter.Create(user);

        _mockUseCase.Verify(uc => uc.Create(user), Times.Once);
    }

    [Fact]
    public void Create_ShouldThrowInvalidException_WhenUserIsInvalid()
    {
        var user = new User("", "", "password", null, "2024-11-15", "Location");
        _mockValidator.Setup(v => v.Validate(user)).Returns(
            new ValidationResult(new[] { new ValidationFailure("Name", "Name is required") }));

        var ex = Assert.Throws<InvalidException>(() => _adapter.Create(user));
        Assert.Contains("Name is required", ex.Message);
    }
}