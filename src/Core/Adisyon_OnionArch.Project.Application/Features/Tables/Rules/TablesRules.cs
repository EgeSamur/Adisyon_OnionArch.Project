using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules.Exceptions;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules.Excepitons;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Rules
{
    public class TablesRules : BaseRules
    {
        public async Task<Task> EnsureTableDoesNotExist(Table? table)
        {
            if (table is not null)
            {
                throw new TableIsAlreadyExistsException();
            }
            return Task.CompletedTask;
        }

        public async Task<Task> EnsureIsTableExists(Table? table)
        {
            if (table is null)
            {
                throw new TableDoesNotExistException();
            }
            return Task.CompletedTask;
        }
    }
}
