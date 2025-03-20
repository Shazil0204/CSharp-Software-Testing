namespace xUnitTesting.Interfaces
{
	internal interface IPinValidator
	{
		(int, string, bool) ValidatePin(int enteredPin);
	}
}
