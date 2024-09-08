using Adisyon_OnionArch.Project.Application.Common.BussinesRules;
using Adisyon_OnionArch.Project.Application.Features.Category.Rules.Exceptions;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules.Exceptions;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using System.Xml.Linq;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Rules
{
    public class ProductRules : BaseRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Task> EnsureProductDoesNotExist(string name)
        {
            var product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAsync(x => x.Name == name);
            if (product != null)
            {
                throw new ProductIsAlreadyExistException();
            }

            return Task.CompletedTask;
        }

        public async Task<Task> EnsureProducExists(Domain.Entities.Product? product)
        {
            if (product == null)
            {
                throw new ProductDoesNotExistException();
            }

            return Task.CompletedTask;
        }
    }
}
