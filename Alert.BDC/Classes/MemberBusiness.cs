using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alert.Shared.CustomModels;
using Alert.BDC.Interfaces;
using Alert.DAL.Interfaces;
using Alert.DAL.Repositories;

namespace Alert.BDC.Classes
{
    public class MemberBusiness : IMemberBusiness
    {
        IMemberRepo objDAL;

        /// <summary>
        /// This method is used to fetch All Members
        /// </summary>
        /// <returns></returns>
        public object GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            using (objDAL = new MemberRepo())
            {
                return objDAL.GetApplicationMemberList(objMemberModel);
            }
        }

        public void Dispose()
        {
            objDAL.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
