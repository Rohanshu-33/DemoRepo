using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace UserLibraryApi.Helpers
{
    public class JWTHelper
    {
        private static readonly string secretKey = "RohanshuBanodhaDemoWebApi290903VAPIGUJARATINDIA";

        // Generate JWT Token for username
        public static string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);  // Convert the key to bytes

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddHours(1),  // Token expires in 1 hour
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);  // Return the token as a string
        }

        // Method to extract username from the JWT token
        public static string ExtractUsernameFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);  // Convert the key to bytes

            try
            {
                // Validate and decode the token
                var principal = ValidateToken(token, key);

                // Retrieve the username claim
                var usernameClaim = principal?.FindFirst(ClaimTypes.Name)?.Value;

                return usernameClaim;  // Return the username if found
            }
            catch (Exception ex)
            {
                // Handle invalid token or error
                Console.WriteLine($"Error decoding token: {ex.Message}");
                return null;
            }
        }

        // Method to validate the JWT token
        private static ClaimsPrincipal ValidateToken(string token, byte[] key)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),  // Key used for validation
                    ValidateIssuer = false,  // You can set these based on your requirements
                    ValidateAudience = false,
                    ValidateLifetime = true,  // Ensures the token is not expired
                    ClockSkew = TimeSpan.Zero  // No extra time allowance for expiration check
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // If token is valid, return the ClaimsPrincipal (which contains the claims)
                return principal;
            }
            catch (Exception ex)
            {
                // Handle invalid token or validation error
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
    }
}