﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Contracts
{
    public interface IAlertControl
    {
        void AcceptAlert();

        void DismissAlert();

        string GetMessageFromAlert();


    }
}
