using System.Linq;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<Project> Products { get; }
    }
}
