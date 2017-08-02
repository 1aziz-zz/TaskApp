using Core.Infrastructure;
using Core.Models.Repositories;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEmployeeRepo Employees { get; private set; }
        public ITaskRepo Tasks { get; private set; }

        public IProjectRepo Projects { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepo(_context);
            Tasks = new TaskRepo(_context);
            Projects = new ProjectRepo(_context);

        }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}