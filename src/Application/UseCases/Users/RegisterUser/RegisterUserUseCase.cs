using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.Interfaces;

namespace Application.UseCases.Users.RegisterUser
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEncryptorService _encryptorService;

        public RegisterUserUseCase(
            IMapper mapper,
            IUserRepository userRepository,
            IEncryptorService encryptorService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _encryptorService = encryptorService;
        }

        public async Task<RegisterUserOutput> Register(RegisterUserInput input)
        {
            var entity = _mapper.Map<User>(input);

            entity.Password = _encryptorService.Encrypt(entity.Password);
            entity.ConfirmPassword = _encryptorService.Encrypt(entity.ConfirmPassword);

            var response = await _userRepository.Add(entity);

            return _mapper.Map<RegisterUserOutput>(response);
        }
    }
}
