using System;
using System.Collections.Generic;

namespace FinancialCrm.netcore.Models;

public partial class Bank
{
    public int BankId { get; set; }

    public string? BankAccountNumber { get; set; }

    public string? BankTitle { get; set; }

    public decimal? BankBalance { get; set; }

    public virtual ICollection<BankProcess> BankProcesses { get; set; } = new List<BankProcess>();
}
