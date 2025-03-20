using xUnitTesting.Interfaces;

namespace xUnitTesting.Controllers
{
	internal class BankController
	{
		private readonly IBankService _bankService;
		private readonly IPinValidator _pinValidator;

		public BankController(IBankService bankService, IPinValidator pinValidator)
		{
			_bankService = bankService;
			_pinValidator = pinValidator;
		}

		public (int, string, bool) ValidatePin(int enteredPin)
		{
			return _pinValidator.ValidatePin(enteredPin);
		}

		public bool Deposit(decimal amount)
		{
			return _bankService.Deposit(amount);
		}

		public bool Withdraw(decimal amount)
		{
			return _bankService.Withdraw(amount);
		}

		public decimal GetBalance()
		{
			return _bankService.GetBalance();
		}
	}
}
