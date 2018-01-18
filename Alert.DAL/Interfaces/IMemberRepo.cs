using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alert.Shared.CustomModels;

namespace Alert.DAL.Interfaces
{
    public interface IMemberRepo : IDisposable
    {
        object GetApplicationMemberList(MemberCustomModel objMemberModel);
    }
}
