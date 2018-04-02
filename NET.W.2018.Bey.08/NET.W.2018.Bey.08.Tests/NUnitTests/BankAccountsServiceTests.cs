namespace NET.W._2018.Bey._08.Tests.NUnitTests
{
    using System;
    using System.IO;
    using System.Linq;
    using Enum;
    using Exception;
    using Exception.User;
    using Interfaces.Services;
    using Models.BankAccount;
    using NUnit.Framework;
    using Repositories;
    using Services;

    [TestFixture]
    public class BankAccountsServiceTests
    {
        private readonly string _fileSourceAccounts = @"D:\Test\AccountStorage.txt";
        private readonly string _fileSourceUsers = @"D:\Test\UserStorage.txt";
        private IBankAccountService<BankAccount> _bankAccountService;
        
        public BankAccountsServiceTests()
        {
            if (File.Exists(this._fileSourceAccounts))
            {
                File.Delete(this._fileSourceAccounts);
            }

            if (File.Exists(this._fileSourceUsers))
            {
                File.Delete(this._fileSourceUsers);
            }

            var user1 = new BankUser("User1", "User1");
            var user2 = new BankUser("User2", "User2");
            var user3 = new BankUser("User3", "User3");

            this._bankAccountService = new BankAccountsService(new BankAccountsStorage(this._fileSourceAccounts), new UserStorage(this._fileSourceUsers));

            this._bankAccountService.CreateAccount(user2, BankAccountType.Base);
            this._bankAccountService.CreateAccount(user3, BankAccountType.Gold);
            this._bankAccountService.CreateAccount(user1, BankAccountType.Platinum);
        }

        [Test]
        public void BankAccountsService_FindUserAccounts_InvalidInputData_Test()
        {
            Assert.Throws<ArgumentNullException>(() => this._bankAccountService.FindUserAccounts(string.Empty, "user4"));
        }

        [Test]
        public void BankAccountsService_FindUserAccounts_InvalidUserData_Test()
        {
            Assert.Throws<NotFoundUserException>(() => this._bankAccountService.FindUserAccounts("user4", "user4"));
        }

        [Test]
        public void BankAccountsService_FindUserAccounts_ValidData_Test()
        {
            Assert.GreaterOrEqual(1, this._bankAccountService.FindUserAccounts("User2", "User2").Count());
        }

        [Test]
        public void BankAccountsService_CloseAccount_InvalidInputData_Test()
        {
            Assert.Throws<GetAccountException>(() => this._bankAccountService.CloseAccount(string.Empty));
        }

        [Test]
        public void BankAccountsService_CloseAccount_ValidInputData_Test()
        {
            var accountList = _bankAccountService.FindUserAccounts("User1", "User1");

            Assert.IsTrue(this._bankAccountService.CloseAccount(accountList.ToArray()[0].AccountId).IsClosed);
        }

        [Test]
        public void BankAccountsService_CreateAccount_InvalidInputData_Test()
        {
            Assert.Throws<ArgumentNullException>(() => this._bankAccountService.CreateAccount(null, BankAccountType.Platinum));            
        }

        [Test]
        public void BankAccountsService_CreateAccount_ValidInputData_Test()
        {
            var user = new BankUser("User5", "User5");
            var account = this._bankAccountService.CreateAccount(user, BankAccountType.Platinum);

            Assert.NotNull(this._bankAccountService.GetAccount(account.AccountId));
        }

        [Test]
        public void BankAccountsService_GetAccount_InvalidInputData_Test()
        {
            Assert.Throws<ArgumentNullException>(() => this._bankAccountService.GetAccount(null));
        }

        [Test]
        public void BankAccountsService_GetAccount_ValidInputData_Test()
        {
            var user = new BankUser("User6", "User6");
            var account = this._bankAccountService.CreateAccount(user, BankAccountType.Platinum);

            Assert.NotNull(this._bankAccountService.GetAccount(account.AccountId));
        }

        [Test]
        public void BankAccountsService_GetAllAccounts_Test()
        {
            Assert.AreEqual(5, this._bankAccountService.GetAllAccounts().Count());
        }

        [Test]
        public void BankAccountsService_DepositMoney_InvalidIdAccount_Test()
        {
            Assert.Throws<GetAccountException>(() => this._bankAccountService.DepositMoney("34567", 567));
        }

        [Test]
        public void BankAccountsService_DepositMoney_InvalidAmount_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User2", "User2").ToArray();

            Assert.Throws<ZeroAmountOperatioException>(() => this._bankAccountService.DepositMoney(accounts[0].AccountId, 0));
        }

        [Test]
        public void BankAccountsService_DepositMoney_SuccessOperation_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User2", "User2").ToArray();

            Assert.AreEqual(2000, this._bankAccountService.DepositMoney(accounts[0].AccountId, 2000).Amount);
            Assert.AreEqual(2050, this._bankAccountService.DepositMoney(accounts[0].AccountId, 50).Amount);
        }

        [Test]
        public void BankAccountsService_DepositMoney_ClosedAccount_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User1", "User1").ToArray();

            Assert.Throws<ClosedAccountException>(() => this._bankAccountService.DepositMoney(accounts[0].AccountId, 0));
        }

        [Test]
        public void BankAccountsService_WithdrwaMoney_InvalidIdAccount_Test()
        {
            Assert.Throws<GetAccountException>(() => this._bankAccountService.WithdrawMoney("34567", 567));
        }

        [Test]
        public void BankAccountsService_WithdrwaMoney_InvalidAmount_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User3", "User3").ToArray();

            Assert.Throws<ZeroAmountOperatioException>(() => this._bankAccountService.WithdrawMoney(accounts[0].AccountId, 0));
        }

        [Test]
        public void BankAccountsService_WithdrwaMoney_SuccessOperation_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User2", "User2").ToArray();

            Assert.AreEqual(1950, this._bankAccountService.WithdrawMoney(accounts[0].AccountId, 100).Amount);
            Assert.AreEqual(1920, this._bankAccountService.WithdrawMoney(accounts[0].AccountId, 30).Amount);
        }

        [Test]
        public void BankAccountsService_WithdrwaMoney_ClosedAccount_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User1", "User1").ToArray();

            Assert.Throws<ClosedAccountException>(() => this._bankAccountService.WithdrawMoney(accounts[0].AccountId, 0));
        }

        [Test]
        public void BankAccountsService_WithdrwaMoney_NotEnoughMoney_Test()
        {
            var accounts = this._bankAccountService.FindUserAccounts("User2", "User2").ToArray();

            Assert.Throws<WithdrawException>(() => this._bankAccountService.WithdrawMoney(accounts[0].AccountId, 3000));
        }
    }
}