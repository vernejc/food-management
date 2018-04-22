using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodManagement.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        private string _base_url;
        private string _base_href_url;


        /// <summary>
        /// Used to setup the variables that the controller need to initialize from AppSettings file.
        /// </summary>
        public virtual void ControllerSetup() {
            _base_url = ConfigurationManager.AppSettings["AppRoot"].ToString();
        }

        /// <summary>
        /// Used to configure the ViewBag of the controller.
        /// </summary>
        public virtual void ViewBagSetup() {
            ViewBag.BaseURL = _base_url;
            ViewBag.Title = Title;
            ViewBag.Base_HREF_URL = _base_url + RelativeURL;
        }

        /// <summary>
        /// Base URL property. Set in this way to enforce the retrieval from the web config to avoid access from within any Controller.
        /// </summary>
        public string BaseURL{
            get {
                return _base_url;
            }
        }
        /// <summary>
        /// base href property. Set in this way to enforce the retrieval from the web config to avoid access from within any Controller.
        /// </summary>
        public string Base_HREF_URL
        {
            get
            {
                return _base_href_url;
            }
        }

        public string Title { get; set; }
        public string RelativeURL { get; set; }
    }
}