using System;
using xUnitTesting.Controllers;

namespace xUnitTesting.View
{
	internal class ATMView
	{
		private readonly BankController _bankController;
		private bool _isLoggedIn;

		public ATMView(BankController bankController)
		{
			_bankController = bankController;
		}

		public void WelcomePage()
		{
			Console.WriteLine("Welcome to our ATM. OWNED BY DEEZNUTS!");
		}

		public void Login()
		{
			bool exitprogram = false;

			while (!_isLoggedIn)
			{
				Console.Write("Please Login Thanks: \t");
				int pin = 0;
				try
				{
					pin = Convert.ToInt32(Console.ReadLine());
				}
				catch 
				{ 
					Console.WriteLine("please insert the value and then press enter"); 
				}

				(int attempts, string message, bool success) = _bankController.ValidatePin(pin);
				if (attempts == 0)
				{
					Console.WriteLine(message);
					_isLoggedIn = true;
				}
				else if (attempts > 0 && attempts < 3)
				{
					Console.WriteLine(message);
				}
				else if (attempts >= 3)
				{
					Console.WriteLine(message);
					exitprogram = true;
					return;
				}
			}

			if (exitprogram)
			{
				Console.WriteLine("FUCK");
				return;
			}

			Console.Clear();
			ShowMainMenu();
		}

		public void ShowMainMenu()
		{
			Console.WriteLine("1. Withdraw");
			Console.WriteLine("2. Deposit");
			Console.WriteLine("3. Check Balance");
			Console.WriteLine("4. Exit");
			Console.Write("Choose an option: ");
			int choice = int.Parse(Console.ReadLine());

			switch (choice)
			{
				case 1:
					WithdrawMoney();
					break;
				case 2:
					DepositMoney();
					break;
				case 3:
					CheckBalance();
					break;
				case 4:
					Console.WriteLine("Thank you for using the ATM. Goodbye!");
					break;
				default:
					Console.WriteLine("Invalid option. Try again.");
					ShowMainMenu();
					break;
			}
		}

		private void WithdrawMoney()
		{
			Console.Write("Enter withdrawal amount: ");
			decimal amount = decimal.Parse(Console.ReadLine());

			if (_bankController.Withdraw(amount))
			{
				Console.WriteLine($"You have successfully withdrawn {amount:C}. Your new balance is {_bankController.GetBalance():C}");
			}
			else
			{
				Console.WriteLine("Transaction failed. Invalid PIN or insufficient balance.");
			}
			ShowMainMenu();
		}

		private void DepositMoney()
		{
			Console.Write("Enter deposit amount: ");
			decimal amount = decimal.Parse(Console.ReadLine());

			if (_bankController.Deposit(amount))
			{
				Console.WriteLine($"You have successfully deposited {amount:C}. Your new balance is {_bankController.GetBalance():C}");
			}
			else
			{
				Console.WriteLine("Deposit failed. Amount must be positive.");
			}
			ShowMainMenu();
		}

		private void CheckBalance()
		{
			Console.WriteLine($"Your current balance is {_bankController.GetBalance():C}");
			ShowMainMenu();
		}
	}
}
