using System.Linq;

namespace mft.adapters
{
    public static class MarkdownDestillator
    {
        const int MAX_LEN_EXCERPT = 40;
            
        public static string Excerpt(this string[] lines) {
            // excerpt from headlines
            var excerpt = lines.FirstOrDefault(x => x.StartsWith("# ") || 
                                                    x.StartsWith("## ") || 
                                                    x.StartsWith("### "));
            if (string.IsNullOrEmpty(excerpt)) excerpt = "";

            // or excerpt from first 10 lines of content
            if (excerpt == "") 
                excerpt = string.Join(" ", lines.Take(10));
            
            // squeeze out excess whitespace (leading/trailing and in between)
            excerpt = excerpt.Trim();
            while (excerpt.IndexOf("  ") >= 0)
                excerpt = excerpt.Replace("  ", " ");

            // shorten excerpt
            if (excerpt.Length > MAX_LEN_EXCERPT)
                excerpt = excerpt.Substring(0, MAX_LEN_EXCERPT) + "...";

            return excerpt;
        }
    }
}