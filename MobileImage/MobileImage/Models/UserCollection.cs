using System;
using System.Collections.Generic;
using System.Text;

namespace MobileImage.Models
{
    class UserCollection
    {
        public int Id_userimage { get; set; }
        public string user_email { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public string url { get; set; }
        public int picid { get; set; }
        public float Price { get; set; }
    }
}
