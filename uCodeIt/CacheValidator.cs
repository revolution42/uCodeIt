using System.IO;
using System.Web.Compilation;

namespace uCodeIt
{
    internal static class CacheValidator
    {
        private const string CacheFile = "uCodeIt-TypeCache.xml";

        public static bool Exists()
        {
            try
            {
                var stream = BuildManager.ReadCachedFile(CacheFile);

                using (var reader = new StreamReader(stream))
                {
                    var contents = reader.ReadToEnd();

                    //todo - properly validate the contents
                    if (!string.IsNullOrEmpty(contents))
                        return true;
                }
            }
            catch
            {
            }

            return false;
        }
    }
}
