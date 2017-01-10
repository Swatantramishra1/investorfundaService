using ServiceDTO;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using static ServiceDTO.InvestFunda;

namespace Service
{

    [ServiceContract]
    public interface IInvestorFundaServices
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login/{Uname}/{password}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<ULogin> GetLogin(string Uname, string password);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UserRegistration", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UserRegistration(RegistrationData request);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCountryDetails", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<Country>> GetCountryDetails();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetTaxStatus", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<TaxStatus>> GetTaxStatus();
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "HoldingNature", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<HoldingNature>> GetHoldingNature();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetSourceOfWealth", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<SourceOfWealth>> GetSourceOfWealth();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetStateDetails", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<State>> GetStateDetails();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetCityDetails", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<List<City>> GetCityDetails();

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAllListDetails", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<ListOfAllData> GetAllListDetails();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserDetailsInfo/{User_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        //Response<UserDetails> GetUserDetailsInfo(string User_ID);


        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserProfileDetailsInfo/{User_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<UserDetailsInfo> GetUserProfileDetailsInfo(string User_ID);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "UpdateUserDetails", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> UpdateUserDetails(string User_ID, UserProfile userprofile, List<UserBankDetails> bankdetails, List<UserNomineeDetails> listNomineeDetails, List<UserUploadDocumentDetails> listDocumentDetails, List<AddressDetails> listAddress);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CreateUsersPlan", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> CreateUsersPlan(string User_ID, Plan userPlan, Portfolio userPortfolio, List<InvestmentScheme> InvestmentList);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "PostData", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> PostData();

        //[OperationContract]
        //[WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "PostData", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        //Response<string> CreateSipOrderEntryParam(string UserID,string Password, SipOrderEntry sipOrderEntry);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CreateMendate", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        Response<string> CreateMendate(MendateCreation MendateCreationData, XSIPRegistration XSIPRegistrationData);

[	OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUserPlanInfo/{UserPlan_ID}/{User_ID}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Response<UserPlan> GetUserPlanInfo(string UserPlan_ID,string User_ID);
    }
}
