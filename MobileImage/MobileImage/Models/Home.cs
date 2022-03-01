using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileImage.Models
{
    class Home
    {
        public int Pic_ID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public float Price { get; set; }
        public string user_email { get; set; }
        public string url { get; set; }
        //public MediaFile pic { get; set; }
    }
}
