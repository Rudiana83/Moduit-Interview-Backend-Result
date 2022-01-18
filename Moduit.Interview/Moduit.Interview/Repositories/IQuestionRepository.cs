using Moduit.Interview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moduit.Interview.Repositories
{
    public  interface IQuestionRepository
    {
        Task<Response> GetQuestionOne();
        Task<List<Response>> GetQuestionTwo();
        Task<List<Response>> GetQuestionThree();
    }
}
