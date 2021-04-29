using System;
using System.IO;
using System.Reflection;

namespace Typeset
{
    internal class StringResourceProvider : IStringResourceProvider
    {
        private readonly Assembly _assembly = typeof(StringResourceProvider).GetTypeInfo().Assembly;

        public string Get(string resourceName)
        {
            var resource = _assembly.GetManifestResourceStream($"Typeset.Resources.{resourceName}");

            if (resource == null)
            {
                throw new Exception($"Failed to load resource {resourceName}");
            }

            using var reader = new StreamReader(resource);
            return reader.ReadToEnd();
        }
    }
}