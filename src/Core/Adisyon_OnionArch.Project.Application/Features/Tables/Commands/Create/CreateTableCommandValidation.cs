using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Create
{
    public class CreateTableCommandValidation : AbstractValidator<CreateTableCommandRequest>
    {
        public CreateTableCommandValidation()
        {
            RuleFor(x => x.TableNumberString)
                .NotEmpty()
                .Must(BeAValidNumber).WithMessage("Masa numarası Numara Olmalıdır.")
                .Must(value => int.Parse(value) >= 0).WithMessage("Masa Numarası 0'dan Büyük Olmalıdır.");
        }

        private bool BeAValidNumber(string tableNumberString)
        {
            // String'in sadece sayısal olup olmadığını kontrol et
            return int.TryParse(tableNumberString, out _);
        }
    }
}
