using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public static class Positions
    {
        //记录方块位置与数据(0为空，1为占据)
        public static int[,] PositionValue = new int[21, 10];
        //记录单一方块坐标，用二维数组表示
        public static int[,] StationPre = new int[2, 4];
        /// <summary>
        /// 方块坐标轴竖值位置(列)位置
        /// </summary>
        static public int X = 4;
        /// <summary>
        ///方块坐标轴平行(行)位置
        /// </summary>
        static public int Y = 24;
    }
    public class OriginPositon : IPositions
    {
        #region 初始图形位置定位
        //返回图形位置
        public void OnePosition()
        {
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[19, 4] = 1;
            Positions.PositionValue[19, 5] = 1;
            OriStatePre(new int[] { 3, 4, 4, 5 }, new int[] { 20, 20, 19, 19 });
        }
        //返回图形位置    
        public void TwoPosition()
        {
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[19, 4] = 1;
            Positions.PositionValue[19, 5] = 1;
            OriStatePre(new int[] { 3, 4, 4, 5 }, new int[] { 20, 20, 19, 19 });

        }
        //返回图形位置
        public int[,] ThreePosition()
        {
            Positions.PositionValue[4, 25] = 1;
            Positions.PositionValue[5, 25] = 1;
            Positions.PositionValue[5, 24] = 1;
            Positions.PositionValue[6, 24] = 1;
            return Positions.PositionValue;
        }
        //返回图形位置
        public int[,] FourPosition()
        {
            Positions.PositionValue[4, 25] = 1;
            Positions.PositionValue[5, 25] = 1;
            Positions.PositionValue[5, 24] = 1;
            Positions.PositionValue[6, 24] = 1;
            return Positions.PositionValue;

        }
        //返回图形位置
        public int[,] FivePosition()
        {
            Positions.PositionValue[4, 25] = 1;
            Positions.PositionValue[5, 25] = 1;
            Positions.PositionValue[5, 24] = 1;
            Positions.PositionValue[6, 24] = 1;
            return Positions.PositionValue;

        }
        //返回图形位置
        public int[,] SixPosition()
        {
            Positions.PositionValue[4, 25] = 1;
            Positions.PositionValue[5, 25] = 1;
            Positions.PositionValue[5, 24] = 1;
            Positions.PositionValue[6, 24] = 1;
            return Positions.PositionValue;

        }
        //返回图形位置                                
        public int[,] SevenPosition()
        {
            Positions.PositionValue[4, 25] = 1;
            Positions.PositionValue[5, 25] = 1;
            Positions.PositionValue[5, 24] = 1;
            Positions.PositionValue[6, 24] = 1;
            return Positions.PositionValue;

        }
        #endregion

        #region 七组四个方块定位记录计算
        /// <summary>
        /// 传递坐标数据 x,y
        /// </summary>
        /// <param name="x">坐标x数组数据</param>
        /// <param name="y">坐标y数组数据</param>
        /// <returns></returns>
        public static int[,] OriStatePre(int[] x, int[] y)
        {
            for (int i = 0; i < 4; i++)
            {
                Positions.StationPre[0, i] = x[i];
            }
            for (int i = 0; i < 4; i++)
            {
                Positions.StationPre[1, i] = y[i];
            }
            return Positions.StationPre;
        }
        #endregion
        /// <summary>
        /// 方块向左移动
        /// </summary>
        public string MoveLeft(object data)
        {
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                if (CheckXY())
                {
                    return "到达底部";
                }
                if (!(Positions.StationPre[0, x] < 1))
                {
                    Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 0;
                    Positions.StationPre[0, x] = Positions.StationPre[0, x] - 1;
                    Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
                }
                else
                {
                    return "到达边界";
                }
            }
            return "左移返回消息";
        }
        /// <summary>
        /// 方块向右移动
        /// </summary>
        public string MoveRight(object data)
        {

            for (int x = Positions.StationPre.GetLength(1)-1; 0 <=x; x--)
            {
                if (CheckXY())
                {
                    return "到达底部";
                }
                    if (Positions.StationPre[0, x] < 9)
                {
                    Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 0;
                
                    Positions.StationPre[0, x] = Positions.StationPre[0, x] + 1;
                    Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
                }
                else
                {
                    return "到达边界";
                }
            }
            return "右移返回消息";
        }
        /// <summary>
        /// 方块下落
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string Down(object data)
        {
            if (CheckXY())
            {
                return "到达底部";
            }
            for (int y = 0; y < Positions.StationPre.GetLength(1); y++)
            {
                if (!(Positions.StationPre[1, y] < 1))
                {
                    Positions.PositionValue[Positions.StationPre[1, y], Positions.StationPre[0, y]] = 0;
                    Positions.StationPre[1, y] = Positions.StationPre[1, y] - 1;
                    Positions.PositionValue[Positions.StationPre[1, y], Positions.StationPre[0, y]] = 1;
                }
                else
                {
                    Positions.PositionValue[Positions.StationPre[1, y], Positions.StationPre[0, y]] = 2;
                    return "到达底部";
                }                
            }
            return "向下移动返回消息";
        }
        /// <summary>
        /// 方块变形
        /// </summary>
        public string Switch(object data)
        {
            return "";
        }

        public bool CheckXY()
        {
            for (int checkXY = Positions.StationPre.GetLength(1) - 1; 0 <= checkXY; checkXY--)
            {
                if (Positions.PositionValue[Positions.StationPre[1, checkXY], Positions.StationPre[0, checkXY]] == 2)
                {
                    for (int i = Positions.StationPre.GetLength(1) - 1; 0 <= i; i--)
                    {
                        Positions.PositionValue[Positions.StationPre[1, i], Positions.StationPre[0, i]] = 2;

                    }
                    return true;
                }
            }
            return false;
        }
    }


}
