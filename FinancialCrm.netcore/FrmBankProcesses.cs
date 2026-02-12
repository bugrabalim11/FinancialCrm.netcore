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

        private void FrmBankProcesses_Load(object sender, EventArgs e)
        {
            var values = db.BankProcesses
                .Include(x => x.Bank)
                .Select(y => new
                {
                    y.BankProcessId,
                    y.Description,
                    y.ProcessDate,
                    y.ProcessType,
                    y.Amount,
                    BankTitle = y.Bank.BankTitle
                }).ToList();
            dataGridView1.DataSource = values;
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
    }
}
