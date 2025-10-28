using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class AboutTbl
{
    public int AboutId { get; set; }

    public string AboutTitle { get; set; } = null!;

    public string AboutDesc { get; set; } = null!;

    public string AboutBtnText { get; set; } = null!;
}
