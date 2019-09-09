using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAccount.Dto;
using UsersAccount.Repository;
using UsersAccount.Models;

namespace UsersAccount.Services
{
    public class RolesServices: IRolesServices
    {
        private readonly IMapper _mapper;
        private readonly IRolesRepository _iRolesRepository;
        public RolesServices(IRolesRepository iRolesRepository, IMapper mapper)
        {
            _iRolesRepository = iRolesRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleDto>> GetAllRolesServices()
        {
            var roleModel = await _iRolesRepository.GetAllRolesRepository();
            var roleDto = _mapper.Map<IEnumerable<RoleDto>>(roleModel);
            return roleDto;
        }
    }
}
