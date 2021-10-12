using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Acme.BookStore.Application.Admin
{
    [Authorize]
    public class AdminAppService : BookStoreAppService
    {
        private readonly IdentityRoleManager roleService;
        private readonly IdentityUserManager userManager;
        private readonly IPermissionManager permissionManager;

        public AdminAppService(IdentityRoleManager roleService, IdentityUserManager userManager, IPermissionManager permissionManager)
        {
            this.permissionManager = permissionManager;
            this.roleService = roleService;
            this.userManager = userManager;
        }
        public string Check()
        {
            return "Ok";
        }
      
        public async Task<string> IsEcOfficerAsync()
        {
            if(await AuthorizationService.IsGrantedAsync(BookStorePermissions.CoiApprove))
            {
                return "YES";
            }
            return "NO";
        }
        public async Task<string> CreateRoleAsync()
        {
            var role = new IdentityRole(GuidGenerator.Create(), "EC Officer");
            await roleService.CreateAsync(role);
            return "Role CreATED";
        }
        public async Task<string> AddCurrentUserToEcOfficer()
        {
            var user = await userManager.FindByIdAsync(CurrentUser.Id.ToString());
            await userManager.AddToRoleAsync(user, "EC Officer");
            return "User added To ROle";
        }
        public async Task<string> AddRoleToPermission()
        {
             await permissionManager.SetForRoleAsync("EC Officer",BookStorePermissions.CoiApprove,true);
             return "Permission Added";

        }
       public List<IdentityRole> GetRoles()
        {
            //Get All Admin Roles except teacher and student ie, 1 and 2
            return roleService.Roles.ToList();
        }
         
    }
}