using System;
using System.Collections.Generic;
using System.Text;

namespace SeekAd.BusinessModel
{
    public class Request
    {
        public string CustomerName { get; set; }
        public List<string> Ads { get; set; }
    }
}
