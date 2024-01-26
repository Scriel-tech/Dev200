using Backend;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class BankAccountTests
{
    [TestMethod]
    public void SavingsAccount_WithdrawWithinBalance_ShouldUpdateBalance()
    {
        var savingsAccount = new SavingsAccount(101, 1500);

        savingsAccount.Withdraw(500);

        Assert.AreEqual(1000, savingsAccount.Balance);
    }

    [TestMethod]
    public void SavingsAccount_WithdrawBelowMinimumBalance_ShouldThrowException()
    {
        var savingsAccount = new SavingsAccount(102, 2000);

        Assert.ThrowsException<WithdrawalAmountTooLargeException>(() => savingsAccount.Withdraw(1001));
    }

    [TestMethod]
    public void SavingsAccount_Deposit_ShouldUpdateBalance()
    {
        var savingsAccount = new SavingsAccount(103, 3000);

        savingsAccount.Deposit(500);

        Assert.AreEqual(3500, savingsAccount.Balance);
    }

    [TestMethod]
    public void CurrentAccount_WithdrawWithinBalanceAndOverdraft_ShouldUpdateBalance()
    {
        var currentAccount = new CurrentAccount(201);
        currentAccount.Deposit(1000);

        currentAccount.Withdraw(500);

        Assert.AreEqual(500, currentAccount.Balance);
    }

    [TestMethod]
    public void CurrentAccount_WithdrawExceedingOverdraft_ShouldThrowException()
    {
        var currentAccount = new CurrentAccount(202);
        currentAccount.Deposit(1000);

        Assert.ThrowsException<WithdrawalAmountTooLargeException>(() => currentAccount.Withdraw(150000));
    }

    [TestMethod]
    public void CurrentAccount_Deposit_ShouldUpdateBalance()
    {
        var currentAccount = new CurrentAccount(203);

        currentAccount.Deposit(1000);

        Assert.AreEqual(1000, currentAccount.Balance);
    }

    [TestMethod]
    public void BankAccountService_WithdrawFromExistingAccount_ShouldUpdateBalance()
    {
        var accountService = new BankAccountService();
        accountService.Withdraw(1, 500);

        var savingsAccount = accountService.GetAccountById(1) as SavingsAccount;

        //Assert.IsNotNull(savingsAccount);
        Assert.AreEqual(1500, savingsAccount.Balance);
    }

    [TestMethod]
    public void BankAccountService_WithdrawFromNonExistingAccount_ShouldThrowException()
    {
        var accountService = new BankAccountService();

        Assert.ThrowsException<AccountNotFoundException>(() => accountService.Withdraw(10, 500));
    }

    [TestMethod]
    public void BankAccountService_DepositToExistingAccount_ShouldUpdateBalance()
    {
        var accountService = new BankAccountService();
        accountService.Deposit(1, 500);

        var savingsAccount = accountService.GetAccountById(1) as SavingsAccount;

        //Assert.IsNotNull(savingsAccount);
        Assert.AreEqual(2500, savingsAccount.Balance);
    }

    [TestMethod]
    public void BankAccountService_DepositToNonExistingAccount_ShouldThrowException()
    {
        var accountService = new BankAccountService();

        Assert.ThrowsException<AccountNotFoundException>(() => accountService.Deposit(10, 500));
    }
}
