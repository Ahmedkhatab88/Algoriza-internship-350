
using ApplicationLayer.BusinessLogic.admins.Commands.AddAdmin;
using ApplicationLayer.BusinessLogic.admins.Commands.DeleteAdmin;
using ApplicationLayer.BusinessLogic.admins.Commands.UpdateAdmin;
using ApplicationLayer.BusinessLogic.admins.Queries.GetAdminById;
using ApplicationLayer.BusinessLogic.admins.Queries.GetAdminsList;
using ApplicationLayer.BusinessLogic.admins.Queries.GetNumberOfDoctors;
using ApplicationLayer.BusinessLogic.admins.Queries.GetNumberOfPatients;
using ApplicationLayer.BusinessLogic.admins.Queries.GetTopFiveSpecializations;
using ApplicationLayer.BusinessLogic.admins.Queries.GetTopTenDoctors;
using ApplicationLayer.BusinessLogic.admins.Queries.NumberOfRequestsLastday;
using ApplicationLayer.BusinessLogic.admins.Queries.NumOfRequests;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdminController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [Authorize]
        [HttpGet("NumberOfDoctors")]
        public async Task<ActionResult<int>> NumberOfDoctors()
        {
            var query = await _mediator.Send(new GetNumberOfDoctorsQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("NumberOfPatients")]
        public async Task<ActionResult<int>> NumberOfPatients()
        {
            var query = await _mediator.Send(new GetNumberOfPatientQuery());

            return Ok(query);
        }


        [Authorize]
        [HttpGet("NumberOfRequests")]
        public async Task<ActionResult<int>> NumberOfRequests()
        {
            var query = await _mediator.Send(new NumberOfRequestQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("NumberOfRequestsAtLastDay")]
        public async Task<ActionResult<int>> NumberOfRequestsAtLastDay()
        {
            var query = await _mediator.Send(new RequestsLastDayQuery());

            return Ok(query);
        }


        [Authorize]
        [HttpGet("TopTenDoctors")]
        public async Task<ActionResult<List<GetTopDoctorsViewModel>>> TopTenDoctors()
        {
            var query = await _mediator.Send(new GetTopTenDoctorsQuery());

            return Ok(query);
        }


        [Authorize]
        [HttpGet("TopFiveSpecializations")]
        public async Task<ActionResult<List<SpecializationViewModel>>> TopFiveSpecializations()
        {
            var query = await _mediator.Send(new TopFiveSpecializationsQuery());

            return Ok(query);
        }

       // [Authorize]
        [HttpGet("GetAllAdmins")]
        public async Task<ActionResult<List<AdminViewModel>>> GetAllAdmins()
        {
            var query = await _mediator.Send(new GetAdminListQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetAdminById/{id}")]
        public async Task<ActionResult<AdminDetailViewModel>> GetAdminById(int id)
        {
            var query = await _mediator.Send(new GetAdminByIdQuery() { Id=id});

            return Ok(query);
        }

        [Authorize]
        [HttpPost("AddAdmin")]
        public async Task<ActionResult<bool>> AddAdmin(AdminViewModel model)
        {
            var query = await _mediator.Send(new AddAdminCommand() { UserName= model.UserName, Password = model.Password});

            return Created("", query);
        }


        [Authorize]
        [HttpPut("updateAdmin/{id}")]
        public async Task<ActionResult<bool>> updateAdmin(UpdateAdminRequest model,int id)
        {

            var map = _mapper.Map<UpdateAdminCommand>(model);
            map.Id= id;
           
            var query = await _mediator.Send(map);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete("deleteAdmin/{id}")]
        public async Task<ActionResult<bool>> deleteAdmin(int id)
        {
            var Admin = new DeleteAdminCommand() { Id = id };

            var query = await _mediator.Send(Admin);

            return Ok(query);
        }


    }
}

/*
   
   "userName": "Ahmed_Khatab",
  "password": "89223116%Mo3ez",
 
  "userName": "Gomaa",
  "password": "Password$1984521a",

 */