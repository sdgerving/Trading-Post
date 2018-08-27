using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading_Post
{
    class RetrieveClient
    {
        public static string fname, mname, lname, homephone, cellphone, workphone, addressline1, addressline2, city, state, make, model, year, color, vin, location, taxtype,itemid;
        public static decimal originalcost, taxtot, newtotal, cost, taxrate, interestrate, storagefee;

        string FinishBytes;
        public static DateTime billdate;
        
        //public static decimal cost;
       
        public RetrieveClient(string finishbytes)
        {
            FinishBytes = finishbytes;
            string activeDir = Main.activeDir+ FinishBytes + @"\Data.txt";
            using (var reader = new StreamReader(activeDir))
            {
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var base64EncodedBytes = System.Convert.FromBase64String(line);
                    var encodedtext = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    var values = encodedtext.Split(',');
                    listA.Add(values[0]);
                    listA.Add(values[1]);
                    listA.Add(values[2]);
                    listA.Add(values[3]);
                    listA.Add(values[4]);
                    listA.Add(values[5]);
                    listA.Add(values[6]);
                    listA.Add(values[7]);
                    listA.Add(values[8]);
                    listA.Add(values[9]);
                    listA.Add(values[10]);
                    listA.Add(values[11]);
                    listA.Add(values[12]);
                    listA.Add(values[13]);
                    listA.Add(values[14]);
                    listA.Add(values[15]);
                    listA.Add(values[16]);
                    listA.Add(values[17]);
                    listA.Add(values[18]);
                    listA.Add(values[19]);
                    listA.Add(values[20]);
                    listA.Add(values[21]);
                    listA.Add(values[22]);
                    listA.Add(values[23]);
                    listA.Add(values[24]);
                    listA.Add(values[25]);

                }
                fname = listA[0];
                mname = listA[1];
                lname = listA[2];
                homephone = listA[3];
                cellphone = listA[4];
                workphone = listA[5];
                addressline1 = listA[6];
                addressline2 = listA[7];
                city = listA[8];
                state = listA[9];
                make = listA[10];
                model = listA[11];
                year = listA[12];
                color = listA[13];
                vin = listA[14];
                location = listA[15];
                cost = Decimal.Parse(listA[16]);
                originalcost = Decimal.Parse(listA[17]);
                taxtot = Decimal.Parse(listA[18]);
                taxtype = listA[19];
                taxrate = Decimal.Parse(listA[20]);
                newtotal = Decimal.Parse(listA[21]);
                billdate = Convert.ToDateTime(listA[22]);
                interestrate = Decimal.Parse(listA[23]);
                storagefee = Decimal.Parse(listA[24]);
                itemid = listA[25];
            }





        }
    }
}
