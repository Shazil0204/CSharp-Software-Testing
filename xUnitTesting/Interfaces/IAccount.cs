namespace xUnitTesting.Interfaces
{
	internal interface IAccount
	{
		bool Withdraw(decimal amount);
		bool Deposit(decimal amount);
		decimal GetBalance();

	}
}

