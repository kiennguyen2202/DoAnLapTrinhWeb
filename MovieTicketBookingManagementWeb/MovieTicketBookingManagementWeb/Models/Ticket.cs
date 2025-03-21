﻿using System;
using System.Collections.Generic;

namespace MovieTicketBookingManagementWeb.Models;

public partial class Ticket
{
    public int ID { get; set; }

    public int UserID { get; set; }

    public int ShowtimeID { get; set; }

    public int SeatID { get; set; }

    public string TicketType { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal FinalPrice { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? BookingTime { get; set; }

    public int? PopcornQuantity { get; set; }

    public int? DrinkQuantity { get; set; }

    public decimal? PopcornPrice { get; set; }

    public decimal? DrinkPrice { get; set; }

    public int? PaymentID { get; set; }

    public virtual Payment? Payment { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual Showtime Showtime { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
