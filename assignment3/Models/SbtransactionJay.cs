﻿using System;
using System.Collections.Generic;

namespace bankingwithdatabase.Models;

public partial class SbtransactionJay
{
    public int TransactionId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public int? AccountNumber { get; set; }

    public string? TrancationType { get; set; }

    public decimal? Amount { get; set; }

    public virtual SbaccountJay? AccountNumberNavigation { get; set; }
}
