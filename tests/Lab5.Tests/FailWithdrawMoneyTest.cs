using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using DomainModel.Entities.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class FailWithdrawMoneyTest
{
    [Fact]
    public void SimulateCashMachine()
    {
        // Arrange
        var repository = new AccountRepositoryMock();
        var currentAccount = new CurrentAccount
        {
            Account = repository.GetAccountById(1),
        };
        var accountService = new AccountService(currentAccount, repository);

        // Act
        Result result = accountService.UpdateBalance(1, -1000);

        // Assert
        Assert.True(result is FailResult);
    }
}