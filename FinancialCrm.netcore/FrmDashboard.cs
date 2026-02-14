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
    public partial class FrmDashboard : Form
    {
        FinancialCrmContext db = new FinancialCrmContext();
        int count = 0;
        private void BankProcessList()
        {
            var values = db.BankProcesses.OrderByDescending(x => x.BankProcessId)
                           .Select(x => new
                           {
                               x.Description,
                               x.Amount,
                               x.ProcessDate
                           }).ToList();
            dataGridView1.DataSource = values;
        }
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;

            // 1. Üstteki Sabit Panelleri Güncelle (Toplam Bakiye)
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = ((decimal)totalBalance).ToString("N2") + " ₺";

            // 2. Fatura Başlığı ve Miktarını Döndür (Mod işlemi ile)
            if (count % 4 == 1)
            {
                var bill1 = db.Bills.Where(x => x.BillTitle == "Elektrik Faturası").FirstOrDefault();
                lblBillTitle.Text = "Elektrik Faturası";
                lblBillAmount.Text = (bill1?.BillAmount?.ToString("N2") ?? "0.00") + " ₺";
            }
            if (count % 4 == 2)
            {
                var bill2 = db.Bills.Where(x => x.BillTitle == "Doğalgaz Faturası").FirstOrDefault();
                lblBillTitle.Text = "Doğalgaz Faturası";
                lblBillAmount.Text = (bill2?.BillAmount?.ToString("N2") ?? "0.00") + " ₺";
            }
            if (count % 4 == 3)
            {
                var bill3 = db.Bills.Where(x => x.BillTitle == "Su Faturası").FirstOrDefault();
                lblBillTitle.Text = "Su Faturası";
                lblBillAmount.Text = (bill3?.BillAmount?.ToString("N2") ?? "0.00") + " ₺";
            }
            if (count % 4 == 0)
            {
                var bill4 = db.Bills.Where(x => x.BillTitle == "İnternet Faturası").FirstOrDefault();
                lblBillTitle.Text = "İnternet Faturası";
                lblBillAmount.Text = (bill4?.BillAmount?.ToString("N2") ?? "0.00") + " ₺";
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            // Veritabanındaki son banka hareketini tarihine göre veya ID'sine göre tersten sıralayıp ilkini alıyoruz
            var lastBankProcess = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Description).FirstOrDefault();

            // Eğer veri varsa yazdır, yoksa "Veri Yok" de
            lblLastBankProcessAmount.Text = lastBankProcess ?? "Son havale bulunamadı";


            // Son 10 işlemi getiriyoruz ve sadece gerekli sütunları seçiyoruz (Anonim tip kullanarak)
            var values = db.BankProcesses.OrderByDescending(x => x.BankProcessId)
                           .Take(10)
                           .Select(x => new
                           {
                               Açıklama = x.Description,
                               Miktar = x.Amount,
                               Tarih = x.ProcessDate
                           }).ToList();

            dataGridView1.DataSource = values;
        }

        private void lblSettingForm_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frmBilling = new FrmBilling();
            frmBilling.Show();
            this.Hide();
        }

        private void lblBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frmBanks = new FrmBanks();
            frmBanks.Show();
            this.Hide();
        }

        private void lblBankForm_Click(object sender, EventArgs e)
        {
            FrmBankProcesses frmBankProcesses = new FrmBankProcesses();
            frmBankProcesses.Show();
            this.Hide();
        }

        private void lblExitForm_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Hide();
        }
    }

}
