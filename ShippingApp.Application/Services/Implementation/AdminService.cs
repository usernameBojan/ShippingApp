using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShippingApp.Application.Dto.Admin;
using ShippingApp.Application.Repository;
using ShippingApp.Application.Utilities;
using ShippingApp.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShippingApp.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Admin> adminRepository;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        public AdminService(IRepository<Admin> repository, IConfiguration configuration, IMapper mapper)
        {
            this.adminRepository = repository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public TokenDto Authenticate(LoginDto login)
        {
            var admin = adminRepository.Query().FirstOrDefault(
                x => x.Username == login.Username && x.Password == Hasher.HashPassword(login.Password))
                ?? throw new Exception("Not Found!");

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new (ClaimTypes.NameIdentifier, admin.Id.ToString()),
                new (ClaimTypes.Name, admin.FullName),
                new (ClaimTypes.GivenName, admin.Username),
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                                             configuration["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(55),
                                             signingCredentials: credentials);

            TokenDto tokenDto = new()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

            return tokenDto;
        }
        public AdminDto GetAdmin(int id)
        {
            var admin = adminRepository.GetById(id) ?? throw new Exception("Not Found");

            return mapper.Map<AdminDto>(admin);
        }
        public IEnumerable<AdminDto> GetAdmins()
        {
            return adminRepository.Query().Select(x => mapper.Map<AdminDto>(x)).ToList();
        }
        public AdminDto CreateAdmin(CreateAdminDto dto, int adminId)
        {
            var currentAdmin = adminRepository.GetById(adminId) ?? throw new Exception("Not Found");

            if (!currentAdmin.CanManageAdmins)
            {
                throw new Exception("Unauthorized.");
            }

            if (adminRepository.Query().Any(x => x.Username == dto.Username))
            {
                throw new Exception("Username already exists");
            }

            var admin = mapper.Map<Admin>(dto);          

            admin.Password = Hasher.HashPassword(dto.Password);

            adminRepository.Create(admin);

            return mapper.Map<AdminDto>(dto);
        }
        public AdminDto EditAdmin(CreateAdminDto editDto, int targetId, int adminId)
        {
            var currentAdmin = adminRepository.GetById(adminId) ?? throw new Exception("Not Found");
            var editAdmin = adminRepository.GetById(targetId) ?? throw new Exception("Not Found");

            if (!currentAdmin.CanManageAdmins)
            {
                throw new Exception("Unauthorized");
            }

            if (adminRepository.Query().Any(x => x.Username == editDto.Username) && editDto.Username != editAdmin.Username)
            {
                throw new Exception("Username already exists");
            }

            editAdmin.FullName = editDto.FullName;
            editAdmin.Username = editDto.Username;
            editAdmin.CanManageAdmins = editDto.CanManageAdmins;

            if (editAdmin.Password != Hasher.HashPassword(editDto.Password))
            {
                editAdmin.Password = Hasher.HashPassword(editDto.Password);
            }

            adminRepository.Update(editAdmin);

            return mapper.Map<AdminDto>(editAdmin);
        }
        public void DeleteAdmin(int targetId, int adminId)
        {
            if (targetId == adminId)
            {
                throw new Exception("You can't delete yourself as admin.");
            }

            var admin = adminRepository.GetById(targetId) ?? throw new Exception("Not Found");
            var currentAdmin = adminRepository.GetById(adminId) ?? throw new Exception("Not Found");

            if (!currentAdmin.CanManageAdmins)
            {
                throw new Exception("Unauthorized");
            }

            adminRepository.Delete(admin);
        }  
    }
}