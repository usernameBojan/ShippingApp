namespace ShippingApp.Domain.Entities
{
    public class Admin : IEntity
    {
        public Admin() { }
        public Admin(int id, string fullName, string username, string password, bool canManage)
        {
            Id = id;
            FullName = fullName;
            Username = username;
            Password = password;
            CanManageAdmins = canManage;
        }
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool CanManageAdmins { get; set; }
    }
}