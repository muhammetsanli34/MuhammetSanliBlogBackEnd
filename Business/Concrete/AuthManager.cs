using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private ITokenHelper _tokenHelper;
        private IUserService _userService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userService.GetByMail(userForLoginDto.Email);
            //Refactor: Common if
            if (user==null)
            {
                return new ErrorDataResult<User>(Messages.InvalidMail);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.Data.PasswordHash, user.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.InvalidPassword);
            }
            return new SuccessDataResult<User>(user.Data,Messages.SuccessLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var logic = BusinessRules.Run(CheckIfUserExist(userForRegisterDto.Email));
            if (logic!=null)
            {
                return new ErrorDataResult<User>(Messages.ExistUser);
            }
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email=userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserAdded);
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claimResult = _userService.GetClaims(user);
            var result=_tokenHelper.CreateToken(user, claimResult.Data);
            return new SuccessDataResult<AccessToken>(result,Messages.TokenCreated);
        }
        public IResult CheckIfUserExist(string email)
        {
            if (_userService.GetByMail(email).Data!=null)
            {
                return new ErrorResult(Messages.ExistUser);
            }
            return new SuccessResult();
        }
    }
}
