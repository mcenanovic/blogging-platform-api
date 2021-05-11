using System.Globalization;
using System.Text;

namespace BloggingPlatform.Core
{
    public static class UtilityService
    {
        public static string GenerateSlug(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return null;
            }

            string formattedTitle = title.ToLower().Replace(" ", "-").Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < formattedTitle.Length; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(formattedTitle[i]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(formattedTitle[i]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
    }
}
