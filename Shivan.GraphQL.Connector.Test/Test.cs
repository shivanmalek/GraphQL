using Microsoft.Extensions.DependencyInjection;
using Shivan.GraphQL.Connector.Services;
using Xunit.Abstractions;

namespace Shivan.GraphQL.Connector.Test
{
    public class Test : IClassFixture<DependencyFixture>
    {

        private DependencyFixture _fixture;

        public Test(DependencyFixture fixture, ITestOutputHelper outputHelper)
        {
            _fixture = fixture.ConfigureSingletonInstances(outputHelper);
        }

        [Fact]
        public async void GetData ()
        {
            string base_url = "https://business.visma.net/api/graphql-service";
            string access_token      = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNCODAwQzc3NTNCNUZDMUMwNTVDOTU1RDkzQ0IxODJEMUJCN0IyQUFSUzI1NiIsIng1dCI6Ik80QU1kMU8xX0J3RlhKVmRrOHNZTFJ1M3NxbyIsInR5cCI6ImF0K0pXVCJ9.eyJpc3MiOiJodHRwczovL2Nvbm5lY3QudmlzbWEuY29tIiwibmJmIjoxNjc3NzU0NjMwLCJpYXQiOjE2Nzc3NTQ2MzAsImV4cCI6MTY3Nzc1ODIzMCwiYXVkIjoiaHR0cHM6Ly9idXNpbmVzcy52aXNtYS5uZXQvYXBpL2dyYXBocWwtc2VydmljZSIsInNjb3BlIjpbImJ1c2luZXNzLWdyYXBocWwtc2VydmljZS1hcGk6YWNjZXNzLWdyb3VwLWJhc2VkIl0sImNsaWVudF9pZCI6Imlzdl9zaGl2YW4ifQ.fQIQmNOZiUmJuyrrgLOwXfHOXKB0LQ4pShC4eUrlgMYeLVAKpP7y_m69_UN-Y1EXqjJWdG2ynbhZLrB0eJwmR3Op7du9E--3ilKDRGhmsbnx5Bs_0gXHTnCYbCt6n4fVv5e-FxXWQlQhPSa6BWvc_kB6r8PT0EGTHrA8eB3MztpxlHBkCCv8oEULh5Z5fKdZeoXuX737M0Ka_T4yFrOws9cHqdgxef4svalBFs7k9GVPpFoA23toymKoI_PrIzJN1rlKpXsbskEtbbEA1b-5Y-ZubjqSJwXovpjFzUB1zhyYCjxbzxzrmDQJkP0FdI1eIIJ2-1kAsKzym8JLK9z7kQ";
            var query = @"
            {
            availableCustomers {
             totalCount
              items {
                name
                vismaNetCustomerId
             }
            }
            availableCompanies {
             totalCount
              items {
                name
                vismaNetCompanyId
              }
            }
            }";


            var service = _fixture.ServiceProvider?.GetRequiredService<IVismaBusinessNXTService>();
            var result = await service.GetGithubUser(base_url,access_token,query);

            
            //Assert.NotEqual(result.access_token,string.Empty);
        }
    }
}