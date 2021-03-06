﻿using System;
using System.Threading.Tasks;
using Template10.Services.Dialog;
using Windows.ApplicationModel;
using Template10.Services.Nag;

namespace Template10.Services.Marketplace
{
    public sealed class MarketplaceService : IMarketplaceService
    {
        public static MarketplaceService Create()
        {
            return new MarketplaceService();
        }

        readonly MarketplaceHelper _helper;
        private MarketplaceService()
        {
            _helper = new MarketplaceHelper();
        }

        public async Task LaunchAppInStore() =>
            await _helper.LaunchAppInStoreByProductFamilyName(Package.Current.Id.FamilyName);

        public async Task LaunchAppReviewInStoreAsync() =>
            await _helper.LaunchAppReviewInStoreByProductFamilyName(Package.Current.Id.FamilyName);

        public async Task LaunchPublisherPageInStoreAsync() =>
            await _helper.LaunchPublisherPageInStore(Package.Current.Id.Publisher);

        public NagObject CreateAppReviewNag() => CreateAppReviewNag($"Review {Package.Current.DisplayName}?");

        public NagObject CreateAppReviewNag(string message)
        {
            return new NagObject("AppReviewNag", message, async () => await LaunchAppReviewInStoreAsync())
            {
                Title = $"Review {Package.Current.DisplayName}",
                AcceptText = "Review app",
                Location = NagStorageStrategies.Roaming
            };
        }
    }
}
