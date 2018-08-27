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
    public partial class NewLayawayForm : Form
    {
       public static string fname, mname, lname, homephone, cellphone, workphone, addressline1, addressline2, city, state,make, model, year, color, vin, location, taxtype,itemid;

        private void NewLayawayForm_Load(object sender, EventArgs e)
        {

        }

        private void HomePhoneTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
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
            DateTime date2 = date.AddMonths(1);
            Titletxt = "             High Desert Trading Post" + "\n";
            Busaddresstxt = "                              3112 HWY 6 & 24" + "\n" + "                        Grand Junction, CO 81504" + "\n" + "                                (970-628-1452)" + "\n" + "                              " + date.ToString("MMMM dd, yyyy");
            divideline = "\n" + "____________________________________________" + "\n";

            vehiclelabeltxt = "Vehicle Information";
            shortlinetxt = "_________________";
            vehicletxt = "Make: " + make + "\n" + "Model: " + model + "\n" + "Year: " + year + "\n" + "Color: " + color + "\n" + "V.I.N.: " + vin + "\n";
            customerinfotxt = "Customer Information";
            Addresstxt = fname + " " + lname + "\n" + addressline1 + " " + addressline2 + "\n" + city + "," + state;

            Paymenttxt =  "Balance: " + newtotal;
            paydatetxt = "Next Payment is Due: " + date2.ToString("MM/dd/yyyy");

            Warningtxt = "Cancelled/Default accounts will forfeit all moneies paid. ";
            Signaturetxt = "Signature" + "                                                           " + "Date";

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
            g.DrawString(shortlinetxt, arial14, Brushes.Black, 510, 800);
            g.DrawString(shortlinetxt, arial14, Brushes.Black, 100, 800);
            g.DrawString(Signaturetxt, arial14, Brushes.Black, 100, 825);
        }

        private void printPreviewDialog1_Load(object sender, PrintPageEventArgs e)
        {
            
        }

        public static decimal originalcost, taxtot, newtotal, newbalance, balance,cost,taxrate,interestrate,storagefee;
       

        public NewLayawayForm()
        {
            InitializeComponent();
        }
        private void Submitbtn_Click(object sender, EventArgs e)
        {
            
            clearall();
            
            fname = CustomerFirstNameTextbox.Text;
            mname = CustomerMiddleNameTextbox.Text;
            lname = CustomerLastNameTextbox.Text;
           
            // homephone = HomePhoneTextbox1.Text;
            // cellphone = CellPhoneTextbox1.Text;
            //workphone = WorkPhoneTextbox1.Text;
            addressline1 = AddressLine1TextBox.Text;
            addressline2 = AddressLine2TextBox.Text;
            city = CityTextBox.Text;
            state = StateProvinceRegionTextBox.Text;
            make = VehicleMakeTextbox.Text;
            model = VehicleModelTextbox.Text;
            year = VehicleYearTextbox.Text;
            color = VehicleColorTextbox.Text;
            vin = VehicleVINTextbox.Text;
            location = VehicleLocationTextbox.Text;
            itemid = itemidtxt.Text;
            
          
          
            if (VehicleCostTextbox.Text != "")
            {
                if (!Regex.IsMatch(VehicleCostTextbox.Text, @"^[0-9]+$"))
                {
                    cost = 0;
                }
                else  cost = Decimal.Parse(VehicleCostTextbox.Text);
            }
          
            if(interestratetxtbx.Text!= "")
            {
                if (Regex.IsMatch(interestratetxtbx.Text, @"^\d+(.\d+){0,1}$"))
                {
                    interestrate = Decimal.Parse(interestratetxtbx.Text);
                    
                }
               
                else interestrate = 0.0M;
            }
                
            if (storagefeetxtbox.Text!= "")
            {
                if (!Regex.IsMatch(storagefeetxtbox.Text, @"^[0-9]+$"))
                {
                    storagefee = 0;
                }
                else storagefee = Decimal.Parse(storagefeetxtbox.Text);
            }
           
            
           
            if (Regex.IsMatch(cost.ToString(), @"^[0-9]+$"))
            {
                cost = Decimal.Parse(cost.ToString() + ".00");

            }
          
            checkfields();

        }
        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            phonewarninglabel.Hide();
            CustomerFirstNameTextbox.BackColor = Color.White;
            CustomerMiddleNameTextbox.BackColor = Color.White;
            CustomerLastNameTextbox.BackColor = Color.White;
            HomePhoneTextbox1.BackColor = Color.White;
            CellPhoneTextbox1.BackColor = Color.White;
            AddressLine1TextBox.BackColor = Color.White;
            AddressLine2TextBox.BackColor = Color.White;
            VehicleMakeTextbox.BackColor = Color.White;
            VehicleModelTextbox.BackColor = Color.White;
            VehicleYearTextbox.BackColor = Color.White;
            VehicleColorTextbox.BackColor = Color.White;
            VehicleVINTextbox.BackColor = Color.White;
            VehicleVINTextbox.BackColor = Color.White;
            VehicleCostTextbox.BackColor = Color.White;
            StateProvinceRegionTextBox.BackColor = Color.White;
            VehicleLocationTextbox.BackColor = Color.White;
            CityTextBox.BackColor = Color.White;
            warninglabel.Hide();
            Main newmain = new Trading_Post.Main();
            newmain.Show();
            this.Close();
        }

        public void checkfields()
        {
            int check = 0;
            if (fname == "")
            {
                CustomerFirstNameTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (mname == "")
            {
                CustomerMiddleNameTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (lname == "")
            {
                CustomerLastNameTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (homephone == "")
            {
                HomePhoneTextbox1.BackColor = Color.Yellow;
                warninglabel.Show();
            }
           
            if (CellPhoneTextbox1.Text == "" || CellPhoneTextbox2.Text == "" || CellPhoneTextbox3.Text == "")
            {
                CellPhoneTextbox1.BackColor = Color.Yellow;
                CellPhoneTextbox2.BackColor = Color.Yellow;
                CellPhoneTextbox3.BackColor = Color.Yellow;
                phonewarninglabel.Show();
            }
            else
            {
                cellphone = "(" + CellPhoneTextbox1.Text + ")" + CellPhoneTextbox2.Text + "-" + CellPhoneTextbox3.Text;
            }
            
               
            if (HomePhoneTextbox1.Text == "" || HomePhoneTextbox2.Text == "" || HomePhoneTextbox3.Text == "")
            {
                HomePhoneTextbox1.BackColor = Color.Yellow;
                HomePhoneTextbox2.BackColor = Color.Yellow;
                HomePhoneTextbox3.BackColor = Color.Yellow;
                phonewarninglabel.Show();
            }
            else
            {
               homephone = "(" + HomePhoneTextbox1.Text + ")" + HomePhoneTextbox2.Text + "-" + HomePhoneTextbox3.Text;
            }

            if (WorkPhoneTextbox1.Text == "" || WorkPhoneTextbox2.Text == "" || WorkPhoneTextbox3.Text == "")
            {
               
            }
            else
            {
                workphone = "(" + WorkPhoneTextbox1.Text + ")" + WorkPhoneTextbox2.Text + "-" + WorkPhoneTextbox3.Text;
            }

            if (cellphone != "" || homephone != "")
            {
                HomePhoneTextbox1.BackColor = Color.White;
                CellPhoneTextbox1.BackColor = Color.White;
            }

            if (addressline1 == "")
            {
                AddressLine1TextBox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            // if (addressline2 == "")
            //{
            //AddressLine2TextBox.BackColor = Color.Yellow;
            //warninglabel.Show();
            //}
            if (addressline1 != "" || addressline2 != "")
            {
                AddressLine1TextBox.BackColor = Color.White;
                AddressLine2TextBox.BackColor = Color.White;
            }
            if (city == "")
            {
                CityTextBox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (state == "")
            {
                StateProvinceRegionTextBox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (make == "")
            {
                VehicleMakeTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (model == "")
            {
                VehicleModelTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (year == "")
            {
                VehicleYearTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (color == "")
            {
                VehicleColorTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (vin == "")
            {
                VehicleVINTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (location == "")
            {
                VehicleLocationTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (Regex.IsMatch(cost.ToString(), @"^[a-z A-Z]+$"))
            {
                check = 1;
                VehicleCostTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if (cost == 0)
            {
                VehicleCostTextbox.BackColor = Color.Yellow;
                warninglabel.Show();
                
            }
            if(interestrate.ToString()=="0.0")
            {
                interestratetxtbx.BackColor = Color.Yellow;
                warninglabel.Show();
            }
            if(storagefee==0)
            {
                storagefeetxtbox.BackColor = Color.Yellow;
                warninglabel.Show();
            }

            if (fname != "" && mname != "" && lname != "" && state != "" && city != "" && make != "" && model != "" && year != "" && color != "" && vin != "" && location != "" && cost.ToString() != "" && check != 1 && cost!=0 &&interestrate.ToString()!="0.0"&&storagefee!=0)
            {
                if (homephone != "" || cellphone != "")
                {

                    if (addressline1 != "" || addressline2 != "")
                    {
                        if (!string.IsNullOrEmpty(fname))
                        {
                            fname = fname.First().ToString().ToUpper() + fname.Substring(1);
                        }
                       
                        if (!string.IsNullOrEmpty(lname))
                        {
                            lname = lname.First().ToString().ToUpper() + lname.Substring(1);
                        }
                        if (!string.IsNullOrEmpty(city))
                        {
                            city = city.First().ToString().ToUpper() + city.Substring(1);
                        }
                        if (!string.IsNullOrEmpty(make))
                        {
                            make = make.First().ToString().ToUpper() + make.Substring(1);
                        }
                        if (!string.IsNullOrEmpty(model))
                        {
                            model = model.First().ToString().ToUpper() + model.Substring(1);
                        }
                        if (!string.IsNullOrEmpty(color))
                        {
                            color = color.First().ToString().ToUpper() + color.Substring(1);
                        }

                        createcustfold();
                    }
                }

            }
            

        }
        public void taxesandfees()
        {
            if (checkBox1.Checked == true)
            {
                taxtype = "State&County Tax";
                taxrate = 5.23M;
                taxtot = decimal.Round((cost)* .0523m, 2);
                newtotal = decimal.Round(taxtot + (cost), 2);
            }
            if (!checkBox1.Checked == true)
            {
                taxtype = "State Tax";
                taxrate = 2.9M;
                taxtot = decimal.Round((cost) * .029m, 2);
                newtotal = decimal.Round(taxtot + (cost), 2);
            }
        }
        public void createcustfold()
        {
            CustomerConfirm custconf = new Trading_Post.CustomerConfirm();
            custconf.Show();
            const string message = "Is the customer information correct?";
            const string caption = "Confirm Customer Information";

            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                taxesandfees();
                custconf.Close();
                string activeDir = @"c:\LayawayData\CustomerInfo\";
                string result1 = mname.Substring(0, 1);
                string custDir = fname + "," + result1 + "," + lname;

                var plaintextbytes = System.Text.Encoding.UTF8.GetBytes(custDir);
                var finishbytes = System.Convert.ToBase64String(plaintextbytes);
                
                
                //Create a new subfolder under the current active folder

                string newPath = System.IO.Path.Combine(activeDir, finishbytes);
                // Create the subfolder
                System.IO.Directory.CreateDirectory(newPath);
                // createsavefile();
                string finalpath = System.IO.Path.Combine(activeDir, finishbytes);
                string path = finalpath + @"\" + "Data.txt";
                if (Regex.IsMatch(VehicleCostTextbox.Text, @"^[0-9]+$"))
                {
                    cost = Decimal.Parse(VehicleCostTextbox.Text.ToString() + ".00");
                    
                }
                else
                {
                    cost = Decimal.Parse(VehicleCostTextbox.Text.ToString());
                    
                }
                if (!File.Exists(finalpath))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        DateTime date = DateTime.Now.Date;
                       
                        newtotal += 55;
                        originalcost = newtotal;
                        date =date.AddMonths(1);
                        var plaintextbytes1 = System.Text.Encoding.UTF8.GetBytes(fname + "," + result1 + "," + lname + "," + homephone + "," + cellphone +
                            "," + workphone + "," + addressline1 + "," + addressline2 + "," + city + "," + state + "," + make + "," + model + "," +
                            year + "," + color + "," + vin + "," + location + "," + cost + "," + originalcost + "," + taxtot + "," + taxtype + "," + taxrate + "," + newtotal + "," + date+","+interestrate+","+storagefee+","+itemid);
                        var finishbytes1 = System.Convert.ToBase64String(plaintextbytes1);
                        sw.WriteLine(finishbytes1);
                        newtotal -= 55;
                        string path2 = finalpath + @"\" + "note.txt";
                        if (!File.Exists(finalpath))
                        {

                            using (StreamWriter aw = File.CreateText(path2))
                            {
                                DateTime thisDay = DateTime.Today;
                                DateTime thistime = DateTime.Now;
                                aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + cost + "," + "Account Created" + "," + "~");
                                aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + cost + "," + taxtype + " " + taxrate + "," + "+" + taxtot + "," + newtotal + "~");
                                cost = newtotal;
                                newtotal += 55;
                                aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + cost + "," + "Dealer Fee" + "," + "+55.00" + "," + newtotal + "~");
                               
                            }

                        }
                        printPreviewDialog1.ShowDialog();
                        this.Close();
                        Main main = new Main();
                        main.Show();
                    }


                }
            }
            else
            {

                custconf.Close();
            }
        }

        public void clearall()
        {
            phonewarninglabel.Hide();
            CustomerFirstNameTextbox.BackColor = Color.White;
            CustomerMiddleNameTextbox.BackColor = Color.White;
            CustomerLastNameTextbox.BackColor = Color.White;
            HomePhoneTextbox1.BackColor = Color.White;
            HomePhoneTextbox2.BackColor = Color.White;
            HomePhoneTextbox3.BackColor = Color.White;
            CellPhoneTextbox1.BackColor = Color.White;
            CellPhoneTextbox2.BackColor = Color.White;
            CellPhoneTextbox3.BackColor = Color.White;
            AddressLine1TextBox.BackColor = Color.White;
            AddressLine2TextBox.BackColor = Color.White;
            VehicleMakeTextbox.BackColor = Color.White;
            VehicleModelTextbox.BackColor = Color.White;
            VehicleYearTextbox.BackColor = Color.White;
            VehicleColorTextbox.BackColor = Color.White;
            VehicleVINTextbox.BackColor = Color.White;
            VehicleVINTextbox.BackColor = Color.White;
            VehicleCostTextbox.BackColor = Color.White;
            StateProvinceRegionTextBox.BackColor = Color.White;
            VehicleLocationTextbox.BackColor = Color.White;
            CityTextBox.BackColor = Color.White;
            interestratetxtbx.BackColor = Color.White;
            storagefeetxtbox.BackColor = Color.White;
            warninglabel.Hide();
        }
    }
}
