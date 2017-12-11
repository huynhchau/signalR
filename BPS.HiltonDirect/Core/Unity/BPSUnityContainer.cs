﻿using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Unity
{
    public class BPSUnityContainer : UnityContainer
    {
        public BPSUnityContainer()
        {
            AddExtension(new BPSUnityExtension());
        }
    }
}