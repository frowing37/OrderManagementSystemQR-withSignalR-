using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR_Business.Abstract;
using SignalR_Entities.Concrete;
using SignalR_Dto.BookingDto;
using AutoMapper;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        protected readonly IBookingService _bookingService;
        protected readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.GetListAllwS());

            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = createBookingDto.Name,
                Mail = createBookingDto.Mail,
                Phone = createBookingDto.Phone,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date
            };

            _bookingService.AddwS(booking);

            return Ok("Rezervasyon eklendi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Mail = updateBookingDto.Mail,
                Phone = updateBookingDto.Phone,
                PersonCount = updateBookingDto.PersonCount
            };

            _bookingService.UpdatewS(booking);

            return Ok("Rezervasyon güncellendi");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int ID)
        {
            var value = _bookingService.GetByIDwS(ID);

            _bookingService.DeletewS(value);

            return Ok("Rezervasyon silindi");
        }

        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int ID)
        {
            var value = _bookingService.GetByIDwS(ID);

            return Ok(value);
        }
    }
}

