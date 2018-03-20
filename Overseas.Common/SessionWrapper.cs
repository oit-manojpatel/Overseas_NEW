using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using Overseas.Manager.DB;


namespace Overseas.Common
{
    public class SessionWrapper
    {
        private HttpSessionState Session { get { return HttpContext.Current.Session; } }

        protected T GetFromSession<T>(string key)
        {
            if (Session[key] != null)
                return (T)Session[key];
            return default(T);
        }

        protected void SetInSession(string key, object value)
        {
            Session[key] = value;
        }

        public void Abandon()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
        }
        public Boolean CreateNewSession()
        {
            SessionIDManager Manager = new SessionIDManager();
            string NewID = Manager.CreateSessionID(HttpContext.Current);
            bool redirected = false;
            bool IsAdded = false;
            Manager.SaveSessionID(HttpContext.Current, NewID, out redirected, out IsAdded);
            return IsAdded;
        }
        #region Properties
        public int UserID
        {
            get
            {
                return GetFromSession<int>("UserID");
            }
            set
            {
                SetInSession("UserID", value);
            }
        }

        public RoleMaster UserType
        {
            get
            {
                return GetFromSession<RoleMaster>("UserType");
            }
            set
            {
                SetInSession("UserType", value);
            }
        }

        public string UserName
        {
            get
            {
                return GetFromSession<string>("UserName");
            }
            set
            {
                SetInSession("UserName", value);
            }
        }

        public bool isUserLoggedIn
        {
            get { return !(UserID == default(int)); }
        }

        public int RoleID
        {
            get
            {
                return GetFromSession<int>("RoleID");
            }
            set
            {
                SetInSession("RoleID", value);
            }
        }

        public int CompanyID
        {
            get
            {
                return GetFromSession<int>("CompanyID");
            }
            set
            {
                SetInSession("CompanyID", value);
            }
        }

        public string CompanyName
        {
            get
            {
                return GetFromSession<string>("CompanyName") ?? "Credit Repair";
            }
            set
            {
                SetInSession("CompanyName", value);
            }
        }



        public int? IsEmployee
        {
            get
            {
                return GetFromSession<int>("IsEmployee");
            }
            set
            {
                SetInSession("IsEmployee", value);
            }
        }


        public string SessionId
        {
            get
            {
                return Session.SessionID;
            }
        }
        public int TrackingCount
        {
            get
            {
                return GetFromSession<int>("TrackingCount");
            }
            set
            {
                SetInSession("TrackingCount", value);
            }
        }

        public int MessageCount
        {
            get
            {
                return GetFromSession<int>("MessageCount");
            }
            set
            {
                SetInSession("MessageCount", value);
            }
        }


        public int ReferralCount
        {
            get
            {
                return GetFromSession<int>("ReferralCount");
            }
            set
            {
                SetInSession("ReferralCount", value);
            }
        }
        public int ReferraltotalCount
        {
            get
            {
                return GetFromSession<int>("ReferraltotalCount");
            }
            set
            {
                SetInSession("ReferraltotalCount", value);
            }
        }

        public int AffiliateCount
        {
            get
            {
                return GetFromSession<int>("AffiliateCount");
            }
            set
            {
                SetInSession("AffiliateCount", value);
            }
        }

        public int DocumentCount
        {
            get
            {
                return GetFromSession<int>("DocumentCount");
            }
            set
            {
                SetInSession("DocumentCount", value);
            }
        }
        public int AgreementLeadCount
        {
            get

            {
                return GetFromSession<int>("AgreementLeadCount");
            }
            set
            {
                SetInSession("AgreementLeadCount", value);
            }
        }

        public int AgreementCount
        {
            get
            {
                return GetFromSession<int>("AgreementCount");
            }
            set
            {
                SetInSession("AgreementCount", value);
            }
        }

        public int BillingPaymentDueCount
        {
            get
            {
                return GetFromSession<int>("BillingPaymentDueCount");

            }
            set
            {
                SetInSession("BillingPaymentDueCount", value);
            }
        }

        public string PlanSizegraph
        {
            get
            {
                return GetFromSession<string>("PlanSizegraph");
            }
            set
            {
                SetInSession("PlanSizegraph", value);
            }
        }

        public string WhatsNewContent
        {
            get
            {
                return GetFromSession<string>("WhatsNewContent");
            }
            set
            {
                SetInSession("WhatsNewContent", value);
            }
        }


        public string WhatsNewHeading
        {
            get
            {
                return GetFromSession<string>("WhatsNewHeading");
            }
            set
            {
                SetInSession("WhatsNewHeading", value);
            }
        }

        public bool IsshowWhatsNew
        {
            get
            {
                return GetFromSession<bool>("IsshowWhatsNew");
            }
            set
            {
                SetInSession("IsshowWhatsNew", value);
            }
        }




        public int PlanSizeGb
        {
            get
            {
                return GetFromSession<int>("PlanSizeGb");
            }
            set
            {
                SetInSession("PlanSizeGb", value);
            }
        }

        public decimal PlanSizeGbUsed
        {
            get
            {
                return GetFromSession<decimal>("PlanSizeGbUsed");
            }
            set
            {
                SetInSession("PlanSizeGbUsed", value);
            }
        }

        public decimal PlanSizebytsUsed
        {
            get
            {
                return GetFromSession<decimal>("PlanSizeGbUsed");
            }
            set
            {
                SetInSession("PlanSizeGbUsed", value);
            }
        }
        public string PlanName
        {
            get
            {
                return GetFromSession<string>("PlanName");

            }
            set
            {
                SetInSession("PlanName", value);
            }
        }

        public int MyPlanSubscriptionId
        {
            get
            {
                return GetFromSession<int>("MyPlanSubscriptionId");

            }
            set
            {
                SetInSession("MyPlanSubscriptionId", value);
            }
        }





        public int ReminderCount
        {
            get
            {
                return GetFromSession<int>("ReminderCount");
            }
            set
            {
                SetInSession("ReminderCount", value);
            }
        }

        public int WebLead
        {
            get
            {
                return GetFromSession<int>("WebLead");
            }
            set
            {
                SetInSession("WebLead", value);
            }
        }



        internal Dictionary<int, Dictionary<int, List<int>>> RoleOperations
        {
            get
            {
                return GetFromSession<Dictionary<int, Dictionary<int, List<int>>>>("RoleOperations");
            }
            set
            {
                SetInSession("RoleOperations", value);
            }
        }



        public int Temuseridfortracherpage
        {
            get
            {
                return GetFromSession<int>("Temuseridfortracherpage");
            }
            set
            {
                SetInSession("Temuseridfortracherpage", value);
            }
        }

        #endregion





    }
}
