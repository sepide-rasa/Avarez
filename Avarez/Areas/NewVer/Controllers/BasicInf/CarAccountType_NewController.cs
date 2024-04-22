﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using Ext.Net.Utilities;
using Avarez.Controllers.Users;

namespace Avarez.Areas.NewVer.Controllers.BasicInf
{
    public class CarAccountType_NewController : Controller
    {
        //
        // GET: /NewVer/CarAccountType_New/

        public ActionResult Index(string containerId)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("LogOn", "Account_New");
            Avarez.Models.OnlineUser.UpdateUrl(Session["UserId"].ToString(), "اطلاعات پایه->نوع کاربری");
            SignalrHub hub = new SignalrHub();
            hub.ReloadOnlineUser();
            var result = new Ext.Net.MVC.PartialViewResult
            {
                WrapByScriptTag = true,
                ContainerId = containerId,
                RenderMode = RenderMode.AddTo
            };

            this.GetCmp<TabPanel>(containerId).SetLastTabAsActive();
            return result;              
        }
        public ActionResult New(int Id)
        {//باز شدن پنجره
            if (Session["UserId"] == null)
                return RedirectToAction("LogOn", "Account_New");
            Ext.Net.MVC.PartialViewResult PartialView = new Ext.Net.MVC.PartialViewResult();
            PartialView.ViewBag.Id = Id;
            return PartialView;
        }


