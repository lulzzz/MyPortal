﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Requests;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;

namespace MyPortal.Logic.Services
{
    public class GSuiteIntegrationService : BaseService
    {
        protected async Task<BaseClientService.Initializer> GetInitializer(Guid userId)
        {
            var scopes = new[]
            {
                DriveService.Scope.Drive
            };

            UserCredential credential;

            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "1052307277247-tjvhmhpf6hch5c2vfo17nmsuqcqga1u6.apps.googleusercontent.com",
                    ClientSecret = "vMmmZ7tni2Vs_yfsXbXCDP0H"
                },
                Scopes = scopes,
                DataStore = new FileDataStore("Store")
            });

            dsAuthorizationBroker.RedirectUri = "http://localhost:5001/signin-google";

            credential = await dsAuthorizationBroker.AuthorizeAsync(flow.ClientSecrets, scopes,
                "11richr1@vle.harrodsschool.co.uk", CancellationToken.None, new FileDataStore("MyPortal.GSuite"));

            return new BaseClientService.Initializer
            {
                ApplicationName = "MyPortal",
                HttpClientInitializer = credential
            };
        }
    }

    public class dsAuthorizationBroker : GoogleWebAuthorizationBroker
    {
        public static string RedirectUri;

        public new static async Task<UserCredential> AuthorizeAsync(
            ClientSecrets clientSecrets,
            IEnumerable<string> scopes,
            string user,
            CancellationToken taskCancellationToken,
            IDataStore dataStore = null)
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = clientSecrets,
            };
            return await AuthorizeAsyncCore(initializer, scopes, user,
                taskCancellationToken, dataStore).ConfigureAwait(false);
        }

        private static async Task<UserCredential> AuthorizeAsyncCore(
            GoogleAuthorizationCodeFlow.Initializer initializer,
            IEnumerable<string> scopes,
            string user,
            CancellationToken taskCancellationToken,
            IDataStore dataStore)
        {
            initializer.Scopes = scopes;
            initializer.DataStore = dataStore ?? new FileDataStore(Folder);
            var flow = new dsAuthorizationCodeFlow(initializer);
            return await new AuthorizationCodeInstalledApp(flow,
                    new LocalServerCodeReceiver())
                .AuthorizeAsync(user, taskCancellationToken).ConfigureAwait(false);
        }
    }


    public class dsAuthorizationCodeFlow : GoogleAuthorizationCodeFlow
    {
        public dsAuthorizationCodeFlow(Initializer initializer)
            : base(initializer) { }

        public override AuthorizationCodeRequestUrl
            CreateAuthorizationCodeRequest(string redirectUri)
        {
            return base.CreateAuthorizationCodeRequest(dsAuthorizationBroker.RedirectUri);
        }
    }
}
