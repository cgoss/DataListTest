using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Datalist;

namespace DataListTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult RetailerLookup(DatalistFilter filter)
        {
            RetailerDataList retailerDataList = new RetailerDataList() {Filter = filter};
            IList<RetailerLookupViewModel> allRetailers = new List<RetailerLookupViewModel>();
            
            for (int n = 0; n < 10; n++)
            {
                allRetailers.Add(new RetailerLookupViewModel()
                {
                    Name = "Steve" + n.ToString(),
                    Sid = n.ToString()
                });
            }
            foreach (RetailerLookupViewModel retailerLookupViewModel in allRetailers)
            {
                retailerDataList.AddData(new Dictionary<String, String>(), retailerLookupViewModel);
            }

           
            
            return Json(retailerDataList.GetData(),
         JsonRequestBehavior.AllowGet);
        }

    }
    public class RetailerDataList : MvcDatalist<RetailerLookupViewModel>
    {

        public RetailerDataList()
        {

            Url = "RetailerLookup";
            Title = "Retailers";

            Filter.Rows = 15;
            Filter.SortColumn = "Name";
            Filter.SortOrder = DatalistSortOrder.Asc;
            

        }
        public override void AddData(Dictionary<String, String> row, RetailerLookupViewModel model)
        {
            base.AddData(row, model);
        }

        public override DatalistData GetData()
        {
            DatalistData datalistData = base.GetData();
            return datalistData;
            
        }

        public override IQueryable<RetailerLookupViewModel> GetModels()
        {
         
            IList<RetailerLookupViewModel> allRetailers = new List<RetailerLookupViewModel>();

            for (int n = 0; n < 10; n++)
            {
                allRetailers.Add(new RetailerLookupViewModel()
                {
                    Name = "Steve" + n.ToString(),
                    Sid = n.ToString()
                });
            }
   

            return allRetailers.AsQueryable();
        }
    }
    public class RetailerLookupViewModel
    {
        [DatalistColumn(Hidden = true)]
        public string Sid { get; set; }

        [DatalistColumn]
        [Display(Name = "Name")]
        public String Name { get; set; }

        //        [DatalistColumn]
        //        [Display(Name = "Surname")]
        //        public String Surname { get; set; }
        //
        //        [DatalistColumn]
        //        [Display(Name = "Age")]
        //        public Int32 Age { get; set; }
        //
        //        [DatalistColumn(Format = "{0:d}")]
        //        [Display(Name = "Birthday", ShortName = "Birth")]
        //        public DateTime Birthday { get; set; }
        //
        //        public Boolean? IsWorking { get; set; }
    }

}