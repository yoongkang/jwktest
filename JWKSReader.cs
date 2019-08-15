using System;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace code
{
    class JWKSReader
    {
        static public JsonWebKeySet parse(string filename)
        {

            String file = File.ReadAllText(filename);
            return new JsonWebKeySet(file);
        }
    }
}
