using SeekAd.BusinessModel;
using SeekAd.Data;
using SeekAd.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeekAd.BusinessServices
{
    public class AdService : IAdService
    {
        public double CheckOut(Request request)
        {
            var deals = Repository.GetAllDeals();

            //if there are no deals/bundles, return default
            if (deals == null)
                return GetDefaultCost(request.Ads);

            var customerDeals = Repository.GetDealsByCustomerName(request.CustomerName);

            //if there are no deals for this customer, return default
            if (!customerDeals.Any())
                return GetDefaultCost(request.Ads);


            return GetDealCost(customerDeals, request.Ads); ;
        }

        private double GetDefaultCost(List<string> ads)
        {
            var totalCost = 0.0;

            var adList = Repository.GetAllAds();

            foreach (var ad in ads)
                totalCost += GetAdCost(adList, ad);

            return totalCost;
        }

        private double GetAdCost(List<Ad> adList, string ad)
        {
            var adDetail = adList.Single(x => string.Equals(x.Code, ad, StringComparison.InvariantCultureIgnoreCase));

            if (adDetail == null)
                return 0;

            return adDetail.Cost;
        }

        private double GetDealCost(List<Deal> customerDeals, List<string> purchasedAds)
        {
            var totalCost = 0.0;
            var groupCost = 0.0;

            var adList = Repository.GetAllAds();

            //sort ad list
            purchasedAds.Sort();

            var adGroup = purchasedAds.GroupBy(x => x)
              .Select(y => new { Code = y.Key, Count = y.Count() })
              .ToList();

            foreach (var ad in adGroup)
            {
                var customerAdDeal = customerDeals.Where(x => x.AdCode == ad.Code).FirstOrDefault();

                var adCost = GetAdCost(adList, ad.Code);

                var adCount = ad.Count;

                //if the specific ad is not part of customer deal
                if (customerAdDeal == null) { 
                    totalCost += adCost;
                    continue;
                }

                switch (customerAdDeal.DiscountType) { 
                    case DiscountType.Amount:
                        groupCost = 0.0;
                        if (adCount >= 1)
                        {
                            groupCost += adCost - customerAdDeal.Discount;
                            groupCost *= adCount;
                        }
                        totalCost += groupCost;
                        break;

                    case DiscountType.Percent:
                        groupCost = 0.0;
                        if (adCount >= 1)
                        {
                            var discountAmount = adCost * ((customerAdDeal.Discount / 100));
                            groupCost = adCost - discountAmount;
                            groupCost *= adCount;
                        }
                        totalCost += groupCost;
                        break;

                    case DiscountType.XForY:
                        while(adCount >= customerAdDeal.PurchaseSize)
                        {
                            totalCost += adCost * customerAdDeal.CostSize;
                            adCount -= customerAdDeal.PurchaseSize;
                        }
                        totalCost += adCost * adCount;
                        break;
                }
            }


            return totalCost;
        }
    }
}
