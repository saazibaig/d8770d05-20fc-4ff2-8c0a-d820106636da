using SeekAd.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeekAd.BusinessServices
{
    public interface IAdService
    {
        public double CheckOut(Request request);
    }
}
