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
    public class QuestionOneController : ControllerBase
    {
        private IQuestionRepository repository;
        public QuestionOneController(IQuestionRepository questionRepository)
        {
            repository = questionRepository;
        }

        [HttpGet]
        public async Task<Response> Get()
        {
            var response = await repository.GetQuestionOne();
            return response;
        }

    }
}
