using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    /// <summary>
    /// 俄罗斯方块21列10行 方块数据表达
    /// </summary>
    public static class Positions
    {
        //记录方块位置与数据(0为空，1为占据)
        public static int[,] PositionValue = new int[21, 10];
        //记录单一方块坐标，用二维数组表示
        public static int[,] StationPre = new int[2, 4];
        //只存储一个值(旋转定位中心) 表示方式[x,y]
        public static Dictionary<string,int> Rotateflag ;

    }


    public class OriginPositon : IPositions
    {
        #region 初始图形位置定位 各x方向位置 从零开始计算 0,1,2,3..........
        //返回图形位置
        /*
        表达时注意数组的属性从零开始计算
             */

        /*
      表达形状   00
                  00  
          */
        public void OnePosition()
        {
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[19, 4] = 1;
            Positions.PositionValue[19, 5] = 1;
            OriStatePre(new int[] { 3, 4, 4, 5 }, new int[] { 20, 20, 19, 19 },4,20);
        }
        /*
         表达形状   0000
           
         */
        public void TwoPosition()
        {
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[20, 5] = 1;
            Positions.PositionValue[20, 6] = 1;
            OriStatePre(new int[] { 3, 4, 5, 6 }, new int[] { 20, 20, 20, 20 },5,20);

        }
        /*
         表达形状   00
                   00
           */
        public void ThreePosition()
        {
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[19, 3] = 1;
            Positions.PositionValue[19, 2] = 1;
            OriStatePre(new int[] { 4, 3, 3, 2 }, new int[] { 20, 20, 19, 19 },3,20);
        }
        /*
         表达形状   00
                    00
           */
        public void FourPosition()
        {
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[19, 3] = 1;
            Positions.PositionValue[19, 4] = 1;
            //此单元只赋值不旋转
            OriStatePre(new int[] { 3, 4, 3, 4 }, new int[] { 20, 20, 19, 19 },0,0);
        }
        /*
         表达形状   0
                    000
           */
        public void FivePosition()
        {
            Positions.PositionValue[20, 3] = 1;
            Positions.PositionValue[19, 3] = 1;
            Positions.PositionValue[19, 4] = 1;
            Positions.PositionValue[19, 5] = 1;
            OriStatePre(new int[] { 3, 3, 4, 5 }, new int[] { 20, 19, 19, 19 },4,19);

        }
        /*
         表达形状    0
                    000
           */
        public void SixPosition()
        {
            Positions.PositionValue[19, 3] = 1;
            Positions.PositionValue[20, 4] = 1;
            Positions.PositionValue[19, 4] = 1;
            Positions.PositionValue[19, 5] = 1;
            OriStatePre(new int[] { 3, 4, 4, 5 }, new int[] { 19, 20, 19, 19 },4,19);

        }
        /*
         表达形状     0
                    000
           */
        public void SevenPosition()
        {
            Positions.PositionValue[19, 3] = 1;
            Positions.PositionValue[19, 4] = 1;
            Positions.PositionValue[19, 5] = 1;
            Positions.PositionValue[20, 5] = 1;
            OriStatePre(new int[] { 3, 4, 5, 5 }, new int[] { 19, 19, 19, 20 },4,19);
        }
        #endregion

        #region 七组四个方块定位记录计算
        /// <summary>
        /// 传递坐标数据 x,y 
        /// 
        /// </summary>
        /// <param name="x">坐标x数组数据</param>
        /// <param name="y">坐标y数组数据</param>
        /// <returns></returns>
        public static void OriStatePre(int[] x, int[] y, int rotateX, int rotateY)
        {
            for (int i = 0; i < 4; i++)
            {
                Positions.StationPre[0, i] = x[i];
            }
            for (int i = 0; i < 4; i++)
            {
                Positions.StationPre[1, i] = y[i];
            }
            try
            {
                Positions.Rotateflag.Remove("x");
                Positions.Rotateflag.Remove("y");
                Positions.Rotateflag.Add("x", rotateX);
                Positions.Rotateflag.Add("y", rotateY);
            }
            catch (Exception)
            {
                Positions.Rotateflag.Add("x", rotateX);
                Positions.Rotateflag.Add("y", rotateY);
            }
        }
        #endregion
        /// <summary>
        /// 方块向左移动
        /// </summary>
        public string MoveLeft(object data)
        {
            //左移动作 
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                if (Positions.StationPre[0, x] == 0)
                {
                    return "到达边界";
                }
            }
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 0;
            }
            //右移赋值 y方向值不变， x方向值加 1
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.StationPre[0, x] = Positions.StationPre[0, x] - 1;
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
            }

            return "左移返回消息";
        }
        /// <summary>
        /// 方块向右移动
        /// </summary>
        public string MoveRight(object data)
        {
            //右移动作
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                if (Positions.StationPre[0, x] == 9)
                {
                    return "到达边界";
                }
            }

            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 0;
            }

            //右移赋值 y方向值不变， x方向值加 1
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.StationPre[0, x] = Positions.StationPre[0, x] + 1;
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
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
                return "碰撞";
            }
            for (int y = 0; y < Positions.StationPre.GetLength(1); y++)
            {
                //判断是否是到达底部的状态 如果是者执行完直接返回 到达底部信息
                if (Positions.StationPre[1, y] == 1)
                {
                    for (int i = 0; i < Positions.StationPre.GetLength(1); i++)
                    {
                        Positions.PositionValue[Positions.StationPre[1, i], Positions.StationPre[0, i]] = 0;
                    }

                    for (int Z = 0; Z < Positions.StationPre.GetLength(1); Z++)
                    {
                        Positions.StationPre[1, Z] = Positions.StationPre[1, Z] - 1;
                        Positions.PositionValue[Positions.StationPre[1, Z], Positions.StationPre[0, Z]] = 2;
                    }
                    return "到达底部";
                }
            }

            #region 正常没有到达底部时的执行
            for (int y = 0; y < Positions.StationPre.GetLength(1); y++)
            {
                Positions.PositionValue[Positions.StationPre[1, y], Positions.StationPre[0, y]] = 0;
            }

            for (int y = 0; y < Positions.StationPre.GetLength(1); y++)
            {
                Positions.StationPre[1, y] = Positions.StationPre[1, y] - 1;
                Positions.PositionValue[Positions.StationPre[1, y], Positions.StationPre[0, y]] = 1;
            }
            return "向下移动返回消息";
            #endregion
        }


        /// <summary>
        /// 方块变形
        /// </summary>
        public string Switch(object data)
        {
            foreach (var item in Positions.StationPre)
            {

            }
       
            int a = (int)((2 - 1) * Math.Cos(90) - (2 - 1) * Math.Sin(90) + 1);
            int b = (int)((2 - 1) * Math.Sin(90) + (2 - 1) * Math.Cos(90) + 1);
            return "";
        }
        /// <summary>
        /// 辅助功能 初始化定位中心
        /// </summary>
        /// <param name="x">旋转中心 x 坐标</param>
        /// <param name="y">旋转中心 y 坐标</param>
        public void CenterRotate(int x,int y)
        {

        }
        public bool CheckXY()
        {
            for (int checkXY = Positions.StationPre.GetLength(1) - 1; 0 <= checkXY; checkXY--)
            {
                if (Positions.PositionValue[Positions.StationPre[1, checkXY] - 1 > 0 ? Positions.StationPre[1, checkXY] - 1 : 0, Positions.StationPre[0, checkXY]] == 2)
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
