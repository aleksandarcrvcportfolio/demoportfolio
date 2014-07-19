using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portfolio.Domain.Entities;

namespace Portfolio.Domain.Abstract
{
    public interface IProjectRepository
    {
        IQueryable<Project> Products { get; }
    }
}
