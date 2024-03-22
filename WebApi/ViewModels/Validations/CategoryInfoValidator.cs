using FluentValidation;

namespace WebApi.ViewModels.Validations;

public class CategoryInfoValidator : AbstractValidator<CategoryInfo>
{
    public CategoryInfoValidator()
    {
        RuleFor(category => category.Name).NotEmpty().WithMessage("名稱必填.");
        RuleFor(category => category.Name).MaximumLength(50).WithMessage("名稱不可超過50個字.");
        RuleFor(category => category.Description).MaximumLength(200).WithMessage("描述不可超過250個字.");
    }
}
