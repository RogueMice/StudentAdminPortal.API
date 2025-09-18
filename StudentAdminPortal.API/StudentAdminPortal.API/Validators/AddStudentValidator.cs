using FluentValidation;
using StudentAdminPortal.API.DTO;
using StudentAdminPortal.API.Service.Interface;

namespace StudentAdminPortal.API.Validators
{
    public class AddStudentValidator : AbstractValidator<StudentViewDTO>
    {
        public AddStudentValidator(IGenderService genderService)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(100000000000);
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = genderService.GetAllAsync().Result.ToList()
                .FirstOrDefault(x => x.Id == id);

                if(gender == null)
                {
                    return false;
                }
                return true;
            }).WithMessage("Please select a valid Gender");
            RuleFor(x => x.PhysicalAddress).NotEmpty();
            RuleFor(x => x.PostalAddress).NotEmpty();
        }
    }
}
