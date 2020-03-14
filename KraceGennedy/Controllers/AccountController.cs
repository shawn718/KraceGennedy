using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KraceGennedy.Interfaces;
using KraceGennedy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using KraceGennedy.Static;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace KraceGennedy.Controllers
{
    public class AccountController : Controller
    {
        //Declare variables for interfaces, logger, dbcontext and repositories
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepositoriesInterface _userRepositoriesInterface;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        //private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountController(ILogger<HomeController> logger, IUserRepositoriesInterface UserRepositoriesInterface, 
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, 
             RoleManager<IdentityRole> roleManager)//IHttpContextAccessor httpContextAccessor,
        {
            _logger = logger;
            _userRepositoriesInterface = UserRepositoriesInterface;
            this.userManager = userManager;
            this.signInManager = signInManager;
            //_httpContextAccessor = httpContextAccessor;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            //declare instance of register view model
            RegisterViewModel rvm = new RegisterViewModel();
            try
            {
                //populate register view model with cities from the database
                rvm.city = _userRepositoriesInterface.GetCities();
                //populate register view model with positions from the database
                rvm.position = _userRepositoriesInterface.GetPositions();
                //declare and poplulate list of roles
                List<Role> roleList = new List<Role>();
                Role role1 = new Role();
                Role role2 = new Role();
                Role role3 = new Role();
                Role role4 = new Role();
                role1.Name = ApplicationVariables.Roles.Employee;
                roleList.Add(role1);
                role2.Name = ApplicationVariables.Roles.Manager;
                roleList.Add(role2);
                role3.Name = ApplicationVariables.Roles.ITAdmin;
                roleList.Add(role3);
                role4.Name = ApplicationVariables.Roles.CEO;
                roleList.Add(role4);
                //Create Roles If Not Exist
                foreach(var roleItem in roleList)
                {
                    var roleExist = await roleManager.FindByNameAsync(roleItem.Name);
                    if (roleExist == null)
                    {
                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = roleItem.Name
                        };

                        IdentityResult roleResult = await roleManager.CreateAsync(identityRole);
                    }
                }
                //declare and populate register view model with list of roles
                rvm.Role = new List<Role>();

                foreach(var role in roleManager.Roles)
                {
                    Role roleItem = new Role();
                    roleItem.Id = role.Id;
                    roleItem.Name = role.Name;
                    rvm.Role.Add(roleItem);
                }
                //Set roles session
                HttpContext.Session.SetString(ApplicationVariables.SessionVariables.Roles, JsonConvert.SerializeObject(rvm.Role));
                //checks if a user was created successfully
                var userCeatedSuccess = HttpContext.Session.GetString(ApplicationVariables.SessionVariables.AddUserSuccess);
                if(userCeatedSuccess != null)
                {
                    //send result to view by storing in viewbag variable accessable in the view
                    ViewBag.AddUserSuccess = userCeatedSuccess;
                    HttpContext.Session.SetString(ApplicationVariables.SessionVariables.AddUserSuccess, "none");
                }
                //send the populated register view model to the view
                return View(rvm);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:" + ex.Message);
                return RedirectToAction("index", "home");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            //checks if the validations placed in the model was passed
            if (ModelState.IsValid)
            {
                try
                {
                    //retrieve user roles /Moved Up for testing
                    List<Role> userRoles = JsonConvert.DeserializeObject<List<Role>>(HttpContext.Session.GetString(ApplicationVariables.SessionVariables.Roles));
                    //select the role from list of roles based on the role id passed from the model
                    var selectedUserRole = userRoles.Where(y => y.Id == rvm.RoleId.ToString()).FirstOrDefault();
                    //create new instance of identity user model and populate it with values recieved from the view
                    var user = new IdentityUser { UserName = rvm.Email, Email = rvm.Email };
                    //check if user exist
                    var userExist = userManager.FindByEmailAsync(user.Email);
                    if (userExist.Result == null)
                    {
                        //create user
                        var result = await userManager.CreateAsync(user, rvm.ConfirmPassword);

                        //checks if user creation was successfull
                        if (result.Succeeded)
                        {
                            //Sign in user
                            //await signInManager.SignInAsync(user, isPersistent: false);
                            
                            
                            //Check if user is already in a role
                            var adminCheck = userManager.IsInRoleAsync(user, ApplicationVariables.Roles.ITAdmin).Result;
                            var managerCheck = userManager.IsInRoleAsync(user, ApplicationVariables.Roles.Manager).Result;
                            var employeeCheck = userManager.IsInRoleAsync(user, ApplicationVariables.Roles.Employee).Result;
                            var ceoCheck = userManager.IsInRoleAsync(user, ApplicationVariables.Roles.CEO).Result;
                            

                            if (!adminCheck && !managerCheck && !employeeCheck && !ceoCheck)
                            {
                                //Add user to role selected if not already in role
                                await userManager.AddToRoleAsync(user, selectedUserRole.Name);
                            }

                            //Populate employee model
                            Employee emp = new Employee()
                            {
                                EmployeeId = user.Id,
                                CityID = rvm.CityID,
                                PositionID = rvm.PositionId,
                                FullName = rvm.FirstName + " " + rvm.LastName,
                                Address = rvm.Address,
                                Telephone = rvm.TelephoneNum,
                                Email = rvm.Email,
                                DOB = rvm.DOB,
                                Gender = rvm.Gender,
                                Country = rvm.Country,
                                Branch = rvm.Branch
                            };

                            //Add user to database
                            _userRepositoriesInterface.CreateEmployee(emp);
                            //update user success session
                            HttpContext.Session.SetString(ApplicationVariables.SessionVariables.AddUserSuccess, "true");
                            
                            //return user to add new employee screen
                            return RedirectToAction("register", "account");
                        }

                        //check for model errors
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("Password", error.Description);
                            //update user success session
                            HttpContext.Session.SetString(ApplicationVariables.SessionVariables.AddUserSuccess, "false");
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error: " + ex.Message);
                    //update user success session
                    HttpContext.Session.SetString(ApplicationVariables.SessionVariables.AddUserSuccess, "false");
                }
                
                
            }

            //if above fail
            //get cities from db
            //get positions from db
            //get roles from session
            //populate model so that we dont encounter a null error from the drop down lists
            rvm.city = _userRepositoriesInterface.GetCities();
            rvm.position = _userRepositoriesInterface.GetPositions();
            rvm.Role = new List<Role>();
            rvm.Role = JsonConvert.DeserializeObject<List<Role>>(HttpContext.Session.GetString(ApplicationVariables.SessionVariables.Roles));
           //return user to add new employee page
            return View(rvm);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            //go to login page
            return View();
        } 
        
        [HttpPost]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel lvm)
        {
            //checks if the validations placed in the model was passed
            if (ModelState.IsValid)
            {
                //attemp to sign in user
                var result = await signInManager.PasswordSignInAsync(lvm.Email, lvm.Password,
                                lvm.RememberMe, false);
                //check if sign in was successfull
                if (result.Succeeded)
                {
                    //if yes store user email in session for future use and retrun to logged in user home
                    HttpContext.Session.SetString(ApplicationVariables.SessionVariables.UserEmail, JsonConvert.SerializeObject(lvm.Email));
                    return RedirectToAction("index", "home");
                }
                
                //else return model error
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

                
            }

            return View(lvm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            //sign out user
            await signInManager.SignOutAsync();
            //return to logged out user home
            return RedirectToAction("index", "home");
        }
        
        public class RoleList
        {
            public List<Role> roleList { get; set; }
        }

    }
}