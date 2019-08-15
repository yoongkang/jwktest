using System;
using System.IO;
using Microsoft.IdentityModel.Tokens;

namespace code
{
    class TokenReader
    {
        static public string parse(string filename)
        {

            String token = File.ReadAllText(filename);
            return token;
        }
    }
}
