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
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository repository;
        public QuestionController(IQuestionRepository questionRepository)
        {
            repository = questionRepository;
        }

        [HttpGet]
        [Route("one")]
        public async Task<Response> One()
        {
            var response = await repository.GetQuestionOne();
            return response;
        }

        [HttpGet]
        [Route("two")]
        public async Task<IEnumerable<Response>> Two()
        {
            var response = await repository.GetQuestionTwo();
            return response;
        }

        [HttpGet]
        [Route("three")]
        public async Task<IEnumerable<Response>> Three()
        {
            var response = await repository.GetQuestionThree();
            return response;
        }
    }
}