        public ActionResult GetCascadeMake()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("LogOn", "Account_New");
            Models.cartaxEntities car = new Models.cartaxEntities();
            return Json(car.sp_CarMakeSelect("", "", 0, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).Select(c => new { fldID = c.fldID, fldName = c.fldName }).OrderBy(l => l.fldName), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Help()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("logon", "Account_New", new { area = "NewVer" });
            Ext.Net.MVC.PartialViewResult PartialView = new Ext.Net.MVC.PartialViewResult();
            return PartialView;
        }
        public ActionResult Save(Models.sp_CarAccountTypeSelect CarAccountType)
        {
            try
            {
                if (Session["UserId"] == null)
                    return RedirectToAction("LogOn", "Account_New");
                System.Data.Entity.Core.Objects.ObjectParameter _CarAccountId = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", typeof(int));
                Models.cartaxEntities Car = new Models.cartaxEntities();
                int UserId = Convert.ToInt32(Session["UserId"]);
                if (UserId != 1 && !CarAccountType.fldName.Contains("سواری") && !CarAccountType.fldName.Contains("آمبولانس") && !CarAccountType.fldName.Contains("وانت دوکابین") || UserId == 1)
                {
                    if (CarAccountType.fldDesc == null)
                        CarAccountType.fldDesc = "";
                    if (CarAccountType.fldID == 0)
                    {//ثبت رکورد جدید
                        if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 70))
                        {
                            Car.sp_CarAccountTypeInsert(_CarAccountId, CarAccountType.fldName, CarAccountType.fldCarMakeID,
                                Convert.ToInt32(Session["UserId"]), CarAccountType.fldDesc, Session["UserPass"].ToString());
                            return Json(new
                            {
                                MsgTitle = "ذخیره موفق",
                                Msg = "ذخیره با موفقیت انجام شد.",
                                Er = 0
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new
                            {
                                MsgTitle = "خطا",
                                Msg = "شما مجاز به دسترسی نمی باشید.",
                                Er = 1
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {//ویرایش رکورد ارسالی
                        if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 72))
                        {
                            Car.sp_CarAccountTypeUpdate(CarAccountType.fldID, CarAccountType.fldName,
                                CarAccountType.fldCarMakeID, Convert.ToInt32(Session["UserId"]), CarAccountType.fldDesc, Session["UserPass"].ToString());
                            return Json(new
                            {
                                MsgTitle = "ویرایش موفق",
                                Msg = "ویرایش با موفقیت انجام شد.",
                                Er = 0
                            }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new
                            {
                                MsgTitle = "خطا",
                                Msg = "شما مجاز به دسترسی نمی باشید.",
                                Er = 1
                            }, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                else
                {
                    return Json(new
                    {
                        MsgTitle = "خطا",
                        Msg = "شما مجاز به دسترسی نمی باشید.",
                        Er = 1
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception x)
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                System.Data.Entity.Core.Objects.ObjectParameter Eid = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", sizeof(int));
                string InnerException = "";
                if (x.InnerException != null)
                    InnerException = x.InnerException.Message;
                Car.sp_ErrorProgramInsert(Eid, InnerException, Convert.ToInt32(Session["UserId"]), x.Message, DateTime.Now, Session["UserPass"].ToString());
                return Json(new
                {
                    MsgTitle = "خطا",
                    Msg = "خطایی با شماره: " + Eid.Value + " رخ داده است لطفا با پشتیبانی تماس گرفته و کد خطا را اعلام فرمایید.",
                    Er = 1
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Delete(int Id)
        {//حذف یک رکورد
            try
            {                
                if (Session["UserId"] == null)
                    return RedirectToAction("LogOn", "Account_New");
                int UserId = Convert.ToInt32(Session["UserId"]);
                if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 71))
                {
                    Models.cartaxEntities Car = new Models.cartaxEntities();
                    var q = Car.sp_CarAccountTypeSelect("fldId", Id.ToString(), 1, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).FirstOrDefault();
                    if (UserId != 1 && !q.fldName.Contains("سواری") && !q.fldName.Contains("آمبولانس") && !q.fldName.Contains("وانت دوکابین") || UserId == 1)
                    {
                        Car.sp_CarAccountTypeDelete(Convert.ToInt32(Id), Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString());
                        return Json(new
                        {
                            MsgTitle = "حذف موفق",
                            Msg = "حذف با موفقیت انجام شد.",
                            Er = 0
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new
                        {
                            MsgTitle = "خطا",
                            Msg = "شما مجاز به دسترسی نمی باشید.",
                            Er = 1
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        MsgTitle = "خطا",
                        Msg = "شما مجاز به دسترسی نمی باشید.",
                        Er = 1
                    }, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception x)
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                System.Data.Entity.Core.Objects.ObjectParameter Eid = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", sizeof(int));
                string InnerException = "";
                if (x.InnerException != null)
                    InnerException = x.InnerException.Message;
                Car.sp_ErrorProgramInsert(Eid, InnerException, Convert.ToInt32(Session["UserId"]), x.Message, DateTime.Now, Session["UserPass"].ToString());
                return Json(new
                {
                    MsgTitle = "خطا",
                    Msg = "خطایی با شماره: " + Eid.Value + " رخ داده است لطفا با پشتیبانی تماس گرفته و کد خطا را اعلام فرمایید.",
                    Er = 1
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Details(int Id)
        {//نمایش اطلاعات جهت رویت کاربر
            try
            {
                if (Session["UserId"] == null)
                    return RedirectToAction("LogOn", "Account_New");
               Models.cartaxEntities Car = new Models.cartaxEntities();
                int UserId = Convert.ToInt32(Session["UserId"]);
                var q = Car.sp_CarAccountTypeSelect("fldId", Id.ToString(), 1, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).FirstOrDefault();
                if (UserId != 1 && !q.fldName.Contains("سواری") && !q.fldName.Contains("آمبولانس") && !q.fldName.Contains("وانت دوکابین") || UserId == 1)
                {
                    return Json(new
                    {
                        Er = 0,
                        fldId = q.fldID,
                        fldName = q.fldName,
                        fldCarMakeID = q.fldCarMakeID.ToString(),
                        fldDesc = q.fldDesc
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        MsgTitle = 0,
                        Msg = "شما مجاز به دسترسی نمی باشید.",
                        Er = 1
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception x)
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                System.Data.Entity.Core.Objects.ObjectParameter Eid = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", sizeof(int));
                string InnerException = "";
                if (x.InnerException != null)
                    InnerException = x.InnerException.Message;
                Car.sp_ErrorProgramInsert(Eid, InnerException, Convert.ToInt32(Session["UserId"]), x.Message, DateTime.Now, Session["UserPass"].ToString());
                return Json(new
                {
                    MsgTitle = "خطا",
                    Msg = "خطایی با شماره: " + Eid.Value + " رخ داده است لطفا با پشتیبانی تماس گرفته و کد خطا را اعلام فرمایید.",
                    Er = 1
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Read(StoreRequestParameters parameters)
        {
            if (Session["UserId"] == null)
                return RedirectToAction("LogOn", "Account_New");
            var filterHeaders = new FilterHeaderConditions(this.Request.Params["filterheader"]);
            Models.cartaxEntities m = new Models.cartaxEntities();
            List<Avarez.Models.sp_CarAccountTypeSelect> data = null;
            if (filterHeaders.Conditions.Count > 0)
            {
                string field = "";
                string searchtext = "";
                List<Avarez.Models.sp_CarAccountTypeSelect> data1 = null;
                foreach (var item in filterHeaders.Conditions)
                {
                    var ConditionValue = (Newtonsoft.Json.Linq.JValue)item.ValueProperty.Value;

                    switch (item.FilterProperty.Name)
                    {
                        case "fldID":
                            searchtext = ConditionValue.Value.ToString();
                            field = "fldId";
                            break;
                        case "fldName":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldName";
                            break;
                        case "fldCarMakeName":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldCarMakeName";
                            break;
                        case "fldDesc":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldDesc";
                            break;
                    }
                    if (data != null)

                        data1 = m.sp_CarAccountTypeSelect(field, searchtext, 100, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList();
                    else
                        data = m.sp_CarAccountTypeSelect(field, searchtext, 100, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList();
                }
                if (data != null && data1 != null)
                    data.Intersect(data1);
            }
            else
            {
                data = m.sp_CarAccountTypeSelect("", "", 100, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList();
            }

            var fc = new FilterHeaderConditions(this.Request.Params["filterheader"]);

            //FilterConditions fc = parameters.GridFilters;

            //-- start filtering ------------------------------------------------------------
            if (fc != null)
            {
                foreach (var condition in fc.Conditions)
                {
                    string field = condition.FilterProperty.Name;
                    var value = (Newtonsoft.Json.Linq.JValue)condition.ValueProperty.Value;

                    data.RemoveAll(
                        item =>
                        {
                            object oValue = item.GetType().GetProperty(field).GetValue(item, null);
                            return !oValue.ToString().Contains(value.ToString());
                        }
                    );
                }
            }
            //-- end filtering ------------------------------------------------------------

            //-- start paging ------------------------------------------------------------
            int limit = parameters.Limit;

            if ((parameters.Start + parameters.Limit) > data.Count)
            {
                limit = data.Count - parameters.Start;
            }

            List<Avarez.Models.sp_CarAccountTypeSelect> rangeData = (parameters.Start < 0 || limit < 0) ? data : data.GetRange(parameters.Start, limit);
            //-- end paging ------------------------------------------------------------

            return this.Store(rangeData, data.Count);
        }
    }
}
