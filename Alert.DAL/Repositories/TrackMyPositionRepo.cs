using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alert.Shared.CustomModels;
using Alert.DAL.Interfaces;

namespace Alert.DAL.Repositories
{
    public class TrackMyPositionRepo : ITrackMyPositionRepo
    {
        AlertBackEntities dbcontext = null;
        Response response;

        public OperationStatus SaveMyCurrentPosition(TrackMyPositionCustomModel model)
        {
            OperationStatus status = OperationStatus.Error;
            try
            {
                using (dbcontext = new AlertBackEntities())
                {
                    if (model.Id == 0)
                    {
                        tblTrackMyPosition _addMyPosition = new tblTrackMyPosition
                        {
                            MemberId = model.MemberId,
                            Title = model.Title,
                            Description = model.Description,
                            Image = model.Image,
                            DDate = model.DDate,
                            Longitude = model.Longitude,
                            Latitude = model.Latitude,
                            Place = model.Place,
                            
                            IsActive = true,
                            IsDeleted = false,
                            CreatedDate = DateTime.Now,
                            CreatedBy = model.CreatedBy,
                            ModifiedDate = DateTime.Now,
                            ModifiedBy = model.ModifiedBy

                        };
                        dbcontext.tblTrackMyPositions.Add(_addMyPosition);
                        dbcontext.SaveChanges();
                        status = OperationStatus.Success;
                    }
                }
            }
            catch (Exception ex)
            {
                dbcontext.Dispose();
                status = OperationStatus.Exception;
                throw ex;
            }
            
            return status;
        }

        public object GetMyCurrentPosition(TrackMyPositionCustomModel model)
        {
            List<TrackMyPositionCustomModel> PositionListModel = new List<TrackMyPositionCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new AlertBackEntities())
                {
                    try
                    {
                        response.success = true;
                        var rs = dbcontext.tblTrackMyPositions.Where(x => x.IsDeleted == false
                        && x.MemberId == model.MemberId
                        )
                            .Select(x => new TrackMyPositionCustomModel
                            {
                                Id = x.Id,
                                MemberId = x.MemberId,
                                MemberName = x.tblMember != null ? x.tblMember.Name : "",
                                Title = x.Title,
                                Description = x.Description,
                                Image = x.Image,
                                DDate = x.DDate,
                                Longitude = x.Longitude,
                                Latitude = x.Latitude,
                                Place = x.Place,

                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate
                            }).OrderByDescending(x => x.Id).FirstOrDefault();

                        return rs;

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

        public object GetMyAllPosition(TrackMyPositionCustomModel model)
        {
            List<TrackMyPositionCustomModel> PositionListModel = new List<TrackMyPositionCustomModel>();

            using (response = new Response())
            {
                using (dbcontext = new AlertBackEntities())
                {
                    try
                    {
                        response.success = true;
                        PositionListModel = dbcontext.tblTrackMyPositions.Where(x => x.IsDeleted == false
                        && x.MemberId == model.MemberId
                        )
                            .Select(x => new TrackMyPositionCustomModel
                            {
                                MemberId = x.MemberId,
                                MemberName = x.tblMember != null ? x.tblMember.Name : "",
                                Title = x.Title,
                                Description = x.Description,
                                Image = x.Image,
                                DDate = x.DDate,
                                Longitude = x.Longitude,
                                Latitude = x.Latitude,
                                Place = x.Place,

                                IsActive = x.IsActive,
                                IsDeleted = x.IsDeleted,
                                CreatedBy = x.CreatedBy,
                                CreatedDate = x.CreatedDate,
                                ModifiedBy = x.ModifiedBy,
                                ModifiedDate = x.ModifiedDate
                            }).OrderByDescending(x => x.MemberId).ToList();

                        return PositionListModel;

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
