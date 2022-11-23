namespace ShippingApp.Application.Dto.Admin
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;   
        public bool CanManageAdmins { get; set; }
    }
}