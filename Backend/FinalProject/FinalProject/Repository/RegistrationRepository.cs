using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Repository
{
    public class RegistrationRepository : Repository<Registration>, IRegistrationRepository
    {
        public List<Registration> GetRegInfoByName(string name)
        {
            return this.context.Registrations.Where(x => x.StudentName == name).ToList();
        }

        public List<Registration> GetAllRegInfo()
        {
            return this.context.Registrations.ToList();
        }
        public int GetTotalReg()
        {
            int totalfee = 0;
            List<Registration> reg= this.context.Registrations.ToList();
            foreach (var tk in reg)
            {
                totalfee += (int)tk.Fee;
            }
            return totalfee;
        }
     
}
}