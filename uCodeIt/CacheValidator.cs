using System.IO;
using System.Web.Compilation;

namespace uCodeIt
{
    internal static class CacheValidator
    {
        private const string BuildManagerTracker = "uCodeIt-Tracker.txt";

        public static bool RebuildRequired()
        {
            try
            {
                var stream = BuildManager.ReadCachedFile(BuildManagerTracker);

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

        internal static void RebuildComplete()
        {
            try
            {
                var stream = BuildManager.CreateCachedFile(BuildManagerTracker);

                using (var writer = new StreamWriter(stream))
                {
                    writer.WriteLine("Build completed");
                }
            }
            catch
            {
            }
        }
    }
}
