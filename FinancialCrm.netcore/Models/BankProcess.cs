using System;
using System.Collections.Generic;

namespace FinancialCrm.netcore.Models;

public partial class BankProcess
{
    public int BankProcessId { get; set; }

    public string? Description { get; set; }

    public DateOnly? ProcessDate { get; set; }

    public string? ProcessType { get; set; }

    public decimal? Amount { get; set; }

    public int? BankId { get; set; }

    public virtual Bank? Bank { get; set; }
}
