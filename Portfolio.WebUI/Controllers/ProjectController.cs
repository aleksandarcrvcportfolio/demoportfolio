using Portfolio.Domain.Abstract;
using System.Linq;
using System.Web.Mvc;

namespace Portfolio.WebUI.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _repository;
        public int pageSize = 4;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }
        // GET: Project
        public ViewResult List(int page = 1)
        {
            return View(_repository.Products.OrderBy(p => p.ProjectID)
                .Skip((page - 1)* pageSize)
                .Take(pageSize));
        }
    }
}