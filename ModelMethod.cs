﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace getimgWPFClient
{
    internal abstract class ModelMethod
    {
        public String methodLocation; // combined with client url and modelLocation to identify the method
        public Method httpMethod;
        public BodyParams bodyParams;
    }
}
