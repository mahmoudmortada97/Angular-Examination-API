using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ExaminationAuthentication.Models;
using ExaminationAuthentication.DTO;
using ExaminationAuthentication.Repositories.InstructorRepository;
using ExaminationAuthentication.Repositories.StudentRepository;


namespace ExaminationAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentRepository _iStudentRepository;


        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration,
            IInstructorRepository instructorRepository,
             IStudentRepository iStudentRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _instructorRepository = instructorRepository;
            _iStudentRepository = iStudentRepository;
        }

        // Actions for user registration and authentication will be added here

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Role = model.Role,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            //await _userManager.AddToRoleAsync(user, model.Role);

            if (user.Role == "student")
            {
                var userManager = await _userManager.FindByEmailAsync(user.Email);
                var student = new Student()
                {
                    Id = userManager.Id,
                    Email = userManager.Email,
                    Password = userManager.PasswordHash,

                };
                _iStudentRepository.Create(student);

            }
            else
            {
                var userManager = await _userManager.FindByEmailAsync(user.Email);
                var instructor = new Instructor()
                {
                    Id = userManager.Id,
                    Email = userManager.Email,
                    Password = userManager.PasswordHash,
                };
                _instructorRepository.Create(instructor);
            }

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new{message= "success" });
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Wrong Email or Password");
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.FirstName),
            new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                message = "success",
                Name = user.FirstName,
                Role = user.Role,
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}