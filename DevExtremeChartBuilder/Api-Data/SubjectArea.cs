using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevExtremeChartBuilder.Api_Data
{
    public class SubjectArea
    {
        public string subject_area_id { get; set; }
        public string business_process_area { get; set; }
        public int subject_area_key { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string subject_area_name { get; set; }
        public bool status { get; set; }
    }
}