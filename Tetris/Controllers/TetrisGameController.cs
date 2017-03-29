using System.Web.Mvc;
using GameCore;
using System.Collections.Generic;

namespace Tetris.Controllers
{
    public class TetrisGameController : Controller
    {
        public static int a = 1;
        public static List<string> I = new List<string>();
        public static List<string> i1 = new List<string>();
        public static OriginPositon originPosition = new OriginPositon();
        // GET: TetrisGame
        public ActionResult Index()
        {
            originPosition.OnePosition();

            return View();
        }
        public ActionResult Test()
        {
            i1.Add("1");
            return View(i1);
        }
        public ActionResult Test2()
        {
            return View(i1);
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
            return originPosition.MoveRight(null);
        }
        public string Down(string BType)
        {
            if (BType == "#div8")
            {
                if (a == 1)
                {
                    originPosition.TwoPosition();
                    foreach (var item in GameCore.Positions.PositionValue)
                    {
                        a++;
                        return originPosition.Down(null);
                    }

                }

                else
                {
                    foreach (var item in GameCore.Positions.PositionValue)
                    {
                        return originPosition.Down(null);
                    }

                }
            }
            return originPosition.Down(null);
        }
    }
}