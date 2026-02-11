using FinancialCrm.netcore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FinancialCrm.netcore
{
    public partial class FrmBilling : Form
    {
        // Global Context Nesnesi
        FinancialCrmContext db = new FinancialCrmContext();
        public FrmBilling()
        {
            InitializeComponent();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {
            // Form açıldığında listelesin
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnCreateBill_Click(object sender, EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string period = txtBillPeriod.Text;

            Bill bills = new Bill();
            bills.BillTitle = title;
            bills.BillAmount = amount;
            bills.BillPeriod = period;

            db.Bills.Add(bills);
            db.SaveChanges(); // Değişiklikleri veritabanına işle

            MessageBox.Show("Ödeme Başarıyla Eklendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Listeyi yenile ki eklenen görünsün
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var removeValue = db.Bills.Find(id); // ID'ye göre bul

            if (removeValue != null) // Eğer veri bulunduysa sil
            {
                db.Bills.Remove(removeValue);
                db.SaveChanges();
                MessageBox.Show("Ödeme Başarıyla Sistemden Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Listeyi yenile
                var values = db.Bills.ToList();
                dataGridView1.DataSource = values;
            }
            else // Eğer veri bulunamadıysa uyarı ver
            {
                MessageBox.Show("Sistemde bu ID'ye ait bir ödeme bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateBill_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtBillId.Text);
            var value = db.Bills.Find(id);

            if (value != null)
            {
                value.BillTitle = txtBillTitle.Text;
                value.BillAmount = decimal.Parse(txtBillAmount.Text);
                value.BillPeriod = txtBillPeriod.Text;

                db.SaveChanges();
                MessageBox.Show("Ödeme Başarıyla Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var values = db.Bills.ToList();
                dataGridView1.DataSource = values;
            } 
        }
    }
}
