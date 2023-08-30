// //Itterativt: 
// //models
// //lägg till using authentication authentization 
// using Microsoft.AspNetCore.Authorization;

// //behöver skapa en cookie - känner man till användaren osv, skapa en cookie till det/den. 
// using System.Security.Claims;
// using Microsoft.AspNetCore.Authentication.Cookies;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Authentication.Google;

// using Microsoft.AspNetCore.Mvc;
// using AuthDemo.Models;
// namespace AuthDemo.Controllers;
// public class AccountController : Controller
// {
//     // Mocked user data
//     private const string MockedUsername = "demo";
//     private const string MockedPassword = "pass"; // Note: NEVER hard-code passwords in real applications.

//     //action metod, gå till sida som visar username och password. 
//     [HttpGet]
//     public IActionResult Login()
//     {
//         return View();
//     }

//     // //när man gjort submit så vill man göra en post request i browsern, 
//     // [HttpPost]
//     // [ValidateAntiForgeryToken] // This ensures that the form is submitted with a valid anti-forgery token to prevent CSRF attacks. Viktigt i login sammanhang
//     // public IActionResult Login(LoginViewModel model)
//     // {
//     //     // Check model validators
//     //     if (!ModelState.IsValid)
//     //         {
//     //             return View(model);
//     //         }
//     //     // Mocked user verification
//     //     if (model.Username == MockedUsername && model.Password == MockedPassword)
//     //         {
//     //             // Normally, here you'd set up the session/cookie for the authenticated user.
//     //             return RedirectToAction("Index", "Home"); // Redirect to a secure area of your application.
//     //         }
//     //     ModelState.AddModelError(string.Empty, "Invalid login attempt."); // Generic error message for security reasons.
//     //     return View(model);
//     // }

//     [Authorize] // This attribute ensures that only authenticated users can access this action.
//     public IActionResult SecretInfo()
//     {
//         return View();
//     }
//     public IActionResult GoogleLogin()
//     {
//         var authProperties = new AuthenticationProperties
//         {
//             RedirectUri = Url.Action("GoogleLoginCallback", "Account")
//         };
//         return Challenge(authProperties, GoogleDefaults.AuthenticationScheme);
//     }
//     public async Task<IActionResult> GoogleLoginCallbackAsync()
//     {
//         var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//         if (!result.Succeeded)
//         {
//             // Handle failure: return to the login page, show an error, etc.
//             return RedirectToAction("Login");
//         }
//         // Here, you could fetch information from result.Principal to store in your database,
//         // or to find an existing user.
//         return RedirectToAction("Index", "Home");
//     }
//     [HttpPost]
//     [ValidateAntiForgeryToken] // This ensures that the form is submitted with a valid anti-forgery token to prevent CSRF attacks.
//     //istället för att skicka ut iaction result så skickar den ut task iactionresult. 
//     public async Task<IActionResult> LoginAsync(LoginViewModel model)
//     {
//         // Check model validators
//         if (!ModelState.IsValid)
//         {
//             return View(model);
//         }
//         // Mocked user verification
//         if (model.Username == MockedUsername && model.Password == MockedPassword)
//         {
//             // Set up the session/cookie for the authenticated user.
//             //lista på Claim(s) stoppar in i vår identity. 
//             var claims = new[] { new Claim(ClaimTypes.Name, model.Username) };
//             var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//             var principal = new ClaimsPrincipal(identity);
//             //nedan skapas cookies, skickar iväg gör något och sen kommer den tillbaka ASYNC 
//             //man kan inte använda en ASYNC metod i en sync kod. 
//             //så fort man gör IO opperationer så vill man göra Asyncroma. (async)?)
//             await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
//             // Normally, here you'd set up the session/cookie for the authenticated user.
//             return RedirectToAction("Index", "Home"); // Redirect to a secure area of your application.
//         }
//         ModelState.AddModelError(string.Empty, "Invalid login attempt."); // Generic error message for security reasons.
//         return View(model);
//     }


//     //logout action att logga ut för att tömma cookies på browsern. 
//     [Authorize]
//     public IActionResult Logout()
//     {
//         return SignOut(
//             new AuthenticationProperties
//             {
//                 RedirectUri = Url.Action("Index", "Home")
//             },
//             CookieAuthenticationDefaults.AuthenticationScheme);
//     }
// }