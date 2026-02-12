using FinancialCrm.netcore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Linq;

namespace FinancialCrm.netcore
{
    public partial class FrmLogin : Form
    {
        FinancialCrmContext db = new FinancialCrmContext();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = db.Users.FirstOrDefault(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text);
            if (user != null)
            {
                FrmDashboard frm = new FrmDashboard();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!", "Giriş Başarısız!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
