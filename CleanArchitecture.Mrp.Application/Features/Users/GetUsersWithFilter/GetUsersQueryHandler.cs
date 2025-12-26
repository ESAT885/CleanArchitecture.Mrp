
using CleanArchitecture.Mrp.Application.Abstractions.Repositories;
using CleanArchitecture.Mrp.Application.DTOs.Users;
using MediatR;
namespace CleanArchitecture.Mrp.Application.Features.Users.GetUsersWithFilter
{
    public class GetUsersQueryHandler
     : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(
            GetUsersQuery request,
            CancellationToken cancellationToken)
        {
            var list = await _userRepository.GetListWithFilter();

            // 🔍 Dinamik filtreleme
            if (!string.IsNullOrWhiteSpace(request.Filter.UserName))
            {
                list = list.Where(x =>
                    x.UserName.Contains(request.Filter.UserName)).ToList();
            }

           

            var dataList=  list
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    UserName = x.UserName,
                   
                })
                .ToList();
            return dataList;
        }

    }
}
