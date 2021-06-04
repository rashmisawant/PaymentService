using Payment.Client.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Payment.Client.Services
{
    public class ClientCommon 
    {
        private readonly RestClient _client;

        public ClientCommon(RestClient client)
        {
            _client = client;
        }

        public Tres SendAndHandleResponse<Tres>(RestRequest request)
            where Tres : class, new()
        {
            var response = _client.Execute<Tres>(request);

            if (response.ErrorMessage != null)
                throw new Exception("Webservice response returned an error message: " 
                    + response.ErrorMessage);

            if (response.ErrorException != null)
                throw new Exception("Webservice response returned an exception. " +
                    "Check inner exception for more details. ", response.ErrorException);

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data;

            if (response.StatusCode == HttpStatusCode.Forbidden)
                return null;

            throw new Exception("Webservice response did not return OK or Forbidden. " +
                "Response content was: " + response.Content);
        }
    }
}
