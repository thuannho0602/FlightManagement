using FlightManagement.Model.BookAPlace;
using FlightManagement.Model.Client;
using FlightManagement.Model.HoldSeat;
using FlightManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPlace_ClientController : BaseController
    {
        private IBookAPlaceServices _bookAPlaceServices;
        public BookAPlace_ClientController(IBookAPlaceServices bookAPlaceServices)
        {
            _bookAPlaceServices = bookAPlaceServices;
        }
        [HttpGet("HoldtheSeat")]
        public async Task<IEnumerable<HoldSeatResponse>> GetHoldTheSeatSeatSeat(HoldSeatRequest holdSeatRequest)
        {
            return await _bookAPlaceServices.GetHoldTheSeatSeatSeat(holdSeatRequest);
        }
        [HttpPost("{BookAPlaceID}/{HoldSeat}")]
        public async Task<bool> CreateBookAPlaceHoldSeat(int bookAPlaceID, HoldSeatInfo holdSeat)
        {
            return await _bookAPlaceServices.CreateHoldtheSeat(bookAPlaceID, holdSeat);
        }
        [HttpPost("CreateBookAPlace")]
        public async Task<int> CreateBookAPlace(BookAPlaceCreateRequest bookAPlace)
        {
            return await _bookAPlaceServices.CreateBookAPlace(bookAPlace);
        }
        [HttpPost("Client")]
        
        public async Task<int> CreateClient(ClientCreateRequest client)
        {
            return await _bookAPlaceServices.CreateClient(client);
        }
        [HttpGet("CustomerInformationBookingTickets")]
        public async Task<List<CustomerInformationBookingTickets>> GetCustomerInformation()
        {
            return await _bookAPlaceServices.GetCustomerInformation();
        }
        [HttpPost("GetMonthlyRevenueReport/{month}")]
        public async Task<List<RevenueByMonthResponse>> GetMonthlyRevenueReport(int month)
        {
            return await _bookAPlaceServices.GetMonthlyRevenueReport(month);
        }

        [HttpPost("GetAnnualRevenueReport/{year}")]
        public async Task<List<RevenueByYearResponse>> GetAnnualRevenueReport(int year)
        {
            return await _bookAPlaceServices.GetAnnualRevenueReport(year);
        }



    }
}
