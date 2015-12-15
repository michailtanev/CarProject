//Snezhina
namespace CarMarket.Web.Controllers
{
    using System.Web.Mvc;
    using CarMarket.Data;

    public class BaseController : Controller
    {
        protected ICarMarketData Data;
        protected IRepo SearchData;

        public BaseController(ICarMarketData data)
        {
            this.Data = data;
        }
        public BaseController(IRepo data)
        {
            this.SearchData = data;
        }
        public BaseController()
            : this(new CarMarketData())
        {
        }
    }
}