using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallme_Web_API.Data;
using Wallme_Web_API.Models;
using Wallme_Web_API.Models.ViewModels.Comments;

namespace Wallme_Web_API.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var res = _unitOfWork.CommentRepository.GetAll(true);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var res = _unitOfWork.CommentRepository.GetById(id);
            return Ok(res);
        }

        [HttpPost]
        public ActionResult Create(CommentVM commentVM)
        {
            var commentObj = _mapper.Map<Comment>(commentVM);
            _unitOfWork.CommentRepository.Add(commentObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpPatch]
        public ActionResult Update(CommentVM commentVM)
        {
            var commentObj = _mapper.Map<Comment>(commentVM);
            _unitOfWork.CommentRepository.Update(commentObj);
            _unitOfWork.Savechanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var commentObj = _unitOfWork.CommentRepository.GetById(id);
            if (commentObj==null)
            {
                return NotFound();
            }
            _unitOfWork.CommentRepository.Delete(id);
            _unitOfWork.Savechanges();
            return Ok();
        }
    }
}
