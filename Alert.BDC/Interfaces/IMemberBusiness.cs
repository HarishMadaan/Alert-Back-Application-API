﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alert.Shared.CustomModels;

namespace Alert.BDC.Interfaces
{
    public interface IMemberBusiness : IDisposable
    {
        object GetApplicationMemberList(MemberCustomModel objMemberModel);
    }
}
