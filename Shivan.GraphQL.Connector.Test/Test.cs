using Microsoft.Extensions.DependencyInjection;
using Shivan.GraphQL.Connector.Services;
using Xunit.Abstractions;

namespace Shivan.GraphQL.Connector.Test
{
    public class Test : IClassFixture<DependencyFixture>
    {
        public string base_url = "https://business.visma.net/api/graphql-service";
        public string access_token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNCODAwQzc3NTNCNUZDMUMwNTVDOTU1RDkzQ0IxODJEMUJCN0IyQUFSUzI1NiIsIng1dCI6Ik80QU1kMU8xX0J3RlhKVmRrOHNZTFJ1M3NxbyIsInR5cCI6ImF0K0pXVCJ9.eyJpc3MiOiJodHRwczovL2Nvbm5lY3QudmlzbWEuY29tIiwibmJmIjoxNjc4MTE3MjYyLCJpYXQiOjE2NzgxMTcyNjIsImV4cCI6MTY3ODEyMDg2MiwiYXVkIjoiaHR0cHM6Ly9idXNpbmVzcy52aXNtYS5uZXQvYXBpL2dyYXBocWwtc2VydmljZSIsInNjb3BlIjpbImJ1c2luZXNzLWdyYXBocWwtc2VydmljZS1hcGk6YWNjZXNzLWdyb3VwLWJhc2VkIl0sImNsaWVudF9pZCI6Imlzdl9zaGl2YW4ifQ.E7J-8JMsJNUSDjUteodlKRbsX0LBWLeUV_MbI3bUmI7OmvxCNlMUbFxUMStWw4RSilfdGwSv-wkIWk2FUMHCknAXu6NI2VGjB-E0i9H7PhSjuZVQSPQYZScaUJYxgyljfo_5a7fgqjvmwZIRRn5vLp5aIJyY07O3-arRNHN7WM5S41zqnaCp7XkVDnB9by2QLk116HDeFFdwoMgEKAbJ5x8YbSeakTKXi9PiUd9jxRjgQWFkmNo5t7mdzCaUjSI6RrgBL3tZTAC3UWkQtAS9N17De6CFV4v4L2dgkkJ0-Dbfy7BebBe13ZQ4_suCA4jTi29z84J61uQf24vIH8ni-g";
        private DependencyFixture _fixture;

        public Test(DependencyFixture fixture, ITestOutputHelper outputHelper)
        {
            _fixture = fixture.ConfigureSingletonInstances(outputHelper);
        }

        [Fact]
        public async void GetData ()
        {
           
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
            var result = await service.GetNextBasicInfo(base_url,access_token,query);

            
            //Assert.NotEqual(result.access_token,string.Empty);
        }


        [Fact]
        public async void PostData()
        {
            //Variables = new { companyId = 3542718, assId = 1021, name = "Shivan Malek" }

            var query = @"
            mutation update
            {
            useCompany(no:3542718) 
            {
            associate_update(  filter: {associateNo: {_eq: 1021}}  value: {name: 'Shivan Malek'})
            { 
                    affectedRows
                        items {
                            name           
                    }
            }
            }
            }";

            var service = _fixture.ServiceProvider?.GetRequiredService<IVismaBusinessNXTService>();
            var result = await service.PostVBNxt(base_url, access_token, query);
        }
    }
}