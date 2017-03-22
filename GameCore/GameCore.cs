using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameCore
{
    /// <summary>
    /// 游戏核心进程控制
    /// </summary>
    public static class GameLogic
    {


        public static int CheckFull()
        {
            return 0;       

        }
        /// <summary>
        /// 方块向左移动
        /// </summary>
        public static void MoveLeft(object data)
        {
            
        }
        /// <summary>
        /// 方块向右移动
        /// </summary>
        public static void MoveRight(object data)
        {
        
        }
        /// <summary>
        /// 方块直接下落
        /// </summary>
        public static void Down(object data)
        {
            Timer tmr = new Timer(Switch,null,0,1000);
        }
        /// <summary>
        /// 转化方块形状
        /// </summary>
        public static void Switch(object data)
        {

        }
    }
}
