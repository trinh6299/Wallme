using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallme_Web_API.Data;
using Wallme_Web_API.Models;
using Wallme_Web_API.Models.ViewModels.Carts;

namespace Wallme_Web_API.Controllers
{
    public class CartController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var res = _unitOfWork.CartRepository.GetAll(true);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var res = _unitOfWork.CartRepository.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Create(CartVM cartVM)
        {
            var cartObj = _mapper.Map<Cart>(cartVM);
            _unitOfWork.CartRepository.Add(cartObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(CartVM cartVM)
        {
            var cartObj = _mapper.Map<Cart>(cartVM);
            _unitOfWork.CartRepository.Update(cartObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cartObj = _unitOfWork.CartRepository.GetById(id);
            if (cartObj==null)
            {
                return NotFound();
            }
            _unitOfWork.CartRepository.Delete(id);
            _unitOfWork.Savechanges();
            return Ok();
        }
    }
}
