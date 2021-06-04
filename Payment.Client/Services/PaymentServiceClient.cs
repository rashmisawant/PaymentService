using Payment.Client.Interfaces;
using Payment.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payment.Client.Services
{
    public class PaymentServiceClient : IPaymentServiceClient
    {
        private readonly ClientCommon _clientCommon;
        public PaymentServiceClient(Uri authServer)
        {
            _clientCommon = new ClientCommon(new RestClient(authServer));
        }

        public AccountResult GetBalance(string accountNumber)
        {            
               var request = new RestRequest("api/account/balance", Method.GET)
               { RequestFormat = DataFormat.Json };

            request.AddParameter("accountNumber", accountNumber);           

            return _clientCommon.SendAndHandleResponse<AccountResult>(request);
        }

        public List<PaymentResult> GetPayments(string accountNumber)
        {
            var request = new RestRequest("api/account/payments", Method.GET)
            { RequestFormat = DataFormat.Json };

            request.AddParameter("accountNumber", accountNumber);

            return _clientCommon.SendAndHandleResponse<List<PaymentResult>>(request);
        }
    }
}