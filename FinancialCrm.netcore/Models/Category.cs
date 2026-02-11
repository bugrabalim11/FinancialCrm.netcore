using System;
using System.Collections.Generic;

namespace FinancialCrm.netcore.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual Spending? Spending { get; set; }
}
