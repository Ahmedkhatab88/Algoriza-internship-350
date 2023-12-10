using ApplicationLayer.BusinessLogic.Doctors.Commands.AddDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Commands.DeleteDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Commands.UpdateDoctor;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsByName;
using ApplicationLayer.BusinessLogic.Doctors.Queries.GetDoctorsList;
using AutoMapper;
using DomainLayer.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using persistence.Identity.IdentityModels;
using persistence.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationLayer.BusinessLogic.Doctors.Commands.ConfirmCheckUp;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly IConfiguration config;

        public DoctorController(IMediator mediator, IMapper mapper, UserManager<ApplicationUser> usermanger, IConfiguration config)
        {
            _mediator = mediator;
            _mapper = mapper;
            this.usermanger = usermanger;
            this.config = config;
        }

        //Create Account new User "Registration" "Post"
        [HttpPost("register")]
        public async Task<IActionResult> Registration(RegisterUser register)
        {
            if (ModelState.IsValid)
            {
                //save
                ApplicationUser user = new ApplicationUser();
                user.UserName = register.UserName;
                user.Email = register.Email;

                IdentityResult result = await usermanger.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Add Success");
                }
                return BadRequest(result.Errors.FirstOrDefault());
            }
            return BadRequest(ModelState);
        }


        //Check Account Valid "Login" "Post"

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser login)
        {
            if (ModelState.IsValid == true)
            {
                //check - create token
                ApplicationUser user = await usermanger.FindByNameAsync(login.UserName);
                if (user != null)//user name found
                {
                    bool found = await usermanger.CheckPasswordAsync(user, login.Password);
                    if (found)
                    {
                        //Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        //get role
                        var roles = await usermanger.GetRolesAsync(user);
                        foreach (var itemRole in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, itemRole));
                        }
                        SecurityKey securityKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //Create token
                        JwtSecurityToken mytoken = new JwtSecurityToken(
                            issuer: config["JWT:ValidIssuer"],//url web api
                            audience: config["JWT:ValidAudiance"],//url consumer angular
                            claims: claims,
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signincred
                            );
                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                            expiration = mytoken.ValidTo
                        });
                    }
                }
                return Unauthorized();

            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("GetAllDoctors")]
        public async Task<ActionResult<List<DoctorViewModel>>> GetAllDoctors()
        {
            var query = await _mediator.Send(new GetDoctorListQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetDoctorById/{id}")]
        public async Task<ActionResult<DoctorDetailViewModel>> GetDoctorById(int id)
        {
            var query = await _mediator.Send(new GetDoctorQuery() { id=id});

            return Ok(query);
        }

        [Authorize]
        [HttpGet("CheckUpBooking/{bookingId}")]
        public async Task<ActionResult<bool>> CheckUpBooking(int bookingId)
        {
            var query = await _mediator.Send(new CheckUpBookingCommand() { BookingId = bookingId });

            return Ok(query);
        }


        [Authorize]
        [HttpPost("AddDoctor")]
        public async Task<ActionResult<int>> AddDoctor(DoctorViewModel model)
        {
            
            var query = await _mediator.Send(new AddDoctorCommand()
            {
                Specialize = model.Specialize,
                Phone = model.Phone,
                Image = model.Image,
                Gender = model.Gender,
                FullName = model.FullName,
                Email = model.Email,
                AdminId = model.AdminId

            });

            return Created("", query);
        }


        [Authorize]
        [HttpPut("UpdateDoctor/{id}")]
        public async Task<ActionResult<bool>> updateDoctor(UpdateDoctorRequest model, int id)
        {
            var UpdateDoctorCommand = _mapper.Map<UpdateDoctorCommand>(model);
            UpdateDoctorCommand.Id= id;

            var query = await _mediator.Send(UpdateDoctorCommand);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete("DeleteDoctor/{id}")]
        public async Task<ActionResult<bool>> deleteDoctor(int id)
        {
            var Doctor = new DeleteDoctorCommand() { id = id };

            var query = await _mediator.Send(Doctor);

            return Ok(query);
        }

    }
}
