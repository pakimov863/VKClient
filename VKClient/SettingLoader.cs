﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VKClient
{
    static class SettingLoader
    {

        public static void logpass(ref int id, ref string log, ref string pass)
        {
            StreamReader sr = new StreamReader("../../../../data.txt");
            id = Convert.ToInt32(sr.ReadLine());
            log = sr.ReadLine();
            pass = sr.ReadLine();
            sr.Close();
        }
    }
}