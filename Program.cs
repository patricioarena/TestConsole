using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestConsole.Services;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup startup = new Startup();
            IServiceProvider serviceProvider = startup.ConfigureServices()
                .BuildServiceProvider();

            #region Set Services
            //var rolesServices = serviceProvider.GetService<IRolesServices>();
            //var people = serviceProvider.GetService<IPeople>();
            //var encryptServices = serviceProvider.GetService<IEncryptService>();
            //var tokenServices = serviceProvider.GetService<ITokenService>();
            //var loggerServices = serviceProvider.GetService<ILogger<Startup>>();
            var documentServices = serviceProvider.GetService<IDocumentoService>();

            #endregion Set Services

            //loggerServices.LogInformation("hello world");

            //var rolesInJson = rolesServices.readJson();
            //rolesServices.printRoles(rolesServices.ConfigToQueue2(rolesInJson));

            //var aPersonA = people.GetPersonByKey(105);
            //var aPersonB = people.GetPersonByLegajo(105);
            //var Dictionary = people.Dictionary();

            //Console.WriteLine(aPersonA.Nombre);
            //Console.WriteLine(aPersonB.Nombre);

            //foreach (var index in Enumerable.Range(100, Dictionary.Count))
            //{
            //    Console.WriteLine($"{Dictionary[index].Id} is {Dictionary[index].Nombre} {Dictionary[index].Apellido}");
            //}

            // Console.WriteLine("==========================================================");
            // var encrypt_username = encryptServices.EncryptString("https://github.com/patricioarena/App_Helper-Firmador-XMLdesign");
            // Console.WriteLine($"encrypt_username  {encrypt_username}");
            // Console.WriteLine("==========================================================");
            // var decrypt_username = encryptServices.DecryptString(encrypt_username);
            // Console.WriteLine($"decrypt_username  {decrypt_username}");
            // Console.WriteLine("==========================================================");

            //Console.WriteLine("==========================================================");
            //Cliente web
            //WebClient client = new WebClient ();
            //string reply = client.DownloadString ("https://restcountries.eu/rest/v2/name/CZ");

            //Console.WriteLine($"Response:  {reply}");
            //Console.WriteLine("==========================================================");

            //var token = tokenServices.JWTEncode("test@test.com");
            //Console.WriteLine("==========================================================");
            //Console.WriteLine($"Token:  { token }");
            //Console.WriteLine("==========================================================");

            //List<Claim> listClaims = tokenServices.JWTDecoder(token);
            //Console.WriteLine($"ListClaims:  { listClaims }");

            //Console.WriteLine("==========================================================");
            //for (int i = 0; i < (listClaims.Count()); i++)
            //{
            //    Console.WriteLine(listClaims.ElementAt(i));
            //}
            //Console.WriteLine("==========================================================");


            //string identityserver4_Access_Token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IkYzQnh4OENPenJxblRVVzNTd0VZR0EiLCJ0eXAiOiJhdCtqd3QifQ.eyJuYmYiOjE1ODA5MTU4NDQsImV4cCI6MTU4MDkxOTE0NCwiaXNzIjoiaHR0cHM6Ly9zZXJ2aWNpb3NkZXYuZmVwYmEuZ292LmFyL2lkZW50aXR5c2VydmVyIiwiYXVkIjpbImFwaTEiLCJyb2xlcyJdLCJjbGllbnRfaWQiOiJhbmd1bGFyZGV2c2VydmVyIiwic3ViIjoiVkx4bHlaQzBJM2hOU1lIUkJjaEtqV3p4VFVmM0pkeXdfQ3h6Rzh5dlluNCIsImF1dGhfdGltZSI6MTU4MDkxNTg0MiwiaWRwIjoiV2luZG93cyIsInJvbGUiOlsiRklTQ0FMSUFcXFVzdWFyaW9zIGRlbCBkb21pbmlvIiwiVG9kb3MiLCJERVZTRVJWRVIwM1xcV2ViIERlcGxveWVycyBwYXJhIEFwbGljYWNpb25lcyIsIkRFVlNFUlZFUjAzXFxXZWIgRGVwbG95ZXJzIHBhcmEgU2VydmljaW9zIiwiQlVJTFRJTlxcQWRtaW5pc3RyYWRvcmVzIiwiQlVJTFRJTlxcVXN1YXJpb3MgZGUgZXNjcml0b3JpbyByZW1vdG8iLCJCVUlMVElOXFxVc3VhcmlvcyIsIk5UIEFVVEhPUklUWVxcTkVUV09SSyIsIk5UIEFVVEhPUklUWVxcVXN1YXJpb3MgYXV0ZW50aWZpY2Fkb3MiLCJOVCBBVVRIT1JJVFlcXEVzdGEgY29tcGHDscOtYSIsIkZJU0NBTElBXFxfQ0lGRV9ERVNBUlJPTExPIiwiRklTQ0FMSUFcXF9Dcml0ZXJpYV9FZGl0b3Jlc19UZXN0IiwiRklTQ0FMSUFcXF9Dcml0ZXJpYV9BZG1pbmlzdHJhZG9yZXNfVGVzdCIsIkZJU0NBTElBXFxfQ3JpdGVyaWFfTGVjdG9yZXNfVGVzdCIsIkZJU0NBTElBXFxfQ0lGRSIsIkZJU0NBTElBXFxfTGVjdHVyYURvY3VtZW50b3NDSUZFIiwiRklTQ0FMSUFcXERCQXNfVGVzdCIsIkZJU0NBTElBXFxfQ29uc3VNZXNhZGVFbnRyYWRhcyIsIkZJU0NBTElBXFxfQ3JpdGVyaWFfRXhlY3V0ZSIsIkZJU0NBTElBXFxfQ29uc3VQZXJzb25hbCIsIkZJU0NBTElBXFxfdmlzdGFkaWdpdGFsIiwiRklTQ0FMSUFcXF9DYXJnYW5hYm9nYWRvcyIsIkZJU0NBTElBXFxfQ29uc3VWYWNhbnRlcyIsIkZJU0NBTElBXFxfQ3JpdGVyaWFfTGVjdG9yZXMiLCJGSVNDQUxJQVxcX0NvbnN1UmVnSnVpY2lvcyIsIkZJU0NBTElBXFxfZmVwYmFwdWJfdG9rZW4iLCJGSVNDQUxJQVxcX0NvbnN1VGVzb3JlcmlhIiwiRklTQ0FMSUFcXF9NaVBlcmZpbF9leGVjdXRlIiwiRklTQ0FMSUFcXF9Dcml0ZXJpYV9leGVjdXRlX3Rlc3QiLCJGSVNDQUxJQVxcX1RhcmVhc1NlY2Z5dCIsIkZJU0NBTElBXFxXZWJEZXBsb3llcnNfZGV2IiwiRklTQ0FMSUFcXF9Db25zdVNlbnRlbmNpYSIsIkZJU0NBTElBXFxfRW1wbGVhZG9zRmlzY2FsaWEiLCJGSVNDQUxJQVxcX1BlcnNvbmFsU2VkZTF5NjAiLCJGSVNDQUxJQVxcQFZhY2FudGVzQ29ucyIsIkZJU0NBTElBXFxDb25zdWx0YSBWYWNhbnRlcyIsIkZJU0NBTElBXFxATGFib3JhbENvbnMiLCJGSVNDQUxJQVxcQ29uc3VsdGEgTWVzYSIsIkZJU0NBTElBXFxAVmlzdGFzQ29ucyIsIkZJU0NBTElBXFxjb25zdVRlc29yZXJpYSIsIkZJU0NBTElBXFxASW50ZXJpb3JDb25zIiwiRklTQ0FMSUFcXENvbnN1bHRhZGVQZXJzb25hbCIsIkZJU0NBTElBXFxAdmlzdGFkaWdpdGFsIiwiRklTQ0FMSUFcXEBUYXJlYXNTZWNmeXQiLCJGSVNDQUxJQVxcQ29uc3VsdGFTZW50ZW5jaWEiLCJGSVNDQUxJQVxcQENvbnRBZG1Db25zIiwiRklTQ0FMSUFcXEBDb25zZWpvZGVleHByb3BpYWNpb25lcyIsIkZJU0NBTElBXFxDYXJnYWRlQ29udGFibGUiLCJGSVNDQUxJQVxcQEludW5kYWNpb25lc0NvbnMiLCJGSVNDQUxJQVxcQEh5cGVydGV4dG9BY2Nlc29XZWIiLCJGSVNDQUxJQVxcQEp1ZExQY29ucyIsIkZJU0NBTElBXFxAQmlibGlvQ29ucyIsIkZJU0NBTElBXFxDb25zdWx0YSBKdWljaW9zIiwiRklTQ0FMSUFcXEBDb250cmFkaWN0b3JpbzFDb25zIiwiRklTQ0FMSUFcXENhcmdhbk1vdkFib2dhZG9zIiwiRklTQ0FMSUFcXEBDb250cmFkaWN0b3JpbzJDb25zIiwiTlQgQVVUSE9SSVRZXFxBdXRlbnRpY2FjacOzbiBOVExNIl0sInNjb3BlIjpbIm9wZW5pZCIsInByb2ZpbGUiLCJlbWFpbCIsImFwaTEiLCJyb2xlcyIsIm9mZmxpbmVfYWNjZXNzIl0sImFtciI6WyJleHRlcm5hbCJdfQ.MCcG8zSfMGViES12s5YUOkKvs4D-ZnD3KDN5m_rbJJ-24y0kVWEiOzDiG0VZbUTULI0k-A37hoc-q7L9ZPZT3_AZwEApiSmsEpdlpzffJOcRq6KUL0vcLbhq93M3BkhpU5ETL5iMQkNMlc6_Kv047WN8Ij03Y_i-_Y9FH1JkA6OYlSbbd4guANeF8dbdPOcE_uy9BLjn9ml0zvHqKpgLplLl8Oo4aJWgkHl06EhNMTGaA-cR2t-f3t2XHmgQ-S813t6qChsxzPXfWms3mk99rJeAdQtQUEKR_UukebQVM5p9DAZnHTo9rgXeIexGDx8-bI_91i9BvQfj-3-k92iJbQ";
            //Console.WriteLine("==========================================================");
            //Console.WriteLine($"Token:  { identityserver4_Access_Token }");
            //Console.WriteLine("==========================================================");

            //List<Claim> listClaims2 = tokenServices.JWTDecoder(identityserver4_Access_Token);
            //Console.WriteLine($"ListClaims2:  { listClaims2 }");
            
            //Console.WriteLine("==========================================================");
            //for (int i = 0; i < (listClaims2.Count()); i++)
            //{
            //    Console.WriteLine(listClaims2.ElementAt(i));
            //}
            //Console.WriteLine("==========================================================");

        }
    }

}

 