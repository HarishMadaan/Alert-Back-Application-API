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
    public class TrackMyPositionBusiness : ITrackMyPositionBusiness
    {
        ITrackMyPositionRepo objDAL;

        /// <summary>
        /// This method is used to save Current Position
        /// </summary>
        /// <returns></returns>
        public OperationStatus SaveMyCurrentPosition(TrackMyPositionCustomModel model)
        {
            using (objDAL = new TrackMyPositionRepo())
            {
                return objDAL.SaveMyCurrentPosition(model);
            }
        }

        /// <summary>
        /// This method is used to fetch Current Position
        /// </summary>
        /// <returns>current position</returns>
        public object GetMyCurrentPosition(TrackMyPositionCustomModel model)
        {
            using (objDAL = new TrackMyPositionRepo())
            {
                return objDAL.GetMyCurrentPosition(model);
            }
        }

        /// <summary>
        /// This method is used to fetch Current Position
        /// </summary>
        /// <returns>all position</returns>
        public object GetMyAllPosition(TrackMyPositionCustomModel model)
        {
            using (objDAL = new TrackMyPositionRepo())
            {
                return objDAL.GetMyAllPosition(model);
            }
        }
        public void Dispose()
        {
            objDAL.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
