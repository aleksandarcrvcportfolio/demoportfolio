using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
