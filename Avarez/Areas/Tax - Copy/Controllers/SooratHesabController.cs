﻿using Avarez.Areas.Tax.Models;
using Avarez.Models;
using Ext.Net;
using Ext.Net.MVC;
using FastMember;
using Microsoft.CSharp.RuntimeBinder;
using MyLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using TaxCollectData.Library.Abstraction.Clients;
using TaxCollectData.Library.Abstraction.Cryptography;
using TaxCollectData.Library.Algorithms;
using TaxCollectData.Library.Dto;
using TaxCollectData.Library.Factories;
using TaxCollectData.Library.Models;
using TaxCollectData.Library.Properties;
using TaxCollectData.Library.Providers;

namespace Avarez.Areas.Tax.Controllers
{
    public class SooratHesabController : Controller
    {
        //
        // GET: /Tax/SooratHesab/

        public ActionResult Index()
        {//باز شدن تب جدید
            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            return new Ext.Net.MVC.PartialViewResult();


        }
        public ActionResult New(int State)
        {
            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });
         
            var result = new Ext.Net.MVC.PartialViewResult();
            return result;
        }
        public ActionResult NewForush1(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
                Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);
           

                cartaxtest2Entities entities2 = new cartaxtest2Entities();
                prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
                long serial = new Random().Next(0x3b9a_ca00);
                string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
                string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;
           
            return result;
        }
        public ActionResult NewForush2(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
            Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);


            cartaxtest2Entities entities2 = new cartaxtest2Entities();
            prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
            long serial = new Random().Next(0x3b9a_ca00);
            string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
            string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;

            return result;
        }
        public ActionResult NewForush3(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
            Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);


            cartaxtest2Entities entities2 = new cartaxtest2Entities();
            prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
            long serial = new Random().Next(0x3b9a_ca00);
            string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
            string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;

            return result;
        }
        public ActionResult NewForush4(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
            Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);


            cartaxtest2Entities entities2 = new cartaxtest2Entities();
            prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
            long serial = new Random().Next(0x3b9a_ca00);
            string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
            string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;

            return result;
        }
        public ActionResult NewForush5(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
            Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);


            cartaxtest2Entities entities2 = new cartaxtest2Entities();
            prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
            long serial = new Random().Next(0x3b9a_ca00);
            string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
            string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;

            return result;
        }
        public ActionResult NewForush6(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
            Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);


            cartaxtest2Entities entities2 = new cartaxtest2Entities();
            prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
            long serial = new Random().Next(0x3b9a_ca00);
            string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
            string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;

            return result;
        }
        public ActionResult NewForush7(int id)
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            sp_GetDate date = new cartaxEntities().sp_GetDate().FirstOrDefault<sp_GetDate>();
            Ext.Net.MVC.PartialViewResult result = new Ext.Net.MVC.PartialViewResult();
            result.ViewBag.TarikhShamsi = date.DateShamsi;
            result.ViewBag.saat = date.Time.ToString().Substring(0, 5);


            cartaxtest2Entities entities2 = new cartaxtest2Entities();
            prs_User_GharardadSelect select = entities2.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
            long serial = new Random().Next(0x3b9a_ca00);
            string str = GenerateTaxId(serial, DateTime.Now, entities2.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>().fldUniqId);
            string str2 = serial.ToString("X").PadLeft(10, '0');

            result.ViewBag.taxId = str;
            result.ViewBag.inno = str2;
            result.ViewBag.id = id;

            return result;
        }
        public ActionResult GetUnits()
        {

            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });
            Models.cartaxtest2Entities p = new Models.cartaxtest2Entities();
            var q = p.prs_tblMeasureUnitSelect("", "", 0).ToList().OrderBy(l => l.fldId).Select(l => new { fldId = l.fldCode, fldName = l.fldName });
            return this.Store(q);

        }
        public ActionResult Save(Areas.Tax.Models.prs_rptSooratHesab_Header Header, List<Areas.Tax.Models.prs_SelectDetailSooratHesab> Forush1Grid_DetailsArray, int fldForushandeId, int fldKharidarId)
        {
            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });
            string Msg = "", MsgTitle = ""; var Er = 0; 
            try
            {


            }
            catch (Exception x)
            {
                if (x.InnerException != null)
                    Msg = x.InnerException.Message;
                else
                    Msg = x.Message;

                MsgTitle = "خطا";
                Er = 1;
            }
            return Json(new
            {
                Msg = Msg,
                MsgTitle = MsgTitle,
                Er = Er
            }, JsonRequestBehavior.AllowGet);
        }
       
            private static ITaxApi CreateTaxApi(string MemoryId, string ApiUrl, string PrivateKeyPath, string CertificatePath)
            {
                TaxProperties taxProperties = new TaxProperties(MemoryId);
                TaxApiFactory factory3 = new TaxApiFactory(ApiUrl, taxProperties);
                ISignatory signatory = new Pkcs8SignatoryFactory().Create(PrivateKeyPath, CertificatePath);
                return factory3.CreateApi(signatory, new EncryptorFactory().Create(factory3.CreatePublicApi(signatory)));
            }

        private static InvoiceDto CreateValidInvoice(string MemoryId, long HeaderId)
        {
            cartaxtest2Entities entities = new cartaxtest2Entities();
            prs_SelectHeaderSooratHesab hesab = entities.prs_SelectHeaderSooratHesab(new long?(HeaderId)).FirstOrDefault<prs_SelectHeaderSooratHesab>();
            List<prs_SelectDetailSooratHesab> list = entities.prs_SelectDetailSooratHesab(new long?(HeaderId)).ToList<prs_SelectDetailSooratHesab>();
            long num = new DateTimeOffset(hesab.fldIndatim).ToUnixTimeMilliseconds();
            long? nullable = null;
            if (hesab.fldIndati2m != null)
            {
                nullable = new long?(new DateTimeOffset(Convert.ToDateTime(hesab.fldIndati2m)).ToUnixTimeMilliseconds());
            }
            List<BodyItemDto> bodylist = new List<BodyItemDto>();
            foreach (var item in list)
            {
                BodyItemDto bd = new BodyItemDto
                {
                    sstid = item.fldsstid,
                    sstt = item.fldsstt,
                    mu = item.fldmu,

                    am = item.fldam,
                    fee = item.fldfee,
                    vra = item.fldvra,
                    prdis = item.fldprdis,
                    dis = item.flddis,
                    adis = item.fldadis,
                    vam = item.fldvam,
                    tsstam = item.fldtsstam,
                    bros = item.fldbros,
                    consfee = item.fldconsfee,
                    cop = item.fldcop,
                    odam = item.fldodam,
                    exr = item.fldexr,
                    ssrv = item.fldssrv,
                    tcpbs = item.fldtcpbs,
                    vop = item.fldvop,
                    spro = item.fldspro,
                    olam = item.fldolam,
                    bsrn = item.fldbsrn,
                    cfee = item.fldcfee,
                    cui = item.fldcui,
                    cut = item.fldcut,
                    nw = item.fldnw,
                    odr = item.fldodr,
                    odt = item.fldodt,
                    olr = item.fldolr,
                    olt = item.fldolt,
                    pspd = item.fldpspd,
                    sscv = item.fldsscv
                };
                bodylist.Add(bd);
            }


            long? indati2m = null;
            if (hesab.fldIndati2m != null)
                indati2m = new DateTimeOffset(Convert.ToDateTime(hesab.fldIndati2m)).ToUnixTimeMilliseconds();

            InvoiceDto invoice = new InvoiceDto()
            {
                Header = new HeaderDto()
                {
                    taxid = hesab.fldTaxId,
                    inno = hesab.fldInno,
                    indatim = new DateTimeOffset(hesab.fldIndatim).ToUnixTimeMilliseconds(),
                    indati2m = indati2m,
                    inty = Convert.ToInt32(hesab.fldInty),

                    inp = hesab.fldinp,
                    ins = hesab.fldins,
                    tins = hesab.fldBid,
                    tinb = hesab.fldkh_Bid,
                    tob = Convert.ToInt32(hesab.fldTob),
                    tprdis = (hesab.fldtprdis),
                    tdis = (hesab.fldtdis),
                    tadis = (hesab.fldtadis),
                    tvam = (hesab.fldtvam),
                    todam = (hesab.fldtodam),
                    tbill = (hesab.fldtbill),
                    setm = hesab.fldsetm,
                    irtaxid = hesab.fldIrtaxId,
                    bid = hesab.fldBid,
                    sbc = hesab.fldSbc,
                    bpc = hesab.fldBpc,
                    bbc = hesab.fldbbc,
                    ft = hesab.fldft,
                    bpn = hesab.fldbpn,
                    scln = hesab.fldscln,
                    scc = hesab.fldscc,
                    cdcn = hesab.fldcdcn,
                    cdcd = Convert.ToInt32(hesab.fldcdcd),
                    crn = hesab.fldcrn,
                    billid = hesab.fldbilid,
                    tonw = (hesab.fldtonw),
                    tocv = (hesab.fldtocv),
                    torv = (hesab.fldtorv),
                    insp = (hesab.fldinsp),
                    cap = (hesab.fldcap),
                    tvop = (hesab.fldtvop),
                    tax17 = (hesab.fldtax17),
                },
                Body = bodylist
            };
            return invoice;
        }

            public ActionResult Delete(int id)
            {
                ActionResult result;
                if (base.Session["TaxUserId"] == null)
                {
                    result = base.RedirectToAction("Login", "AccountTax", new { area = "Tax" });
                }
                else
                {
                    cartaxtest2Entities entities = new cartaxtest2Entities();
                    string str = "";
                    string str2 = "";
                    int num = 0;
                    try
                    {
                        str2 = "حذف موفق";
                        str = "حذف با موفقیت انجام شد.";
                        entities.prs_tblSooratHesab_HeaderDelete(new long?((long)id), new long?(Convert.ToInt64(base.Session["TaxUserId"])));
                    }
                    catch (Exception exception)
                    {
                        str = (exception.InnerException == null) ? exception.Message : exception.InnerException.Message;
                        str2 = "خطا";
                        num = 1;
                    }
                    result = base.Json(new
                    {
                        Msg = str,
                        MsgTitle = str2,
                        Er = num
                    }, JsonRequestBehavior.AllowGet);
                }
                return result;
            }

            public ActionResult Details(int Id)
            {
                prs_SelectHeaderSooratHesab hesab = new cartaxtest2Entities().prs_SelectHeaderSooratHesab(new int?(Id)).FirstOrDefault<prs_SelectHeaderSooratHesab>();
                return base.Json(new
                {
                    fldId = Id,
                    fldbbc = hesab.fldbbc,
                    fldBid = hesab.fldBid,
                    fldbilid = hesab.fldbilid,
                    fldBpc = hesab.fldBpc,
                    fldbpn = hesab.fldbpn,
                    fldcap = hesab.fldcap,
                    fldcdcd = hesab.fldcdcd,
                    fldcdcn = hesab.fldcdcn,
                    fldcrn = hesab.fldcrn,
                    fldft = hesab.fldft,
                    fldf_CodePosti = hesab.fldf_CodePosti,
                    fldf_name = hesab.fldf_name,
                    fldIndati2m = hesab.fldIndati2m,
                    fldIndati2m_Zaman = hesab.fldIndati2m_Zaman,
                    fldIndatim = hesab.fldIndatim,
                    fldIndatim_Zaman = hesab.fldIndatim_Zaman,
                    fldInno = hesab.fldInno,
                    fldinp = hesab.fldinp,
                    fldins = hesab.fldins.ToString(),
                    fldinsp = hesab.fldinsp,
                    fldInty = hesab.fldInty,
                    fldIrtaxId = hesab.fldIrtaxId,
                    fldkh_Bid = hesab.fldkh_Bid,
                    fldkh_Name = hesab.fldkh_Name,
                    fldKh_Tob = hesab.fldKh_Tob,
                    fldNamePettern = hesab.fldNamePettern,
                    fldSbc = hesab.fldSbc,
                    fldscc = hesab.fldscc,
                    fldscln = hesab.fldscln,
                    fldsetm = hesab.fldsetm,
                    fldSh_Indati2m = hesab.fldSh_Indati2m,
                    fldSh_Indatim = hesab.fldSh_Indatim,
                    fldtadis = hesab.fldtadis,
                    fldtax17 = hesab.fldtax17,
                    fldTaxId = hesab.fldTaxId,
                    fldtbill = hesab.fldtbill,
                    fldtdis = hesab.fldtdis,
                    fldTinb = hesab.fldTinb,
                    fldTins = hesab.fldTins,
                    fldTob = hesab.fldTob,
                    fldtyeShkashFoorosh = hesab.fldtyeShkashFoorosh,
                    fldTypeShakhKharid = hesab.fldTypeShakhKharid,
                    fldTypeSooratHesab = hesab.fldTypeSooratHesab
                }, JsonRequestBehavior.AllowGet);
            }

        private static string GenerateTaxId(long serial, DateTime now, string MemoryId)
        {
            TaxIdProvider taxIdProvider = new TaxIdProvider(new VerhoeffAlgorithm());
            return taxIdProvider.GenerateTaxId(MemoryId, serial, now);
        }
        public ActionResult GetCurrencyType()
            {
            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });
            Models.cartaxtest2Entities p = new Models.cartaxtest2Entities();
            var q = p.prs_tblCurrencyTypeSelect("", "", 0).ToList().OrderBy(l => l.fldId).Select(l => new { fldId = l.fldNumericCode, fldName = l.fldCurrency });
            return this.Store(q);

            }

          
            


            private static string PrintInquiryResult(List<InquiryResultModel> inquiryResults, long HeaderId, long UserId,string SerializeObjectErsal)
            {
                cartaxtest2Entities entities = new cartaxtest2Entities();
                string fldMatn = "";
                byte num = 1;
            foreach (var result in inquiryResults)
            {
                    fldMatn = "Status = " + result.Status;
                    var errors = result.Data.Error;
                    if (errors != null)
                    {
                        fldMatn = fldMatn + "*** Errors:";
                    }
                foreach (var error in errors)
                {
                        num = 3;
                        string code = error.Code;
                        string message = error.Message;
                        string[] textArray1 = new string[] { fldMatn, "*** Code: ", code, ", Message: ", message };
                        fldMatn = string.Concat(textArray1);
                    }
                    List<InvoiceErrorModel> list2 = result.Data.Warning;
                    if (list2 != null)
                    {
                        fldMatn = fldMatn + "***  Warnings:";
                    }
                    foreach (InvoiceErrorModel model3 in list2)
                    {
                        num = 2;
                        string code = model3.Code;
                        string message = model3.Message;
                        string[] textArray2 = new string[] { fldMatn, "***  Code: ", code, ", Message: ", message };
                        fldMatn = string.Concat(textArray2);
                    }
                    entities.prs_tblSooratHesabStatusInsert(new long?((long)HeaderId), new byte?(num), fldMatn, result.ReferenceNumber, SerializeObjectErsal, result.Uid, new long?(UserId));
                }
                return (num.ToString() + ";" + fldMatn);
            }
        public ActionResult Read(StoreRequestParameters parameters)
        {
            if (Session["TaxUserId"] == null)
                return RedirectToAction("Login", "AccountTax", new { area = "Tax" });

            Models.cartaxtest2Entities p = new Models.cartaxtest2Entities();
            var filterHeaders = new FilterHeaderConditions(this.Request.Params["filterheader"]);

            List<Models.prs_tblSooratHesab_HeaderSelect> data = null;
            if (filterHeaders.Conditions.Count > 0)
            {
                string field = "";
                string searchtext = "";
                List<Models.prs_tblSooratHesab_HeaderSelect> data1 = null;
                foreach (var item in filterHeaders.Conditions)
                {
                    var ConditionValue = (Newtonsoft.Json.Linq.JValue)item.ValueProperty.Value;

                    switch (item.FilterProperty.Name)
                    {        
                        case "fldId":
                            searchtext = ConditionValue.Value.ToString();
                            field = "fldId";
                            break;
                        case "fldf_NationalCode":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldf_NationalCode";
                            break;
                        case "fldTypeSooratHesab":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldTypeSooratHesab";
                            break;
                        case "fldSubject":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldSubject";
                            break;
                        case "fldkh_name":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldkh_name";
                            break;
                        case "fldIndatim":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldIndatim";
                            break;
                        case "fldf_Name":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldf_Name";
                            break;
                        case "fldkh_fldNationalCode":
                            searchtext = "%" + ConditionValue.Value.ToString() + "%";
                            field = "fldkh_fldNationalCode";
                            break;
                    }
                    if (data != null)
                        data1 = p.prs_tblSooratHesab_HeaderSelect(field, searchtext,"","", 100).ToList();
                    else
                        data = p.prs_tblSooratHesab_HeaderSelect(field, searchtext,"", "", 100).ToList();
                }
                if (data != null && data1 != null)
                    data.Intersect(data1);
            }
            else
            {
                data = p.prs_tblSooratHesab_HeaderSelect("", "","", "", 100).ToList();
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

            List<Models.prs_tblSooratHesab_HeaderSelect> rangeData = (parameters.Start < 0 || limit < 0) ? data : data.GetRange(parameters.Start, limit);
            //-- end paging ------------------------------------------------------------

            return this.Store(rangeData, data.Count);
        }

       
            public ActionResult ReadDetails(Ext.Net.StoreRequestParameters parameters, int HeaderId)
            {
                List<prs_SelectDetailSooratHesab> data = null;
                data = new cartaxtest2Entities().prs_SelectDetailSooratHesab(new int?(HeaderId)).ToList<prs_SelectDetailSooratHesab>();
                return this.Store(data);
            }

            public ActionResult SamaneMoadian(long HeaderId)
            {
                string path = "";
                string str2 = "";
                try
                {
                    cartaxtest2Entities entities = new cartaxtest2Entities();
                    prs_User_GharardadSelect select = entities.prs_User_GharardadSelect("fldID", base.Session["TaxUserId"].ToString(), 0, "", 1, "").FirstOrDefault<prs_User_GharardadSelect>();
                    prs_tblTarfGharardadSelect select2 = entities.prs_tblTarfGharardadSelect("fldId", select.fldTarfGharardadId.ToString(), 0).FirstOrDefault<prs_tblTarfGharardadSelect>();
                    path = base.Server.MapPath(@"~\Uploaded\privateKey" + select2.fldId.ToString() + ".pem");
                    str2 = base.Server.MapPath(@"~\Uploaded\certificate" + select2.fldId.ToString() + ".crt");
                    if (!System.IO.File.Exists(path))
                    {
                    System.IO.File.WriteAllBytes(path, select2.fldPrivateKey.ToArray<byte>());
                    }
                    if (!System.IO.File.Exists(str2))
                    {
                    System.IO.File.WriteAllBytes(str2, select2.fldSignatureCertificate.ToArray<byte>());
                    }
                    string fldUniqId = select2.fldUniqId;
                    string str5 = "ارسال با موفقیت انجام شد";
                    ITaxApi taxApi = CreateTaxApi(fldUniqId, "https://tp.tax.gov.ir/requestsmanager", path, str2);
                    InvoiceDto item = CreateValidInvoice(fldUniqId, HeaderId);
                    List<InvoiceDto> list1 = new List<InvoiceDto>();
                    list1.Add(item);
                    List<InvoiceDto> invoiceList = list1;

                List<InvoiceResponseModel> responseModels = taxApi.SendInvoices(invoiceList);
                Thread.Sleep(10_000);
                InquiryByReferenceNumberDto inquiryDto = new InquiryByReferenceNumberDto(responseModels.Select(r => r.ReferenceNumber).ToList());
                List<InquiryResultModel> inquiryResults = taxApi.InquiryByReferenceId(inquiryDto);

                string SerializeObjectErsal = Newtonsoft.Json.JsonConvert.SerializeObject(invoiceList);
                string mmsgg=PrintInquiryResult(inquiryResults, HeaderId,Convert.ToInt64(Session["TaxUserId"]), SerializeObjectErsal);
                var msgtitle = "ارسال موفق";
                var msg = "ارسال با موفقیت انجام شد.";

                if (mmsgg.Split(';')[0] != "1")
                    msg = mmsgg.Split(';')[1];

                if (mmsgg.Split(';')[0]=="2")
                    msgtitle = "هشدار";
                if (mmsgg.Split(';')[0] == "3")
                    msgtitle = "خطا";
               


                System.IO.File.Delete(path);
                System.IO.File.Delete(str2);

                return base.Json(new
                {
                    Msg = msg,
                    MsgTitle = msgtitle,
                    Er = mmsgg.Split(';')[0]
                }, JsonRequestBehavior.AllowGet);
            }
                catch (Exception exception)
                {
                    string str7 = "";
                    str7 = (exception.InnerException == null) ? exception.Message : exception.InnerException.Message;
                    return base.Json(new
                    {
                        Msg = "خطا",
                        MsgTitle = str7,
                        Er = 1
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            public ActionResult Savee(int HeaderId, prs_SelectHeaderSooratHesab Header,List<prs_SelectDetailSooratHesab> Grid_DetailsArray,  int fldForushandeId, int fldKharidarId)
            {
                string str="ذخیره با موفقیت انجام شد.";
                string str2 = "عملیات موفق";
                int num=0;
                if (base.Session["TaxUserId"] != null)
                {
                    str = "";
                    str2 = "";
                    num = 0;
                    try
                    {
                    if (HeaderId == 0)
                    {
                        ParamValue value2;
                        decimal? fldtonw;
                        int? nullable18;
                        int? nullable36;
                        int? nullable37;
                        int? nullable38;
                        cartaxtest2Entities entities = new cartaxtest2Entities();
                        DateTime Indatim = Shamsi.Shamsi2miladiDateTime(Header.fldSh_Indatim);
                        char[] separator = new char[] { ':' };
                        char[] chArray2 = new char[] { ':' };
                        TimeSpan Indatimspan = new TimeSpan(Convert.ToInt32(Header.fldIndatim_Zaman.Split(separator)[0]), Convert.ToInt32(Header.fldIndatim_Zaman.Split(chArray2)[1]), 0);
                        Indatim = Indatim.Date + Indatimspan;
                        DateTime? Indati2m = null;
                        if (Header.fldSh_Indati2m != null)
                        {
                            Indati2m = new DateTime?(Shamsi.Shamsi2miladiDateTime(Header.fldSh_Indati2m));
                            char[] chArray3 = new char[] { ':' };
                            char[] chArray4 = new char[] { ':' };
                            TimeSpan Indati2mspan2 = new TimeSpan(Convert.ToInt32(Header.fldIndati2m_Zaman.Split(chArray3)[0]), Convert.ToInt32(Header.fldIndati2m_Zaman.Split(chArray4)[1]), 0);
                            Indati2m = new DateTime?(Convert.ToDateTime(Indati2m).Date + Indati2mspan2);
                        }
                        long? tprdis = 0;
                        long? tdis = 0;
                        long? tadis = 0;
                        long? tvam = 0;
                        long? todam = 0;
                        long? tbill = 0;
                        decimal? tonw = 0;
                        long? torv = 0;
                        decimal? tocv = 0;
                        long? tvop = 0;
                        foreach (var hesab in Grid_DetailsArray)
                        {
                            if (hesab.fldprdis != null)
                            {
                                tprdis = tprdis+hesab.fldprdis;
                            }
                            if (hesab.flddis != null)
                            {
                                tdis = tdis + hesab.flddis;
                            }
                            if (hesab.fldadis != null)
                            {
                                tadis = tadis + hesab.fldadis;
                            }
                            if (hesab.fldvam != null)
                            {
                                tvam = tvam + hesab.fldvam;
                            }
                            if (hesab.fldodam != null)
                            {
                                todam = todam + hesab.fldodam;
                            }
                            if (hesab.fldtsstam != null)
                            {
                                tbill = tbill + hesab.fldtsstam;
                            }
                            if (hesab.fldnw != null)
                            {
                                tonw = tonw + hesab.fldnw;
                            }
                            if (hesab.fldssrv != null)
                            {
                                torv = torv + hesab.fldssrv;
                            }
                            if (hesab.fldsscv != null)
                            {
                                tocv = tocv + hesab.fldsscv;
                            }
                            if (hesab.fldvop != null)
                            {
                                tvop = tvop + hesab.fldvop;
                            }
                        }
                        decimal num3 = 0M;
                        List<ParamValue> source = new List<ParamValue>();
                        Header.fldtvop = tvop;
                        Header.fldtocv = tocv;
                        Header.fldtorv = torv;
                        Header.fldtonw = tonw;
                        Header.fldtbill = tbill;
                        Header.fldtodam = todam;
                        Header.fldtvam = tvam;
                        Header.fldtadis = tadis;
                        Header.fldtdis = tdis;
                        Header.fldtprdis = tprdis;

                        byte? fldins = 0;
                        if ((Header.fldins != null))
                            fldins = Header.fldins;

                        value2 = new ParamValue
                        {
                            fldParamertId = 1,
                            fldValue = fldins.ToString()
                        };
                        source.Add(value2);

                        byte? fldft = 0;
                        if (Header.fldft != null)
                        {
                            fldft = Header.fldft;
                            value2 = new ParamValue
                            {
                                fldParamertId = 9,
                                fldValue = Header.fldft.ToString()
                            };
                            source.Add(value2);
                        }
                        if ((Header.fldbpn != "") && (Header.fldbpn != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 10,
                                fldValue = Header.fldbpn
                            };
                            source.Add(value2);
                        }
                        if ((Header.fldscln != "") && (Header.fldscln != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 11,
                                fldValue = Header.fldscln
                            };
                            source.Add(value2);
                        }
                        if ((Header.fldscc != "") && (Header.fldscc != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 12,
                                fldValue = Header.fldscc
                            };
                            source.Add(value2);
                        }
                        if ((Header.fldcdcn != "") && (Header.fldcdcn != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 13,
                                fldValue = Header.fldcdcn
                            };
                            source.Add(value2);
                        }
                     
                        if (Header.fldcdcd != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 14,
                                fldValue = Header.fldcdcd.ToString()
                            };
                            source.Add(value2);
                        }
                        if ((Header.fldcrn != "") && (Header.fldcrn != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 15,
                                fldValue = Header.fldcrn
                            };
                            source.Add(value2);
                        }
                        if ((Header.fldbilid != "") && (Header.fldbilid != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x10,
                                fldValue = Header.fldbilid
                            };
                            source.Add(value2);
                        }
                        long? fldtprdis = 0;
                        if ((Header.fldtprdis != null))
                            fldtprdis = Header.fldtprdis;

                        value2 = new ParamValue
                        {
                            fldParamertId = 0x11,
                            fldValue = fldtprdis.ToString()
                        };
                        source.Add(value2);

                        long? fldtdis = 0;
                        if ((Header.fldtdis != null))
                            fldtdis = Header.fldtdis;

                        value2 = new ParamValue
                        {
                            fldParamertId = 0x12,
                            fldValue = fldtdis.ToString()
                        };

                        long? fldtadis = 0;
                        if ((Header.fldtadis != null))
                            fldtadis = Header.fldtadis;

                        value2 = new ParamValue
                        {
                            fldParamertId = 0x13,
                            fldValue = fldtadis.ToString()
                        };
                        source.Add(value2);

                        long? fldtvam = 0;
                        if ((Header.fldtvam != null))
                            fldtvam = Header.fldtvam;

                        value2 = new ParamValue
                        {
                            fldParamertId = 20,
                            fldValue = fldtvam.ToString()
                        };
                        source.Add(value2);

                        long? fldtodam = 0;
                        if ((Header.fldtodam != null))
                            fldtodam = Header.fldtodam;
                        value2 = new ParamValue
                        {
                            fldParamertId = 0x15,
                            fldValue = fldtodam.ToString()
                        };
                        source.Add(value2);

                        long? fldtbill = fldtvam + fldtodam + fldtadis;
                        if ((fldtbill != null))
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x16, //tbill
                                fldValue = fldtbill.ToString()
                            };
                            source.Add(value2);
                        }

                        if (Header.fldtonw != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x17,
                                fldValue = Header.fldtonw.ToString()
                            };
                            source.Add(value2);
                        }
                       
                        if (Header.fldtorv != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x18,
                                fldValue = Header.fldtorv.ToString()
                            };
                            source.Add(value2);
                        }

                        if (Header.fldtocv != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x19,
                                fldValue = Header.fldtocv.ToString()
                            };
                            source.Add(value2);
                        }

                        byte? fldsetm = 0;
                        if ((Header.fldsetm != null))
                            fldsetm = Header.fldsetm;

                        value2 = new ParamValue
                        {
                            fldParamertId = 0x1a,
                            fldValue = fldsetm.ToString()
                        };

                        if (Header.fldcap != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x1b,
                                fldValue = Header.fldcap.ToString()
                            };
                            source.Add(value2);
                        }
             
                        if (Header.fldinsp != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x1c,
                                fldValue = Header.fldinsp.ToString()
                            };
                            source.Add(value2);
                        }
                        if (Header.fldtvop != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 0x1d,
                                fldValue = Header.fldtvop.ToString()
                            };
                            source.Add(value2);
                        }
                       
                        if (Header.fldtax17 != null)
                        {
                            value2 = new ParamValue
                            {
                                fldParamertId = 30,
                                fldValue = Header.fldtax17.ToString()
                            };
                            source.Add(value2);
                        }
                        DataTable table1 = new DataTable();
                        table1.TableName = "movadi.tblSooratHesabHeader_Value";
                        DataTable table = table1;
                        using (ObjectReader reader = ObjectReader.Create<ParamValue>(source.ToList<ParamValue>(), Array.Empty<string>()))
                        {
                            table.Load(reader);
                        }
                        long num2 = entities.prs_tblSooratHesab_HeaderInsert(new ObjectParameter("fldid", typeof(long)), Header.fldTaxId, new DateTime?(Indatim), Indati2m, new byte?(Header.fldInty), Header.fldinp, Header.fldInno, Header.fldIrtaxId, new long?((long)fldKharidarId), new long?((long)fldForushandeId),
                            Header.fldFunctionName, Header.fldbpn, Header.fldft, Header.fldscln, Header.fldscc, Header.fldcrn, table, new long?((long)Convert.ToInt32(base.Session["TaxUserId"])));
                        foreach (prs_SelectDetailSooratHesab hesab2 in Grid_DetailsArray)
                        {
                            ParamValue value3;
                            List<ParamValue> list2 = new List<ParamValue>();
                            if ((hesab2.fldsstid != "") && (hesab2.fldsstid != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x1f,
                                    fldValue = hesab2.fldsstid
                                };
                                list2.Add(value3);
                            }
                            if ((hesab2.fldsstt != "") && (hesab2.fldsstt != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x20,
                                    fldValue = hesab2.fldsstt
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldam != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x21,
                                    fldValue = hesab2.fldam.ToString()
                                };
                                list2.Add(value3);
                            }
                            if ((hesab2.fldmu != "") && (hesab2.fldmu != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x22,
                                    fldValue = hesab2.fldmu
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldnw != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x23,
                                    fldValue = hesab2.fldnw.ToString()
                                };
                                list2.Add(value3);
                            }
                       
                            if (hesab2.fldfee != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x24,
                                    fldValue = hesab2.fldfee.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldcfee != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x25,
                                    fldValue = hesab2.fldcfee.ToString()
                                };
                                list2.Add(value3);
                            }
                            if ((hesab2.fldcut != "") && (hesab2.fldcut != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x26,
                                    fldValue = hesab2.fldcut
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldexr != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x27,
                                    fldValue = hesab2.fldexr.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldssrv != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 40,
                                    fldValue = hesab2.fldssrv.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldsscv != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x29,
                                    fldValue = hesab2.fldsscv.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldprdis != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x2a,
                                    fldValue = hesab2.fldprdis.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.flddis != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x2b,
                                    fldValue = hesab2.flddis.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldadis != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x2c,
                                    fldValue = hesab2.fldadis.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldvra != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x2d,
                                    fldValue = hesab2.fldvra.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldvam != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x2e,
                                    fldValue = hesab2.fldvam.ToString()
                                };
                                list2.Add(value3);
                            }
                            if ((hesab2.fldodt != "") && (hesab2.fldodt != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x2f,
                                    fldValue = hesab2.fldodt
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldodr != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x30,
                                    fldValue = hesab2.fldodr.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldodam != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x31,
                                    fldValue = hesab2.fldodam.ToString()
                                };
                                list2.Add(value3);
                            }
                            if ((hesab2.fldolt != "") && (hesab2.fldolt != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 50,
                                    fldValue = hesab2.fldolt
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldolr != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x33,
                                    fldValue = hesab2.fldolr.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldolam != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x34,
                                    fldValue = hesab2.fldolam.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldconsfee != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x35,
                                    fldValue = hesab2.fldconsfee.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldspro != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x36,
                                    fldValue = hesab2.fldspro.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldbros != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x37,
                                    fldValue = hesab2.fldbros.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldtcpbs != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x38,
                                    fldValue = hesab2.fldtcpbs.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldcop != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x39,
                                    fldValue = hesab2.fldcop.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldvop != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x3a,
                                    fldValue = hesab2.fldvop.ToString()
                                };
                                list2.Add(value3);
                            }
                            if ((hesab2.fldbsrn != "") && (hesab2.fldbsrn != null))
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x3b,
                                    fldValue = hesab2.fldbsrn
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldtsstam != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 60,
                                    fldValue = hesab2.fldtsstam.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldpspd != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x3d,
                                    fldValue = hesab2.fldpspd.ToString()
                                };
                                list2.Add(value3);
                            }
                            if (hesab2.fldcui != null)
                            {
                                value3 = new ParamValue
                                {
                                    fldParamertId = 0x3e,
                                    fldValue = hesab2.fldcui.ToString()
                                };
                                list2.Add(value3);
                            }
                            DataTable table3 = new DataTable();
                            table3.TableName = "movadi.tblSooratHesab_Detail";
                            DataTable table2 = table3;
                            using (ObjectReader reader2 = ObjectReader.Create<ParamValue>(list2, Array.Empty<string>()))
                            {
                                table2.Load(reader2);
                            }
                            entities.prs_tblSooratHesab_DetailInsert(new long?(num2), table2, new long?((long)Convert.ToInt32(base.Session["TaxUserId"])));
                        }
                    }
                    else
                    {
                        //edit
                    }
                    }
                    catch (Exception exception)
                    {
                        str = (exception.InnerException == null) ? exception.Message : exception.InnerException.Message;
                        str2 = "خطا";
                        num = 1;
                    }
                }
                else
                {
                    return base.RedirectToAction("Login", "AccountTax", new { area = "Tax" });
                }
                return base.Json(new
                {
                    Msg = str,
                    MsgTitle = str2,
                    Er = num
                }, JsonRequestBehavior.AllowGet);
            }

      
    }
}
