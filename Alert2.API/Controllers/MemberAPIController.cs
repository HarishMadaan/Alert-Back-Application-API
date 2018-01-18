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
    public class MemberAPIController : ApiController
    {
        #region Global Variable
        Response _response = new Response();
        private IMemberBusiness memberService;
        #endregion

        public MemberAPIController()
        {

        }

        /// <summary>
        /// This method is used to fetch Farmer Registration
        /// </summary>
        /// <returns>List of Farmer Registration</returns>
        [HttpGet]
        [Route("API/MemberAPI/GetApplicationMemberList")]
        public Response GetApplicationMemberList(MemberCustomModel objMemberModel)
        {
            _response = new Response();
            try
            {
                MemberBusiness memberService = new MemberBusiness();
                _response.responseData = memberService.GetApplicationMemberList(objMemberModel);
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
                memberService = null;
            }
            return _response;
        }

    }
}
