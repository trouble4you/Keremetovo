﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSphere.Domain.Abstract;

namespace WebSphere.WebUI.Controllers
{
    public class OpcController : Controller
    { 
        public ActionResult GetAllOpcTagsValues()
        {
           var tags= MvcApplication.OpcPoller.ReadTags();

           return Json(tags);
        }
        public ActionResult GetOpcInfo()
        {
            var tags = MvcApplication.OpcPoller.GetOpcInfo();

            return Json(tags);
        }
        public ActionResult ServerChangeState(int cmd,int pollerId)
        {
            bool z;
            if (cmd==1) 
                  z = MvcApplication.OpcPoller.Connect(pollerId);
              else if (cmd==0) 
                     z = MvcApplication.OpcPoller.Stop(pollerId); 
                 else  
                   z = MvcApplication.OpcPoller.Reinicialize(pollerId);   
            return Json(z);
        }
 
	}
}