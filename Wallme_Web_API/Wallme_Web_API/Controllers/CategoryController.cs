using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Wallme_Web_API.Data;
using Wallme_Web_API.Models;
using Wallme_Web_API.Models.ViewModels.Categories;

namespace Wallme_Web_API.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET: CategoryController
        [HttpGet]
        public ActionResult GetAll()
        {
            //var res = _categoryRepository.GetAll();
            var res = _unitOfWork.CategoryRepository.GetAll(true);
            return Ok(res);
        }

        // GET: CategoryController/Details/5
        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var res = _unitOfWork.CategoryRepository.GetById(id);
            return Ok(res);
        }

        // GET: CategoryController/Create
        [HttpPost]
        public ActionResult Create(CategoryVM categoryVM)
        {
            var categoryObj = _mapper.Map<Category>(categoryVM);
            _unitOfWork.CategoryRepository.Add(categoryObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(CategoryVM categoryVM)
        {
            var categoryObj = _mapper.Map<Category>(categoryVM);
            _unitOfWork.CategoryRepository.Update(categoryObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoryObj = _unitOfWork.CategoryRepository.GetById(id);
            if (categoryObj == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Savechanges();
            return Ok();
        }
    }
}