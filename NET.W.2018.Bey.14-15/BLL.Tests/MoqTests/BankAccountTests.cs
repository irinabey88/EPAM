using BLL.Interface.Enumes;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using Moq;
using NUnit.Framework;

namespace BLL.Tests.MoqTests
{
    [TestFixture]
    class BankAccountTests
    {
        private Mock<IAccountRepository> _accountRepository;
        private Mock<INumberCreatorService> _numberService;
        private Mock<IBonusCounter> _bonusCounter;

        [SetUp]
        public void Init()
        {
            var mockAccountRepository = new Mock<IAccountRepository>();
            _accountRepository = mockAccountRepository;  
            
            var mockNumberService = new Mock<INumberCreatorService>();
            _numberService = mockNumberService;

            var mockbonusCounter = new Mock<IBonusCounter>();
            _bonusCounter = mockbonusCounter;
        }

        [TestCase("Owner1", "Owner1", AccountType.Base)]
        [TestCase("Owner2", "Owner2", AccountType.Gold)]
        [TestCase("Owner3", "Owner3", AccountType.Platinum)]
        [TestCase("Owner4", "Owner4", AccountType.Base)]
        public void CreateAccount_Test(string firstName, string lastName, AccountType type)
        {
            var accountService = new AccountService(_accountRepository.Object, _numberService.Object, _bonusCounter.Object);

            _accountRepository.Setup(n => n.Add(It.IsAny<BankAccount>())).Returns(new BankAccount(_bonusCounter.Object){FirstName = firstName, Lastname = lastName, Type = (int)type});
            accountService.CreateAccount(firstName, lastName, type);         
            
            _accountRepository.Verify(n => n.Add(It.IsAny<BankAccount>()), Times.Once);
        }

        [TestCase("Owner1", "Owner1", AccountType.Base)]
        [TestCase("Owner2", "Owner2", AccountType.Gold)]
        [TestCase("Owner3", "Owner3", AccountType.Platinum)]
        [TestCase("Owner4", "Owner4", AccountType.Base)]
        public void CloseAccount_Test(string firstName, string lastName, AccountType type)
        {
            var accountService = new AccountService(_accountRepository.Object, _numberService.Object, _bonusCounter.Object);

            _accountRepository.Setup(n => n.Update(It.IsAny<BankAccount>())).Returns(new BankAccount(_bonusCounter.Object) {Number = 1, FirstName = firstName, Lastname = lastName, Type = (int)type, IsClosed = true});
            _accountRepository.Setup(n => n.Get(It.IsAny<int>())).Returns(new BankAccount(_bonusCounter.Object) { Number = 1, FirstName = firstName, Lastname = lastName, Type = (int)type, IsClosed = false });
            accountService.CloseAccount(1);

            _accountRepository.Verify(n => n.Get(It.IsAny<int>()), Times.Once);
            _accountRepository.Verify(n => n.Update(It.Is<BankAccount>( account => account.FirstName == firstName && account.Lastname == lastName)), Times.Once);
        }

        [TestCase("Owner1", "Owner1", AccountType.Base)]
        [TestCase("Owner2", "Owner2", AccountType.Gold)]
        [TestCase("Owner3", "Owner3", AccountType.Platinum)]
        [TestCase("Owner4", "Owner4", AccountType.Base)]
        public void GetAccount_Test(string firstName, string lastName, AccountType type)
        {
            var accountService = new AccountService(_accountRepository.Object, _numberService.Object, _bonusCounter.Object);
            
            _accountRepository.Setup(n => n.Get(It.IsAny<int>())).Returns(new BankAccount(_bonusCounter.Object) { Number = 1, FirstName = firstName, Lastname = lastName, Type = (int)type, IsClosed = false });
            accountService.GetAccount(It.IsAny<int>());

            _accountRepository.Verify(n => n.Get(It.IsAny<int>()), Times.Once);
        }

        [TestCase(1, "Owner1", "Owner1", AccountType.Base, 100, 0)]
        [TestCase(2, "Owner2", "Owner2", AccountType.Gold, 35, 0)]
        [TestCase(3, "Owner3", "Owner3", AccountType.Platinum, 125, 0)]
        [TestCase(4, "Owner4", "Owner4", AccountType.Base, 345, 0)]
        public void WithDraw_Test(int number,string firstName, string lastName, AccountType type, decimal amount, int bonus)
        {
            var accountService = new AccountService(_accountRepository.Object, _numberService.Object, _bonusCounter.Object);

            _accountRepository.Setup(n => n.Get(It.IsAny<int>())).Returns(new BankAccount(_bonusCounter.Object) { Number = number, FirstName = firstName, Lastname = lastName, Type = (int)type, Amount = amount, Bonus = bonus, IsClosed = false });
            _accountRepository.Setup(n => n.Update(It.IsAny<BankAccount>())).Returns(new BankAccount(_bonusCounter.Object) { Number = number, FirstName = firstName, Lastname = lastName, Type = (int)type, Amount = amount - 10, Bonus = bonus, IsClosed = false });
            accountService.WithdrawMoney(number, 10);

            _accountRepository.Verify(n => n.Get(It.Is<int>(s => s == number)), Times.Once);
            _accountRepository.Verify(n => n.Update(It.Is<BankAccount>(account => account.FirstName == firstName && account.Lastname == lastName)), Times.Once);
        }

        [TestCase(1, "Owner1", "Owner1", AccountType.Base, 100, 0)]
        [TestCase(2, "Owner2", "Owner2", AccountType.Gold, 35, 0)]
        [TestCase(3, "Owner3", "Owner3", AccountType.Platinum, 125, 0)]
        [TestCase(4, "Owner4", "Owner4", AccountType.Base, 345, 0)]
        public void Deposit_Test(int number, string firstName, string lastName, AccountType type, decimal amount, int bonus)
        {
            var accountService = new AccountService(_accountRepository.Object, _numberService.Object, _bonusCounter.Object);

            _accountRepository.Setup(n => n.Get(It.IsAny<int>())).Returns(new BankAccount(_bonusCounter.Object) { Number = number, FirstName = firstName, Lastname = lastName, Type = (int)type, Amount = amount, Bonus = bonus, IsClosed = false });
            _accountRepository.Setup(n => n.Update(It.IsAny<BankAccount>())).Returns(new BankAccount(_bonusCounter.Object) { Number = number, FirstName = firstName, Lastname = lastName, Type = (int)type, Amount = amount + 10, Bonus = bonus, IsClosed = false });
            accountService.DepositMoney(number, 10);

            _accountRepository.Verify(n => n.Get(It.Is<int>(s => s == number)), Times.Once);
            _accountRepository.Verify(n => n.Update(It.Is<BankAccount>(account => account.FirstName == firstName && account.Lastname == lastName)), Times.Once);
        }
    }
}

