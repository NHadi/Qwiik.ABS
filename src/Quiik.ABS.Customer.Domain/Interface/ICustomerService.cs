using Quiik.ABS.Customer.Domain.DTO;

namespace Quiik.ABS.Customer.Domain.Interface
{
    public interface ICustomerService
    {
        CustomerResponse Save(CustomerRequest request);
        List<CustomerResponse> Get(CustomerRequest request);
    }
}
