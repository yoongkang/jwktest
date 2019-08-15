using System;
using System.IO;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Parameters;

namespace code
{
    class PublicKeyReader
    {
        static public JsonWebKey parse(string filename)
        {
            PemReader pm = new PemReader((StreamReader) File.OpenText("./ecdsa_public_key.pem"));
            var keyParams = (ECPublicKeyParameters) pm.ReadObject();
            string x = Base64UrlEncoder.Encode(keyParams.Q.AffineXCoord.ToBigInteger().ToByteArrayUnsigned());
            string y = Base64UrlEncoder.Encode(keyParams.Q.AffineYCoord.ToBigInteger().ToByteArrayUnsigned());
            JsonWebKey key = new JsonWebKey();
            key.Alg = "ES256";
            key.Kid = "12345";
            key.Kty = "EC";
            key.X = x;
            key.Y = y;
            return key;
        }
    }
}
