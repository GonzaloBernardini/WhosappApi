using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Whosapp.Entities;
using Whosapp.Entities.Authentication;
using Whosapp.UOWork;

namespace Whosapp.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uOw;
        private readonly IConfiguration _config;

        public UserService(IUnitOfWork uow, IConfiguration config)
        {
            _uOw = uow;
            _config = config;
        }
        public string GetToken(AuthenticateResponse usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.Id.ToString()),
                //new Claim(JwtRegisteredClaimNames.GivenName, usuario.Name),
                new Claim(JwtRegisteredClaimNames.GivenName, usuario.Username),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Role.ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };
            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public AuthenticateResponse Login(string email, string password)
        {
            if (_uOw.UserRepository.ExisteUsuario(email))
            {
                AuthenticateResponse response = new AuthenticateResponse();

                // Traigo al usuario por el email
                User user = _uOw.UserRepository.GetByEmail(email);

                // Verifico si existe el password ingresado y que coinsida con el de la BBDD
                if (!VerificarPassword(password, user.PasswordHash, user.PasswordSalt))
                {
                    return null;
                }

                // Se mappea a un UserResponse
                response.Email = email;
                response.Username = user.Username;
                response.Id = user.Id;
                response.Role = user.Role;

                return response;
            }
            return null;
        }

        private bool VerificarPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hMac = new HMACSHA512(passwordSalt);
            var hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Comparo el password de la BBDD con el que se acaba de encriptar
            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != passwordHash[i]) return false;
            }
            return true;
        }

        public AuthenticateResponse RegisterUser(AuthenticateRequest usuario, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPassHash(password, out passwordHash, out passwordSalt);

            User user = new User();
            user.Username = usuario.Username;
            user.Email = usuario.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            Role rol = new Role();
            rol.User = "User";
            user.Role = rol.User;
            _uOw.UserRepository.Insert(user);
            _uOw.Save();

            AuthenticateResponse response = new AuthenticateResponse();
            response.Id = user.Id;
            response.Email = user.Email;
            response.Username = user.Username;
            response.Role = user.Role;

            return response;
        }

        public AuthenticateResponse RegisterAdmin(AuthenticateRequest usuario, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPassHash(password, out passwordHash, out passwordSalt);

            User user = new User();
            user.Username = usuario.Username;
            user.Email = usuario.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            Role rol = new Role();

            user.Role = rol.Admin;
            _uOw.UserRepository.Insert(user);
            _uOw.Save();

            AuthenticateResponse response = new AuthenticateResponse();
            response.Id = user.Id;
            response.Email = user.Email;
            response.Username = user.Username;
            //response.Role = user.Role;

            return response;
        }

        private void CrearPassHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            // Creo una encriptacion
            var hMac = new HMACSHA512();
            // Se le asigna la llave de la incriptacion al passwordSalt
            passwordSalt = hMac.Key;
            // Se encripta el pass y lo guardo en passwordHash
            passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
