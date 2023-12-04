using MediatR;
using Application.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.User.Queries.FindById
{
    public class FindUserByIdQuery : IRequest<UserInfo>
    {
        public int Id { get; set; }
    }
}
