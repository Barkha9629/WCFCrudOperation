using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using EntityExam.Class;
using System.Text;

namespace EntityExam
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DoWork();

        #region CastList
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetCastList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckCastList GetCastList();
        #endregion

        #region ContactList
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetContactList/{EmployeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckContactList GetContactList(string EmployeeId);
        #endregion

        #region AddList
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetAddList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList GetAddList(string FirstName, string MiddleName, string Gender, string LastName, string MaritalStatus, string BankName, string BranchName, string AccountType, string AccountNumber, string IFSCCode);
        #endregion

        #region UpdateList
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUpdateList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList GetUpdateList(string EmployeeId, string BankName, string BranchName, string AccountType);
        #endregion

        #region DeleteList
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetDeleteList/{EmployeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList GetDeleteList(string EmployeeId);
        #endregion

        #region CastList
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "MetCastList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckCastList MetCastList();
        #endregion

        #region ContactList
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "MetContactList/{EmployeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckContactList MetContactList(string EmployeeId);
        #endregion

        #region AddList
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "MetEmployeeList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList MetEmployeeList(string FirstName, string MiddleName, string Gender, string LastName, string MaritalStatus);
        #endregion

        #region UpdateList
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "GetUpdList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        CheckEmployeeList GetUpdList(string EmployeeId, string BankName, string BranchName, string AccountType);
        #endregion

    }
}
