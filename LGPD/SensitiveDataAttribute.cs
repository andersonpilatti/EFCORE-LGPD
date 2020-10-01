using System;

namespace LGPD
{
    // SensitiveDataAttribute
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SensitiveDataAttribute : Attribute
    {
    }
}