using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace DataConsent
{
    public partial class DataConsent : Form
    {
        public DataConsent()
        {
            InitializeComponent();
        }

        private void b_verify_Click(object sender, EventArgs e)
        {

                try
                {
                // Create a UnicodeEncoder to convert between byte array and string.
                ASCIIEncoding ByteConverter = new ASCIIEncoding();

                string dataString = "Data to Sign";

                // Create byte arrays to hold original, encrypted, and decrypted data.
                byte[] originalData = ByteConverter.GetBytes(dataString);
                byte[] signedData = null;
                RSAParameters pubKey;
                RSAParameters privKey;

                // Create a new instance of the RSACryptoServiceProvider class 
                // and automatically create a new key-pair.
                RSACryptoServiceProvider RSAalg; // = new RSACryptoServiceProvider();
                
                if (File.Exists("public_key.xml"))
                {
                    RSAalg = Cryptography.importPublicKey();
                    pubKey = RSAalg.ExportParameters(false);
                    privKey = RSAalg.ExportParameters(false);

                    signedData = System.IO.File.ReadAllBytes("signeddata");
                    MessageBox.Show("Loading signeddata...");
                }
                else
                {


                    RSAalg = new RSACryptoServiceProvider();
                    pubKey = RSAalg.ExportParameters(false);
                    privKey = RSAalg.ExportParameters(true);

                    if (!File.Exists("private_key.xml"))
                    {
                        signedData = Cryptography.hashAndSignBytes(originalData, privKey);

                        File.WriteAllBytes("signeddata", signedData);
                    }


                    try
                    {
                        Cryptography.exportKeyToXmlFile(RSAalg, true);
                    }
                    catch (Exception f)
                    {

                        MessageBox.Show(f.Message);
                    }

                    try
                    {
                        Cryptography.exportKeyToXmlFile(RSAalg, false);
                    }
                    catch (Exception f)
                    {

                        MessageBox.Show(f.Message);
                    }




                }


                // Export the key information to an RSAParameters object.
                // You must pass true to export the private key for signing.
                // However, you do not need to export the private key
                // for verification.

                //string key = RSAalg.ToXmlString(false);
                //char[] buffer_key = key.ToCharArray();


                // Hash and sign the data.


                    

                // Verify the data and display the result to the 
                // console.
                if (Cryptography.verifySignedHash(originalData, signedData, pubKey))
                {
                    MessageBox.Show("The data was verified.");
                }
                else
                {
                    MessageBox.Show("The data does not match the signature.");
                }

                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("The data was not signed or verified");

                }
            }

        private void b_addfile_Click(object sender, EventArgs e)
        {
            DialogResult result = oFD_addfile.ShowDialog();
            string filename = null;
            byte[] file = null;

            if (result == DialogResult.OK)
            {
                filename = oFD_addfile.FileName;

                try
                {
                    file = File.ReadAllBytes(filename);
                }
                catch (IOException f)
                {

                    return; //Implement logging here.
                }
            }

            try
            {
                File.WriteAllBytes(filename, file);
            }
            catch (Exception f)
            {

                return; //Implement logging here.
            }
            


        }
    }
}   