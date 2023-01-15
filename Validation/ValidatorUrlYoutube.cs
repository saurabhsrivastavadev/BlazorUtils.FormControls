using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Web;

namespace BlazorUtils.FormControls.Validation
{
    public class ValidatorUrlYoutube : IValidator<string>
    {
        public ValidatorType Type { get; } = ValidatorType.YOUTUBE_URL;

        public string YoutubeVideoId { get; private set; }

        public ValidationResult<string> Validate(string value)
        {
            var result = new ValidationResult<string>(this);
            UriCreationOptions options = new();

            // Check if URL is specified in text, url, or title, in this order.
            if (Uri.TryCreate(value, options, out Uri parsedUri))
            {
                if (parsedUri.Host == "youtube.com" || parsedUri.Host == "www.youtube.com")
                {
                    var parsedQuery = HttpUtility.ParseQueryString(parsedUri.Query);
                    string videoId = parsedQuery.Get("v");
                    if (string.IsNullOrWhiteSpace(videoId))
                    {
                        result.Result = false;
                        result.Message = "Invalid youtube.com URL, no video parameter.";
                    }
                }
                else if (parsedUri.Host == "youtu.be" || parsedUri.Host == "www.youtu.be")
                {
                    if (parsedUri.Segments.Length > 1)
                    {
                        YoutubeVideoId = parsedUri.Segments[1];
                        result.Result = true;
                        result.Message = "Successfully parsed youtube video id from URL";
                    }
                    else
                    {
                        result.Result = false;
                        result.Message = "Invalid youtu.be URL, no video in path.";
                    }
                }
                else
                {
                    result.Result = false;
                    result.Message = $"Not a YouTube Host URL [{parsedUri.Host}]";
                }
            }
            else
            {
                result.Result = false;
                result.Message = "No valid URL found";
            }

            return result;
        }
    }
}
