﻿using BantuLite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BantuLite.Service
{
    public interface IGLService
    {
        Tuple<List<GeneralLedger>, int> GetGeneralLedgers(int? page, int? limit, string filterQuery);

        GeneralLedger GetGeneralLedger(string accountID);
        GeneralLedger AddGeneralLedger(GeneralLedger generalLedger);
        GeneralLedger EditGeneralLedger(GeneralLedger generalLedger);
        GeneralLedger DisableGL(GeneralLedger generalLedger);
        //GeneralLedger SearchColumns(string accountID, string Description, string Shortname, string CurrencyID);
    }
}
