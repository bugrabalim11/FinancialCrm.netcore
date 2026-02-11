using System;
using System.Collections.Generic;

namespace FinancialCrm.netcore.Models;

public partial class Spending
{
    public int SpendingId { get; set; }

    public string? SpendingTitle { get; set; }

    public decimal? SpendingAmount { get; set; }

    public DateOnly? SpendingDate { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category SpendingNavigation { get; set; } = null!;
}
