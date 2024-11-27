using FluentValidation;
using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.Repositories.Interface;

namespace ThosCase.DAL.BusinessObjects.Validators
{
    internal class UserSaveRequestValidator : AbstractValidator<UserSaveRequest>
    {
        private readonly IUserRepository _userRepository;
        public UserSaveRequestValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Adı boş geçilemez");
            RuleFor(x => x.Surname).NotNull().NotEmpty().WithMessage("Soyadı boş geçilemez");
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.password).NotNull().NotEmpty().WithMessage("Şifre boş geçilemez");

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
