using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace PetStore.Products.Validation {
    internal class ProductValidator : AbstractValidator<Product> {
        public ProductValidator() {
            RuleFor(product => product.Name).NotEmpty();
            RuleFor(product => product.Description).MinimumLength(10).Unless(product => product.Description == null);
            RuleFor(product => product.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(product => product.Price).GreaterThan(0);
        }
    }
}
