﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BantuLite.Models
{
    public class Login
    {
        [Display(Name = "Branch")]
        public string BranchID { get; set; }

        [Display(Name = "Login Date")]
        public string LoginDate { get; set; }

        public string OperatorID { get; set; }
        public string Password { get; set; }

        //public SystemBranch SystemBranch { get; set; }
    }


    public class GeneralLedger
    {
        public string OperatorID { get; set; }
        public string BankID { get; set; }
        public string AccountID { get; set; }
        public string Description { get; set; }
        public string ShortName { get; set; }
        public string CurrencyID { get; set; }
        public string GLAccountTypeID { get; set; }
        public string GLSubAccountTypeID { get; set; }
        public string GLCateGoryID { get; set; }
        public string PostingTypeID { get; set; }
        public string GLClassID { get; set; }
        public string ContraAccountID { get; set; }
        public string MainGLAccountID { get; set; }
        public bool IsRevaluate { get; set; }
        public string Remarks { get; set; }
        public string ClosedBy { get; set; }
        public string ClosedOn { get; set; }
        public string ClosedDate { get; set; }
        public string ClosedReason { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public string SupervisedBy { get; set; }
        public string SupervisedOn { get; set; }
        public string UpdateCount { get; set; }
        public string GLTypeGroupID { get; set; }
        public string Clasification1 { get; set; }
        public string Clasification2 { get; set; }
        public string Clasification3 { get; set; }
    }

    public class GLSubType
    {
        public string GLAccountTypeID { get; set; }
        public string GLSubAccountTypeID { get; set; }
        public string GLTypeGroupID { get; set; }
        public string Description { get; set; }
    }

    public class SystemBranch
    {
        public string OurBranchID { get; set; }
        public string BranchName { get; set; }
        public string BankID { get; set; }
        public byte UpdateCount { get; set; }

        public string SODDate { get; set; }
    }

    public class SystemBranchStatus
    {
        public string OurBranchID { get; set; }
        public string IsTrxAllow { get; set; }
        public string BranchStatusID { get; set; }
        public string BranchStatus { get; set; }
        public string SODDate { get; set; }
        public string EODDate { get; set; }
        public string CEDate { get; set; }
        public string EOMDate { get; set; }
        public string EOYDate { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
    }

    public class SystemBranchDetails
    {
        public string Branch { get; set; }
        public string SystemDate { get; set; }
        public string Operator { get; set; }
    }

    public static class DbConModel
    {
        public static string ConnectionString { get; set; }
    }

    public class DbCon
    {
        public static IDbConnection Connection()
        {
            IDbConnection _db = new SqlConnection(DbConModel.ConnectionString);

            return _db;
        }
    }
}
