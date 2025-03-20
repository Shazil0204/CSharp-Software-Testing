using System;
using xUnitTesting.Controllers;
using xUnitTesting.Models;
using xUnitTesting.Services;
using xUnitTesting.View;

namespace xUnitTesting
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Account account = new Account(1234, 1000);
			PinValidator pinValidator = new PinValidator(1234);
			BankService bankService = new BankService(account, pinValidator);
			BankController bankController = new BankController(bankService, pinValidator);
			ATMView atmView = new ATMView(bankController);

			atmView.WelcomePage();
			atmView.Login();

			Console.ReadKey();
		}
	}
}
