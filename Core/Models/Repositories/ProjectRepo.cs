using Core.Infrastructure;

namespace Core.Models.Repositories
{
    public class ProjectRepo : Repository<Project>, IProjectRepo
    {
        public ProjectRepo(AppDbContext dbContext) : base(dbContext)
        {
        }
        public AppDbContext AppDbContext => Context as AppDbContext;

    }
}