using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Drawing;

namespace Trading_Post
{
    class PrintSample
    {
        public void RunSample()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.PrintPageEvent);
            pd.Print();
        }

        private void PrintPageEvent(object sender, PrintPageEventArgs ev)
        {
            string strHello = "Hello Printer!";
            Font oFont = new Font("Arial", 10);
            Rectangle marginRect = ev.MarginBounds;

            ev.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Black), marginRect);
            ev.Graphics.DrawString(strHello, oFont, new SolidBrush(System.Drawing.Color.Blue),
              (ev.PageBounds.Right / 2), ev.PageBounds.Bottom / 2);
        }
    }
}
