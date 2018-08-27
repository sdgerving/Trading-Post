using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Trading_Post
{
    public partial class Main : Form
    {
        public static string fname, mname, lname, homephone, cellphone, workphone, addressline1, addressline2, city, state,make, model, year, color, vin, location, taxtype,itemid;
        decimal originalcost, taxtot, newtotal,cost,taxrate, interestrate, storagefee, taxtemp, temptotalwithtax, storagetemp;
        public static string activeDir = @"c:\LayawayData\CustomerInfo\";
        public static int archivecheck;
        public static string selectedfile = "tippycheck";
        int xcoord = 10, ycoord = 200, i;
        public string searchvalue, searchvaluecaps, finalpath;
        
        public DateTime billdate;
        public decimal taxtottemp;
        RadioButton[] radioButtons = new RadioButton[50];
        public Main()
        {
            InitializeComponent();
        }

        private void findcustbtn_Click(object sender, EventArgs e)
        {
            
            int i = 0, j = 0;
            
            foreach (string d in Directory.GetDirectories(activeDir))
            {
                i += 1;
                j += 1;
                string text = Path.GetFileName(d);

                var base64EncodedBytes = System.Convert.FromBase64String(text);
                var encodedtext = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                string correctstring = encodedtext.Replace(",", " ");
                radioButtons[i] = new RadioButton();
                radioButtons[i].Text = correctstring;
                radioButtons[i].Size = new Size(180, 30);
                radioButtons[i].Font = new Font(radioButtons[i].Font.FontFamily, 14);
                radioButtons[i].Location = new System.Drawing.Point(xcoord, ycoord + (j * 25));
                radioButtons[i].CheckedChanged += RadioButton_CheckedChanged;
                this.Controls.Add(radioButtons[i]);

                if (i == 10 || i == 20 || i == 30 || i == 40)
                {
                    if (i==40)
                    {
                        xcoord = 0;
                    }
                    xcoord += 180;
                    ycoord = 200;
                    j = 0;

                }
                findcustbtn.Hide();

                cancelbtn.Show();
            }
        }

        private void NewLayawayBtn_Click(object sender, EventArgs e)
        {
            MonthlyCharges();
            NewLayawayForm nlf = new Trading_Post.NewLayawayForm();
            nlf.Show();
            this.Hide();
        }
        public void MonthlyCharges()
        {
            DateTime thisday = DateTime.Today;

           
            var allFiles = Directory.GetFiles(activeDir, "*Data.txt", SearchOption.AllDirectories);
            List<string> filelist = new List<string>();
            foreach (string files in allFiles)
            {
                List<string> listA = new List<string>();
                using (var reader = new StreamReader(files))
                {

                    try
                    {
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
                    catch (Exception e)
                    {
                        //listBox1.Items.Add("fail!!!!");
                    }
                }
                //billdate = new DateTime(2017, 11, 30);

               
                if (billdate < thisday)
                {
                    taxtemp = newtotal * (interestrate / 100);
                    //test2.Text = newtotal + " * " + interestrate + " = " + taxtemp + "   " + billdate;
                    temptotalwithtax = newtotal + taxtemp;
                   // test.Text = newtotal + " + " + taxtemp + " = " + temptotalwithtax; 
                    storagetemp = temptotalwithtax + storagefee;
                    billdate = thisday.AddMonths(1);

                   
                    //listBox1.Items.Add(billdate);
                    // balance = Decimal.Parse(listA[20]);
                    //newtotal = Decimal.Parse(listA[20]);
                    //taxtottemp = decimal.Round(newtotal * .01m, 2);
                    //newbalance = taxtottemp + newtotal;
                    //listBox1.Items.Add(balance + "* (1%) = " + taxtottemp +" = "+newbalance);


                    editfile();

                }
            }
        }
        private void editfile()
        {
            if (!File.Exists(finalpath))
            {
                
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

                using (StreamWriter sw = File.CreateText(path))
                {
                   

                    var plaintextbytes1 = System.Text.Encoding.UTF8.GetBytes(fname + "," + mname + "," + lname + "," + homephone + "," + cellphone +
                             "," + workphone + "," + addressline1 + "," + addressline2 + "," + city + "," + state + "," + make + "," + model + "," +
                             year + "," + color + "," + vin + "," + location + "," + cost + "," + originalcost + "," + taxtot + "," + taxtype + "," + taxrate + "," + Decimal.Round(storagetemp, 2) + "," + billdate + "," + interestrate + "," + storagefee + "," +itemid);
                    var finishbytes1 = System.Convert.ToBase64String(plaintextbytes1);
                    sw.WriteLine(finishbytes1);

                    string path2 = finalpath + @"\" + "note.txt";
                    if (!File.Exists(finalpath))
                    {

                        using (StreamWriter aw = File.AppendText(path2))
                        {
                            aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + Decimal.Round(newtotal, 2) + "," + "Monthly Interest(" + Decimal.Round(interestrate) +"%)" + "," + "+$" + Decimal.Round(taxtemp,2) + "," + Decimal.Round(temptotalwithtax, 2) + "~");
                            aw.WriteLine(DateTime.Today.ToString("MM-dd-yyyy") + "," + DateTime.Now.ToString("HH:mm:ss") + "," + Decimal.Round(temptotalwithtax, 2) + "," + "Storage Fee($" + Decimal.Round(storagefee) + ")"+"," +"$"+ Decimal.Round(storagefee) + "," + Decimal.Round(storagetemp, 2) + "~");
                        }

                    }

                }

            }
        }
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radiobutton = (RadioButton)sender;
            if (radiobutton.Checked)
            {
                nocustlabel.Hide();
                selectedfile = radiobutton.Text;
                findcustbtn.Hide();
                Confirmbtn.Show();
                cancelbtn.Show();
            }

        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            clearcha();
            Confirmbtn.Hide();
            cancelbtn.Hide();
            findcustbtn.Show();


            for (int j = 0; j < radioButtons.Length; j++)
            {
                Controls.Remove(radioButtons[j]);

            }
            i = 0;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                cancelbtn_Click( sender,  e);
                activeDir = @"c:\LayawayData\Archive\";
                Archivelabel.Show();
                archivecheck = 1;
            }
            else
            {
                cancelbtn_Click(sender, e);
                activeDir = @"c:\LayawayData\CustomerInfo\";
                Archivelabel.Hide();
            }
        }

        private void cancelbtn_Click_1(object sender, EventArgs e)
        {
            clearcha();
            Confirmbtn.Hide();
            cancelbtn.Hide();
            findcustbtn.Show();


            for (int j = 0; j < radioButtons.Length; j++)
            {
                Controls.Remove(radioButtons[j]);

            }
            i = 0;


        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void Confirmbtn_Click_1(object sender, EventArgs e)
        {
            MonthlyCharges();
            
            selectedfile = selectedfile.Replace(" ", ",");
            ManageAccount mnga = new Trading_Post.ManageAccount();
            mnga.Show();
            checkBox1.Checked = false;
            this.Hide();
            
        }

        private void findfilebycha()
        {
            int xcoord = 10, ycoord = 200;
            int j = 0;
            string activeDir = @"c:\LayawayData\CustomerInfo";
            foreach (string d in Directory.GetDirectories(activeDir))
            {
                i += 1;

                string text = Path.GetFileName(d);

                var base64EncodedBytes = System.Convert.FromBase64String(text);
                var encodedtext = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);

                List<string> listA = new List<string>();
                var base64EncodedBytes1 = System.Convert.FromBase64String(text);
                var encodedtext1 = System.Text.Encoding.UTF8.GetString(base64EncodedBytes1);
                var values = encodedtext1.Split(',');
                listA.Add(values[0]);
                listA.Add(values[1]);
                listA.Add(values[2]);
                var tempstring = listA[2];


                tempstring = tempstring.Substring(0, 1);

                if (searchvalue == tempstring || searchvaluecaps == tempstring)
                {
                    string correctstring = encodedtext.Replace(",", " ");
                    radioButtons[i] = new RadioButton();
                    radioButtons[i].Text = correctstring;
                    radioButtons[i].Size = new Size(230, 30);
                    radioButtons[i].Font = new Font(radioButtons[i].Font.FontFamily, 14);
                    radioButtons[i].Location = new System.Drawing.Point(xcoord, ycoord + (j * 25));
                    radioButtons[i].CheckedChanged += RadioButton_CheckedChanged;
                    this.Controls.Add(radioButtons[i]);
                    j += 1;
                    if (j == 20 || j == 12 || j == 18 || j == 24)
                    {
                        xcoord += 145;
                        ycoord = 5;
                        j = 0;

                    }
                }



            }
        }

        private void clearcha()
        {
            for (int j = 0; j < radioButtons.Length; j++)
            {
                Controls.Remove(radioButtons[j]);

            }
            i = 0;
            al.BackColor = Color.Tan;
            bl.BackColor = Color.Tan;
            cl.BackColor = Color.Tan;
            dl.BackColor = Color.Tan;
            el.BackColor = Color.Tan;
            fl.BackColor = Color.Tan;
            gl.BackColor = Color.Tan;
            hl.BackColor = Color.Tan;
            il.BackColor = Color.Tan;
            jl.BackColor = Color.Tan;
            kl.BackColor = Color.Tan;
            ll.BackColor = Color.Tan;
            ml.BackColor = Color.Tan;
            nl.BackColor = Color.Tan;
            ol.BackColor = Color.Tan;
            pl.BackColor = Color.Tan;
            ql.BackColor = Color.Tan;
            rl.BackColor = Color.Tan;
            sl.BackColor = Color.Tan;
            tl.BackColor = Color.Tan;
            ul.BackColor = Color.Tan;
            vl.BackColor = Color.Tan;
            wl.BackColor = Color.Tan;
            xl.BackColor = Color.Tan;
            yl.BackColor = Color.Tan;
            zl.BackColor = Color.Tan;
        }
        private void al_Click(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "a";
            searchvaluecaps = "A";
            findfilebycha();
            al.BackColor = Color.Yellow;
        }

        private void zl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "z";
            searchvaluecaps = "Z";
            findfilebycha();
            zl.BackColor = Color.Yellow;
        }

        private void yl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "y";
            searchvaluecaps = "Y";
            findfilebycha();
            yl.BackColor = Color.Yellow;
        }

        private void xl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "x";
            searchvaluecaps = "X";
            findfilebycha();
            xl.BackColor = Color.Yellow;
        }

        private void wl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "w";
            searchvaluecaps = "W";
            findfilebycha();
            wl.BackColor = Color.Yellow;
        }

        private void vl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "v";
            searchvaluecaps = "V";
            findfilebycha();
            vl.BackColor = Color.Yellow;
        }

        private void ul_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "u";
            searchvaluecaps = "U";
            findfilebycha();
            ul.BackColor = Color.Yellow;
        }

        private void tl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "t";
            searchvaluecaps = "T";
            findfilebycha();
            tl.BackColor = Color.Yellow;
        }

        private void sl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "s";
            searchvaluecaps = "S";
            findfilebycha();
            sl.BackColor = Color.Yellow;
        }

        private void ql_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "q";
            searchvaluecaps = "Q";
            findfilebycha();
            ql.BackColor = Color.Yellow;
        }

        private void pl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "p";
            searchvaluecaps = "P";
            findfilebycha();
            pl.BackColor = Color.Yellow;
        }

        private void ol_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "o";
            searchvaluecaps = "O";
            findfilebycha();
            ol.BackColor = Color.Yellow;
        }

        private void nl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "n";
            searchvaluecaps = "N";
            findfilebycha();
            nl.BackColor = Color.Yellow;
        }

        private void ml_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "m";
            searchvaluecaps = "M";
            findfilebycha();
            ml.BackColor = Color.Yellow;
        }

        private void ll_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "l";
            searchvaluecaps = "L";
            findfilebycha();
            ll.BackColor = Color.Yellow;
        }

        private void kl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "k";
            searchvaluecaps = "K";
            findfilebycha();
            kl.BackColor = Color.Yellow;
        }

        private void jl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "j";
            searchvaluecaps = "J";
            findfilebycha();
            jl.BackColor = Color.Yellow;
        }

        private void il_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "i";
            searchvaluecaps = "I";
            findfilebycha();
            il.BackColor = Color.Yellow;
        }

        private void bl_Click(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "b";
            searchvaluecaps = "B";
            findfilebycha();
            bl.BackColor = Color.Yellow;
        }

        private void cl_Click(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "c";
            searchvaluecaps = "C";
            findfilebycha();
            cl.BackColor = Color.Yellow;
        }

        private void dl_Click(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "d";
            searchvaluecaps = "D";
            findfilebycha();
            dl.BackColor = Color.Yellow;
        }

        private void el_Click(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "e";
            searchvaluecaps = "E";
            findfilebycha();
            el.BackColor = Color.Yellow;
        }

        private void fl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "f";
            searchvaluecaps = "F";
            findfilebycha();
            fl.BackColor = Color.Yellow;
        }


        private void gl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "g";
            searchvaluecaps = "G";
            findfilebycha();
            gl.BackColor = Color.Yellow;
        }

        private void hl_Click_1(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "h";
            searchvaluecaps = "H";
            findfilebycha();
            hl.BackColor = Color.Yellow;
        }

        private void rl_Click(object sender, EventArgs e)
        {
            clearcha();
            searchvalue = "r";
            searchvaluecaps = "R";
            findfilebycha();
            rl.BackColor = Color.Yellow;
        }

    }
}
