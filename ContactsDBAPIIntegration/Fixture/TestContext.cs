using ContactsDBAPI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ContactsDBAPIIntegration.Fixture
{
    public class TestContext : IDisposable
    {

        public HttpClient Client { get; private set; }
        public TestServer Server { get; set; }

        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            Server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());

            Client = Server.CreateClient();
        }

        public TService GetService<TService>()
           where TService : class
        {
            return Server?.Host?.Services?.GetService(typeof(TService)) as TService;
        }


        public void Dispose()
        {
            Server?.Dispose();
            Client?.Dispose();
        }
    }
}
