using System;
using Xunit;
using CaezarCipher;

namespace CaezarCipherTests
{
    public class CipherUnitTests
    {
        [Fact]
        public void Encrypting_Text_With_UpperCase_Letters_And_Symbols()
        {
            var text = "Laba diena!";

            text = Cipher.Encrypt(text, 6);

            Assert.Equal("Rghg joktg!", text);

        }

        [Fact]
        public void Encrypting_Text_With_Very_Big_Shift()
        {
            var text = "Laba diena!";

            text = Cipher.Encrypt(text, 123);

            Assert.Equal("Etut wbxgt!", text);

        }

        [Fact]
        public void Encrypting_Empty_Or_Null_String()
        {
            var text = "";

            text = Cipher.Encrypt(text, 6);

            Assert.True(string.IsNullOrEmpty(text));
        }

        [Fact]
        public void Encrypting_Long_String()
        {
            var text = "If he had anything confidential to say, he wrote it in cipher, that is," +
                " by so changing the order of the letters of the alphabet," +
                " that not a word could be made out.";

            text = Cipher.Encrypt(text, 7);

            Assert.Equal(text, "Pm ol ohk hufaopun jvumpkluaphs av zhf, ol dyval pa pu jpwoly," +
                " aoha pz, if zv johunpun aol vykly vm aol slaalyz" +
                " vm aol hswohila, aoha uva h dvyk jvbsk il thkl vba.");
        }

        //Method to see if last letters of the alphabet offset correctly after shifting
        [Fact]
        public void Encrypting_End_Of_Alphabet()
        {
            var text = "xwz";

            text = Cipher.Encrypt(text, 6);

            Assert.Equal("dcf", text);
        }

        [Fact]
        public void Encrypting_End_Of_Alphabet_UpperCase()
        {
            var text = "XWZ";

            text = Cipher.Encrypt(text, 6);

            Assert.Equal("DCF", text);
        }

        [Fact]
        public void Decrypting_End_Of_Alphabet()
        {
            var text = "dcf";

            text = Cipher.Decrypt(text, 6);

            Assert.Equal("xwz", text);
        }

        [Fact]
        public void Decrypting_End_Of_Alphabet_UpperCase()
        {
            var text = "DCF";

            text = Cipher.Decrypt(text, 6);

            Assert.Equal("XWZ", text);
        }

        [Fact]
        public void Decrypting_Long_String()
        {
            var text = "Pm ol ohk hufaopun jvumpkluaphs av zhf, ol dyval pa pu jpwoly," +
                " aoha pz, if zv johunpun aol vykly vm aol slaalyz" +
                " vm aol hswohila, aoha uva h dvyk jvbsk il thkl vba.";

            text = Cipher.Decrypt(text, 7);

            Assert.Equal(text, "If he had anything confidential to say, he wrote it in cipher, that is," +
                " by so changing the order of the letters of the alphabet," +
                " that not a word could be made out.");
        }

        [Fact]
        public void Decrypting_Text_With_Very_Big_Shift()
        {
            var text = "Etut wbxgt!";

            text = Cipher.Decrypt(text, 123);

            Assert.Equal("Laba diena!", text);

        }
    }
}
