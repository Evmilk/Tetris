using System.Web.Mvc;
using GameCore;
using System.Collections.Generic;
using System;

namespace Tetris.Controllers
{
    public class TetrisGameController : Controller
    {
        public static OriginPositon originPosition = new OriginPositon();
        // GET: TetrisGame
        public ActionResult Index()
        {
            return View();
        }

        #region ForTest

        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Test2()
        {
            return View();
        }

        #endregion

        public string Start()
        {
               return   Genarate();
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
            return originPosition.Down(null);
        }

        public string Switching(string BType)
        {
            return originPosition.Switching(null);
        }
        /// <summary>
        /// 生成 方块
        /// </summary>
        /// <returns></returns>
        public string Genarate()
        {
            Random random = new Random();
            int ran = random.Next(1, 7);
            switch (ran)
            {
                case 1: originPosition.OnePosition(); break;
                case 2: originPosition.TwoPosition(); break;
                case 3: originPosition.ThreePosition(); break;
                case 4: originPosition.FourPosition(); break;
                case 5: originPosition.FivePosition(); break;
                case 6: originPosition.SixPosition(); break;
                case 7: originPosition.SevenPosition(); break;
                default: break;
            }
            return "#div"+ran;
        }
    }
}