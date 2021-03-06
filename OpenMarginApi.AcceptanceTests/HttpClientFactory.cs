﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.SelfHost;
using System.Net.Http.Headers;
using System.Security.Claims;
using MarkG1968.OpenMargin;

namespace MarkG1968.OpenMarginApi.AcceptanceTests
{
    class HttpClientFactory
    {
        public static HttpClient Create()
        {
            return Create("foo");
        }

        public static HttpClient Create(string userName)
        {
            var baseAddress = new Uri("http://localhost:8765");
            var config = new HttpSelfHostConfiguration(baseAddress);
            new Bootstrap().Configure(config);
            var server = new HttpSelfHostServer(config);
            var client = new HttpClient(server);
            try
            {
                client.BaseAddress = baseAddress;
                return client;
            }
            catch
            {
                client.Dispose();
                throw;
            }
        }
    }
}
