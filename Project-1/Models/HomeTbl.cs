using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class HomeTbl
{
    public int HomeId { get; set; }

    public string HomeTitle { get; set; } = null!;

    public string? HomeDesc { get; set; }

    public string HomeBgImg { get; set; } = null!;
}
