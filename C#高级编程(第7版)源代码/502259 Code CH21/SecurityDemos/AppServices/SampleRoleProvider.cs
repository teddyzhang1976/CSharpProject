using System;
using System.Web.Security;

namespace Wrox.ProCSharp.Security
{
    public class SampleRoleProvider : RoleProvider
    {
        internal static string ManagerRoleName = "Manager".ToLowerInvariant();
        internal static string EmployeeRoleName = "Employee".ToLowerInvariant();

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (string.Compare(username, SampleMembershipProvider.ManagerUserName, true) == 0)
            {
                return new string[] { ManagerRoleName };
            }
            else if (string.Compare(username, SampleMembershipProvider.EmployeeUserName, true) == 0)
            {
                return new string[] { EmployeeRoleName };
            }
            else
            {
                return new string[0];
            }

        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = GetRolesForUser(username);
            foreach (var role in roles)
            {
                if (string.Compare(role, roleName, true) == 0)
                {
                    return true;
                }
            }
            return false;

        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
