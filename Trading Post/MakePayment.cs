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

using System.Drawing.Printing;

namespace Trading_Post
{
    public partial class MakePayment : Form
    {

        public static string fname, mname, lname, homephone, cellphone, workphone, addressline1, addressline2, city, state, make, model, year, color, vin, location, taxtype, itemid;
        public static decimal originalcost, taxtot, newtotal, newbalance, balance, cost, taxrate, payment, interestrate, storagefee;
        public int check;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            String Titletxt = System.Environment.UserName;
            String Addresstxt = System.Environment.UserName;
            String Busaddresstxt = System.Environment.UserName;
            String divideline = System.Environment.UserName;
            String vehicletxt = System.Environment.UserName;
            String vehiclelabeltxt = System.Environment.UserName;
            String shortlinetxt = System.Environment.UserName;
            String customerinfotxt = System.Environment.UserName;
            String Paymenttxt = System.Environment.UserName;
            String paydatetxt = System.Environment.UserName;
            String Warningtxt = System.Environment.UserName;
            String Signaturetxt = System.Environment.UserName;
            DateTime date = DateTime.Now.Date;
            if (newtotal == 0)
            {
                Titletxt = "             High Desert Trading Post" + "\n";
                Busaddresstxt = "                              3112 HWY 6 & 24" + "\n" + "                        Grand Junction, CO 81504" + "\n" + "                                (970-628-1452)"+"\n"+"                              " + date.ToString("MMMM dd, yyyy");
                divideline = "\n" + "____________________________________________" + "\n";

                vehiclelabeltxt = "Vehicle Information";
                shortlinetxt = "_________________";
                vehicletxt = "Make: " + make + "\n" + "Model: " + model + "\n" + "Year: " + year + "\n" + "Color: " + color + "\n" + "V.I.N.: " + vin + "\n";
                customerinfotxt = "Customer Information";
                Addresstxt = fname + " " + lname + "\n" + addressline1 + " " + addressline2 + "\n" + city + "," + state;

                Paymenttxt = "Original Balance: " + cost + "\n" + "Payment: " + payment +".00" + "\n" + "New Balance: " + newtotal;
                paydatetxt = "This is the final payment on this account.";

                Warningtxt = "Cancelled/Default accounts will forfeit all moneies paid. ";
                Signaturetxt = "Signature" + "                                                                                                     "+ "Date";
            }
            else
            {
                Titletxt = "             High Desert Trading Post" + "\n";
                Busaddresstxt = "                              3112 HWY 6 & 24" + "\n" + "                        Grand Junction, CO 81504" + "\n" + "                                (970-628-1452)" + "\n" + "                              " + date.ToString("MMMM dd, yyyy");
                divideline = "\n" + "____________________________________________" + "\n";

                vehiclelabeltxt = "Vehicle Information";
                shortlinetxt = "_________________";
                vehicletxt = "Make: " + make + "\n" + "Model: " + model + "\n" + "Year: " + year + "\n" + "Color: " + color + "\n" + "V.I.N.: " + vin + "\n";
                customerinfotxt = "Customer Information";
                Addresstxt = fname + " " + lname + "\n" + addressline1 + " " + addressline2 + "\n" + city + "," + state;

                Paymenttxt = "Original Balance: " + cost + "\n" + "Payment: " + payment + ".00" + "\n" + "New Balance: " + newtotal;
                paydatetxt = "Next Payment is Due: " + billdate.ToString("MM/dd/yyyy");

                Warningtxt = "Cancelled/Default accounts will forfeit all moneies paid. ";
                Signaturetxt = "Signature" + "                                                           " + "Date";
            }
            Font arial24 = new Font("Arial", 24, System.Drawing.GraphicsUnit.Point);
            Font arial18 = new Font("Arial", 18, System.Drawing.GraphicsUnit.Point);
            Font arial14 = new Font("Arial", 14, System.Drawing.GraphicsUnit.Point);

            g.DrawString(Titletxt, arial24, Brushes.Black, 100, 100);
            g.DrawString(Busaddresstxt, arial18, Brushes.Black, 100, 140);
            g.DrawString(divideline, arial18, Brushes.Black, 100, 201);

            g.DrawString(customerinfotxt, arial14, Brushes.Black, 100, 270);
            g.DrawString(shortlinetxt, arial14, Brushes.Black, 100, 270);
            g.DrawString(Addresstxt, arial14, Brushes.Black, 100, 300);

