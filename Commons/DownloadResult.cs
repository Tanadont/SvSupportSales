using System.Net.Mime;

namespace SvSupportSales.Commons
{
    public class DownloadResult
    {
        public string? ContentType { get; set; }
        public string? FileName { get; set; }
        public string? PresignedUrl { get; set; }
        public dynamic? Content { get; set; }
        public DownloadResult() { }
        public DownloadResult(string? contentType, string? fileName, string? presignedUrl, dynamic content)
        {
            ContentType = contentType;
            FileName = fileName;
            PresignedUrl = presignedUrl;
            Content = content;
        }
    }
}
