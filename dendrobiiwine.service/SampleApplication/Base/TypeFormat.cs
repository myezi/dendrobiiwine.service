using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SampleApplication.Base
{
    public class TypeFormat
    {
        public static int GetInt(object input)
        {
            int output = 0;
            if ((input != null) && (input.ToString().Length != 0))
            {
                try
                {
                    output = Int32.Parse(input.ToString());
                }
                catch (Exception)
                {
                    //
                }
            }
            return output;
        }
    }
}