using Backend;

class Program
{
    static void Main()
    {
        // Example usage
        var accountService = new BankAccountService();

        // Deposit and withdraw from savings account
        accountService.OpenSavingsAccount(5, 1500);
        accountService.Deposit(5, 500);
        accountService.Withdraw(5, 200);

        // Deposit and withdraw from current account
        accountService.OpenCurrentAccount(6);
        accountService.Deposit(6, 2000);
        accountService.Withdraw(6, 1500);
    }
}