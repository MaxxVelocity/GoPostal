﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GoPostal.CommandLine
{
    public class Url : IParameterValue  
    {
        public static bool IsPopulated => instance?.value != null;

        public static string Value => instance.value;

        private static Url instance;

        public static void Initialize(string[] args)
        {
            instance = instance == null 
                ? UniqueParamterFactory.Create<Url>("U|Url", args)
                : throw new ArgumentException("There can be only one URL specification.");
        }
    }
}