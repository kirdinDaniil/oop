using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Moks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class ReplenishmentBalanceTest
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
        if (currentAccount.Account is null)
            Assert.Fail();
        decimal previousBalance = currentAccount.Account.Balance;
        decimal newBalance = 100;
        accountService.UpdateBalance(1, newBalance);

        // Assert
        Assert.True(currentAccount.Account.Balance == previousBalance + newBalance);
    }
}