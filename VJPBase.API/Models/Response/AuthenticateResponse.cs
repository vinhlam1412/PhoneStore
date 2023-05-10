using System.Text.Json.Serialization;
using VJPBase.Data.Entities;
using VJPBase.API.Models.Response.Dto;

namespace VJPBase.API.Models.Response
{
    public class AuthenticateResponse
    {

        public UserInfor UserInfor { get; set; }
        public string JwtToken { get; set; }


        [JsonIgnore] // refresh token is returned in http only cookie
        public string RefreshToken { get; set; }

        public AuthenticateResponse(User user, string jwtToken, string refreshToken)
        {

            UserInfor = new UserInfor
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
            };
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}
