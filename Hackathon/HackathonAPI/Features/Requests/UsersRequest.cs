using HackathonDAL;
using MediatR;

namespace HackathonAPI.Features.Requests
{
    

    public class UsersRequest : IRequest<string>
    {
        public string Data { get; set; }
    }

    // Request handler class
    public class MyRequestHandler : IRequestHandler<UsersRequest, string>
    {
        private readonly ContextMssql _dbmssql;
        private readonly ContextDapper _dbdapper;
        private readonly IMediator _mediator;

        public MyRequestHandler(ContextMssql dbmssql, ContextDapper dbdapper, IMediator mediator)
        {
            _dbmssql = dbmssql;
            _dbdapper = dbdapper;
            _mediator = mediator;
        }
        public async Task<string> Handle(UsersRequest request, CancellationToken cancellationToken)
        {
            return "Return Value: " + request.Data;
        }
    }
}
