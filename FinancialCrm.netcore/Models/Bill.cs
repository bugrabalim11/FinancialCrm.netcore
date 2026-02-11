using System;
using System.Collections.Generic;

namespace FinancialCrm.netcore.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public string? BillTitle { get; set; }

    public decimal? BillAmount { get; set; }

    public string? BillPeriod { get; set; }
}
