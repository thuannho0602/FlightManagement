using FlightManagement.Model.BookAPlace;
using FlightManagement.Model.Client;
using FlightManagement.Model.HoldSeat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightManagement.Services
{
    public interface IBookAPlaceServices
    {
        Task<List<HoldSeatResponse>> GetHoldTheSeatSeatSeat(HoldSeatRequest holdSeatRequest);
        Task<bool> CreateHoldtheSeat(int bookAPlaceID, HoldSeatInfo holdSeat);
        Task<int> CreateClient(ClientCreateRequest client);
        Task<int> CreateBookAPlace(BookAPlaceCreateRequest bookAPlace);
        Task<bool> CreateBookAPlace(BookAPlaceInof bookAPlaceInof);

        Task<List<CustomerInformationBookingTickets>> GetCustomerInformation();


        Task<List<RevenueByMonthResponse>> GetMonthlyRevenueReport(int month);

        Task<List<RevenueByYearResponse>> GetAnnualRevenueReport(int year);



    }
}
