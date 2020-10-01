using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Repository
{
    interface ILoginRepository
    {
        string ValidateStudent(string UserName, string Password);

        string checkUserType(string UserName, string Password);
    }
}
