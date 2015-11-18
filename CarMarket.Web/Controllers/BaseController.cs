//Snezhina
namespace CarMarket.Web.Controllers
{
    using System.Web.Mvc;
    using CarMarket.Data;

    public class BaseController : Controller
    {
        protected IUnitOfWorkData Data;

        public BaseController(IUnitOfWorkData data)
        {
            this.Data = data;
        }

        public BaseController()
            : this(new UnitOfWorkData())
        {
        }
    }
}