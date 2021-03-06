﻿using System.Threading.Tasks;
using Watchburn.RunAround.Services;
using Watchburn.RunAround.WinPhone.Services;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof (QrCodeScanningService))]

namespace Watchburn.RunAround.WinPhone.Services
{
	public class QrCodeScanningService : IQrCodeScanningService
	{
		public async Task<string> ScanAsync()
		{
			var scanner = new MobileBarcodeScanner();
			var scanResults = await scanner.Scan();

			return scanResults.Text;
		}
	}
}