            g.DrawString(vehiclelabeltxt, arial14, Brushes.Black, 495, 270);
            g.DrawString(shortlinetxt, arial14, Brushes.Black, 495, 271);
            g.DrawString(vehicletxt, arial14, Brushes.Black, 495, 300);
            g.DrawString(Paymenttxt, arial14, Brushes.Black, 100, 600);
            g.DrawString(paydatetxt, arial14, Brushes.Black, 415, 600);
            g.DrawString(divideline, arial18, Brushes.Black, 100, 620);
            g.DrawString(Warningtxt, arial14, Brushes.Black, 100, 685);
            g.DrawString(shortlinetxt, arial14, Brushes.Black,510, 800);
            g.DrawString(shortlinetxt, arial14, Brushes.Black, 100, 800);
            g.DrawString(Signaturetxt, arial14, Brushes.Black, 100, 825);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }



        public DateTime billdate;
        public MakePayment()
        {
            InitializeComponent();
        }

        private void MakePayment_Load(object sender, EventArgs e)
        {
            
            Application.OpenForms.OfType<ManageAccount>().First().Close();
            fname = ManageAccount.fname;
            mname = ManageAccount.mname;
            lname = ManageAccount.lname;
            homephone = ManageAccount.homephone;
            cellphone = ManageAccount.cellphone;
            workphone = ManageAccount.workphone;
            addressline1 = ManageAccount.addressline1;
            addressline2 = ManageAccount.addressline2;
            city = ManageAccount.city;
            state = ManageAccount.state;
            make = ManageAccount.make;
            model = ManageAccount.model;
            year = ManageAccount.year;
            color = ManageAccount.color;
            vin = ManageAccount.vin;
            location = ManageAccount.location;
            cost = ManageAccount.remainbalance;
            originalcost = ManageAccount.originalcost;
            taxtot = ManageAccount.taxtot;
            taxtype = ManageAccount.taxtype;
            taxrate = ManageAccount.taxrate;
            newtotal = ManageAccount.remainbalance;
            billdate = ManageAccount.billdate;
            previousbalancelabel.Text = cost.ToString();
            interestrate = ManageAccount.interestrate;
            storagefee = ManageAccount.storagefee;
            itemid = ManageAccount.itemid;
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            ManageAccount openma = new Trading_Post.ManageAccount();
            openma.Show();
            this.Close();
        }
        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            if (paymentbox.Text != "")
            {
                paymentbox.Hide();
                amountlabel.Show();
                if (Regex.IsMatch(paymentbox.Text, @"^[0-9]+$") )
                {
                    amountlabel.Text = paymentbox.Text.ToString() + ".00";
                    payment = Decimal.Parse(paymentbox.Text.ToString() + ".00");
                    Warninglabel.Hide();
                }
                else if(Regex.IsMatch(paymentbox.Text, @"^[0-9]*(?:\.[0-9]*)?$"))
                    {
                    amountlabel.Text = paymentbox.Text.ToString();
                    payment = Decimal.Parse(paymentbox.Text.ToString() );
                    Warninglabel.Hide();

                }
               else if (paymentbox.Text == "Default" || paymentbox.Text == "DEFAULT"|| paymentbox.Text == "default")
                {
                    const string message2 = "Is this account in Default?" +"\n" + "You are about to move it to the Archives Folder";
                    const string caption2 = "Confirm Move to Archives";
                    var result2 = MessageBox.Show(message2, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                    {
                        check = 1;
                        editfile();
                        string selectedfile = Main.selectedfile;
                        var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
                        var finishbytes = System.Convert.ToBase64String(plaintextbytes);

                        selectedfile = Main.selectedfile;
                        plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
                        finishbytes = System.Convert.ToBase64String(plaintextbytes);
                        Directory.Move(@"c:\LayawayData\CustomerInfo\" + finishbytes, @"c:\LayawayData\Archive\" + finishbytes);

                        this.Close();


                    }

                    else { this.Close(); ManageAccount nma = new ManageAccount(); nma.Show(); }
                }
                else if (!Regex.IsMatch(paymentbox.Text, @"^[0-9]+$"))
                {
                    Warninglabel.Show();
                    amountlabel.Hide();
                    paymentbox.Show();
                    return;
                }
                else
                {
                    Warninglabel.Hide();
                    amountlabel.Text = paymentbox.Text.ToString();
                    payment = Decimal.Parse(paymentbox.Text.ToString());
                }

                newbalancelabel.Show();

                newbalance = cost - payment;
                newbalancelabel.Text = newbalance.ToString();
                label3.Show();

                const string message = "Is the Payement amount correct?";
                const string caption = "Confirm Payment Amount";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    payment = Decimal.Parse(amountlabel.Text);
                    newtotal = newbalance;
                   Checkbalance();
                    this.Close();


                }
             
                else { this.Close(); ManageAccount nma = new ManageAccount();nma.Show(); }
            }
        }
        private void Checkbalance()
        {
            
            if (newtotal <= 0)
            {
                const string message = "This is the final payment on this account?";
                const string caption = "Account will be moved into the Archive's";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    
                    editfile();
                    string selectedfile = Main.selectedfile;
                    var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
                    var finishbytes = System.Convert.ToBase64String(plaintextbytes);

                    selectedfile = Main.selectedfile;
                    plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
                    finishbytes = System.Convert.ToBase64String(plaintextbytes);
                    Directory.Move(@"c:\LayawayData\CustomerInfo\" + finishbytes, @"c:\LayawayData\Archive\" + finishbytes);

                }
                else { this.Close(); ManageAccount nma = new ManageAccount(); nma.Show(); }
            }
            else
            {
               
                editfile();
            }
          
        }
        private void editfile()
        {

            string selectedfile = Main.selectedfile;
            var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(selectedfile);
            var finishbytes = System.Convert.ToBase64String(plaintextbytes);
            File.Copy(@"c:\LayawayData\CustomerInfo\" + finishbytes + @"\note.txt", @"c:\LayawayData\CustomerInfo\note.txt");
                string activeDir = @"c:\LayawayData\CustomerInfo\" + finishbytes + @"\Data.txt";
                File.Delete(activeDir);
                Directory.Delete(@"c:\LayawayData\CustomerInfo\" + finishbytes, true);
                if (!File.Exists(activeDir))
                {

                    string activeDir1 = @"c:\LayawayData\CustomerInfo\";

                    string custDir = fname + "," + mname + "," + lname;
                    var plaintextbytes1 = System.Text.Encoding.UTF8.GetBytes(custDir);
                    var finishbytes1 = System.Convert.ToBase64String(plaintextbytes1);
                    //Create a new subfolder under the current active folder
                    string newPath = System.IO.Path.Combine(activeDir1, finishbytes1);

                    // Create the subfolder
                    System.IO.Directory.CreateDirectory(newPath);
                    // createsavefile();
                    string finalpath = System.IO.Path.Combine(activeDir1, finishbytes1);
                    string path = finalpath + @"\" + "Data.txt";

                    if (!File.Exists(finalpath))
                    {

                        using (StreamWriter sw = File.CreateText(path))
                        {
                        DateTime thisDay = DateTime.Today;
                        DateTime thistime = DateTime.Now;
                        if (billdate <= thisDay)
                        {
                            billdate = billdate.AddMonths(1);
                        }
                        
                        var plaintextbytest1 = System.Text.Encoding.UTF8.GetBytes(fname + "," + mname + "," + lname + "," + homephone + "," + cellphone +
                                 "," + workphone + "," + addressline1 + "," + addressline2 + "," + city + "," + state + "," + make + "," + model + "," +
                                 year + "," + color + "," + vin + "," + location + "," + cost + "," + originalcost + "," + taxtot + "," + taxtype + "," + taxrate + "," + newtotal + "," + billdate + "," + interestrate + "," + storagefee + "," + itemid);
                            var finishbytes2 = System.Convert.ToBase64String(plaintextbytest1);
                            sw.WriteLine(finishbytes2);
                            string path2 = finalpath + @"\" + "note.txt";
                            File.Copy(@"c:\LayawayData\CustomerInfo\note.txt", finalpath + @"\note.txt");
                            File.Delete(@"c:\LayawayData\CustomerInfo\note.txt");
                            using (StreamWriter aw = File.AppendText(path2))
                            {
                                if(newtotal==0)
                                {
                                aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") +","+ "Account Has Been Paid in Full." + "~");
                                }
                            if (check == 1)
                            {
                                aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + ","+"(note)"+","+ "Account is delinquent and moved to archives." + "~");
                            }
                            else
                            {
                                aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + cost + "," + "Payment" + "," + "-" + payment + "," + newtotal + "," + "~");
                            }
                           

                        }


                        }

                    }

                    printPreviewDialog1.ShowDialog();

                }
                Main openmain = new Trading_Post.Main();
                openmain.Show();

            }

            }

        }
    

