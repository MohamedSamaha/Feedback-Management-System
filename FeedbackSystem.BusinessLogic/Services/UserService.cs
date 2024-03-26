using AutoMapper;
using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces;
using FeedbackSystem.Core.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackSystem.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            try
            {
                var actualUser = _mapper.Map<User>(userDto);
                if (actualUser != null)
                {
                    actualUser.Password = GetSha512Hash(userDto.Password);
                    await _unitOfWork.Users.CreateAsync(actualUser);
                    _unitOfWork.Save();
                }
                return userDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteUser(long Id)
        {

            {
                try
                {
                    var user = await _unitOfWork.Users.GetByLongIdAsync(Id);
                    if (user != null)
                    {
                        await _unitOfWork.Users.DeleteAsync(user);
                        _unitOfWork.Save();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            try
            {
                var allUsers = await _unitOfWork.Users.GetAllAsync();
                var withoutSoftDeletedItems = allUsers.Where(x => x.DeletedAt == null);
                return _mapper.Map<IEnumerable<UserDto>>(withoutSoftDeletedItems);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<UserDto> GetUserById(long Id)
        {
            try
            {
                var user = await _unitOfWork.Users.GetByLongIdAsync(Id);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            try
            {
                if (userDto != null)
                {
                    var updatedUser = _mapper.Map<User>(userDto);
                    if (updatedUser != null)
                    {
                        await _unitOfWork.Users.UpdateAsync(updatedUser);
                        _unitOfWork.Save();
                    }
                }
                return userDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private static string GetSha512Hash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a StringBuilder to collect the bytes and create a string.
                StringBuilder builder = new StringBuilder();

                // Loop through each byte of the hashed data and format it as a hexadecimal string.
                foreach (byte b in data)
                {
                    builder.Append(b.ToString("x2"));
                }

                // Return the hexadecimal string.
                return builder.ToString();
            }
        }
    }
}
