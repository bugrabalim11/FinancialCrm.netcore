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
            int id = int.Parse(txtUserId.Text);
            var user = db.Users.Find(id);
            user.UserName=txtUsername.Text;
            user.Password=txtPassword.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi Başarılı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
