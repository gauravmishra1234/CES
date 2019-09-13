using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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

namespace UsersAccount.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IMapper _mapper = null;
        private readonly IUsersRepository _iUsersRepository = null;
        private readonly AppSettings _appSettings = null;
        public UsersServices(IOptions<AppSettings> appSettings, IUsersRepository iUsersRepository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _iUsersRepository = iUsersRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> ValidateUsersServices(string email, string password)
        {
            try
            {
                string encrypted = string.Empty;
                string encryptkey = _appSettings.EncryptAndDecryptKey;
                if (!string.IsNullOrEmpty(password))
                {
                    encrypted = EncryptAndDecrypt.Encrypt(password, encryptkey);
                    password = encrypted;
                }

                User userModel = await _iUsersRepository.ValidateUsersRepository(email, password);
                UserDto userDto = _mapper.Map<UserDto>(userModel);

                if (userModel.Role != null && !(string.IsNullOrEmpty(userModel.Role.Role1)))
                    userDto.Role = userModel.Role.Role1;

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
                    new Claim(ClaimTypes.Role,userDto.Role)
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
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersServices(int pageNum)
        {
            try
            {
                IEnumerable<User> userModel = await _iUsersRepository.GetAllUsersRepository(pageNum);
                IEnumerable<UserDto> userDto = _mapper.Map<IEnumerable<UserDto>>(userModel);
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<UserDto> GetByUserIdServices(int userId)
        {
            try
            {
                User userModel = await _iUsersRepository.GetByUserIdRepository(userId);
                UserDto userDto = _mapper.Map<UserDto>(userModel);
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> UpdateByUserIdServices(UserDto userDto)
        {
            int result = 0;
            try
            {
                User user = _mapper.Map<User>(userDto);
                result = await _iUsersRepository.UpdateByUserIdRepository(user);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<int> InsertUserServices(UserDto userDto)
        {
            int result = 0;
            try
            {
                string encrypted = string.Empty;
                string key = _appSettings.EncryptAndDecryptKey;
                if (!string.IsNullOrEmpty(userDto.Password))
                {
                    encrypted = EncryptAndDecrypt.Encrypt(userDto.Password, key);
                    userDto.Password = encrypted;
                }
                User user = _mapper.Map<User>(userDto);
                result = await _iUsersRepository.InsertUserRepository(user);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<int> DeleteByIdServices(int userId)
        {
            int result = 0;
            try
            {
                result = await _iUsersRepository.DeleteByIdUserRepository(userId);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<UserDto> ValidateEmailServices(string email)
        {
            try
            {
                User userModel = await _iUsersRepository.ValidateEmailRepository(email);
                UserDto userDto = _mapper.Map<UserDto>(userModel);
                userDto.Password = null;
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
