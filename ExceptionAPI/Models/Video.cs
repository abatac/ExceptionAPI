using ExceptionAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WasteManagementAPI.Models
{
    public class Video
    {

        [JsonProperty("video_status")]
        [Display(Name = "video_status")]
        public string VideoStatus { get; set; }

        [JsonProperty("video_urls")]
        [Display(Name = "video_urls")]
        public ICollection<VideoUrl> VideoUrls { get; set; }
    }
}
