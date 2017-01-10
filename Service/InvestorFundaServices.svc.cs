using ServiceBusinessLayer;
using ServiceDTO;
using System;
using System.Collections.Generic;
using static ServiceDTO.InvestFunda;

namespace Service
{

    public class InvestorFundaServices : IInvestorFundaServices
    {

        #region ALL GetAPIs ...............

        public Response<ULogin> GetLogin(string Uname, string password)
        {

            Response<ULogin> response = null;
            ULogin Logindetails = new ULogin();
            try
            {
                businessLayer businessLayer = new businessLayer();
                Logindetails = businessLayer.Login(Uname, password);
                response = new Response<ULogin>(Logindetails);
                if (Logindetails != null)
                {
                    if (response.Result.LoginID != "" && response.Result.LoginID != null && response.Result.Username != null && response.Result.Name != null)
                    {
                        response.ResponseCode = 0;
                        response.Status = "Login Successfully";
                        response.ResponseMessage = "Success";
                    }
                    else
                    {
                        response.ResponseCode = 1;
                        response.Status = "Faliure";
                        response.ResponseMessage = "Login details not available";
                    }
                }

            }
            catch (Exception ex)
            {
                response = new Response<ULogin>(Logindetails);
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = ex.Message;
            }

            return response;
        }
        #endregion


        #region ALL POSTAPIs ...............


