using BussinessLayer.DTOs.Authentication;
using BussinessLayer.Helper;
using BussinessLayer.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using BussinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IRevokedTokenService _revokedTokenService;

        public AuthController(IUserService userService, ITokenService tokenService, IRevokedTokenService revokedTokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _revokedTokenService = revokedTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            // 1. Lấy người dùng theo StudentCode
            var user = await _userService.GetUserByStudentCodeAsync(req.StudentCode);

            // 2. Kiểm tra xem người dùng có tồn tại không
            if (user == null)
            {
                return Unauthorized("Mã sinh viên hoặc mật khẩu không hợp lệ."); // Thông báo chung chung hơn để bảo mật
            }

            // 3. Xác minh mật khẩu bằng helper
            bool isPasswordValid = HashPasswordHelper.VerifyPassword(req.Password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return Unauthorized("Mã sinh viên hoặc mật khẩu không hợp lệ."); // Thông báo chung chung hơn để bảo mật
            }

            // 4. Tạo token nếu thông tin đăng nhập hợp lệ
            var token = _tokenService.GenerateAccessToken(user);
            return Ok(new LoginResponse { AccessToken = token });
        }

        [Authorize] // Đảm bảo người dùng đã đăng nhập mới có thể logout
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Lấy token từ tiêu đề Authorization
            var authorizationHeader = Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader) || !authorizationHeader.StartsWith("Bearer "))
            {
                return BadRequest("Token không hợp lệ.");
            }

            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            // Đọc thời gian hết hạn của token từ chính token
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                return BadRequest("Token JWT không hợp lệ.");
            }

            var expiryDate = jwtToken.ValidTo;

            // Thêm token vào danh sách đen
            await _revokedTokenService.AddRevokedTokenAsync(token, expiryDate);

            return Ok("Đăng xuất thành công. Token đã bị vô hiệu hóa.");
        }
    }
}
