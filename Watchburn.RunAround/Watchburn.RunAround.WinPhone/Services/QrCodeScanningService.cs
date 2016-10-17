using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.UI.Popups;
using Lumia.Imaging;
using VideoEffects;
using Watchburn.RunAround.Services;
using Watchburn.RunAround.WinPhone.Services;
using Xamarin.Forms;
using ZXing;
using ZXing.Common;

[assembly: Dependency(typeof (QrCodeScanningService))]

namespace Watchburn.RunAround.WinPhone.Services
{
	public class QrCodeScanningService : IQrCodeScanningService
	{
		private readonly BarcodeReader _reader;
		private MediaCapture _mediaCapture;
		private Result _result;
		private MessageDialog dialog;
		public int exit = 0;

		public QrCodeScanningService()
		{
			_reader = new BarcodeReader
			{
				Options = new DecodingOptions
				{
					PossibleFormats = new[] {BarcodeFormat.QR_CODE},
					TryHarder = true
				}
			};
		}

		public async Task<string> ScanAsync()
		{
			using (var capture = new MediaCapture())
			{
				await capture.InitializeAsync();

				var definition = new LumiaAnalyzerDefinition(ColorMode.Yuv420Sp, 640, AnalyzeBitmap);
				await capture.AddEffectAsync(MediaStreamType.VideoPreview, definition.ActivatableClassId, definition.Properties);

				return _result?.Text ?? "Failed";
			}
		}

		private void AnalyzeBitmap(Bitmap bitmap, TimeSpan time)
		{
			_result = _reader.Decode(
				bitmap.Buffers[0].Buffer.ToArray(),
				(int) bitmap.Buffers[0].Pitch,
				(int) bitmap.Dimensions.Height,
				RGBLuminanceSource.BitmapFormat.Gray8
				);
		}
	}
}