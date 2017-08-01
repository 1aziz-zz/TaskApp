using Core.Models.Repositories;

namespace Core.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IEmployeeRepo Employees { get; private set; }
        public ITaskRepo Tasks { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepo(context);
            Tasks = new TaskRepo(context);
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