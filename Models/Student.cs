﻿using System;
using System.Collections.Generic;

namespace bankingwithdatabase.Models;

public partial class Student
{
    public int Sid { get; set; }

    public string? Sname { get; set; }

    public double? Marks { get; set; }

    public DateOnly? Dob { get; set; }
}
