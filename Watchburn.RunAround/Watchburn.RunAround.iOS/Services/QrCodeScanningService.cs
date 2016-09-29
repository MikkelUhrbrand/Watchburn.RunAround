using System.Threading.Tasks;
using Watchburn.RunAround.iOS.Services;
using Watchburn.RunAround.Services;
using Xamarin.Forms;
using ZXing.Mobile;

[assembly: Dependency(typeof (QrCodeScanningService))]

namespace Watchburn.RunAround.iOS.Services
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