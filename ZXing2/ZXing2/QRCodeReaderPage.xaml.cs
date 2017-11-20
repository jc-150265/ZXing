﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QRCodeReader
{
    public partial class QRCodeReaderPage : ContentPage
    {
        public QRCodeReaderPage()
        {
            InitializeComponent();
        }
        async void ScanButtonClicked(object sender, EventArgs s)
        {
            var scanPage = new ZXingScannerPage()
            {
                DefaultOverlayTopText = "バーコードを読み取ります",
                DefaultOverlayBottomText = "",
            };

            // スキャナページを表示
            await Navigation.PushAsync(scanPage);

            scanPage.OnScanResult += (result) =>
            {
                // スキャン停止
                scanPage.IsScanning = false;

                // PopAsyncで元のページに戻り、結果をダイアログで表示
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await DisplayAlert("スキャン完了", result.Text, "OK");
                });

                //scanedData.Add(result.Text);
            };
        }

    }
}
