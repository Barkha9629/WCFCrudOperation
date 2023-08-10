using EntityExam.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using static EntityExam.Class.CommonClass;
using System.Configuration;
using System.Web.Hosting;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Script.Services;
using System.Linq.Expressions;
using System.Runtime.Remoting;
using System.Text;
using EntityExam.Entityframework;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace EntityExam
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        EmployeedbEntities db = new EmployeedbEntities();
        public void DoWork()
        {
        }

        #region CastList
        public CheckCastList GetCastList()
        {
            CheckCastList objca = new CheckCastList();

            try
            {

                var MyCast = (from C in db.CastMasters
                              orderby C.CastId ascending
                              where C.IsActive == true
                              select C).ToList();

                if (MyCast != null)
                {
                    var lstCast = new List<CastList>();

                    foreach (var item in MyCast)
                    {
                        CastList objE = new CastList();
                        objE.CastId = item.CastId;
                        objE.CastName = item.CastName;

                        lstCast.Add(objE);

                    }
                    objca.Data = lstCast;
                    objca.status = true;
                    objca.message = "Success";


                }
                else
                {
                    objca.Data = null;
                    objca.status = false;
                    objca.message = "Fail";

                }
            }
            catch (Exception ex)
            {
                objca.Data = null;
                objca.status = false;
                objca.message = "Fail";

            }


            return objca;

        }
        #endregion

        #region ContactList
        public CheckContactList GetContactList(string EmployeeId)
        {
            CheckContactList objc = new CheckContactList();

            try
            {
                var empid = Convert.ToInt32(EmployeeId);
                var MyContact = (from E in db.EmployeeDetails
                                 join C in db.ContactDetails
                                 on E.EmployeeId equals C.EmployeeId
                                 where E.EmployeeId == empid
                                 select new { E.FirstName, E.LastName, C.EmailId, C.MobileNumber })
                                 .FirstOrDefault();

                var lstContact = new List<ContactList>();

                if (MyContact != null)
                {
                    ContactList objE = new ContactList();
                    objE.FirstName = MyContact.FirstName;
                    objE.LastName = MyContact.LastName;
                    objE.EmailId = MyContact.EmailId;
                    objE.MobileNumber = MyContact.MobileNumber;

                    lstContact.Add(objE);

                    objc.Data = lstContact;
                    objc.status = true;
                    objc.message = "Success";

                }
                else
                {
                    objc.Data = null;
                    objc.status = false;
                    objc.message = "Fail";

                }
            }
            catch (Exception ex)
            {
                objc.Data = null;
                objc.status = false;
                objc.message = "Fail";

            }


            return objc;

        }
        #endregion

        #region AddList 
        public CheckEmployeeList GetAddList(string FirstName, string MiddleName, string Gender, string LastName, string MaritalStatus, string BankName, string BranchName, string AccountType, string AccountNumber, string IFSCCode)
        {
            CheckEmployeeList obja = new CheckEmployeeList();

            try
            {

                int isinsert = 0;

                var emp = new EmployeeDetail
                {
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    LastName = LastName,
                    Gender = Gender,
                    MaritalStatus = MaritalStatus,

                };

                db.EmployeeDetails.Add(emp);

                isinsert = db.SaveChanges();

                var empid = emp.EmployeeId;

                var cont = new BankDetail
                {
                    EmployeeId = empid,
                    BankName = BankName,
                    BranchName = BranchName,
                    AccountNumber = AccountNumber,
                    AccountType = AccountType,
                    IFSCCode = IFSCCode,
                };
                db.BankDetails.Add(cont);

                db.SaveChanges();

                if (isinsert > 0)
                {
                    obja.EmployeeId = isinsert;
                    obja.status = true;
                    obja.message = "Success";

                }
                else
                {
                    obja.EmployeeId = 0;
                    obja.status = false;
                    obja.message = "Fail";

                }
            }
            catch (Exception ex)
            {
                obja.EmployeeId = 0;
                obja.status = false;
                obja.message = "Fail";

            }


            return obja;

        }
        #endregion

        #region UpdateList
        public CheckEmployeeList GetUpdateList(string EmployeeId, string BankName, string BranchName, string AccountType)
        {
            CheckEmployeeList obja = new CheckEmployeeList();

            try
            {

                int isinsert = 0;

                var empid = Convert.ToInt32(EmployeeId);
                var update = (from B in db.BankDetails
                              where B.EmployeeId == empid
                              select B)
                              .FirstOrDefault();


                if (update != null)
                {
                    update.BankName = BankName;
                    update.BranchName = BranchName;
                    update.AccountType = AccountType;


                    isinsert = db.SaveChanges();


                }

                if (isinsert > 0)
                {
                    obja.EmployeeId = empid;
                    obja.status = true;
                    obja.message = "Success";

                }
                else
                {
                    obja.EmployeeId = 0;
                    obja.status = false;
                    obja.message = "Fail";

                }
            }
            catch (Exception ex)
            {
                obja.EmployeeId = 0;
                obja.status = false;
                obja.message = "Fail";

            }


            return obja;



        }
        #endregion

        #region DeleteList
        public CheckEmployeeList GetDeleteList(string EmployeeId)
        {
            CheckEmployeeList obja = new CheckEmployeeList();

            try
            {

                int isinsert = 0;

                var empid = Convert.ToInt32(EmployeeId);
                var Delete = (from B in db.Experiences
                              where B.EmployeeId == empid
                              select B)
                              .FirstOrDefault();
                Delete.IsActive = false;
                isinsert = db.SaveChanges();


                if (isinsert > 0)
                {
                    obja.EmployeeId = empid;
                    obja.status = true;
                    obja.message = "Success";

                }
                else
                {
                    obja.EmployeeId = 0;
                    obja.status = false;
                    obja.message = "Fail";

                }
            }
            catch (Exception ex)
            {
                obja.EmployeeId = 0;
                obja.status = false;
                obja.message = "Fail";

            }


            return obja;
        }
        #endregion


        #region CastList
        public CheckCastList MetCastList()
        {
            CheckCastList obh = new CheckCastList();

            try
            {
                var My = (from C in db.CastMasters
                          orderby C.CastId ascending
                          where C.IsActive == true
                          select C).ToList();

                if (My != null)
                {
                    var list = new List<CastList>();

                    foreach (var m in My)
                    {
                        CastList cst = new CastList();
                        cst.CastName = m.CastName;
                        cst.CastId = m.CastId;

                        list.Add(cst);

                    }

                    obh.Data = list;
                    obh.status = true;
                    obh.message = "Success";
                }
                else
                {
                    obh.Data = null;
                    obh.status = false;
                    obh.message = "UnsuccessFull";

                }


            }

            catch (Exception ex)
            {
                obh.Data = null;
                obh.status = false;
                obh.message = "UnsuccessFull";

            }
            return obh;
        }

        #endregion

        #region ContactList
        public CheckContactList MetContactList(string EmployeeId)
        {
            CheckContactList obn = new CheckContactList();

            try
            {
                var emp = Convert.ToInt32(EmployeeId);

                var ol = (from CD in db.ContactDetails
                          join E in db.EmployeeDetails
                          on CD.EmployeeId equals E.EmployeeId
                          where E.EmployeeId == emp
                          select new { E.FirstName, E.LastName, CD.EmailId, CD.MobileNumber }).FirstOrDefault();

                if (ol != null)
                {
                    var lst = new List<ContactList>();

                    ContactList ct = new ContactList();
                    ct.EmailId = ol.EmailId;
                    ct.MobileNumber = ol.MobileNumber;
                    ct.FirstName = ol.FirstName;
                    ct.LastName = ol.LastName;

                    lst.Add(ct);

                    obn.Data = lst;
                    obn.status = true;
                    obn.message = "Success";

                }
                else
                {
                    obn.Data = null;
                    obn.status = false;
                    obn.message = "Failed";

                }


            }
            catch (Exception ex)
            {
                obn.Data = null;
                obn.status = false;
                obn.message = "Failed";

            }

            return obn;

        }

        #endregion

        #region AddList

       public  CheckEmployeeList MetEmployeeList(string FirstName, string MiddleName, string Gender, string LastName, string MaritalStatus)
        {

            CheckEmployeeList obk = new CheckEmployeeList();


            int isinsert = 0;

            try
            {

                var pol = new EmployeeDetail
                {
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    Gender = Gender,
                    LastName = LastName,
                    MaritalStatus = MaritalStatus,

                };

                db.EmployeeDetails.Add(pol);

                isinsert = db.SaveChanges();

                if(isinsert > 0)
                {
                    obk.EmployeeId = isinsert;
                    obk.message = "success";
                    obk.status = true;

                }
                else
                {

                        obk.EmployeeId = 0;
                        obk.message = "Failed";
                        obk.status = true;

                }
                
           

                
            }
            catch(Exception ex)
            {
                obk.EmployeeId = 0;
                obk.message = "Failed";
                obk.status = true;

            }

            return obk;

        }
        #endregion

        #region UpdateList

        public CheckEmployeeList GetUpdList(string EmployeeId, string BankName, string BranchName, string AccountType)
        {
            CheckEmployeeList bk = new CheckEmployeeList();
            try
            {
               int isupdate = 0;

                var bank = Convert.ToInt32(EmployeeId);

                var pol = (from B in db.BankDetails
                           join E in db.EmployeeDetails
                           on B.EmployeeId equals E.EmployeeId
                           where E.EmployeeId == bank
                           select B).FirstOrDefault();
                if (pol != null)
                {
                    pol.AccountType = AccountType;
                    pol.BankName = BankName;
                    pol.BranchName = BranchName;

                    isupdate = db.SaveChanges();

                }
                if(isupdate > 0)
                {
                    bk.EmployeeId = isupdate;
                    bk.status = true;
                    bk.message = "Success";

                }
                else
                {
                    bk.EmployeeId = 0;
                    bk.status = true;
                    bk.message = "Failed";

                }

            }
            catch(Exception ex)
            {
                bk.EmployeeId = 0;
                bk.status = true;
                bk.message = "Failed";

            }
            return bk;

        }


        #endregion







    }







}







