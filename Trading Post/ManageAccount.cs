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
   
    public partial class ManageAccount : Form
    {
        public static string fname, mname, lname, homephone, cellphone, workphone, addressline1, addressline2, city, state, make, model, year, color, vin, location, taxtype,itemid;
        
        private void payprintbtn_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            string selectedfile = Main.selectedfile;
            label12.Text = selectedfile.ToString();
            var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
            var finishbytes = System.Convert.ToBase64String(plaintextbytes);
            RetrieveClient client = new Trading_Post.RetrieveClient(finishbytes);
            

            fnameprintlabel.Text = RetrieveClient.fname;
            mnameprintlabel.Text = RetrieveClient.mname;
            lnameprintlabel.Text = RetrieveClient.lname;
            homephonelabel.Text = RetrieveClient.homephone;
            cellphonelabel.Text = RetrieveClient.cellphone;
            workphonelabel.Text = RetrieveClient.workphone;
            addressline1data.Text = RetrieveClient.addressline1;
            addressline2data.Text = RetrieveClient.addressline2;
            citylabel.Text = RetrieveClient.city;
            statelabel.Text = RetrieveClient.state;
            makelabel.Text = RetrieveClient.make;
            modellabel.Text = RetrieveClient.model;
            yearlabel.Text = RetrieveClient.year;
            colorlabel.Text = RetrieveClient.color;
            VINlabel.Text = RetrieveClient.vin;
            Vehicleloclabel.Text = RetrieveClient.location;
            vehiclecostdatalabel.Text = RetrieveClient.originalcost.ToString();
            remainbal.Text = RetrieveClient.newtotal.ToString();
            taxtot = RetrieveClient.taxtot;
            taxtype = RetrieveClient.taxtype;
            taxrate = RetrieveClient.taxrate;
            billdate = Convert.ToDateTime(RetrieveClient.billdate);
            interestratelabel.Text = RetrieveClient.interestrate.ToString();
            storagefeelabel.Text = RetrieveClient.storagefee.ToString();
            interestrate = RetrieveClient.interestrate;
            storagefee = RetrieveClient.storagefee;
            itemid = RetrieveClient.itemid;
            itemidlabel.Text = itemid;
            duedatelabel.Text = RetrieveClient.billdate.ToString("MM/dd/yyyy");
            var plaintextbytes2 = System.Text.Encoding.UTF8.GetBytes(selectedfile);
            var finishbytes2 = System.Convert.ToBase64String(plaintextbytes2);
            Font font = new Font("Times New Roman", 11.0f, FontStyle.Bold);

            Font arial11 = new Font("Arial", 11, System.Drawing.GraphicsUnit.Point);
            Font arial24 = new Font("Arial", 24, System.Drawing.GraphicsUnit.Point);
            Font arial18 = new Font("Arial", 18, System.Drawing.GraphicsUnit.Point);
            Font arial14 = new Font("Arial", 14, System.Drawing.GraphicsUnit.Point);
            string activeDir2 = Main.activeDir + finishbytes2 + @"\note.txt";
            paymenthistorytxtbox.Font = font;

            String temp = System.Environment.UserName;
            List<string> printlist = new List<string>();
            using (var reader = new StreamReader(activeDir2))
            {
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split('~');

                    if (line.Contains("Account Created"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }

                        templist[2] = "$" + templist[2];
                        int count2 = 11 - templist[2].Length;
                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }

                        const string format = "{0,0} {1,13} {2,14}{3,27}{2,44}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[2]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        printlist.Add(test);

                    }

                    if (line.Contains("(note)"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        if (templist[2].Length == 6)
                        {
                            paymenthistorytxtbox.AppendText(templist[0] + "     " + templist[1] + "      " + templist[3] + "\n");
                        }


                    }

                    if (line.Contains("Account Has Been Paid in Full."))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }

                        paymenthistorytxtbox.AppendText(templist[0] + "    " + templist[1] + "               " + templist[2] + "\n");



                    }
                    if (line.Contains("State Tax"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[3] = templist[3] + "%";
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,27}{4,22}{5,14}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        printlist.Add(test);

                    }




                    if (line.Contains("State&County Tax"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);


                        }
                        templist[2] = "$" + templist[2];
                        templist[3] = templist[3] + "%";
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,27}{4,13} {5,13}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");

                        printlist.Add(test);

                    }

                    if (line.Contains("Storage Fee"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[4] = "$" + templist[4];
                        templist[3] = templist[3].Insert(12, "$");
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }


                        const string format = "{0,0} {1,13} {2,13}{3,26}{4,46}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        printlist.Add(test);
                    }

                    if (line.Contains("Dealer Fee"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];

                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,25}{4,27} {5,12}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        printlist.Add(test);
                    }


                    if (line.Contains("Payment"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,22}{4,32} {5,12}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        printlist.Add(test);
                    }

                    if (line.Contains("Monthly Interest"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,28}{4,16} {5,10}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        printlist.Add(test);
                    }
                    

                }
            }
            DateTime date = DateTime.Now.Date;
            int x=100, y=210;
            String Titletxt = System.Environment.UserName;
            String datetxt = System.Environment.UserName;
            String divideline = System.Environment.UserName;
            String datatypestop = System.Environment.UserName;
            String datatypesbottom = System.Environment.UserName;
            Titletxt = "Account History";
            datetxt = date.ToString("MMMM dd, yyyy");
            divideline = "\n" + "_________________________________________________" + "\n";
            datatypestop = "Change                       +/-                      New" + "\n";
            datatypesbottom = "Date                  Time          Balance                           Made                    Balance               Balance" + "\n";
            g.DrawString(Titletxt, arial24, Brushes.Black, 300, 100);
            g.DrawString(datetxt, arial18, Brushes.Black, 320, 130);
            g.DrawString(divideline, arial18, Brushes.Black, 100, 105);
            g.DrawString(divideline, arial18, Brushes.Black, 100, 151);
            g.DrawString(datatypestop, arial11, Brushes.Black, 450, 170);
            g.DrawString(datatypesbottom, arial11, Brushes.Black, 100, 190);

            foreach (var astring in printlist)
            {

                temp = astring;
                g.DrawString(temp, arial11, Brushes.Black, x, y);
                y += 25;
            }
        }

        public static decimal originalcost, taxtot, newtotal, newbalance, balance, cost, taxrate, remainbalance, interestrate, storagefee;
        public string selectedfile;
        public int marker = 0;
        public static int custcheck;

        private void savenotebtn_Click(object sender, EventArgs e)
        {
           string note = notetxtbox.Text;
           string selectedfile = Main.selectedfile;
           var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
           var finishbytes = System.Convert.ToBase64String(plaintextbytes);
           string activeDir = @"c:\LayawayData\CustomerInfo\" + finishbytes + @"\note.txt";
           if (File.Exists(activeDir))
            {
               using (StreamWriter aw = File.AppendText(activeDir))
                        {
                            DateTime thisDay = DateTime.Today;
                            DateTime thistime = DateTime.Now;
                            aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," +"(note)"+","+ note+","+"~");
                        }
                    }
            notetxtbox.Text = "";
            ManageAccount_Load_1(sender,  e);


            }

        private void Paymentbtn_Click(object sender, EventArgs e)
        {
            fname = fnameprintlabel.Text;
            mname = mnameprintlabel.Text;
            lname = lnameprintlabel.Text;
            homephone = homephonelabel.Text;
            cellphone = cellphonelabel.Text;
            workphone = workphonelabel.Text;
            addressline1 = addressline1data.Text;
            addressline2 = addressline2data.Text;
            city = citylabel.Text;
            state = statelabel.Text;
            make = makelabel.Text;
            model = modellabel.Text;
            year = yearlabel.Text;
            color = colorlabel.Text;
            vin = VINlabel.Text;
            cost = Decimal.Parse(vehiclecostdatalabel.Text);
            originalcost = Decimal.Parse(vehiclecostdatalabel.Text);
            location = Vehicleloclabel.Text;
            remainbalance = Decimal.Parse(remainbal.Text.ToString());
            interestrate = Decimal.Parse(interestratelabel.Text.ToString());
            storagefee = Decimal.Parse(storagefeelabel.Text.ToString());
           
            MakePayment openmp = new Trading_Post.MakePayment();
            openmp.Show();
        }

        

        private void cancelchangesbtn_Click(object sender, EventArgs e)
        {
            if (marker == 1)
            {
                backagain();
                marker = 0;
            }
            else
            {

                Main openmain = new Trading_Post.Main();
                
                openmain.Show();
                this.Close();
            }
        }
        private void backagain()
        {
            cancelchangesbtn.Location = new Point(856, 634);
            cancelchangesbtn.Height = 52;
            cancelchangesbtn.Font = new Font("serif", 15);
            Paymentbtn.Show();
            confirmeditbtn.Hide();
            editcustinfobtn.Show();
            fnameprintlabel.Show();
            mnameprintlabel.Show();
            lnameprintlabel.Show();
            homephonelabel.Show();
            cellphonelabel.Show();
            workphonelabel.Show();
            addressline1data.Show();
            addressline2data.Show();
            citylabel.Show();
            statelabel.Show();
            makelabel.Show();
            modellabel.Show();
            yearlabel.Show();
            colorlabel.Show();
            VINlabel.Show();
            Vehicleloclabel.Show();
            vehiclecostdatalabel.Show();

            fnameprinttxtbox.Hide();
            mnameprinttxtbox.Hide();
            lnameprinttxtbox.Hide();
            homephonetxtbox.Hide();
            textBox2.Hide();
            textBox3.Hide();
            addressline1datatxtbox.Hide();
            addressline2datatxtbox.Hide();
            citytxtbox.Hide();
            statetxtbox.Hide();
            maketxtbox.Hide();
            modeltxtbox.Hide();
            yeartxtbox.Hide();
            colortxtbox.Hide();
            VINtxtbox.Hide();
            Vehicleloctxtbox.Hide();
            
        }
        private void editcustinfobtn_Click(object sender, EventArgs e)
        {
            marker = 1;
            cancelchangesbtn.Location = new Point(858, 581);
            cancelchangesbtn.Height = 109;
            cancelchangesbtn.Font = new Font("serif", 20);
            Paymentbtn.Hide();
            confirmeditbtn.Show();
            cancelchangesbtn.Show();
            editcustinfobtn.Hide();
            fnameprintlabel.Hide();
            mnameprintlabel.Hide();
            lnameprintlabel.Hide();
            homephonelabel.Hide();
            cellphonelabel.Hide();
            workphonelabel.Hide();
            addressline1data.Hide();
            addressline2data.Hide();
            citylabel.Hide();
            statelabel.Hide();
            makelabel.Hide();
            modellabel.Hide();
            yearlabel.Hide();
            colorlabel.Hide();
            VINlabel.Hide();
            Vehicleloclabel.Hide();
            vehiclecostdatalabel.Hide();
            fnameprinttxtbox.Show();
            mnameprinttxtbox.Show();
            lnameprinttxtbox.Show();
            homephonetxtbox.Show();
            textBox2.Show();
            textBox3.Show();
            addressline1datatxtbox.Show();
            addressline2datatxtbox.Show();
            citytxtbox.Show();
            statetxtbox.Show();
            maketxtbox.Show();
            modeltxtbox.Show();
            yeartxtbox.Show();
            colortxtbox.Show();
            VINtxtbox.Show();
            Vehicleloctxtbox.Show();
            vehiclecostdatalabel.Show();
            fnameprinttxtbox.Text = fnameprintlabel.Text;
            mnameprinttxtbox.Text = mnameprintlabel.Text;
            lnameprinttxtbox.Text = lnameprintlabel.Text;
            homephonetxtbox.Text = homephonelabel.Text;
            textBox2.Text = cellphonelabel.Text;
            textBox3.Text = workphonelabel.Text;
            addressline1datatxtbox.Text = addressline1data.Text;
            addressline2datatxtbox.Text = addressline2data.Text;
            citytxtbox.Text = citylabel.Text;
            statetxtbox.Text = statelabel.Text;
            maketxtbox.Text = makelabel.Text;
            modeltxtbox.Text = modellabel.Text;
            yeartxtbox.Text = yearlabel.Text;
            colortxtbox.Text = colorlabel.Text;
            VINtxtbox.Text = VINlabel.Text;
            Vehicleloctxtbox.Text = Vehicleloclabel.Text;
            vehiclecostdatalabel.Text = vehiclecostdatalabel.Text;
            itemidlabel.Text = itemid;
        }
        private void editfile()
        {
            selectedfile = Main.selectedfile;
            var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
            var finishbytes = System.Convert.ToBase64String(plaintextbytes);
            File.Copy(@"c:\LayawayData\CustomerInfo\" + finishbytes + @"\note.txt", @"c:\LayawayData\CustomerInfo\note.txt");
            string activeDir = @"c:\LayawayData\CustomerInfo\" + finishbytes + @"\Data.txt";
            string deldir = @"c:\LayawayData\CustomerInfo\" + finishbytes;
            File.Delete(activeDir);
            Directory.Delete(deldir, true);
            if (!File.Exists(activeDir))
            {
                string activeDir1 = @"c:\LayawayData\CustomerInfo\";
                string result1 = mnameprinttxtbox.Text.Substring(0, 1);
                string custDir = fnameprinttxtbox.Text + "," + result1 + "," + lnameprinttxtbox.Text;
                var plaintextbytes1 = System.Text.Encoding.UTF8.GetBytes(custDir);
                var finishbytes1 = System.Convert.ToBase64String(plaintextbytes1);

                string finalpath = System.IO.Path.Combine(activeDir1, finishbytes1);
                System.IO.Directory.CreateDirectory(finalpath);
                string path = finalpath + @"\" + "Data.txt";
                File.Copy(@"c:\LayawayData\CustomerInfo\note.txt", finalpath + @"\" + "note.txt");
                if (!File.Exists(finalpath))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        paymenthistorytxtbox.AppendText(billdate.ToString());
                        plaintextbytes1 = System.Text.Encoding.UTF8.GetBytes(fnameprinttxtbox.Text + "," + result1 + "," + lnameprinttxtbox.Text + "," + homephonetxtbox.Text + "," + textBox2.Text +
                        "," + textBox3.Text + "," + addressline1datatxtbox.Text + "," + addressline2datatxtbox.Text + "," + citytxtbox.Text + "," + statetxtbox.Text + "," + maketxtbox.Text + "," + modeltxtbox.Text + "," +
                        yeartxtbox.Text + "," + colortxtbox.Text + "," + VINtxtbox.Text + "," + Vehicleloctxtbox.Text + "," + vehiclecostdatalabel.Text + "," + vehiclecostdatalabel.Text + "," + taxtot + "," + taxtype + "," + taxrate + "," + remainbal.Text + "," + billdate + "," + interestrate + "," + storagefee+","+itemid);
                        finishbytes1 = System.Convert.ToBase64String(plaintextbytes1);
                        sw.WriteLine(finishbytes1);

                        File.Delete(@"c:\LayawayData\CustomerInfo\note.txt");
                    }
                }
            }
        }

        

        private void confirmeditbtn_Click(object sender, EventArgs e)
        {
            if (fnameprinttxtbox.Text != "" && mnameprinttxtbox.Text != "" && lnameprinttxtbox.Text != "" && statetxtbox.Text != "" && citytxtbox.Text != "" &&
                maketxtbox.Text != "" && modeltxtbox.Text != "" && yeartxtbox.Text != "" && colortxtbox.Text != "" && colortxtbox.Text != "" && Vehicleloctxtbox.Text != "" && vehiclecostdatalabel.Text != "")
            {
                if (homephonetxtbox.Text != "" || textBox2.Text != "")
                {
                    if (addressline1datatxtbox.Text != "" || addressline2datatxtbox.Text != "")
                    {
                        custcheck = 1;
                        fname = fnameprinttxtbox.Text;
                        mname = mnameprinttxtbox.Text;
                        lname = lnameprinttxtbox.Text;
                        homephone = homephonetxtbox.Text;
                        cellphone = textBox2.Text;
                        workphone = textBox3.Text;
                        addressline1 = addressline1datatxtbox.Text;
                        addressline2 = addressline2datatxtbox.Text;
                        city = citytxtbox.Text;
                        state = statetxtbox.Text;
                        make = maketxtbox.Text;
                        model = modeltxtbox.Text;
                        year = yeartxtbox.Text;
                        color = colortxtbox.Text;
                        vin = VINtxtbox.Text;
                        location = Vehicleloctxtbox.Text;
                        cost = Decimal.Parse(vehiclecostdatalabel.Text);
                        remainbalance=Decimal.Parse(remainbal.Text);
                        
                        CustomerConfirm custconf = new Trading_Post.CustomerConfirm();
                        custconf.Show();
                        const string message = "Is the customer information correct?";
                        const string caption = "Confirm Customer Information";
                        label11.Text=cost+ "  "+ remainbalance;
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            custcheck = 0;
                            editfile();
                            Main openmain = new Trading_Post.Main();
                            openmain.Show();
                            custconf.Close();
                            this.Close();
                        }
                        else
                        {
                            custconf.Close();
                            backagain();
                        }


                    }
                }
            }
            else
            if (fnameprinttxtbox.Text == "")
            {
                fnameprinttxtbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (mnameprinttxtbox.Text == "")
            {
                mnameprinttxtbox.BackColor = Color.Yellow;
            }
            if (lnameprinttxtbox.Text == "")
            {
                lnameprinttxtbox.BackColor = Color.Yellow;
            }

            if (homephonetxtbox.Text == "")
            { homephonetxtbox.BackColor = Color.Yellow; }

            if (textBox2.Text == "")
            {
                if (textBox3.Text == "")
                {
                    textBox3.BackColor = Color.Yellow;
                    textBox2.BackColor = Color.Yellow;
                }

            }
            if (addressline1datatxtbox.Text == "")
            { addressline1datatxtbox.BackColor = Color.Yellow; }
            if (addressline2datatxtbox.Text == "")
            { addressline2datatxtbox.BackColor = Color.Yellow; }
            if (citytxtbox.Text == "")
            { citytxtbox.BackColor = Color.Yellow; }
            if (statetxtbox.Text == "")
            { statetxtbox.BackColor = Color.Yellow; }
            if (maketxtbox.Text == "")
            { maketxtbox.BackColor = Color.Yellow; }
            if (modeltxtbox.Text == "")
            { modeltxtbox.BackColor = Color.Yellow; }
            if (yeartxtbox.Text == "")
            { yeartxtbox.BackColor = Color.Yellow; }
            if (colortxtbox.Text == "")
            { colortxtbox.BackColor = Color.Yellow; }
            if (VINtxtbox.Text == "")
            { VINtxtbox.BackColor = Color.Yellow; }
            if (Vehicleloctxtbox.Text == "")
            { Vehicleloctxtbox.BackColor = Color.Yellow; }
        }

        public static DateTime billdate;
        Font font = new Font("Times New Roman", 11.0f, FontStyle.Bold);
       // paymenthistorytxtbox.Font = font;
        public ManageAccount()
        {
            InitializeComponent();
        }

        private void ManageAccount_Load_1(object sender, EventArgs e)
        {
            string selectedfile = Main.selectedfile;
            if (Main.archivecheck ==1)
            {
                confirmeditbtn.Hide();
                Paymentbtn.Hide();
                editcustinfobtn.Hide();


            }
           
           
            var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
            var finishbytes = System.Convert.ToBase64String(plaintextbytes);
            RetrieveClient client = new Trading_Post.RetrieveClient(finishbytes);
            
            fnameprintlabel.Text = RetrieveClient.fname;
            mnameprintlabel.Text = RetrieveClient.mname;
            lnameprintlabel.Text = RetrieveClient.lname;
            homephonelabel.Text = RetrieveClient.homephone;
            cellphonelabel.Text = RetrieveClient.cellphone;
            workphonelabel.Text = RetrieveClient.workphone;
            addressline1data.Text = RetrieveClient.addressline1;
            addressline2data.Text = RetrieveClient.addressline2;
            citylabel.Text = RetrieveClient.city;
            statelabel.Text = RetrieveClient.state;
            makelabel.Text = RetrieveClient.make;
            modellabel.Text = RetrieveClient.model;
            yearlabel.Text = RetrieveClient.year;
            colorlabel.Text = RetrieveClient.color;
            VINlabel.Text = RetrieveClient.vin;
            Vehicleloclabel.Text = RetrieveClient.location;
            vehiclecostdatalabel.Text = RetrieveClient.originalcost.ToString();
            remainbal.Text = RetrieveClient.newtotal.ToString();
            taxtot = RetrieveClient.taxtot;
            taxtype = RetrieveClient.taxtype;
            taxrate = RetrieveClient.taxrate;
            billdate = Convert.ToDateTime(RetrieveClient.billdate);
            interestratelabel.Text = RetrieveClient.interestrate.ToString();
            storagefeelabel.Text = RetrieveClient.storagefee.ToString();
            interestrate = RetrieveClient.interestrate;
            storagefee = RetrieveClient.storagefee;
            itemid = RetrieveClient.itemid;
            itemidlabel.Text = itemid;
            duedatelabel.Text = RetrieveClient.billdate.ToString("MM/dd/yyyy");
            var plaintextbytes2 = System.Text.Encoding.UTF8.GetBytes(selectedfile);
            var finishbytes2 = System.Convert.ToBase64String(plaintextbytes2);
            Font font = new Font("Times New Roman", 11.0f, FontStyle.Bold);

            string activeDir2 = Main.activeDir + finishbytes2 + @"\note.txt";
            paymenthistorytxtbox.Font = font;
            using (var reader = new StreamReader(activeDir2))
            {
                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();
                    var values = line.Split('~');

                    if (line.Contains("Account Created"))
                    {
                       
                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }

                        templist[2] = "$" + templist[2];
                        int count2 = 11 - templist[2].Length;
                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                       
                        const string format = "{0,0} {1,13} {2,14}{3,27}{2,44}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[2]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                     
                    }

                    if (line.Contains("(note)"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        if (templist[2].Length == 6)
                        {
                            paymenthistorytxtbox.AppendText(templist[0] + "     " + templist[1] + "      "  + templist[3] + "\n");
                        }
                        

                    }
                    
                        if (line.Contains("Account Has Been Paid in Full."))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                       
                            paymenthistorytxtbox.AppendText(templist[0] + "    " + templist[1] + "               "  + templist[2]+ "\n");
                        
                       

                    }
                    if (line.Contains("State Tax"))
                    {
                        
                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[3] = templist[3] + "%";
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,27}{4,22}{5,14}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");
                        

                    }




                    if (line.Contains("State&County Tax"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);


                        }
                        templist[2] = "$" + templist[2];
                        templist[3] = templist[3] + "%";
                        templist[4] = "$" + templist[4];
                        templist[5] = "$"+templist[5]; 
                        int count2 = 11-templist[2].Length;
                        
                        if(count2>0)
                        {
                           templist[2] += new string('_', count2);
                        }
                        

                        int count4 = 11- templist[4].Length ;
                        if(count4>0)
                        {
                            templist[4] += new string('_', count4)  ;
                        }
                        int count5 = 11 - templist[5].Length ;
                        if (count5>0)
                        {
                          templist[5] = new string('_', count5)+templist[5] ;
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,27}{4,13} {5,13}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");

                        

                    }

                    if (line.Contains("Storage Fee"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[4] = "$" + templist[4];
                        templist[3] = templist[3].Insert(12, "$");
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        
                        
                        const string format = "{0,0} {1,13} {2,13}{3,26}{4,46}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4]);
                        paymenthistorytxtbox.AppendText(test + "\n");

                    }

                    if (line.Contains("Dealer Fee"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,25}{4,27} {5,12}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");

                    }


                    if (line.Contains("Payment"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[4] = "$" + templist[4];
                        templist[5] = "$"+templist[5]; 
                        int count2 = 11-templist[2].Length;
                        
                        if(count2>0)
                        {
                           templist[2] += new string('_', count2);
                        }
                        

                        int count4 = 11- templist[4].Length ;
                        if(count4>0)
                        {
                            templist[4] += new string('_', count4)  ;
                        }
                        int count5 = 11 - templist[5].Length ;
                        if (count5>0)
                        {
                          templist[5] = new string('_', count5)+templist[5] ;
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,22}{4,32} {5,12}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");

                    }

                    if (line.Contains("Monthly Interest"))
                    {

                        String headache = values[0].ToString();
                        Char delimiter = ',';
                        String[] substrings = headache.Split(delimiter);
                        List<string> templist = new List<string>();
                        foreach (var substring in substrings)
                        {
                            templist.Add(substring);

                        }
                        templist[2] = "$" + templist[2];
                        templist[4] = "$" + templist[4];
                        templist[5] = "$" + templist[5];
                        int count2 = 11 - templist[2].Length;

                        if (count2 > 0)
                        {
                            templist[2] += new string('_', count2);
                        }


                        int count4 = 11 - templist[4].Length;
                        if (count4 > 0)
                        {
                            templist[4] += new string('_', count4);
                        }
                        int count5 = 11 - templist[5].Length;
                        if (count5 > 0)
                        {
                            templist[5] = new string('_', count5) + templist[5];
                        }
                        const string format = "{0,0} {1,13} {2,14}{3,28}{4,16} {5,10}";
                        string test = string.Format(format, templist[0], templist[1], templist[2], templist[3], templist[4], templist[5]);
                        paymenthistorytxtbox.AppendText(test + "\n");

                    }


                }
                paymenthistorytxtbox.AppendText(Environment.NewLine);

            }
           


                }
            }
        }

    

