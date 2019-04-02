using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataConsent
{
    class General
    {

        private static Random random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void loadListView(ListView listview)
        {

            if(DataConsent.listViewLoaded == true)
            {
                return;
            }

            int count = 0;
            DataConsent.listViewLoaded = true;
            ListViewItem item = null;

            if (File.Exists("ListViewContent.txt")){

                foreach (string line in File.ReadAllLines("ListViewContent.txt"))
                {

                    if (count == 0)
                    {

                        item = new ListViewItem(line);
                        listview.Items.Add(item);
                        count++;

                    }else if (count == 1)
                    {

                        item.SubItems.Add(line);
                        item = null;
                        count = 0;

                    }

                }

            }

        }

        public static void saveListView(ListView listview)
        {
            int count = 0;
            StringBuilder listViewContent = new StringBuilder();

            TextWriter tw = new StreamWriter("ListViewContent.txt");

            foreach (ListViewItem item in listview.Items)
            {

                listViewContent.Append(item.Text);
                listViewContent.Append(Environment.NewLine);


                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {

                    if (count == 1)
                    {
                        MessageBox.Show("1: " + subitem.Text);
                        listViewContent.Append(subitem.Text);
                        count = 0;

                    }else if (count != 1)
                    {

                        count++;

                    }

                }

                tw.WriteLine(listViewContent.ToString());
                listViewContent.Clear();
            }

            tw.Close();
        }

        public static bool containsListView(ListView listview, string safefilename)
        {

            foreach(ListViewItem item in listview.Items)
            {
                if(item.Text == safefilename)
                {
                    return true;
                }
            }

            return false;
        }

        public static string ConvertByteToStringWithoutEncoding(byte[] data)
        {
            char[] characters = data.Select(b => (char)b).ToArray();
            return new string(characters);
        }

    }
}
