using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alert.Shared.CustomModels;
using Alert.DAL.Interfaces;

namespace Alert.DAL.Repositories
{
    public class MemberRepo : IMemberRepo
    {
        AlertBackEntities dbcontext = null;
        Response response;

        public object GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            IList<MemberCustomModel> MemberListModel = new List<MemberCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new AlertBackEntities())
                {
                    try
                    {
                        response.success = true;
                        MemberListModel = dbcontext.tblMembers.Where(x => x.IsDeleted == false)
                            .Select(x => new MemberCustomModel
                            {
                                MemberId = x.MemberId,
                                Name = x.Name,
                                EmailId = x.EmailId,
                                MobileNo = x.MobileNo,
                                MotherName = x.MotherName,
                                FatherName = x.FatherName,
                                Address = x.Address,
                                DateOfBirth = x.DateOfBirth,
                                Gender = x.Gender,
                                Image = x.Image,
                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifyBy = x.ModifyBy,
                                ModifiedDate = x.ModifiedDate,

                            }).OrderByDescending(x => x.MemberId).ToList();

                        return MemberListModel;

                    }
                    catch (Exception ex)
                    {
                        response.success = false;
                        response.message = ex.Message;
                        return response;
                    }
                }
            }
        }

        public void Dispose()
        {
            dbcontext.Dispose();
            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }
    }
}
