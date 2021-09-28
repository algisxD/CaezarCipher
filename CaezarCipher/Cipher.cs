using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaezarCipher
{
    public static class Cipher
    {
        public static string Encrypt(string text, int shift)
        {
            string result = string.Empty;

            foreach (var character in text)
            {
                if (!char.IsLetter(character))
                {
                    result += character;
                    continue;
                }

                //checks if letter is upper case if true, then takes capital 'A' code, else takes lower case 'a' code
                char a = char.IsUpper(character) ? 'A' : 'a';

                result += (char)((((character + shift) - a) % 26) + a);
            }

            return result;
        }

        //Decryption works in the same way as encryption, just in different directions
        public static string Decrypt(string encryptedText, int shift)
        {
            return Encrypt(encryptedText, 26 - (shift % 26));
        }
    }
}
