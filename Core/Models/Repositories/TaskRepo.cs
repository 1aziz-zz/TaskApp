using Core.Infrastructure;

namespace Core.Models.Repositories
{
    public class TaskRepo : Repository<Task>, ITaskRepo
    {
        public TaskRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
        public AppDbContext AppDbContext => Context as AppDbContext;

    }
}