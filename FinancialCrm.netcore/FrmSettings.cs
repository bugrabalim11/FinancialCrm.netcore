using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using FinancialCrm.netcore.Models;
using System.Windows.Markup;

namespace FinancialCrm.netcore
{
    public partial class FrmSettings : Form
    {
        FinancialCrmContext db = new FinancialCrmContext();
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            txtUserId.Text = UserSession.UserId.ToString();

            var user = db.Users.Find(UserSession.UserId);
            if (user != null)
            {
                txtUsername.Text = user.UserName;
                txtPassword.Text = user.Password;
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        // {

        //}

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var newUser = new User();
            newUser.UserName = txtUsername.Text;
            newUser.Password = txtPassword.Text;

            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Ekleme İşlemi Başarılı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = UserSession.UserId;
            var user = db.Users.Find(id);
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Close(); 
        }
    }
}
