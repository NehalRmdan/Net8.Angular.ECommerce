using API.DTOS;
using API.Errors;
using API.Extensions;
using AutoMapper;
using core.Entities.Identity;
using core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IMapper mapper,
        ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet("user")]
        public async Task<UserDTO> GetCurrentUser()
        {
           var user= await _userManager.FindByEmailFromClaimsPrincipalAsync(User);
           if(user is null)
               return null;
           return new UserDTO{
                DisplayName= user.DisplayName,
                Email= user.Email,
                Token= _tokenService.CreateToken(user)
           };
        }

        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<Address>> GetUserAddress()
        {
            var user= await _userManager.FindByEmailWithAddressAsync(User);
            
            if(user is null)
                return BadRequest(new APIResponse(404));

           var address= _mapper.Map<AddressDto>(user.Address);
           
           return Ok(address);   
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<Address>> UpdateUserAddress(AddressDto addressDto)
        {
            var user= await _userManager.FindByEmailWithAddressAsync(User);
            
            user.Address= _mapper.Map<Address>(addressDto);
           
            var result= await _userManager.UpdateAsync(user);

            if(!result.Succeeded)
                return BadRequest("Problem not updating");
            
           var address= _mapper.Map<AddressDto>(user.Address);
            
            return Ok(address);   
        }

        [HttpPost("login")]
        public async  Task<ActionResult<UserDTO>> Login(LogInDTO login)
        {
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if(user is null) return Unauthorized(new APIResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            
            if(!result.Succeeded)
            {
                return Unauthorized(new APIResponse(401));
            }

            return new UserDTO{
                Email= user.Email,
                DisplayName= user.DisplayName,
                Token = _tokenService.CreateToken(user)
            };
           
        }

        [HttpPost("register")]
        public async Task<UserDTO> Register(RegisterDTO registerDTO)
        {
            var user= new AppUser{
                DisplayName= registerDTO.DisplayName,
                Email= registerDTO.Email,
                UserName= registerDTO.Email
            };

            await _userManager.CreateAsync(user,registerDTO.Password);

            return new  UserDTO{
                DisplayName=registerDTO.DisplayName,
                Email= registerDTO.Email,
                Token= _tokenService.CreateToken(user)
            };
        }

        [HttpGet("email-exists")]
        public async Task<bool> CheckMailExistsAsync(string email)
        {
              return  await _userManager.FindByEmailAsync(email) != null;
        }
    }
}