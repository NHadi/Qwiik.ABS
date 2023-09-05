using AutoMapper;   
using Quiik.ABS.Customer.Domain;
using Quiik.ABS.Customer.Domain.DTO;
using Quiik.ABS.Customer.Domain.Interface;

namespace Quiik.ABS.Customer.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;
        public CustomerService(ICustomerRepository customerRepository,
            IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }     
        public CustomerResponse Save(CustomerRequest request)
        {
            try
            {
                var data = mapper.Map<Customers>(request);
                data.CreatedBy = "Admin";
                data.CreateDate = DateTime.Now;
                data.IsActive = true;

                customerRepository.Insert(data);
                customerRepository.Save();

                var resposne = mapper.Map<CustomerResponse>(data);
                return resposne;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<CustomerResponse> Get(CustomerRequest request)
        {
            try
            {
                var qry = customerRepository.Get().AsQueryable();

                if (!string.IsNullOrEmpty(request.Name))
                    qry = qry.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));

                if (!string.IsNullOrEmpty(request.Email))
                    qry = qry.Where(x => x.Email.ToLower().Contains(request.Email.ToLower()));

                var data = qry.ToList();

                return mapper.Map<List<CustomerResponse>>(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
