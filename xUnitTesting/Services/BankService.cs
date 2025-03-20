using xUnitTesting.Interfaces;

namespace xUnitTesting.Services
{
	internal class BankService : IBankService
	{
		private readonly IAccount _account;
		private readonly IPinValidator _pinValidator;

		public BankService(IAccount account, IPinValidator pinValidator)
		{
			_account = account;
			_pinValidator = pinValidator;
		}

		public bool Deposit(decimal amount)
		{
			return _account.Deposit(amount);
		}

		public decimal GetBalance()
		{
			return _account.GetBalance();
		}

		public bool Withdraw(decimal amount)
		{
			return _account.Withdraw(amount);
		}
	}
}
