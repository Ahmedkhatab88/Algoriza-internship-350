using ApplicationLayer.BusinessLogic.Patients.Commands.AddPatient;
using ApplicationLayer.BusinessLogic.Patients.Commands.DeletePatient;
using ApplicationLayer.BusinessLogic.Patients.Commands.UpdatePatient;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientList;
using AutoMapper;
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
using PatientDetailViewModel = ApplicationLayer.BusinessLogic.Patients.Queries.GetPatientById.PatientDetailViewModel;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetAllDoctors;
using ApplicationLayer.BusinessLogic.Patients.Queries.GetAllBookings;
using ApplicationLayer.BusinessLogic.Patients.Commands.CancelBook;
using ApplicationLayer.BusinessLogic.Patients.Commands.AddBooking;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> usermanger;
        private readonly IConfiguration config;

        public PatientController(IMediator mediator, IMapper mapper, UserManager<ApplicationUser> usermanger, IConfiguration config)
        {
            _mediator = mediator;
            _mapper = mapper;
            this.usermanger = usermanger;
            this.config = config;
        }

        //Create Account new User "Registration" "Post"
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser register)
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
        [HttpGet("GetAllDoctors/{NumberOfPage}/{Size}")]
        public async Task<ActionResult<List<DoctorSearchViewModel>>> GetAllDoctors(int NumberOfPage, int Size)
        {
            var query = await _mediator.Send(new GetDoctorsListQuery() { NumberPage = NumberOfPage,SizePage = Size});

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetAllBookings/{patientId}")]
        public async Task<ActionResult<List<GetBookingViewModel>>> GetAllBookings(int patientId)
        {
            var query = await _mediator.Send(new GetBookingQuery() { PatientId = patientId});

            return Ok(query);
        }


        [Authorize]
        [HttpGet("CancelBooking/{bookId}")]
        public async Task<ActionResult<bool>> CancelBooking(int bookId)
        {
            var query = await _mediator.Send(new CancelBookCommand() { BookId = bookId });

            return Ok(query);
        }

        [Authorize]
        [HttpGet("Booking/{patientId}")]
        public async Task<ActionResult<bool>> Booking(int patientId,int doctorId,string status)
        {
            var query = await _mediator.Send(new AddBookingQuery() { PatientId = patientId,DoctorId = doctorId,status = status });

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetAllPatients")]
        public async Task<ActionResult<List<PatientDetailViewModel>>> GetAllPatients()
        {
            var query = await _mediator.Send(new GetPatientListQuery());

            return Ok(query);
        }

        [Authorize]
        [HttpGet("GetPatientById/{id}")]
        public async Task<ActionResult<PatientDetailViewModel>> GetPatientById(int id)
        {
            var query = await _mediator.Send(new GetPatientQuery() { id=id});

            return Ok(query);
        }

        [Authorize]
        [HttpPost("AddPatient")]
        public async Task<ActionResult<bool>> AddPatient(PatientDetailViewModel model)
        {
            var query = await _mediator.Send(new AddPatientCommand());

            return Created("", query);
        }



        [Authorize]
        [HttpPut("UpdatePatient/{id}")]
        public async Task<ActionResult<bool>> updatePatient(UpdatePatientRequest model, int id)
        {
            var UpdatePatientRequest = _mapper.Map<UpdatePatientCommand>(model);
            UpdatePatientRequest.Id = id;

            var query = await _mediator.Send(UpdatePatientRequest);

            return Ok(query);
        }

        [Authorize]
        [HttpDelete("DeletePatient/{id}")]
        public async Task<ActionResult<bool>> deletePatient(int id)
        {
            var Patient = new DeletePatientCommand() { id = id };

            var query = await _mediator.Send(Patient);

            return Ok(query);
        }

       
    }
}
