using Microsoft.EntityFrameworkCore;
using Quiik.ABS.Appointment.Domain;
using Quiik.ABS.Appointment.Domain.Interface;
using Quiik.ABS.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiik.ABS.Appointment.Infrastructure.Repositories
{
    public class TokenRepository : EfRepository<Tokens>, ITokenRepository
    {
        private readonly ABS_AppointmentsContext _context;
        public TokenRepository(ABS_AppointmentsContext context) : base(context)
        {
            _context = context;
        }
    }
}
