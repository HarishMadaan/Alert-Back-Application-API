using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Alert.Shared.CustomModels;
using Alert.BDC.Interfaces;
using Alert.BDC.Classes;

namespace Alert2.API.Controllers
{
    public class TrackMyPositionAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IMemberBusiness memberService;
        #endregion

        public TrackMyPositionAPIController()
        {

        }

        /// <summary>
        /// This method is used to save my current position
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("API/TrackMyPosition/SaveMyCurrentPosition")]
        public Response SaveMyCurrentPosition(TrackMyPositionCustomModel model)
        {
            _response = new Response();
            TrackMyPositionBusiness objBDS = new TrackMyPositionBusiness();
            try
            {                
                _response.responseData = objBDS.SaveMyCurrentPosition(model);
                _response.message = "Records saved successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                objBDS = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to get my current position
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("API/TrackMyPosition/GetMyCurrentPosition")]
        public Response GetMyCurrentPosition(TrackMyPositionCustomModel model)
        {
            _response = new Response();
            TrackMyPositionBusiness objBDS = new TrackMyPositionBusiness();
            try
            {
                _response.responseData = objBDS.GetMyCurrentPosition(model);
                _response.message = "Records loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                objBDS = null;
            }
            return _response;
        }

        /// <summary>
        /// This method is used to get my all position
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("API/TrackMyPosition/GetMyAllPosition")]
        public Response GetMyAllPosition(TrackMyPositionCustomModel model)
        {
            _response = new Response();
            TrackMyPositionBusiness objBDS = new TrackMyPositionBusiness();
            try
            {
                _response.responseData = objBDS.GetMyAllPosition(model);
                _response.message = "Records loaded successfully !!";
                _response.success = true;
            }
            catch (Exception ex)
            {
                _response.success = false;
                _response.message = ex.Message.ToString();
            }
            finally
            {
                objBDS = null;
            }
            return _response;
        }

    }
}
