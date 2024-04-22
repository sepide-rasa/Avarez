﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterPage.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    رسید پرداخت
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%@ Register Assembly="FastReport.Web" Namespace="FastReport.Web" TagPrefix="cc1" %>
<%{
      Avarez.DataSet.DataSet1 dt = new Avarez.DataSet.DataSet1();
      Avarez.DataSet.DataSet1TableAdapters.sp_PictureSelectTableAdapter sp_pic = new Avarez.DataSet.DataSet1TableAdapters.sp_PictureSelectTableAdapter();      
      Avarez.DataSet.DataSet1TableAdapters.rpt_ReceiptTableAdapter resid = new Avarez.DataSet.DataSet1TableAdapters.rpt_ReceiptTableAdapter();
      Avarez.DataSet.DataSet1TableAdapters.sp_SelectCarDetilsTableAdapter carDitail = new Avarez.DataSet.DataSet1TableAdapters.sp_SelectCarDetilsTableAdapter();
      Avarez.Models.cartaxEntities car = new Avarez.Models.cartaxEntities();
      Avarez.Models.MyTablighat MyTablighat = new Avarez.Models.MyTablighat(Session["UserMnu"].ToString());
      var q = car.rpt_Receipt(Convert.ToInt32(Session["ResidId"]), 1).FirstOrDefault(); ;
      var mnu = car.sp_MunicipalitySelect("fldId", Session["UserMnu"].ToString(), 1, 1, "").FirstOrDefault();
      var State = car.sp_StateSelect("fldId", Session["UserState"].ToString(), 1, 1, "").FirstOrDefault();
      carDitail.Fill(dt.sp_SelectCarDetils, Convert.ToInt32(q.fldCarId));
      sp_pic.Fill(dt.sp_PictureSelect, "fldMunicipalityPic", Session["UserMnu"].ToString(), 1, 1, "");
      resid.Fill(dt.rpt_Receipt, Convert.ToInt32(Session["ResidId"]),1);

      WebReport1.Report.Load(AppDomain.CurrentDomain.BaseDirectory + @"\" + @"\Reports\Rpt_Resid.frx");
      WebReport1.RegisterData(dt, "complicationsCarDBDataSet");
      WebReport1.Report.SetParameterValue("date", MyLib.Shamsi.Miladi2ShamsiString(DateTime.Now));
      var time = DateTime.Now;
      WebReport1.Report.SetParameterValue("time", time.Hour + ":" + time.Minute + ":" + time.Second);
      WebReport1.Report.SetParameterValue("MunicipalityName", mnu.fldName);
      WebReport1.Report.SetParameterValue("StateName", State.fldName);
      WebReport1.Report.SetParameterValue("AreaName", "");
      WebReport1.Report.SetParameterValue("OfficeName", "");
      WebReport1.Report.SetParameterValue("MyTablighat", MyTablighat.Matn);
      WebReport1.Prepare();
      Session.Remove("ResidId");
  } %>
<form id="Form1" runat="server" dir="ltr" >
<cc1:WebReport ID="WebReport1" runat="server" Width="800" Height="100%" style="direction:ltr;" Font-Names="Tornado Tahoma" ToolbarIconsStyle="Green" ToolbarStyle="Large" PrintInPdf="True" AutoWidth="False" AutoHeight="False" />
</form>
</asp:Content>
