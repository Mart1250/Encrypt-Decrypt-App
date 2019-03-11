using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataConsent
{
    class Cryptography
    {

        public static byte[] hashAndSignBytes(byte[] dataToSign, RSAParameters key)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the 
                // key from RSAParameters.  
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(key);

                // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
                // to specify the use of SHA1 for hashing.
                return RSAalg.SignData(dataToSign, new SHA1CryptoServiceProvider());
            }
            catch (CryptographicException e)
            {

                return null;
            }
        }

        public static bool verifySignedHash(byte[] DataToVerify, byte[] signedData, RSAParameters key)
        {
            try
            {
                // Create a new instance of RSACryptoServiceProvider using the 
                // key from RSAParameters.
                RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();

                RSAalg.ImportParameters(key);

                // Verify the data using the signature.  Pass a new instance of SHA1CryptoServiceProvider
                // to specify the use of SHA1 for hashing.
                return RSAalg.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), signedData);

            }
            catch (CryptographicException e)
            {

                return false;
            }
        }

        public static bool exportKeyToXmlFile(RSACryptoServiceProvider provider, bool exportPrivateKey) //Exports key information to XMLfile.
        {
            try
            {
                if (exportPrivateKey == false)
                {

                    File.WriteAllText("public_key.xml", provider.ToXmlString(exportPrivateKey), Encoding.UTF8);

                }else if(exportPrivateKey == true)
                {

                    File.WriteAllText("private_key.xml", provider.ToXmlString(exportPrivateKey), Encoding.UTF8);

                }
            }
            catch (Exception e)
            {

                return false;
            }

            return true;
        }

        public static RSACryptoServiceProvider importPublicKey()
        {

            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();

            try
            {
                string xmlString = System.IO.File.ReadAllText("public_key.xml");

                provider.FromXmlString(xmlString);
            }
            catch (Exception e)
            {

                return null;
            }

            return provider;
        }

    }
}
