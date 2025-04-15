using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Application.Models;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Users.LoginUser
{
    public class LoginUserUseCase : ILoginUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEncryptorService _encryptorService;
        private readonly IAuthenticationService _authenticationService;

        public LoginUserUseCase(
            IMapper mapper,
            IUserRepository userRepository,
            IEncryptorService encryptorService,
            IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _encryptorService = encryptorService;
            _authenticationService = authenticationService;
        }

        public async Task<LoginUserOutput?> Login(LoginUserInput input)
        {
            var dto = _mapper.Map<User>(input);
            dto.Password = _encryptorService.Encrypt(dto.Password);

            Console.WriteLine("Encrpyed Login Password: " + dto.Password);

            var entity = await _userRepository
                .Query()
                .FirstOrDefaultAsync(u =>
                    u.Username == dto.Username &&
                    u.Password == dto.Password
                );

            if (entity != null)
            {
                var auth = _authenticationService.GenerateToken(_mapper.Map<UserAuth>(entity));

                var response = _mapper.Map<LoginUserOutput>(entity);
                response.Token = auth;

                return response;
            }
            else
            {
                return null;
            }
        }
    }
}
