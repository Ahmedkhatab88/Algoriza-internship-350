
using ApplicationLayer.BusinessLogic.Settings.Commands.AddSetting;
using ApplicationLayer.BusinessLogic.Settings.Commands.DeactivateCommand;
using ApplicationLayer.BusinessLogic.Settings.Commands.DeleteSetting;
using ApplicationLayer.BusinessLogic.Settings.Commands.UpdateSetting;
using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingById;
using ApplicationLayer.BusinessLogic.Settings.Queries.GetSettingList;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SettingController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet("GetAllSettings")]
        public async Task<ActionResult<List<SettingViewModel>>> GetAllSettings()
        {
            var query = await _mediator.Send(new GetSettingListQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetSettingById/{id}")]
        public async Task<ActionResult<SettingDetailViewModel>> GetSettingById(int id)
        {
            var query = await _mediator.Send(new GetSettingQuery() { id=id});

            return Ok(query);
        }

        [Authorize]
        [HttpPost("AddSetting")]
        public async Task<ActionResult<int>> AddSetting(AddSettingCommand model)
        {
            var query = await _mediator.Send(new AddSettingCommand()
            {
                DoctorId = model.DoctorId,
                Price = model.Price,
                TimeSlot = model.TimeSlot,
            });

            return Created("",query);
        }



        [Authorize]
        [HttpPut("UpdateSetting/{id}")]
        public async Task<ActionResult<bool>> updateSetting(UpdateSettingRequest model,int id)
        {
            var UpdateSettingCommand = _mapper.Map<UpdateSettingCommand>(model);
            UpdateSettingCommand.Id= id;

            var query= await _mediator.Send(UpdateSettingCommand);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete("DeleteSetting/{id}")]
        public async Task<ActionResult<bool>> deleteSetting(int id)
        {
            var Setting = new DeleteSettingCommand() { Id = id };

            var query = await _mediator.Send(Setting);

            return Ok(query);
        }


        [Authorize]
        [HttpDelete("Deactivate/{Id}")]
        public async Task<ActionResult<bool>> Deactivate(int Id)
        {
            var command = await _mediator.Send(new DeactivateSettingCommand() { id = Id });

            return Ok(command);
        }

    }
}

