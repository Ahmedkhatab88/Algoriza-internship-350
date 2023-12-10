using ApplicationLayer.BusinessLogic.Bills.Commands.AddBill;
using ApplicationLayer.BusinessLogic.Bills.Commands.DeleteBill;
using ApplicationLayer.BusinessLogic.Bills.Commands.UpdateBill;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsById;
using ApplicationLayer.BusinessLogic.Bills.Queries.GetBillsList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BookingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet("GetAllBookings")]
        public async Task<ActionResult<List<BookingViewModel>>> GetAllBookings()
        {
            var query = await _mediator.Send(new GetBookingListQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetBookingById/{id}")]
        public async Task<ActionResult<BookingDetailViewModel>> GetBookingById(int id)
        {
            var query = await _mediator.Send(new GetBookingQuery() { id = id });

            return Ok(query);
        }

        [Authorize]
        [HttpPost("AddBooking")]
        public async Task<ActionResult<int>> AddBooking(AddBookingCommand model)
        {
            var query = await _mediator.Send(model);

            return Created("", query);
        }



        [Authorize]
        [HttpPut("updateBooking/{id}")]
        public async Task<ActionResult<bool>> updateBooking(UpdateBookingRequest model, int id)
        {
            var UpdateBillCommand = _mapper.Map<UpdateBookingCommand>(model);
            UpdateBillCommand.Id= id;

            var query = await _mediator.Send(UpdateBillCommand);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete("deleteBooking/{id}")]
        public async Task<ActionResult<bool>> deleteBooking(int id)
        {
            var query = await _mediator.Send(new DeleteBookingCommand() { id = id });

            return Ok(query);
        }

    }
}
