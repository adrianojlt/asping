namespace Sharping
{
    public static class Extensions
    {
        public static async Task<byte[]> ToByteArray(this string str)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    await writer.WriteAsync(str);
                    await writer.FlushAsync();
                }

                return stream.ToArray();
            }
        }
    }
}
