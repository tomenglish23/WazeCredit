using WazeCredit.Models;

namespace WazeCredit.Service
{
    public interface IMarketForcaster
    {
        MarketResult GetMarketPrediction();
    }
}