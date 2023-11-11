using LasserreDetresTravelAgency.Data.Models;
using LasserreDetresTravelAgency.Data.Repositories;
using Microsoft.Identity.Client;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LasserreDetresTravelAgency.Business.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
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

        public List<UserDto> GetAllMinorTravelers(User user)
        {
            List<User> users = userRepository.GetAllMinorTravelers();
            List<UserDto> usersDto = new List<UserDto>();

            if (ConvertDateOnlyToInt(user.Birthday) >= 18) 
            {
                foreach (User people in users)
                {
                    usersDto.Add(ModelToDto(people));
                }
            }
            return usersDto;
            
        }

        public int ConvertDateOnlyToInt(DateOnly birthday)
        {
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Today); ;
            int age = currentDate.Year - birthday.Year;

            if (birthday.DayOfYear > currentDate.DayOfYear)
            {
                age--;
            }
            return age;
        }

        private User DtoToModel(UserDto dto)
        {
            User user = new User{
                Id = dto.Id,
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Password = dto.Password,
                Birthday = dto.Birthday,
                Description = dto.Description,
            };

            return user;
        }

        private UserDto ModelToDto(User user)
        {
            UserDto userDto = new UserDto{
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
