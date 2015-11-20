//Snezhina
namespace CarMarket.Web.Controllers
{
    using System.Web.Mvc;
    using CarMarket.Data;

    public class BaseController : Controller
    {
        protected ICarMarketData Data;

        public BaseController(ICarMarketData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new CarMarketData())
        {
        }
    }
}