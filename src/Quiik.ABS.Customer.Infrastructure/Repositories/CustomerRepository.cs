using Quiik.ABS.Common.Repositories;
using Quiik.ABS.Customer.Domain;
using Quiik.ABS.Customer.Domain.Interface;
using Quiik.ABS.Customer.Infrastructure;

namespace Quiik.ABS.Customer.Infrastructure.Repositories
{
    public class CustomerRepository : EfRepository<Customers>, ICustomerRepository
    {
        private readonly ABS_CustomersContext _context;
        public CustomerRepository(ABS_CustomersContext context) : base(context)
        {
            _context = context;
        }
    }
}
