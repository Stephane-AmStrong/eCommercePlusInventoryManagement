using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class AppUserDuplicateException : DuplicateException
    {
        public AppUserDuplicateException(AppUser appUser) : base($"An appUser named {appUser.FirstName} {appUser.LastName}, born on {appUser.Birthdate} already exists")
        {
        }
    }
}