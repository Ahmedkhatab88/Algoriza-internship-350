using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.AddDiscountCodeCoupon;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.DeleteDiscountCodeCoupon;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Commands.UpdateDiscountCodeCoupon;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponById;
using ApplicationLayer.BusinessLogic.DiscountCodeCoupons.Queries.GetDiscountCodeCouponList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeCouponController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DiscountCodeCouponController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllDiscountCodeCoupons")]
        public async Task<ActionResult<List<DiscountCodeCouponViewModel>>> GetAllDiscountCodeCoupons()
        {
            var query = await _mediator.Send(new GetDiscountCodeCouponListQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountCodeCouponDetailedViewModel>> GetDiscountCodeCouponById(int id)
        {
            var query = await _mediator.Send(new GetDiscountCodeCouponByIdQuery() { Id = id });

            return Ok(query);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<bool>> AddDiscountCodeCoupon(DiscountCodeCouponViewModel model)
        {
            var query = await _mediator.Send(new AddDiscountCodeCouponCommand());

            return Created("", query);
        }


        [Authorize]
        [HttpPut]
        public async Task<ActionResult<bool>> updateDiscountCodeCoupon(UpdateDiscountCodeCouponRequest model, int id)
        {

            var map = _mapper.Map<UpdateDiscountCodeCouponCommand>(model);
            map.Id = id;

            var query = await _mediator.Send(map);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> deleteDiscountCodeCoupon(int id)
        {
            var DiscountCodeCoupon = new DeleteDiscountCodeCouponCommand() { Id = id };

            var query = await _mediator.Send(DiscountCodeCoupon);

            return Ok(query);
        }

    }
}
