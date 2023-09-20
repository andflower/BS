using System;

namespace BS
{
    public partial class SampleAdd : Sample
    {
        public SampleAdd()
        {
            InitializeComponent();
        }

        public int editID = 0;

        public virtual void btnSave_Click(object sender, EventArgs e)
        {

        }

        public virtual void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public virtual void btnDel_Click(object sender, EventArgs e)
        {

        }
    }
}
