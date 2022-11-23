using ShippingApp.Application.Dto.Company;

namespace ShippingApp.Application.Services
{
    public interface ICompanyService
    {
        CompanyDto GetCompany(string name);
        IEnumerable<CompanyDto> GetCompanies();
        CompanyDto CreateCompany(CreateCompanyDto createCompanyDto);
        CompanyDto EditCompany(CreateCompanyDto editCompany, string name);
        void DeleteCompany(string name); 
    }
}