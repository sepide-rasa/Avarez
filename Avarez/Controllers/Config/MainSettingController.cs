﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Collections;
using Avarez.Controllers.Users;
namespace Avarez.Controllers.Config
{
    [Authorize]
    public class MainSettingController : Controller
    {
        //
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
                return RedirectToAction("logon", "Account");
            if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 177))
            {
                return PartialView();
            }
            else
            {
                Session["ER"] = "شما مجاز به دسترسی نمی باشید.";
                return RedirectToAction("error", "Metro");
            }
        }
        public ActionResult Fill([DataSourceRequest] DataSourceRequest request)
        {
            Models.cartaxEntities m = new Models.cartaxEntities();
            var q = m.sp_MainSettingSelect("", "", 30, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList().ToDataSourceResult(request);
            return Json(q);

        }
        public ActionResult Save(Models.MainSetting MainSetting)
        {
            try
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                if (MainSetting.fldDesc == null)
                    MainSetting.fldDesc = "";
                if (MainSetting.fldID == 0)
                {//ثبت رکورد جدید
                    if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 178))
                    {
                        Car.sp_MainSettingInsert(MainSetting.fldLateFine, MainSetting.fldTax, MainSetting.fldTypeCountryDivisions, MainSetting.fldCodeCountryDivisions,
                            Convert.ToInt32(Session["UserId"]), MainSetting.fldDesc,
                            MyLib.Shamsi.Shamsi2miladiDateTime(MainSetting.fldImplementationDate),
                            MainSetting.fldCountryDivisionsTreeApply, MainSetting.fldTypeCar, MainSetting.fldCodeCar,
                            MainSetting.fldCarSeriesTreeApply, Session["UserPass"].ToString(),Convert.ToBoolean(MainSetting.fldFineType)
                            ,MainSetting.fldFirstInsurance);

                        return Json(new { data = "ذخیره با موفقیت انجام شد.", state = 0 });
                    }
                    else
                    {
                        Session["ER"] = "شما مجاز به دسترسی نمی باشید.";
                        return RedirectToAction("error", "Metro");
                    }
                }
                else
                {//ویرایش رکورد ارسالی
                    if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 180))
                    {
                        Car.sp_MainSettingUpdate(MainSetting.fldID, MainSetting.fldLateFine, MainSetting.fldTax, MainSetting.fldTypeCountryDivisions, MainSetting.fldCodeCountryDivisions,
                            Convert.ToInt32(Session["UserId"]), MainSetting.fldDesc,
                            MyLib.Shamsi.Shamsi2miladiDateTime(MainSetting.fldImplementationDate),
                            MainSetting.fldCountryDivisionsTreeApply, MainSetting.fldTypeCar, MainSetting.fldCodeCar,
                            MainSetting.fldCarSeriesTreeApply, Session["UserPass"].ToString(), Convert.ToBoolean(MainSetting.fldFineType)
                            , MainSetting.fldFirstInsurance);
                        return Json(new { data = "ویرایش با موفقیت انجام شد.", state = 0 });
                    }
                    else
                    {
                        Session["ER"] = "شما مجاز به دسترسی نمی باشید.";
                        return RedirectToAction("error", "Metro");
                    }
                }
            }
            catch (Exception x)
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                System.Data.Entity.Core.Objects.ObjectParameter Eid = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", sizeof(int));
                string InnerException = "";
                if (x.InnerException.Message != null)
                    InnerException = x.InnerException.Message;
                Car.sp_ErrorProgramInsert(Eid, InnerException, Convert.ToInt32(Session["UserId"]), x.Message, DateTime.Now, Session["UserPass"].ToString());
                return Json(new { data = "خطایی با شماره: " + Eid.Value + " رخ داده است لطفا با پشتیبانی تماس گرفته و کد خطا را اعلام فرمایید.", state = 1 });
            }
        }

        public JsonResult _CountryTree(int? id)
        {
            string url = Url.Content("~/Content/images/");
            var p = new Models.cartaxEntities();
            //پروسیجر تشخیص کاربر در تقسیمات کشوری برای
            //لود درخت همان ناحیه ای کاربر در سطح آن تعریف شده 
            //var id=sp_gettreeId(userid);
            string CountryDivisionTempIdUserAccess = "1";//id;
            if (id != null)
            {
                var rols = (from k in p.sp_TableTreeSelect("fldPID", id.ToString(), 0, 0, 0).Where(w => w.fldNodeType != 9)
                            select new
                            {
                                id = k.fldID,
                                fldNodeType = k.fldNodeType,
                                fldSid = k.fldSourceID,
                                Name = k.fldNodeName,
                                image = url + k.fldNodeType.ToString() + ".png",
                                hasChildren = p.sp_TableTreeSelect("fldPID", id.ToString(), 0, 0, 0).Where(w => w.fldNodeType != 9).Any()

                            });
                return Json(rols, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var rols = (from k in p.sp_TableTreeSelect("fldId", CountryDivisionTempIdUserAccess, 0, 0, 0).Where(w => w.fldNodeType != 9)
                            select new
                            {
                                id = k.fldID,
                                fldNodeType = k.fldNodeType,
                                fldSid = k.fldSourceID,
                                Name = k.fldNodeName,
                                image = url + k.fldNodeType.ToString() + ".png",
                                hasChildren = p.sp_TableTreeSelect("fldId", CountryDivisionTempIdUserAccess, 0, 0, 0).Where(w => w.fldNodeType != 9).Any()

                            });
                return Json(rols, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult _CarTree(int? id)
        {
            string url = Url.Content("~/Content/images/c");
            var p = new Models.cartaxEntities();
            //پروسیجر تشخیص کاربر در سلسله مراتب خودرو برای
            //لود درخت همان ناحیه ای کاربر در سطح آن تعریف شده 
            //var id=sp_gettreeId(userid);
            //string CountryDivisionTempIdUserAccess = "1";//id;
            if (id != null)
            {
                var rols = (from k in p.sp_TableTreeCarSelect("fldPID", id.ToString(), 0, 0, 0)
                            select new
                            {
                                id = k.fldID,
                                fldNodeType = k.fldNodeType,
                                fldSid = k.fldSourceID,
                                Name = k.fldNodeName,
                                image = url + k.fldNodeType.ToString() + ".png",
                                hasChildren = p.sp_TableTreeCarSelect("fldPID", id.ToString(), 0, 0, 0).Any()

                            });
                return Json(rols, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var rols = (from k in p.sp_TableTreeCarSelect("fldId", "1", 0, 0, 0)
                            select new
                            {
                                id = k.fldID,
                                fldNodeType = k.fldNodeType,
                                fldSid = k.fldSourceID,
                                Name = k.fldNodeName,
                                image = url + k.fldNodeType.ToString() + ".png",
                                hasChildren = p.sp_TableTreeCarSelect("fldId", "1", 0, 0, 0).Any()

                            });
                return Json(rols, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CountryPosition(int id)
        {
            Models.cartaxEntities car = new Models.cartaxEntities();
            var nodes = car.sp_SelectUpTreeCountryDivisions(id, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList();
            ArrayList ar = new ArrayList();

            foreach (var item in nodes)
            {
                ar.Add(item.fldNodeName);
            }
            string nodeNames = "";
            for (int i = 0; i < ar.Count; i++)
            {
                if (i < ar.Count - 1)
                    nodeNames += ar[i].ToString() + "-->";
                else
                    nodeNames += ar[i].ToString();
            }

            return Json(new { Position = nodeNames });
        }

        public JsonResult CarPosition(int id)
        {
            Models.cartaxEntities car = new Models.cartaxEntities();
            var nodes = car.sp_SelectUpTreeCarSeries(id, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList();
            ArrayList ar = new ArrayList();

            foreach (var item in nodes)
            {
                ar.Add(item.fldNodeName);
            }
            string nodeNames = "";
            for (int i = 0; i < ar.Count; i++)
            {
                if (i < ar.Count - 1)
                    nodeNames += ar[i].ToString() + "-->";
                else
                    nodeNames += ar[i].ToString();
            }

            return Json(new { Position = nodeNames });
        }

        public ActionResult Reload(string field, string value, int top, int searchtype)
        {//جستجو
            string[] _fiald = new string[] { "fldCountryDivisionsName", "fldImplementationDate" };
            string[] searchType = new string[] { "%{0}%", "{0}%", "{0}" };
            string searchtext = string.Format(searchType[searchtype], value);
            Models.cartaxEntities m = new Models.cartaxEntities();
            var q = m.sp_MainSettingSelect(_fiald[Convert.ToInt32(field)], searchtext, top, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).ToList();
            return Json(q, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(string id)
        {//حذف یک رکورد
            try
            {
                if (Permossions.haveAccess(Convert.ToInt32(Session["UserId"]), 179))
                {
                    Models.cartaxEntities Car = new Models.cartaxEntities();
                    if (Convert.ToInt32(id) != 0)
                    {
                        Car.sp_MainSettingDelete(Convert.ToInt32(id), Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString());
                        return Json(new { data = "حذف با موفقیت انجام شد.", state = 0 });
                    }
                    else
                    {
                        return Json(new { data = "رکوردی برای حذف انتخاب نشده است.", state = 1 });
                    }
                }
                else
                {
                    Session["ER"] = "شما مجاز به دسترسی نمی باشید.";
                    return RedirectToAction("error", "Metro");
                }
            }
            catch (Exception x)
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                System.Data.Entity.Core.Objects.ObjectParameter Eid = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", sizeof(int));
                string InnerException = "";
                if (x.InnerException.Message != null)
                    InnerException = x.InnerException.Message;
                Car.sp_ErrorProgramInsert(Eid, InnerException, Convert.ToInt32(Session["UserId"]), x.Message, DateTime.Now, Session["UserPass"].ToString());
                return Json(new { data = "خطایی با شماره: " + Eid.Value + " رخ داده است لطفا با پشتیبانی تماس گرفته و کد خطا را اعلام فرمایید.", state = 1 });
            }
        }

        public JsonResult Details(int id)
        {//نمایش اطلاعات جهت رویت کاربر
            try
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                var MainSetting = Car.sp_MainSettingSelect("fldId", id.ToString(), 1, Convert.ToInt32(Session["UserId"]), Session["UserPass"].ToString()).FirstOrDefault();
                var countryId = Car.sp_TableTreeSelect("fldSourceID", MainSetting.CountryCode.ToString(), 0, 0, 0).Where(h => h.fldNodeType == MainSetting.CountryType).FirstOrDefault();
                var CarId = Car.sp_TableTreeCarSelect("fldSourceID", MainSetting.CarCode.ToString(), 0, 0, 0).Where(h => h.fldNodeType == MainSetting.CarType).FirstOrDefault();
                return Json(new
                {
                    fldId = MainSetting.fldID,
                    fldLateFine = MainSetting.fldLateFine,
                    fldTax = MainSetting.fldTax,
                    fldImplementationDate = MainSetting.fldImplementationDate,
                    fldCountryDivisionsTreeApply = MainSetting.fldCountryDivisionsTreeApply,
                    fldCarSeriesTreeApply = MainSetting.fldCarSeriesTreeApply,
                    fldDesc = MainSetting.fldDesc,
                    CountryType = MainSetting.CountryType,
                    countryCode = MainSetting.CountryCode,
                    carType = MainSetting.CarType,
                    carCode = MainSetting.CarCode,
                    carid = CarId.fldID,
                    countryId = countryId.fldID,
                    firstbime = MainSetting.fldFirstInsurance,
                    finetype = MainSetting.fldFineType
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception x)
            {
                Models.cartaxEntities Car = new Models.cartaxEntities();
                System.Data.Entity.Core.Objects.ObjectParameter Eid = new System.Data.Entity.Core.Objects.ObjectParameter("fldId", sizeof(int));
                string InnerException = "";
                if (x.InnerException.Message != null)
                    InnerException = x.InnerException.Message;
                Car.sp_ErrorProgramInsert(Eid, InnerException, Convert.ToInt32(Session["UserId"]), x.Message, DateTime.Now, Session["UserPass"].ToString());
                return Json(new { data = "خطایی با شماره: " + Eid.Value + " رخ داده است لطفا با پشتیبانی تماس گرفته و کد خطا را اعلام فرمایید.", state = 1 });
            }
        }

    }
}
