using HackathonDAL;
using HackathonDAL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HackathonAPI.Features.Requests
{


    public class UsersRequest : IRequest<List<Users>>
    {
        public string username { get; set; }
    }

    // Request handler class
    public class MyRequestHandler : IRequestHandler<UsersRequest, List<Users>>
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;

        public MyRequestHandler(ContextMssql dbmssql, ContextDapper dbdapper, IMediator mediator)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
        }
        public async Task<List<Users>> Handle(UsersRequest request, CancellationToken cancellationToken)
        {
            return await _dbmssql.Users.Where(ok => ok.Username == request.username).ToListAsync();
        }
    }
}
