using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Snake.DataAccess;
using Snake.DataAccess.Models;
using Snake.DataAccess.Repositories;

namespace Snake.Game.Controllers
{
    [Route("api/HighScores")]
    public class HighScoresController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IGenericRepository<HighScores> _repository;

        public HighScoresController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<HighScores>();
        }

        [HttpGet]
        public IEnumerable<HighScores> GetAll()
        {
            return _repository.Get();
        }
    }
}