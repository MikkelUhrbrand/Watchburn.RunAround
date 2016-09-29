using System.Threading.Tasks;

namespace Watchburn.RunAround.Services
{
	public interface IQrCodeScanningService
	{
		Task<string> ScanAsync();
	}
}