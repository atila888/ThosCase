using AutoMapper;
using ThosCase.Business.Helper.Common;
using ThosCase.Business.Managers.Interfaces;
using ThosCase.DAL.BusinessObjects.Request.User;
using ThosCase.DAL.BusinessObjects.Response.User;
using ThosCase.DAL.BusinessObjects.Validators;
using ThosCase.DAL.Repositories.Interface;
using ThosCase.Data.Models.Context;

namespace ThosCase.Business.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;

        }
        public async Task<List<UserResponse>> GetAllUser()
        {
            List<UserResponse> userResponses = new List<UserResponse>();

            var result = await _userRepository.GetAllAsync();
            _mapper.Map(result.ToList(), userResponses);

            return userResponses;
        }
        public async Task<bool> SaveAsync(UserSaveRequest userSaveRequest)
        {
            userSaveRequest.Validate(_userRepository);

            var user = new User();
            _mapper.Map(userSaveRequest, user);

            user.Hashpassword = userSaveRequest.password.ToEncoded();
            user.Saltpassword = userSaveRequest.password.ToGetSalt();

            try
            {
                await _userRepository.AddAsync(user);
                _userRepository.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Kullanıcı Kaydedilirken hata ile karşılaşıldı.");
            }
        }
        public async Task<bool> UpdateAsync(UserUpdateRequest userUpdateRequest)
        {
            userUpdateRequest.Validate(_userRepository);

            try
            {
                var user = await _userRepository.FirstOrDefaultAsync(x => x.Userid == userUpdateRequest.Userid);
                if (user.Hashpassword != userUpdateRequest.password || !String.IsNullOrEmpty(userUpdateRequest.password))
                {
                    user.Hashpassword = userUpdateRequest.password.ToEncoded();
                    user.Saltpassword = userUpdateRequest.password.ToGetSalt();
                }
                _mapper.Map(userUpdateRequest, user);
                _userRepository.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Kullanıcı Güncellenirken hata ile karşılaşıldı.");
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var user = await _userRepository.FirstOrDefaultAsync(x => x.Userid == id);
                    if (user != null)
                    {
                        _userRepository.Remove(user);

                        return true;
                    }
                }
                return false;

            }
            catch (Exception)
            {
                throw new Exception("Kategori Silinirken hata ile karşılaşıldı.");
            }
        }
    }
}
