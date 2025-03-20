using xUnitTesting.Interfaces;

namespace xUnitTesting.Models
{
	internal class Account : IAccount
	{
		public decimal Balance;
		public int PIN {  get; private set; }

		public Account(int pin, decimal initialBalance)
		{
			PIN = pin;
			Balance = initialBalance > 0 ? initialBalance : 0;
		}

		public bool Deposit(decimal amount)
		{
			if (amount != 0)
			{
				Balance += amount;
				return true;
			}
			return false;
		}

		public bool Withdraw(decimal amount)
		{
			if (amount > 0 && amount <= Balance)
			{
				Balance -= amount;
				return true;
			}
			return false;

		}

		public decimal GetBalance()
		{
			return Balance;
		}
	}
}
