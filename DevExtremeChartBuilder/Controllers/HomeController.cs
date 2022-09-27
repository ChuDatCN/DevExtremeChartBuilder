using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DevExtremeChartBuilder.Api_Data;

namespace DevExtremeChartBuilder.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        public async Task<ActionResult> SubjectArea()
        {
            SubjectArea[] jwt = await RestSharpAPI.Get_SubjectArea();

            if (jwt == null)
            {
                ViewBag.Message = "Failed";
            }
            else ViewBag.Message = "Success";

            ViewBag.jwt = jwt;

            return View();
        }
        public async Task<ActionResult> Table_so_dv_hc()
        {
            So_don_vi_hanh_chinh[] jwt = await RestSharpAPI.Lay_so_don_vi_hanh_chinh();
            if (jwt == null)
            {
                ViewBag.Message = "Failed";
            }
            else ViewBag.Message = "Success";

            ViewBag.jwt = jwt;

            return View();
        }

        public async Task<ActionResult> Chart_so_dv_hc_2018()
        {
            So_don_vi_hanh_chinh[] jwt = await RestSharpAPI.Lay_so_don_vi_hanh_chinh();
            if (jwt == null)
            {
                ViewBag.Message = "Failed";
            }
            else ViewBag.Message = "Success";

            ViewBag.jwt = jwt;
            var jwt_2018 = from temp in jwt
                           where temp.ky_du_lieu == "2018"
                           select temp;
            ViewBag.jwt_2018 = jwt_2018.ToList();
            return View();
        }

        public async Task<ActionResult> Chart_so_dv_hc_2021()
        {
            So_don_vi_hanh_chinh[] jwt = await RestSharpAPI.Lay_so_don_vi_hanh_chinh();
            if (jwt == null)
            {
                ViewBag.Message = "Failed";
            }
            else ViewBag.Message = "Success";

            ViewBag.jwt = jwt;
            var jwt_2021 = from temp in jwt
                           where temp.ky_du_lieu == "2021"
                           select temp;
            ViewBag.jwt_2021 = jwt_2021.ToList();
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Chart_An_Giang()
        {
                List<SelectListItem> listItems = new List<SelectListItem>();
                listItems.Add(new SelectListItem
                {
                    Text = "Barchart",
                    Value = "Barchart",
                    Selected = true,

                });
                listItems.Add(new SelectListItem
                {
                    Text = "PieChart",
                    Value = "PieChart",
                });
                listItems.Add(new SelectListItem
                {
                    Text = "Line",
                    Value = "Line"
                });
            ViewBag.listItems = listItems;
            So_don_vi_hanh_chinh[] jwt = await RestSharpAPI.Lay_so_don_vi_hanh_chinh();
            if (jwt == null)
            {
                ViewBag.Message = "Failed";
            }
            else ViewBag.Message = "Success";
            ViewBag.jwt = jwt;


            var jwt_AnGiang = from temp in jwt
                              where temp.tieu_chi_phan_loai == "An Giang"
                              select temp;
            ViewBag.jwt_AnGiang = jwt_AnGiang.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Chart_An_Giang(FormCollection form)
        {
            string strDDLValue = form["yourDropName"].ToString();
            ViewBag.strDDLValue = strDDLValue;
            return View();
        }

        public async Task<ActionResult> Chart_Ba_ria_Vung_tau()
        {
            So_don_vi_hanh_chinh[] jwt = await RestSharpAPI.Lay_so_don_vi_hanh_chinh();
            if (jwt == null)
            {
                ViewBag.Message = "Failed";
            }
            else ViewBag.Message = "Success";
            ViewBag.jwt = jwt;


            var jwt_AnGiang = from temp in jwt
                              where temp.tieu_chi_phan_loai == "Bà Rịa - Vũng Tàu"
                              select temp;
            ViewBag.jwt_AnGiang = jwt_AnGiang.ToList();
            return View();
        }
    }

}