        public Response<string> UserRegistration(RegistrationData request)
        {
            Response<string> response = new Response<string>();

            try
            {
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UserRegistration(request);

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> UpdateUserDetails(string User_ID, UserProfile userprofile, List<UserBankDetails> bankdetails, List<UserNomineeDetails> listNomineeDetails, List<UserUploadDocumentDetails> listDocumentDetails, List<AddressDetails> listAddress)
        {
            Response<string> response = new Response<string>();

            try
            {
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.UpdateUserDetails(User_ID, userprofile, bankdetails, listNomineeDetails, listDocumentDetails, listAddress);

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<string> CreateUsersPlan(string User_ID, Plan userPlan, Portfolio userPortfolio,List<InvestmentScheme> InvestmentList)
        {
            Response<string> response = new Response<string>();

            try
            {
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.CreateUserPlan(User_ID, userPlan, userPortfolio, InvestmentList);

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<List<Country>> GetCountryDetails()
        {

            Response<List<Country>> response = new Response<List<Country>>();
            List<Country> CountryList = new List<Country>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                CountryList = businessLayer.GetCountryDetails();
                response.Result = CountryList;
                if (CountryList != null)
                {
                    response.ResponseCode = 0;
                    response.Status = "Success";
                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Failure";
                    response.ResponseMessage = "No data available";
                }
            }
            catch (Exception EX)
            {
                response = new Response<List<Country>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<List<State>> GetStateDetails()
        {
            List<State> StateList = new List<State>();
            Response<List<State>> response = new Response<List<State>>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                StateList = businessLayer.GetStateDetails();
                response.Result = StateList;
                if (StateList != null)
                {
                    response.ResponseCode = 0;
                    response.Status = "Success";
                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Failure";
                    response.ResponseMessage = "No data available";
                }

            }
            catch (Exception EX)
            {
                response = new Response<List<State>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<List<City>> GetCityDetails()
        {
            List<City> CityList = new List<City>();
            Response<List<City>> response = new Response<List<City>>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                CityList = businessLayer.GetCityDetails();
                response.Result = CityList;
                if (CityList != null)
                {
                    response.ResponseCode = 0;
                    response.Status = "Success";
                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Failure";
                    response.ResponseMessage = "No data available";
                }

            }
            catch (Exception EX)
            {
                response = new Response<List<City>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }


        public Response<ListOfAllData> GetAllListDetails()
        {
            Response<ListOfAllData> objResponse = new Response<ListOfAllData>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetAllListDetails();
            return objResponse;
        }

        //public Response<UserDetails> GetUserDetailsInfo(string User_ID)
        //{
        //    Response<UserDetails> objResponse = new Response<UserDetails>();
        //    businessLayer businessLayer = new businessLayer();
        //    objResponse = businessLayer.GetUserDetailsInfo(User_ID);
        //    return objResponse;
        //}

        public Response<UserDetailsInfo> GetUserProfileDetailsInfo(string User_ID)
        {
            Response<UserDetailsInfo> objResponse = new Response<UserDetailsInfo>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetUserProfileDetailsInfo(User_ID);
            string s = objResponse.Result.IsComplete;
            if (s == "0")
            {
                MFOrderEntry.MFOrderEntryClient MF_OrderObj = new MFOrderEntry.MFOrderEntryClient();
                MFUploadServiceAdv.MFUploadServiceClient MFUploadObj = new MFUploadServiceAdv.MFUploadServiceClient();
                string MF_UploadPasResponse = MFUploadObj.getPassword("1065201", "10652", "123456", "asdfdsnh1234djbub");
                if (MF_UploadPasResponse.Split('|')[0] == "100")
                {
                    if (objResponse.Result.ClientCodeGenerateStatus != "100")
                    {
                        string MF_ClientCode = MFUploadObj.MFAPI("02", "1065201", MF_UploadPasResponse.Split('|')[1], "234533" + "|" + objResponse.Result.UserProfileData.HoldingNatureBSECode + "|" + objResponse.Result.UserProfileData.TaxStatusBSECode + "|" + objResponse.Result.UserProfileData.SOWBSECode + "|" + objResponse.Result.UserName + "|||20/10/1992|M||BOAPM1314N||||P||||||SB|1234565432|415098002|KKBK0000430|Y|||||||||||||||||||||Swatantra|Allahabad Naini|||Bengaluru|KA|560010|india|||||swatantramishra1@gmail.com|P|01|||||||||||||||9538406805");
                        if (MF_ClientCode.Split('|')[0] == "100")
                        {


                            //string MF_ClientMendateRegistration = MFUploadObj.MFAPI("06", "1065201", MF_UploadPasResponse.Split('|')[1], "10652|"+ MF_ClientCode.Split('|')[1]+"|");
                        }
                        else
                        {
                            objResponse.ResponseMessage = objResponse.ResponseMessage + " | Client Code is not able to generate " + MF_ClientCode.Split('|')[1];
                        }
                    }
                    //if (objResponse.Result.ClientMendateCodeGenerateStatus != "100")
                    //{

                    //}
                    //if (objResponse.Result.ClientPaymentCodeGenerateStatus != "100")
                    //{

                    //}

                    string no = objResponse.Result.User_ID + "|SI|01|02|" + objResponse.Result.UserName + "|||20/10/1992|M||BOAPMN1314N||||P||||||SB|1234565432|415098002|HDFC009100|Y|||||||||||||||||||||Swatantra|Allahabad Naini|||Bengaluru|KA|560010|india|||||swatantramishra1@gmail.com|P|01|||||||||||||||9538406805";
                    string totalno = Convert.ToString(no.Split('|').Length);
                }

            }
            return objResponse;
        }

        public Response<UserPlan> GetUserPlanInfo(string UserPlan_ID, string User_ID)
        {
            Response<UserPlan> objResponse = new Response<UserPlan>();
            businessLayer businessLayer = new businessLayer();
            objResponse = businessLayer.GetUserPlanInfo(UserPlan_ID, User_ID);
            return objResponse;
        }

        public Response<List<TaxStatus>> GetTaxStatus()
        {
            List<TaxStatus> taxStatus = new List<TaxStatus>();
            Response<List<TaxStatus>> response = new Response<List<TaxStatus>>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                taxStatus = businessLayer.GetTaxStatus();
                response.Result = taxStatus;
                if (taxStatus != null)
                {
                    response.ResponseCode = 0;
                    response.Status = "Success";
                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Failure";
                    response.ResponseMessage = "No data available";
                }

            }
            catch (Exception EX)
            {
                response = new Response<List<TaxStatus>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<List<HoldingNature>> GetHoldingNature()
        {
            List<HoldingNature> holdingNature = new List<HoldingNature>();
            Response<List<HoldingNature>> response = new Response<List<HoldingNature>>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                holdingNature = businessLayer.GetHoldingNature();
                response.Result = holdingNature;
                if (holdingNature != null)
                {
                    response.ResponseCode = 0;
                    response.Status = "Success";
                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Failure";
                    response.ResponseMessage = "No data available";
                }

            }
            catch (Exception EX)
            {
                response = new Response<List<HoldingNature>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        public Response<List<SourceOfWealth>> GetSourceOfWealth()
        {
            List<SourceOfWealth> sourceOfWealth = new List<SourceOfWealth>();
            Response<List<SourceOfWealth>> response = new Response<List<SourceOfWealth>>();
            try
            {
                businessLayer businessLayer = new businessLayer();
                sourceOfWealth = businessLayer.GetSourceOfWealth();
                response.Result = sourceOfWealth;
                if (sourceOfWealth != null)
                {
                    response.ResponseCode = 0;
                    response.Status = "Success";
                }
                else
                {
                    response.ResponseCode = 1;
                    response.Status = "Failure";
                    response.ResponseMessage = "No data available";
                }

            }
            catch (Exception EX)
            {
                response = new Response<List<SourceOfWealth>>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        #endregion


        #region
        public Response<string> CreateMendate(MendateCreation MendateCreateData, XSIPRegistration XSIPRegistrationData)
        {
            Response<string> response = new Response<string>();

            try
            {
                MF_AdditionService.MFUploadServiceClient MFAdditionalService = new MF_AdditionService.MFUploadServiceClient();
                LiveMF_Order.MFOrderEntryClient MF_OrderSrvc = new LiveMF_Order.MFOrderEntryClient();
                string GetPassUpload = MFAdditionalService.getPassword("1065201", "10652", "123456", "ABCDRsw123msdb");

                string GetPass = MF_OrderSrvc.getPassword("1065201", "123456", "ABCDRsw123msdb");
                response.Status = "Success";
                string MendateCreation_res = MFAdditionalService.MFAPI("06", "1065201", GetPassUpload.Split('|')[1], "10652|" + MendateCreateData.ClientCode + "|" + MendateCreateData.Amount + "|" + MendateCreateData.IFSC + "|" + MendateCreateData.AccountNumber + "|" + "X");
                //response.Result = MF_OrderSrvc.xsipOrderEntryParam("NEW", "2016122101000005", "INF846K01CF1",
                //"10652", "02", "1065201", "02", "P", "P", "18/12/2016", "MONTHLY",
                //"1", "2000", "12", "This is sample", "", "Y", "", MendateCreation_res.Split('|')[2], "", "E165332", "Y", "Y", "", "", GetPass.Split('|')[1], "ABCDRsw123msdb", "", "", "");

                response.Result = MF_OrderSrvc.xsipOrderEntryParam("NEW", "2016122101000018", XSIPRegistrationData.SchemeCode,
               "10652", XSIPRegistrationData.ClientCode, "1065201", "02", "P", "P", XSIPRegistrationData.StartDate, XSIPRegistrationData.FrequencyType,
               "1", XSIPRegistrationData.InstallmentAmount, XSIPRegistrationData.NoOfInstallment, XSIPRegistrationData.Remark,
               "", "Y", "", MendateCreation_res.Split('|')[2], "", "E165332", "Y", "Y", "", "", GetPass.Split('|')[1], "ABCDRsw123msdb", "", "", "");

            }

            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }
        public Response<string> PostData()
        {
            Response<string> response = new Response<string>();

            try
            {
                businessLayer businessLayer = new businessLayer();
                response = businessLayer.PostData();

            }
            catch (Exception EX)
            {
                response = new Response<string>();
                response.ResponseCode = 1;
                response.Status = "Error";
                response.ResponseMessage = EX.Message;
            }
            return response;
        }

        //public Response<string> CreateSipOrderEntryParam(string UserID, string Password, SipOrderEntry sipOrderEntry)
        //{
        //    Response<string> response = new Response<string>();

        //    try
        //    {
        //        businessLayer businessLayer = new businessLayer();
        //        response = businessLayer.CreateSipOrderEntryParam(UserID,Password,sipOrderEntry);
        //    }
        //    catch (Exception EX)
        //    {
        //        response = new Response<string>();
        //        response.ResponseCode = 1;
        //        response.Status = "Error";
        //        response.ResponseMessage = EX.Message;
        //    }
        //    return response;
        //}     
        #endregion
    }
}
