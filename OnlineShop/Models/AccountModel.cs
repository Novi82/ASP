using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using System.Data.SqlClient;
namespace Models
{
    public class AccountModel
    {
        private OnlineShopDbContext _context = null;
        public AccountModel()
        {
            _context = new OnlineShopDbContext();
        }

        public bool Login(String userName, String password)
        {
            return _context.Database.SqlQuery<bool>("[dbo].[Sp_Account_Login] @UserName,@Password", new[] {
                    new SqlParameter ("@UserName",userName),
                    new SqlParameter ("@Password",password)
            }).SingleOrDefault<bool>();
        }
    }
}
