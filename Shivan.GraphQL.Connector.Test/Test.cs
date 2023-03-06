using Microsoft.Extensions.DependencyInjection;
using Shivan.GraphQL.Connector.Services;
using Xunit.Abstractions;

namespace Shivan.GraphQL.Connector.Test
{
    public class Test : IClassFixture<DependencyFixture>
    {
        public string base_url = "https://business.visma.net/api/graphql-service";
        public string access_token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjNCODAwQzc3NTNCNUZDMUMwNTVDOTU1RDkzQ0IxODJEMUJCN0IyQUFSUzI1NiIsIng1dCI6Ik80QU1kMU8xX0J3RlhKVmRrOHNZTFJ1M3NxbyIsInR5cCI6ImF0K0pXVCJ9.eyJpc3MiOiJodHRwczovL2Nvbm5lY3QudmlzbWEuY29tIiwibmJmIjoxNjc4MTI4NzczLCJpYXQiOjE2NzgxMjg3NzMsImV4cCI6MTY3ODEzMjM3MywiYXVkIjoiaHR0cHM6Ly9idXNpbmVzcy52aXNtYS5uZXQvYXBpL2dyYXBocWwtc2VydmljZSIsInNjb3BlIjpbImJ1c2luZXNzLWdyYXBocWwtc2VydmljZS1hcGk6YWNjZXNzLWdyb3VwLWJhc2VkIl0sImNsaWVudF9pZCI6Imlzdl9zaGl2YW4ifQ.hkT7omJ5TzaPZydzTXrNO3jKe7pxXxuwSGWVkqUVnY0cMPdIVD2Js2EH1oMzgp2H6lV9DwMRwsa_jMkBu59FgyXLu0Og2n6mrhproe-6LM3RAv2rb0JEW04ASRWehckB8BU4cny453HHZG0wCfKMhrGl6w90STMDLrs7JFmxm1nlg91c_oOAZXF_DyjUU6mfrejuIB1a-E_jO3a5qaRDAZ2cjqbX6JAuoTXJoKSL_fMYv24cTQBJpLNdENJDIwtUiOZ7qrpT8ilxKNlPtPwRYxpxxAVLWO3UYzjV_jeIL8fMUrm5ZBtYwRO5Vg0Bxwy_KekzOPBHg-XTqLfEaf0k2A";
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
            var query = @"
            mutation update
            {
            useCompany(no:3542718) 
            {
            associate_update(  filter: {associateNo: {_eq: 1021}}  value: {name: ""Shivan Malek""})
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