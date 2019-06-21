using ContactsDBAPIIntegration.Fixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContactsDBAPIIntegration.Scenarios
{
    public class AuthTest
    {




        [Fact]
        public async Task CreateUserReturnsOkResponse()
        {

            using (var client = new TestContext().Client)
            {


                var content = new StringContent("{\"email\":\"test@gmail.com\",\"password\":\"test\"}", Encoding.UTF8, "application/json");


                var response = await client.PostAsync("/api/Auth/register", content);


                response.StatusCode.Should().Be(HttpStatusCode.Created);



            }
        }





        [Fact]
        public async Task CreateUserReturnsBadRequestUserAlreadyOnDB()
        {

            using (var client = new TestContext().Client)
            {


                var content = new StringContent("{\"email\":\"test@gmail.com\",\"password\":\"test\"}", Encoding.UTF8, "application/json");


                var response = await client.PostAsync("/api/Auth/register", content);


                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);



            }
        }












    }

}
