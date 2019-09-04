using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UsersAccount.Dto;
using UsersAccount.Helpers;
using UsersAccount.Repository;
using UsersAccount.Models;
using Microsoft.IdentityModel.Protocols;

namespace UsersAccount.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _iUsersRepository;
        private readonly AppSettings _appSettings;
        public UsersServices(IOptions<AppSettings> appSettings, IUsersRepository iUsersRepository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _iUsersRepository = iUsersRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> ValidateUsersServices(string userName, string password)
        {
            User userModel = await _iUsersRepository.ValidateUsersRepository(userName, password);
            UserDto userDto = _mapper.Map<UserDto>(userModel);

            // return null if user not found
            if (userDto == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,Convert.ToString(userDto.UserId)),
                    //new Claim(ClaimTypes.Role,userDto.Role)
                    new Claim(ClaimTypes.Role,"Admin")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userDto.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            userDto.Password = null;
            return userDto;
        }
    }
}
