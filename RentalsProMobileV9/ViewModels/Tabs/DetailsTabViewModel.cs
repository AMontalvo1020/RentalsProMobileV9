﻿using System.Collections.ObjectModel;
using System.Net;
using CommunityToolkit.Mvvm.ComponentModel;
using RentalsProAPIV8.Client.DataTransferObjects;
using RentalsProAPIV8.Core.Extensions;
using RentalsProMobileV9.ViewModels.Base;

namespace RentalsProMobileV9.ViewModels.Tabs
{
    public partial class DetailsTabViewModel : TabViewModelBase
    {
        [ObservableProperty] private TypeDTO type;
        [ObservableProperty] private ObservableCollection<TypeDTO> types = new();
        [ObservableProperty] private StatusDTO status;
        [ObservableProperty] private ObservableCollection<StatusDTO> statuses = new();
        [ObservableProperty] private StatusDTO paymentStatus;
        [ObservableProperty] private ObservableCollection<StatusDTO> paymentStatuses = new();

        public DetailsTabViewModel() : base() { }

        public DetailsTabViewModel(INavigation navigation, PropertyDTO property) : base(navigation, property) { }

        public override async Task InitializeAsync()
        {
            await LoadPropertyAsync(Property.ID.Value);
            await LoadTypesAsync(Property.Type?.ID);
            await LoadStatusesAsync(Property.Status?.ID);
            await LoadPaymentStatusesAsync(Property.PaymentStatus?.ID);
        }

        partial void OnStatusChanged(StatusDTO value)
        {
            if (value != null && value?.ID != Property.Status?.ID)
            {
                UpdatePropertyStatusAsync(Property.ID.Value, value.ID.Value);
            }
        }

        partial void OnPaymentStatusChanged(StatusDTO value)
        {
            if (value != null && value?.ID != Property.PaymentStatus?.ID)
            {
                UpdatePaymentStatusAsync(Property.ID.Value, value.ID.Value);
            }
        }

        private async Task LoadPropertyAsync(int propertyID)
        {
            var response = await _Repository.GetPropertyAsync(propertyID);
            if (response?.Content != null)
            {
                Property = response.Content;
            }
            else
            {
                DisplayAlertAsync("Error", "Failed to load property details.");
            }
        }

        private async Task LoadTypesAsync(int? typeID = null)
        {
            var response = await _Repository.GetPropertyTypesAsync();
            if (response?.Content != null)
            {
                Types = response.Content.AsObservable();
                Type = Types.FirstOrDefault(t => t.ID == typeID) ?? Types.FirstOrDefault();
            }
        }

        private async Task LoadStatusesAsync(int? statusID = null)
        {
            var response = await _Repository.GetStatusesAsync();
            if (response?.Content != null)
            {
                Statuses = response.Content.AsObservable();
                Status = Statuses.FirstOrDefault(s => s.ID == statusID) ?? Statuses.FirstOrDefault();
            }
        }

        private async Task LoadPaymentStatusesAsync(int? paymentStatusID = null)
        {
            var response = await _Repository.GetPaymentStatusesAsync();
            if (response?.Content != null)
            {
                PaymentStatuses = response.Content.AsObservable();
                PaymentStatus = PaymentStatuses.FirstOrDefault(ps => ps.ID == paymentStatusID) ?? PaymentStatuses.FirstOrDefault();
            }
        }

        private async Task UpdatePropertyStatusAsync(int propertyID, int statusID)
        {
            await IsBusyFor(async () =>
            {
                try
                {
                    var response = await _Repository.PatchPropertyStatusAsync(propertyID, statusID);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        await RefreshPropertyAsync(propertyID, statusID, isPaymentStatus: false);
                    }
                    else
                    {
                        DisplayAlertAsync("Error", "Failed to update property status.");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlertAsync("Error", $"An error occurred while updating property status: {ex.Message}");
                }
                
            });
        }

        private async Task UpdatePaymentStatusAsync(int propertyID, int statusID)
        {
            await IsBusyFor(async () =>
            {
                try
                {
                    var response = await _Repository.PatchPropertyPaymentStatusAsync(propertyID, statusID);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        await RefreshPropertyAsync(propertyID, statusID, isPaymentStatus: true);
                    }
                    else
                    {
                        DisplayAlertAsync("Error", "Failed to update payment status.");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlertAsync("Error", $"An error occurred while updating payment status: {ex.Message}");
                }
            });
        }

        private async Task RefreshPropertyAsync(int propertyID, int statusID, bool isPaymentStatus)
        {
            await LoadPropertyAsync(propertyID);

            if (isPaymentStatus)
            {
                PaymentStatus = PaymentStatuses.FirstOrDefault(ps => ps.ID == statusID);
            }
            else
            {
                Status = Statuses.FirstOrDefault(s => s.ID == statusID);
            }
        }
    }
}
