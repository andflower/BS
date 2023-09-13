using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BS.View;
using BS.Model;

namespace BS
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
            MainClass.MsgCaption = "결제 시스템";
            MainClass.conString =
                @"Server=GOMDDANJI\\SQLEXPRESS01;
                  Database=BS;
                  Trusted_Connection=True;";
        }
    }
}
