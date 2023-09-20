using System.Windows.Forms;

namespace BS
{
    public partial class Sample : Form
    {
        public Sample()
        {
            InitializeComponent();
            MainClass.MsgCaption = "결제 시스템";
            MainClass.conString =
                @"Data Source=GOMDDANJI\SQLEXPRESS01;
                Initial Catalog=BillingSystem;
                Integrated Security=True";
            MainClass.con.ConnectionString = MainClass.conString;
        }
    }
}
