using FlightManagement.Model.Client;
using FlightManagement.Model.HoldSeat;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Model.BookAPlace
{

    public class BookAPlaceCreateRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime? ReturnDay { get; set; }
        public int FlightID { get; set; }
        public int ClientID { get; set; }
    }

    //Doanh Thu Theo Tháng
    public class RevenueByMonthResponse
    {
        public string NamePlane { get; set; }
        public int PlaneId { get; set; }
        public int FlightId { get; set; }
        public decimal Revenue { get; set; }
        public int TicketNumber { get; set; }
    }
    public class RevenueByYearResponse
    {
        public int Month { get; set; }
        public string NamePlane { get;set; }
        public int PlaneId { get; set; }
        public int FlightId { get; set; }
        public decimal Revenue { get; set; }
        public int FlightNumber { get; set; }
    }


    //Thong tin khách hàng Đặt Vé 
    public class CustomerInformationBookingTickets
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StartDate { get; set; }
        public string ReturnDay { get; set; }
        public string Time { get; set; }
        public string NamePlane { get; set; }
    }


    // Đặt Chổ Inof
    public class BookAPlaceInof
    {
        public BookAPlaceCreateRequest BookAPlace { get; set; }
        public ClientCreateRequest Client { get; set; }
        public List<HoldSeatInfo> HoldSeats { get; set; }
    }
}
