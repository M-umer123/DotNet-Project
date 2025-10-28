namespace Project_1.Models
{
    public class DashboardViewModel
    {
        public int TotalBookings { get; set; }
        public int TotalMenuItems { get; set; }
        public int UpcomingBookings { get; set; }

        public List<BookingTbl> RecentBookings { get; set; }
        public List<Menu> Menus { get; set; }
    }
}
