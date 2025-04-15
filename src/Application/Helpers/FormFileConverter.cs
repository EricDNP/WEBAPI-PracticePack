using Microsoft.AspNetCore.Http;

namespace Application.Helpers
{
    public static class FormFileConverter
    {
        public static string ConvertToBase64(IFormFile? file)
        {
            if (file == null) return "";

            using var ms = new MemoryStream();
            file.CopyTo(ms);
            return Convert.ToBase64String(ms.ToArray());
        }
    }
}
