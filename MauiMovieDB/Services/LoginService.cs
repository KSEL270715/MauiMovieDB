using System;
using MauiMovieDB.Interfaces;
using MauiMovieDB.Models;
using MauiMovieDB.Utils;
using Newtonsoft.Json;

namespace MauiMovieDB.Services
{
    public class LoginService : ILoginService
    {
        private readonly IAPIService _iAPIServiceLogin;
        private readonly ISecurityService _securityService;

        public LoginService(IAPIService iAPIServiceLogin, ISecurityService securityService)
        {
            _iAPIServiceLogin = iAPIServiceLogin;
            _securityService = securityService;
        }

        public async Task<bool> ValidateLoginAsync(string userName, string password)
        {
            string requestToken = await GetRequestTokenAsync();
            LoginModel loginModel = new LoginModel
            {
                username = userName,
                password = password,
                request_token = requestToken
            };
            string requestBody = JsonConvert.SerializeObject(loginModel);
            LoginResponseModel loginModelResponse = await _iAPIServiceLogin.PostRequestAsync<LoginResponseModel>(AppConstants.GetRequestValidateLogin, requestBody);
            if (loginModelResponse.success == "true")
            {
                _securityService.RequestToken = loginModelResponse.request_token;
                await CreateSessionAsync();
                await GetAccountID();
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<string> GetRequestTokenAsync()
        {
            LoginResponseModel loginModel = await _iAPIServiceLogin.GetRequestAsync<LoginResponseModel>(AppConstants.GetRequestTokenEndPoint);
            return loginModel.request_token;
        }

        private async Task CreateSessionAsync()
        {
            LoginSessionRequest loginSessionRequest = new LoginSessionRequest
            {
                RequestToken = _securityService.RequestToken
            };
            string requestBody = JsonConvert.SerializeObject(loginSessionRequest);
            LoginSessionModel loginSessionModelResponse = await _iAPIServiceLogin.PostRequestAsync<LoginSessionModel>(AppConstants.PostCreateNewSession, requestBody);
            _securityService.SessionID = loginSessionModelResponse.SessionId;
        }

        private async Task GetAccountID()
        {
            string path = "?session_id=" + _securityService.SessionID;
            AccountDetails accountDetails = await _iAPIServiceLogin.GetRequestPathAsync<AccountDetails>(AppConstants.GetAccountDetails + path);
            _securityService.AccountID = accountDetails.Id;
        }

    }

}

