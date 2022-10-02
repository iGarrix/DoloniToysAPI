using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.RequestModels.QuestionRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Services
{
    public interface IQuestionService
    {
        QuestionDto AddQuestion(AddQuestionRequest request);
        PaginationResponse<QuestionDto> GetAllQuestion(int page = 1, int take = 1);
    }
}
