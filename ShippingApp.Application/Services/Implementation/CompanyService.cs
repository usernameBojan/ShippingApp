using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShippingApp.Application.Dto.Company;
using ShippingApp.Application.Repository;
using ShippingApp.Application.Utilities;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Application.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> companyRepository;
        private readonly IMapper mapper;

        public CompanyService(IRepository<Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }
        public CompanyDto GetCompany(string name)
        {
            var company = companyRepository.Query()
                                           .Include(x => x.ParcelLimitations)
                                           .Include(x => x.ParcelVolumeRange)
                                           .Include(x => x.ParcelWeightRange)
                                           .FirstOrDefault(x => x.Name == name)
                                           ?? throw new Exception("Not Found");

            return mapper.Map<CompanyDto>(company);
        }
        public IEnumerable<CompanyDto> GetCompanies()
        {
            return companyRepository.Query()
                                    .Include(x => x.ParcelLimitations)
                                    .Include(x => x.ParcelVolumeRange)
                                    .Include(x => x.ParcelWeightRange)
                                    .Select(c => mapper.Map<CompanyDto>(c))
                                    .ToList();
        }
        public CompanyDto CreateCompany(CreateCompanyDto createCompanyDto)
        {
            if(companyRepository.Query().Any(x => x.Name == createCompanyDto.Name))
            {
                throw new Exception("Company with this name already exists");
            }

            createCompanyDto.ValidateRangeValues();

            var company = mapper.Map<Company>(createCompanyDto);

            companyRepository.Create(company);

            return mapper.Map<CompanyDto>(company);
        }
        public CompanyDto EditCompany(CreateCompanyDto editCompany, string companyName)
        {
            var company = companyRepository.Query()
                                           .Include(x => x.ParcelLimitations)
                                           .Include(x => x.ParcelVolumeRange)
                                           .Include(x => x.ParcelWeightRange)
                                           .FirstOrDefault(x => x.Name == companyName)
                                           ?? throw new Exception("Not Found");

            if (companyRepository.Query().Any(x => x.Name == editCompany.Name))
            {
                throw new Exception("Company with this name already exists");
            }

            editCompany.ValidateRangeValues();

            company.Name = editCompany.Name;
            company.ParcelLimitations = mapper.Map<ParcelLimitations>(editCompany.ParcelLimitations);
            company.ParcelVolumeRange = editCompany.ParcelVolumeRange.Select(x => mapper.Map<ParcelVolumeRange>(x)).ToList();
            company.ParcelWeightRange = editCompany.ParcelWeightRange.Select(x => mapper.Map<ParcelWeightRange>(x)).ToList();

            companyRepository.Update(company);

            return mapper.Map<CompanyDto>(company);
        }
        public void DeleteCompany(string name)
        {
            var company = companyRepository.Query().FirstOrDefault(x => x.Name == name)
                                           ?? throw new Exception("Not Found");

            companyRepository.Delete(company);  
        }        
    }
}