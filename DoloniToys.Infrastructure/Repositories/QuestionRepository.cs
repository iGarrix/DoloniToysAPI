using DoloniToys.Domain.Interfaces.Repositories;
using DoloniToys.Domain.Models.DbModels;
using DoloniToys.Infrastructure.Context;
using DoloniToys.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Infrastructure.Repositories
{
    public class QuestionRepository : BaseRepository<Question, Guid>, IQuestionRepository
    {
        public QuestionRepository(DataContext context) : base(context)
        {

        }
    }
}
