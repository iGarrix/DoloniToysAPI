using AutoMapper;
using DoloniToys.Application.Extensions.Identity;
using DoloniToys.Application.Extensions.Pagination;
using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers;
using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.Models.DbModels;
using DoloniToys.Domain.RequestModels.QuestionRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Services.Common
{
    public class QuestionService : IQuestionService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public QuestionService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public QuestionDto AddQuestion(AddQuestionRequest request)
        {
            if (request is null)
            {
                throw new BadHandler();
            }

            Question newQuestion = new Question()
            {
                Name = request.Name,
                Email = request.Email,
                Message = request.Message,
            };

            Question createdQuestion = _repositoryWrapper.QuestionRepository.Add(newQuestion);
            return createdQuestion.ToDto<Question, QuestionDto>(_mapper);
        }

        public PaginationResponse<QuestionDto> GetAllQuestion(int page = 1, int take = 1)
        {
            PaginationResponse<QuestionDto> paginateProduct = Pagination.PaginateToDtos<Question, QuestionDto>(new PaginationParams<Question>()
            {
                TData = _repositoryWrapper.QuestionRepository.Items,
                CurrentPage = page,
                Take = take,
            }, _mapper);

            if (paginateProduct is null)
            {
                throw new BadHandler();
            }

            if (paginateProduct.Pageables.Count() == 0)
            {
                throw new NotFoundHandler();
            }

            return paginateProduct;
        }
    }
}
