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
using System.Runtime.InteropServices;
using NetMQ.Sockets;
using NetMQ;

namespace DataConsent
{
    public partial class DataConsent : Form
    {
        public DataConsent()
        {
            InitializeComponent();
        }

        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        public static bool listViewLoaded;
        string safefilename = null;
        string filename = null;
        byte[] file = null;
        byte[] password;
        byte[] salt;

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
            DialogResult result = oFD_loadfile.ShowDialog();
  
            string signedDataPath;
            string passwordDataPath;
            string saltDataPath;
            string randomString;
            byte[] signedData;
            byte[] encryptedFile;
            RSAParameters privKey;
            RSAParameters pubKey;


            // Create a new instance of the RSACryptoServiceProvider class 
            // and automatically create a new key-pair.
            RSACryptoServiceProvider RSAalg; // = new RSACryptoServiceProvider();



            if (result == DialogResult.OK)
            {
                safefilename = oFD_loadfile.SafeFileName;
                filename = oFD_loadfile.FileName;

                //MessageBox.Show(l_files.Items[0].Text + ":" + safefilename);

                if (!General.containsListView(l_files, safefilename))
                {

                    try
                    {
                        file = File.ReadAllBytes(filename);
                    }
                    catch (IOException f)
                    {

                        return; //Implement logging here.
                    }

                }
                else
                {

                    MessageBox.Show("This file already exists.");

                    return;
                }

            }
            else
            {
                return;
            }


            if (File.Exists("private_key.xml"))
            {

                RSAalg = Cryptography.importPrivateKey();
                privKey = RSAalg.ExportParameters(true);

            }
            else
            {

                RSAalg = new RSACryptoServiceProvider(512);
                privKey = RSAalg.ExportParameters(true);

                Cryptography.exportKeyToXmlFile(RSAalg, true);
                Cryptography.exportKeyToXmlFile(RSAalg, false);

            }

            try
            {

                password = Encryption.GenerateRandomSalt();

                randomString = General.RandomString(32);

                //GCHandle gch = GCHandle.Alloc(System.Text.Encoding.UTF8.GetString(password), GCHandleType.Pinned); //Indien errors tijdens decrypten, check of de UTF8 encoding hiervoor zorgt.

                //MessageBox.Show("Password: " + System.Text.Encoding.UTF8.GetString(password));

                //MessageBox.Show("result: " + filename);
                Encryption.FileEncrypt(filename, randomString, password, salt = Encryption.GenerateRandomSalt());

                //ZeroMemory(gch.AddrOfPinnedObject(), password.Length * 2);
                //gch.Free();

                //MessageBox.Show("Password: " + System.Text.Encoding.UTF8.GetString(password));

                encryptedFile = File.ReadAllBytes("files/" + randomString + ".aes");
            }
            catch (Exception f)
            {

                MessageBox.Show("Error:" + f.Message);
                return; //Implement logging here.
            }


            if ((signedData = Cryptography.hashAndSignBytes(encryptedFile, privKey)) != null) {

                signedDataPath = "files/signeddata/" + randomString + ".aes.signed";
                passwordDataPath = "files/passwords/" + randomString + ".aes.pass";
                saltDataPath = "files/salts/" + randomString + ".salt";

                try
                {

                    File.WriteAllBytes(signedDataPath, signedData);
                    File.WriteAllBytes(passwordDataPath, password);
                    File.WriteAllBytes(saltDataPath, salt);

                }
                catch (Exception f)
                {

                    MessageBox.Show("Error:" + f.Message);
                }


                ListViewItem item = new ListViewItem(safefilename, 0);
                item.SubItems.Add(randomString);
                l_files.Items.Add(item);

                General.saveListView(l_files);
            }
        }

    private void DataConsent_Load(object sender, EventArgs e)
        {
            
            b_decrypt.Enabled = false;

            General.loadListView(l_files);
            l_files.FullRowSelect = true;
            //l_files.GridLines = true;
            l_files.Columns.Add("Filename");
            l_files.Columns.Add("Pseudonym");
        }

        private void b_savelist_Click(object sender, EventArgs e)
        {

            General.saveListView(l_files);

        }

        private void b_loadlist_Click(object sender, EventArgs e)
        {

            General.loadListView(l_files);

        }

        private void b_decrypt_Click(object sender, EventArgs e)
        {

            string fileDataPath;
            string passwordDataPath;
            string saltDataPath;

            b_decrypt.Enabled = false;
            sFD_savefile.FileName = l_files.SelectedItems[0].SubItems[0].Text;
            DialogResult result = sFD_savefile.ShowDialog();
            

            if (result == DialogResult.OK)
            {

                filename = sFD_savefile.FileName;
                MessageBox.Show("" + l_files.SelectedItems[0].SubItems[1].Text);

                fileDataPath = "files/" + l_files.SelectedItems[0].SubItems[1].Text + ".aes";
                passwordDataPath = "files/passwords/" + l_files.SelectedItems[0].SubItems[1].Text + ".aes.pass";
                saltDataPath = "files/salts/" + l_files.SelectedItems[0].SubItems[1].Text + ".salt";

                password = File.ReadAllBytes(passwordDataPath);
                salt = File.ReadAllBytes(passwordDataPath);
                MessageBox.Show(General.ConvertByteToStringWithoutEncoding(password));

                try
                {

                    Encryption.FileDecrypt(fileDataPath, filename, password, salt);

                }

                catch (Exception f)
                {

                    MessageBox.Show("Error:" + f.Message);

                }           
                //password = null;
                //salt = null;
            }
            
        }

        private void l_files_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (l_files.SelectedItems.Count > 0)
            {

                b_decrypt.Enabled = true;

            }else if (l_files.SelectedItems.Count < 1)
            {

                b_decrypt.Enabled = false;

            }

        }

        public void b_connect_Click(object sender, EventArgs e)
        {


            TCPRequest.test();

            //AsynchronousClient.StartClient();


        }
    }
}   