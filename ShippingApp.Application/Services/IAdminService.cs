using ShippingApp.Application.Dto.Admin;

namespace ShippingApp.Application.Services
{
    public interface IAdminService
    {
        TokenDto Authenticate(LoginDto login);
        AdminDto GetAdmin(int id);
        IEnumerable<AdminDto> GetAdmins();
        AdminDto CreateAdmin(CreateAdminDto dto, int id);
        AdminDto EditAdmin(CreateAdminDto dto, int targetId, int id);
        void DeleteAdmin(int targetId, int adminId);
    }
}