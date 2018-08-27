using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trading_Post
{
    public partial class CustomerConfirm : Form
    {
        public static string fname, mname, lname, homephone, cellphone, workphone, addressline1, addressline2, city, state;

        private void AddressLine2label_Click(object sender, EventArgs e)
        {

        }

        public static string make, model, year, color, vin, location, cost;
        public static decimal remainbalance, originalcost;

        public CustomerConfirm()
        {
            InitializeComponent();
        }

        private void CustomerConfirm_Load(object sender, EventArgs e)
        {
            if (ManageAccount.custcheck == 1)
            {
                fnameprintlabel.Text = ManageAccount.fname;
                mnameprintlabel.Text = ManageAccount.mname;
                lnameprintlabel.Text = ManageAccount.lname;

                homephonelabel.Text = ManageAccount.homephone;
                cellphonelabel.Text = ManageAccount.cellphone;
                workphonelabel.Text = ManageAccount.workphone;

                addressline1data.Text = ManageAccount.addressline1;
                addressline2data.Text = ManageAccount.addressline2;
                citylabel.Text = ManageAccount.city;
                statelabel.Text = ManageAccount.state;

                makelabel.Text = ManageAccount.make;
                modellabel.Text = ManageAccount.model;
                yearlabel.Text = ManageAccount.year;
                colorlabel.Text = ManageAccount.color;
                VINlabel.Text = ManageAccount.vin;
                Vehicleloclabel.Text = ManageAccount.location;
                vehiclecostdatalabel.Text = ManageAccount.cost.ToString();
                
            }
            else
            {
                fnameprintlabel.Text = NewLayawayForm.fname;
                mnameprintlabel.Text = NewLayawayForm.mname;
                lnameprintlabel.Text = NewLayawayForm.lname;

                homephonelabel.Text = NewLayawayForm.homephone;
                cellphonelabel.Text = NewLayawayForm.cellphone;
                workphonelabel.Text = NewLayawayForm.workphone;

                addressline1data.Text = NewLayawayForm.addressline1;
                addressline2data.Text = NewLayawayForm.addressline2;
                citylabel.Text = NewLayawayForm.city;
                statelabel.Text = NewLayawayForm.state;

                makelabel.Text = NewLayawayForm.make;
                modellabel.Text = NewLayawayForm.model;
                yearlabel.Text = NewLayawayForm.year;
                colorlabel.Text = NewLayawayForm.color;
                VINlabel.Text = NewLayawayForm.vin;
                Vehicleloclabel.Text = NewLayawayForm.location;
                vehiclecostdatalabel.Text = NewLayawayForm.cost.ToString();
            }
        }

    }
  
}
