using DietitianProject.BusinessLayer.CQRS.Results.DietContentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.CQRS.Queries.DietContentQueries
{
    public class GetAllDietContentQuery : IRequest<List<GetAllDietContentQueryResult>>
    {
    }
}
