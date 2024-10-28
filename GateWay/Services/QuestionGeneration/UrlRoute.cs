using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.ClientAI.Services.QuestionGeneration
{
    public class UrlRoute
    {
        public static string RetakeAssessment = "api/assessment/RetakeAssesment/";
        public static string TakeAssessment = "api/assessment/TakeAssessment/";
        public static string Generate = "api/assessment/GenerateTextQuestions";
        public static string Result = "api/assessment/AssessmentResult";
        public static string AssessmentResult = "api/assessment/Result";
        public static string TextDetails = "api/assessment/GetTextAssessment";

        

    }
}
