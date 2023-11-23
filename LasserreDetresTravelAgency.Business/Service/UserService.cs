using LasserreDetresTravelAgency.Business.Dto;
using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository, IDestinationRepository destinationRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserDto> Add(UserDto dto)
        {
            User user = DtoToModel(dto);
            await userRepository.Add(user);
            UserDto userDto = ModelToDto(user);

            return userDto;
        }

        public async Task<int> Delete(int id)
        {
            return await userRepository.Delete(id);
        }

        public async Task<UserDto> Get(int id)
        {
            return ModelToDto(await userRepository.Get(id));
        }

        public List<UserDto> GetAll()
        {
            return ListModelToDto(userRepository.GetAll());
        }

        public async Task<UserDto> Update(UserDto dto)
        {
            User user = DtoToModel(dto);
            await userRepository.Update(user);
            UserDto userDto = ModelToDto(user);

            return userDto;
        }

        public List<UserDto> GetAllMinorTravelers()
        {
            List<User> users = userRepository.GetAllMinorTravelers();
            return ListModelToDto(users);
        }

        private User DtoToModel(UserDto dto)
        {
            User user = new User
            {
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Birthday = dto.Birthday,
                Description = dto.Description,
            };

            // Encrypt password to store it in the database
            byte[] data = System.Text.Encoding.ASCII.GetBytes(dto.Password);
            data = System.Security.Cryptography.SHA256.HashData(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            user.Password = hash;

            return user;
        }

        private UserDto ModelToDto(User user)
        {
            UserDto userDto = new UserDto
            {
                Id = user.Id,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Password = user.Password,
                Birthday = user.Birthday,
                Description = user.Description,
            };

            return userDto;
        }

        private List<UserDto> ListModelToDto(List<User> users)
        {
            List<UserDto> userDtos = new List<UserDto>();

            foreach (User user in users)
            {
                userDtos.Add(ModelToDto(user));
            }
            return userDtos;
        }
    }
}