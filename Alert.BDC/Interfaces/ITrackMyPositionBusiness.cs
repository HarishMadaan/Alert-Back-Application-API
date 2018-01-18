using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alert.Shared.CustomModels;

namespace Alert.BDC.Interfaces
{
    public interface ITrackMyPositionBusiness : IDisposable
    {
        OperationStatus SaveMyCurrentPosition(TrackMyPositionCustomModel model);

        object GetMyCurrentPosition(TrackMyPositionCustomModel model);

        object GetMyAllPosition(TrackMyPositionCustomModel model);
    }
}
