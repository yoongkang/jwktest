using System;
using System.IO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography.X509Certificates;


namespace code
{
    class Program
    {
        static void Main(string[] args)
        {
            // This part reads the JWKS file and decodes/verifies the token
            JsonWebKeySet jwks = JWKSReader.parse("jwks.json");
            JsonWebKey key = jwks.Keys[0];
            String token = TokenReader.parse("token.txt");
            SecurityToken validatedToken;
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            TokenValidationParameters validationParameters = new TokenValidationParameters();
            validationParameters.IssuerSigningKey = key;
            validationParameters.ValidateLifetime = false;
            validationParameters.ValidateAudience = false;
            validationParameters.ValidateIssuer = false;
            handler.ValidateToken(token, validationParameters, out validatedToken);
            Console.WriteLine("The decoded token is:");
            Console.WriteLine(validatedToken);
            Console.WriteLine("\n\n");

            // This part tries to recreate a JsonWebKey from a public key in PEM format.
            JsonWebKey pubKey = PublicKeyReader.parse("ecdsa_public_key.pem");
            Console.WriteLine("Creating a JsonWebKey from public key:");
            Console.WriteLine("x: " + pubKey.X.ToString());
            Console.WriteLine("y: " + pubKey.Y.ToString());

        }
    }
}
