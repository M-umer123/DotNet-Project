using System;
using System.Collections.Generic;

namespace Project_1.Models;

public partial class BookingTbl
{
    public int BookId { get; set; }

    public string? BookerName { get; set; }

    public string? BookerPhone { get; set; }

    public string? BookerEmail { get; set; }

    public int? BookerTotalPersons { get; set; }

    public DateTime? BookerBookingDate { get; set; }
}
