using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moduit.Interview.Models;
using Moduit.Interview.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moduit.Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionThreeController : ControllerBase
    {
        private IQuestionRepository repository;
        public QuestionThreeController(IQuestionRepository questionRepository)
        {
            repository = questionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Response>> Get()
        {
            var response = await repository.GetQuestionThree();
            return response;
        }

    }
}
