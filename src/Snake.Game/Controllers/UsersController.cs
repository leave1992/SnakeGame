using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snake.Game.Models;
using Snake.DataAccess;
using Snake.DataAccess.Repositories;

namespace Snake.Game.Controllers
{
    [Route("api/User")]
    public class UsersController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<User> _repository;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<User>();
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _repository.Get();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(int id)
        {
            var user = _repository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            _repository.Insert(user);
            _unitOfWork.Save();
            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User item)
        {
            if(item == null || item.UserId != id)
            {
                return BadRequest();
            }

            var user = _repository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FullName = item.FullName;
            user.Nickname = item.Nickname;

            _repository.Update(user);
            _unitOfWork.Save();

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repository.GetByID(id);
            if (user == null)
            {
                return NotFound();
            }
            _repository.Delete(id);
            _unitOfWork.Save();

            return new NoContentResult();
        }
    }
}
