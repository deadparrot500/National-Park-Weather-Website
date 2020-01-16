using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL.Interfaces
{
    public interface ISurveyDao
    {
        bool SubmitForm(Survey survey);

        IList<SurveyResult> GetSurveyResults();
    }
}
