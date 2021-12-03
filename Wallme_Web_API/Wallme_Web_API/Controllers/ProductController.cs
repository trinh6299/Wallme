using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallme_Web_API.Data;
using Wallme_Web_API.Models;
using Wallme_Web_API.Models.ViewModels.Products;

namespace Wallme_Web_API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            //Có nên lấy list ảnh luôn không ???
            var products = _unitOfWork.ProductRepository.GetAll();
            List<ProductVM> res = new List<ProductVM>();
            foreach (var item in products)
            {
                res.Add(_mapper.Map<ProductVM>(item));
            }
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            var res = _unitOfWork.ProductRepository.GetById(id);
            return Ok(_mapper.Map<ProductVM>(res));
        }

        [HttpPost]
        public ActionResult Create(ProductVM productVM)
        {
            var productObj = _mapper.Map<Product>(productVM);
            _unitOfWork.ProductRepository.Add(productObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(ProductVM productVM)
        {
            var productObj = _mapper.Map<Product>(productVM);
            _unitOfWork.ProductRepository.Update(productObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var productObj = _unitOfWork.ProductRepository.GetById(id);
            if (productObj == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Savechanges();
            return Ok();
        }
    }
}
