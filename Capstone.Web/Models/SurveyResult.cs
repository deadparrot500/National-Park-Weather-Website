using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResult
    {
        public string ParkCode { get; set; }

        public string ParkName { get; set; }

        public int Count { get; set; }

    }
}
