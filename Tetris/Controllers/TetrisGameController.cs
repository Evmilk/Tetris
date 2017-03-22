using System.Web.Mvc;
using GameCore;

namespace Tetris.Controllers
{
    public class TetrisGameController : Controller
    {
        public static OriginPositon originPosition = new OriginPositon();
        // GET: TetrisGame
        public ActionResult Index()
        {
            originPosition.OnePosition();
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public string Start(string BType)
        {
            return "";
        }
        public string Left(string BType)
        {
            return originPosition.MoveLeft(null);
        }
        public string Right()
        {
            return originPosition.MoveRight(null) ;
        }
        public string Down(string BType)
        {
            if (BType == "8")
            {
                originPosition.TwoPosition();
            }
            return originPosition.Down(null);
        }
    }
}