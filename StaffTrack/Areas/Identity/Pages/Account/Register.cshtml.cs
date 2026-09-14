using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StaffTrack.Data;

namespace StaffTrack.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required.")]
            [StringLength(
                100,
                MinimumLength = 6,
                ErrorMessage = "Password must contain at least 6 characters.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Required(ErrorMessage = "Confirm password is required.")]
            [DataType(DataType.Password)]
            [Compare(
                nameof(Password),
                ErrorMessage = "Passwords do not match.")]
            public string ConfirmPassword { get; set; } = string.Empty;
        }

        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var email = Input.Email.Trim();

            var existingUser = await _userManager.FindByEmailAsync(email);

            if (existingUser != null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "This email address is already registered.");

                return Page();
            }

            var user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = email,
                NormalizedUserName = email.ToUpperInvariant(),
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(
                user,
                Input.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                return Page();
            }

            var savedUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == user.Id);

            if (savedUser == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "User could not be saved to the database.");

                return Page();
            }

            await _signInManager.SignInAsync(
                savedUser,
                isPersistent: false);

            return LocalRedirect(
                returnUrl ?? Url.Content("~/"));
        }
    }
}