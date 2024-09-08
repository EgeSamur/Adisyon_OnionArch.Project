﻿using Adisyon_OnionArch.Project.Domain.Enums;
using MediatR;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Update
{
    public class UpdateProductCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool? IsBestSeller { get; set; }
        public BestSellerRank? BestSellerRank { get; set; }
        public IList<Guid>? CategoryIds { get; set; }
    }
}
