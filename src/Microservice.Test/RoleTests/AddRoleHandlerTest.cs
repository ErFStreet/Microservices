namespace Microservice.Test.RoleTests;

public class AddRoleHandlerTest
{
    private readonly AddRoleHandler _handler;

    private readonly Mock<IRepository<Role, Guid>> _repository;

    private readonly Mock<IUnitOfWork> _unitOfWork;


    public AddRoleHandlerTest()
    {
        _repository = new Mock<IRepository<Role, Guid>>();

        _unitOfWork = new Mock<IUnitOfWork>();

        _handler = new AddRoleHandler(_repository.Object,
            _unitOfWork.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnResult()
    {
        _repository.Setup(r => r.AddAsync(It.IsAny<Role>(),
            CancellationToken.None));

        _unitOfWork.Setup(r => r.SaveChangesAsync(CancellationToken
            .None))
            .ReturnsAsync(1);

        var role = new AddRoleRequest()
        {
            Name = "Test",
        };

        var response =
            await _handler.Handle(role, CancellationToken.None);

        response.IsSuccess.Should().BeTrue();
    }
}
