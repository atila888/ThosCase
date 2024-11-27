using FluentValidation;
using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.Repositories.Interface;

namespace ThosCase.DAL.BusinessObjects.Validators
{
    internal class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        private readonly IUserRepository _userRepository;
        public UserUpdateRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Adı boş geçilemez");
            RuleFor(x => x.Surname).NotNull().NotEmpty().WithMessage("Soyadı boş geçilemez");
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");

            RuleFor(x => x.Username).Must((model, result) =>
            {
                return UserNameSearch(model.Username);
            }).WithMessage("Kullanıcı Adı daha önceden alınmış");
        }
        //VALIDASYONDA KULLANILAN PRIVATE METHODLAR
        #region PRIVATE METHODS
        private bool UserNameSearch(string username)
        {
            var category = _userRepository.FirstOrDefault(x => x.Username == username);
            if (category != null)
                return false;
            return true;
        }
        #endregion
    }
}
