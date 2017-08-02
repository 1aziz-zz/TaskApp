using Core.Infrastructure;

namespace Core.Models.Repositories
{
    public class EmployeeRepo : Repository<Employee>, IEmployeeRepo
    {
        public EmployeeRepo(AppDbContext context) : base(context)
        {
        }

        public AppDbContext AppDbContext => Context as AppDbContext;
    }
}