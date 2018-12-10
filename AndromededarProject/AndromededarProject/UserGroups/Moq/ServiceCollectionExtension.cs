using Andromedarproject.Users.Abstractions;
using Andromedarproject.Users.Abstractions.Groups;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndromededarProject.Web.UserGroups.Moq
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection TryAddUserGroupMoq(this IServiceCollection sc)
        {
            sc.TryAddSingleton<IUserReader, UserGroupServiceMoq>();
            sc.TryAddSingleton<IGroupReader, UserGroupServiceMoq>();
            return sc;
        }
    }
}
