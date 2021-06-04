using NUnit.Framework;
using Payment.BL.Interfaces;
using Payment.BL.Models;
using Payment.Dal.Interfaces;
using System.Collections.Generic;
using Moq;
using Payment.Dal.Models;
using System.Linq;
using Payment.BL.Services;

namespace Payment.BL.Test
{
    public class PaymentServiceTests : IPaymentService
    {       
        private Mock<IAccountDal> _accountDalMOCK;
        private Mock<IPaymentDal> _paymentDalMOCK;
        private IPaymentService _paymentService;

        [SetUp]
        public void Setup()
        {
            _accountDalMOCK = new Mock<IAccountDal>();
            _paymentDalMOCK = new Mock<IPaymentDal>();
            _paymentService = new PaymentService(_accountDalMOCK.Object, _paymentDalMOCK.Object);
        }

        [Test]
        public void CheckAccountExistsReturnsBoolean()
        {
            //Arrange
            string accountNumber = "12345";
            bool expectedReturnValue = true;
            var account = new DbAccount
            {
                AccountNumber = accountNumber
            };
            _accountDalMOCK.Setup(x => x.GetByAccountNumber(accountNumber)).Returns(account);
            
            //Act
            var returnValue = CheckAccountExists(accountNumber);

            //Assert
            Assert.AreEqual(expectedReturnValue, returnValue);
        }

        [Test]
        public void GetAccountBalanceReturnsAccountDetails()
        {
            //Arrange
            string accountNumber = "12345";
            int accountId = 1;
            double expectedReturnValue = 60;
            var account = new DbAccount
            {
                Id = accountId,
                AccountNumber = accountNumber
            };

            var payments = new List<DbPayment>
            {
                new DbPayment { Id =1, AccountId = accountId, Amount =100 },
                new DbPayment { Id =2, AccountId = accountId, Amount =-40 }
            };
            _accountDalMOCK.Setup(x => x.GetByAccountNumber(accountNumber)).Returns(account);
            _paymentDalMOCK.Setup(x => x.GetPayments(accountId)).Returns(payments);

            //Act
            var returnValue = GetAccountBalance(accountNumber);

            //Assert
            Assert.AreEqual(expectedReturnValue, returnValue.Balance);
        }

        [Test]
        public void GetPaymentsReturnsListPayment()
        {
            //Arrange
            string accountNumber = "12345";
            int accountId = 1;
            var account = new DbAccount
            {
                Id = accountId,
                AccountNumber = accountNumber
            };
            var payments = new List<DbPayment>
            {
                new DbPayment { Id =1, AccountId = accountId, Amount =100 },
                new DbPayment { Id =2, AccountId = accountId, Amount =-40 }
            };

            var expectedReturnValue = new List<Models.Payment> 
            {  
                new Models.Payment { Id = 1, Amount =100 },
                 new Models.Payment { Id = 2, Amount =-40 }
            };

            _accountDalMOCK.Setup(x => x.GetByAccountNumber(accountNumber)).Returns(account);
            _paymentDalMOCK.Setup(x => x.GetPayments(accountId)).Returns(payments);

            //Act
            var returnValue = GetPayments(accountNumber);

            //Assert
            Assert.AreEqual(expectedReturnValue.Count(), returnValue.Count());
        }

        public bool CheckAccountExists(string accountNumber)
        {
            return _paymentService.CheckAccountExists(accountNumber);
        }

        public AccountDetails GetAccountBalance(string accountNumber)
        {
            return _paymentService.GetAccountBalance(accountNumber);
        }

        public List<Models.Payment> GetPayments(string accountNumber)
        {
            return _paymentService.GetPayments(accountNumber);
        }

       
    }    
}