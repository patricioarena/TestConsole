using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Test.Services
{
    public interface ITokenService
    {
        string JWTEncode(string email);
        List<Claim> JWTDecoder(string SecurityToken);
    }

    public class TokenService : ITokenService
    {
        public TokenService() { }

        public List<Claim> JWTDecoder(string stringToken)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            List<Claim> claims = new List<Claim>();

            var readableToken = jwtHandler.CanReadToken(stringToken);

            if (readableToken == true)
            {
                var token = jwtHandler.ReadJwtToken(stringToken);
                claims = token.Claims.ToList();

                /**
                //claims = token.Claims.Where(e => (e.Type != "aud") || (e.Type != "role") || (e.Type != "scope") || (e.Type != "amr") || (e.Type != "aud")).ToList();

                //var aud = token.Claims.Where(e => e.Type.Equals("aud")).ToList();
                //var role = token.Claims.Where(e => e.Type.Equals("role")).ToList();
                //var scope = token.Claims.Where(e => e.Type.Equals("scope")).ToList();
                //var amr = token.Claims.Where(e => e.Type.Equals("amr")).ToList();

                
                //for (int i = 0; i < (claims2.Count()); i++)
                //{
                //    //Console.WriteLine($"claims: {aud.ElementAt(i)}");
                //    Console.WriteLine(claims2.ElementAt(i));

                //}

                //for (int i = 0; i < (claims.Count()); i++)
                //{
                //    //Console.WriteLine($"claims: {aud.ElementAt(i)}");
                //    Console.WriteLine(claims.ElementAt(i));

                //}

                //for (int i = 0; i < (aud.Count()); i++)
                //{
                //    //Console.WriteLine($"aud: {aud.ElementAt(i)}");
                //    Console.WriteLine(aud.ElementAt(i));

                //}

                //for (int i = 0; i < (role.Count()); i++)
                //{
                //    //Console.WriteLine($"role: {role.ElementAt(i)}");
                //    Console.WriteLine(role.ElementAt(i));

                //}

                //for (int i = 0; i < (scope.Count()); i++)
                //{
                //    //Console.WriteLine($"scope: {role.ElementAt(i)}");
                //    Console.WriteLine(scope.ElementAt(i));

                //}

                //for (int i = 0; i < (amr.Count()); i++)
                //{
                //    //Console.WriteLine($"amr: {role.ElementAt(i)}");
                //    Console.WriteLine(amr.ElementAt(i));

                //}

                ////Extract the headers of the JWT

                //JObject JHeaders = new JObject();
                //JObject JClaims = new JObject();

                //foreach (var h in token.Header)
                //{
                //    JProperty property = new JProperty(h.Key, h.Value);
                //    JHeaders.Add(property);
                //}

                //JWT.Add("Headers", JHeaders);

                ////Extract the payload of the JWT

                //foreach (Claim claim in token.Claims)
                //{
                //    JProperty property = new JProperty(claim.Type, claim.Value);
                //    if (!JClaims.ContainsKey(claim.Type)){
                //        JClaims.Add(property);
                //    }
                //}

                //JWT.Add("Claims",JClaims);
                */
            }
            return claims;
        }

        public string JWTEncode(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, email),
                new Claim("miValor", "Lo que yo quiera")
            };

            string privateSecretKey = "OfED+KgbZxtu4e4+JSQWdtSgTnuNixKy1nMVAEww8QL3IN3idcNgbNDSSaV4491Fo3sq2aG" +
                "SCtYvekzs7JwXJnNAyvDSJjfK/7M8MpxSMnm1vMscBXyiYFXhGC4wqWlYBE828/5DNyw3QZW5EjD7hvDrY5OlYd4smCTa" +
                "53helNnJz5NT9HQaDbE2sMwIDAQABAoIBAEs63TvT94njrPDP3A/sfCEXg1F2y0D/PjzUhM1aJGcRiOUXnGlYdViGhLnn" +
                "JoNZTZm9qI1LT0NWcDA5NmBN6gcrk2EApyTt1D1i4AQ66rYoTF9iEC4Wye28v245BYESA6IIelgIxXGsVyllERsbTkaph" +
                "zibbYfHmvwMxkn135Zfzd/NOXl/O32vYIomzrNEP+tN2WXhhG8c8+iZ8PErBV3CqrYogYy97d2CeQbXcpd5unPiU4TK0n" +
                "nzeBAXdgeYuJHFC45YHl9UvShRoe6CHR47ceIGp6WMc5BTyyTkZpctuYJTwaChdj/QuRSkTYmn6jFL+MRfYQJ8VVwSVo5" +
                "DbkECgYEA4/YIMKcwObYcSuHzgkMwH645CRDoy9M98eptAoNLdJBHYz23U5IbGL1+qHDDCPXxKs9ZG7EEqyWezq42eoFo" +
                "ebLA5O6/xrYXoaeIb094dbCF4D932hAkgAaAZkZVsSiWDCjYSV+JoWX4NVBcIL9yyHRhaaPVULTRbPsZQWq9+hMCgYEA4" +
                "8j4RGO7CaVpgUVobYasJnkGSdhkSCd1VwgvHH3vtuk7/JGUBRaZc0WZGcXkAJXnLh7QnDHOzWASdaxVgnuviaDi4CIkmT" +
                "CfRqPesgDR2Iu35iQsH7P2/o1pzhpXQS/Ct6J7/GwJTqcXCvp4tfZDbFxS8oewzp4RstILj+pDyWECgYByQAbOy5xB8GG" +
                "xrhjrOl1OI3V2c8EZFqA/NKy5y6/vlbgRpwbQnbNy7NYj+Y/mV80tFYqldEzQsiQrlei78Uu5YruGgZogL3ccj+izUPMg" +
                "mP4f6+9XnSuN9rQ3jhy4k4zQP1BXRcim2YJSxhnGV+1hReLknTX2IwmrQxXfUW4xfQKBgAHZW8qSVK5bXWPjQFnDQhp92" +
                "QM4cnfzegxe0KMWkp+VfRsrw1vXNx";

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "yourdomain.com",
               audience: "yourdomain.com",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
