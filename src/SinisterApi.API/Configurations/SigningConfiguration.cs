using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace SinisterApi.API.Configurations
{
    public class SigningConfiguration
    {
        public SecurityKey Key { get; }

        public SigningCredentials SigningCredentials { get; }

        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
