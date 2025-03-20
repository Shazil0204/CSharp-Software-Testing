namespace xUnitTesting.Interfaces
{
	internal interface IBankService
	{
		bool Withdraw(decimal amount);
		bool Deposit(decimal amount);
		decimal GetBalance();
	}
}
