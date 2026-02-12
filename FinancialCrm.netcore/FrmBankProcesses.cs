using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FinancialCrm.netcore.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialCrm.netcore
{

    public partial class FrmBankProcesses : Form
    {
        FinancialCrmContext db = new FinancialCrmContext();
        public FrmBankProcesses()
        {
            InitializeComponent();
        }
        private void GetAllProcesses()
        {
            var values = db.BankProcesses.ToList();
            dataGridView1.DataSource = values;
        }
        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            GetAllProcesses();
        }

        private void lblSearchProcess_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchProcess_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchProcess_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            DateOnly startDate = DateOnly.FromDateTime(dtpStart.Value);
            DateOnly endDate = DateOnly.FromDateTime(dtpEnd.Value);

            var filtredValues = db.BankProcesses
            .Where(x => x.ProcessDate >= startDate && x.ProcessDate <= endDate)
            .ToList();

            dataGridView1.DataSource = filtredValues;

            var totalAmount = filtredValues.Sum(x => x.Amount);
            lblTotalAmount.Text = (totalAmount ?? 0).ToString("C2");//totalAmount boş gelirse 0 say C2 para birimi şeklinde yazdırma
        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {
            
        }
    }
}
