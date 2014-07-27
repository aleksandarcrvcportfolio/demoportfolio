using System.Linq;
using Portfolio.Domain.Abstract;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Concrete
{
    public class EFProjectRepository : IProjectRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Project> Products { get { return context.Projects; } }
    }
}
