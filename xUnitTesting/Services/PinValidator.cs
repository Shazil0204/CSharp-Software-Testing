using xUnitTesting.Interfaces;

namespace xUnitTesting.Services
{
	internal class PinValidator : IPinValidator
	{
		private readonly int _correctPin;
		private int _failedAttempts = 0;
		private const int _maxAttempts = 3;
		public PinValidator(int pin)
		{
			_correctPin = pin;
		}
		public (int, string, bool) ValidatePin(int enteredPin)
		{
			if (_failedAttempts >= _maxAttempts)
			{
				return (_failedAttempts,"You have already failed 3 attempts! Your bank card has been blocked Manike!", false);
			}
			if (enteredPin == _correctPin)
			{
				_failedAttempts = 0;
				return (_failedAttempts, "Welcome Manike Bank Customer", true);
			}
			else
			{
				_failedAttempts++;
				return (_failedAttempts, "Wrong Password. Please try again \nLogin Attempts: " + _failedAttempts, false);
			}
		}
	}
}
