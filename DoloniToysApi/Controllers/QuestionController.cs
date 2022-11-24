using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.RequestModels.QuestionRequests;
using DoloniToys.Domain.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoloniToysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost(QuestionPaths.Add)]
        public QuestionDto AddQuestion([FromBody] AddQuestionRequest request)
        {
            QuestionDto createdQuestion = _questionService.AddQuestion(request);
            return createdQuestion;
        }

        [HttpGet(QuestionPaths.GetAll)]
        [Authorize]
        public PaginationResponse<QuestionDto> GetAll(int page = 1, int take = 1)
        {
            return _questionService.GetAllQuestion(page, take);
        }
    }
}
