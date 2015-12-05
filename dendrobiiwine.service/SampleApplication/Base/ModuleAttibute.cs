using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleApplication.Base
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Method)]
    public class ModuleAttribute : Attribute
    {
        public Module AllowModules { get; set; }
    }

    [Flags]
    public enum Module : int
    {
        Vehicle = 1,
        Maintanence = 2,
        Booking = 4
    }
}