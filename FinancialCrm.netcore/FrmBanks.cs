using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FinancialCrm.netcore.Models;
using System.Linq;

namespace FinancialCrm.netcore
{
    public partial class FrmBanks : Form
    {
        FinancialCrmContext db = new FinancialCrmContext();
        public FrmBanks()
        {
            InitializeComponent();
        }

        private void FrmBanks_Load(object sender, EventArgs e)
        {
            // 1. Banka Bakiyelerini Listeleme
            // Ziraat Bankası (Örnek: ID'si veya Adı üzerinden çekebilirsin)
            var ziraatBankBalance = db.Banks.Where(x => x.BankTitle == "Ziraat Bankası").Select(y => y.BankBalance).FirstOrDefault();
            lblZiraatBankBalance.Text = ziraatBankBalance.ToString() + " ₺";

            // Vakıfbank
            var vakifBankBalance = db.Banks.Where(x => x.BankTitle == "Vakıf Bank").Select(y => y.BankBalance).FirstOrDefault();
            lblVakifBankBalance.Text = vakifBankBalance.ToString() + " ₺";

            // İş Bankası
            var isBankBalance = db.Banks.Where(x => x.BankTitle == "İş Bankası").Select(y => y.BankBalance).FirstOrDefault();
            lblİsBankasiBalance.Text = isBankBalance.ToString() + " ₺";

            // 2. Son 5 Banka Hareketini Listeleme (GroupBox içindeki akış)
            // Bu kısım veritabanındaki "BankProcesses" tablosundan son hareketleri çeker.

            var bankProcess1 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Take(1).FirstOrDefault();
            if (bankProcess1 != null) // Eğer veri varsa yazdır
            {
                lblBankProcess1.Text = bankProcess1.Description + " " + bankProcess1.Amount + " " + bankProcess1.ProcessDate;
            }
            else // Veri yoksa boş geç veya bilgi ver
            {
                lblBankProcess1.Text = "Hareket Yok";
            }
            var bankProcess2 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(1).Take(1).FirstOrDefault();
            if (bankProcess2 != null)
            {
                lblBankProcess2.Text = bankProcess2.Description + " " + bankProcess2.Amount + " " + bankProcess2.ProcessDate;
            }
            else
            {
                lblBankProcess2.Text = "Hareket Yok";
            }

            var bankProcess3 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(2).Take(1).FirstOrDefault();
            if (bankProcess3 != null)
            {
                lblBankProcess3.Text = bankProcess3.Description + " " + bankProcess3.Amount + " " + bankProcess3.ProcessDate;
            }
            else
            {
                lblBankProcess3.Text = "Hareket Yok";
            }

            var bankProcess4 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(3).Take(1).FirstOrDefault();
            if (bankProcess4 != null)
            {
                lblBankProcess4.Text = bankProcess4.Description + " " + bankProcess4.Amount + " " + bankProcess4.ProcessDate;
            }
            else
            {
                lblBankProcess4.Text = "Hareket Yok";
            }

            var bankProcess5 = db.BankProcesses.OrderByDescending(x => x.BankProcessId).Skip(4).Take(1).FirstOrDefault();
            if (bankProcess5 != null)
            {
                lblBankProcess5.Text = bankProcess5.Description + " " + bankProcess5.Amount + " " + bankProcess5.ProcessDate;
            }
            else
            {
                lblBankProcess5.Text = "Hareket Yok";
            }
        }
    }
}

