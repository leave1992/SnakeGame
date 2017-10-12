using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snake.Game.Models;
using Snake.DataAccess;
using Snake.DataAccess.Repositories;
using Snake.DataAccess.Models;

namespace Snake.Game.Controllers
{
    [Route("api/Score")]
    public class ScoresController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<Scores> _repository;

        public ScoresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<Scores>();
        }

        [HttpGet]
        public IEnumerable<Scores> GetAll()
        {
            return _repository.Get();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var score = _repository.GetByID(id);
            if (score == null)
            {
                return NotFound();
            }
            return new ObjectResult(score);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UsersScoreViewModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var score = new Scores
            {
                Date = item.Date,
                Score = item.Score,
                UserId = item.UserId
            };

            _repository.Insert(score);
            _unitOfWork.Save();
            return new ObjectResult(score);

        }
    }
}
