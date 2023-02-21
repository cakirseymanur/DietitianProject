using DietitianProject.BusinessLayer.CQRS.Queries.DietContentQueries;
using DietitianProject.BusinessLayer.CQRS.Results.DietContentResults;
using DietitianProject.DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DietitianProject.BusinessLayer.CQRS.Handlers.DietContentHandlers
{
    public class GetAllDietContentQueryHandler : IRequestHandler<GetAllDietContentQuery, List<GetAllDietContentQueryResult>>
    {
        private readonly Context _context;

        public GetAllDietContentQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllDietContentQueryResult>> Handle(GetAllDietContentQuery request, CancellationToken cancellationToken)
        {
            return await _context.DietContents.Select(x =>
           new GetAllDietContentQueryResult
           {
               Id=x.Id,
               Subject = x.Subject,
               Content = x.Content,
               CreatedDate = x.CreatedDate,
               Status=x.Status,
               ImageUrl=x.ImageUrl
           }).AsNoTracking().ToListAsync();
        }
    }
}
