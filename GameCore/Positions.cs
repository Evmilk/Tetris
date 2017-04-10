using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

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
        public static int RotateX;
        public static int RotateY;

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
            OriStatePre(new int[] { 3, 4, 4, 5 }, new int[] { 20, 20, 19, 19 }, 4, 20);
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
            OriStatePre(new int[] { 3, 4, 5, 6 }, new int[] { 20, 20, 20, 20 }, 5, 20);

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
            OriStatePre(new int[] { 4, 3, 3, 2 }, new int[] { 20, 20, 19, 19 }, 3, 20);
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
            OriStatePre(new int[] { 3, 4, 3, 4 }, new int[] { 20, 20, 19, 19 }, 0, 0);
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
            OriStatePre(new int[] { 3, 3, 4, 5 }, new int[] { 20, 19, 19, 19 }, 4, 19);

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
            OriStatePre(new int[] { 3, 4, 4, 5 }, new int[] { 19, 20, 19, 19 }, 4, 19);

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
            OriStatePre(new int[] { 3, 4, 5, 5 }, new int[] { 19, 19, 19, 20 }, 4, 19);
        }
        #endregion

        #region 七组四个方块定位记录计算
        /// <summary>
        /// 传递坐标数据 x,y 
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

            Positions.RotateX = rotateX;
            Positions.RotateY = rotateY;
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
            //上一个判断已经判断是否在边界，不用担心超出索引长度 如果碰撞者返回
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
               int XCol = Positions.StationPre[0, x] - 1;
                if (Positions.PositionValue[Positions.StationPre[1, x], XCol] == 2)
                {
                    for (int i = Positions.StationPre.GetLength(1) - 1; 0 <= i; i--)
                    {
                        Positions.PositionValue[Positions.StationPre[1, i], Positions.StationPre[0, i]] = 2;
                    }
                    return "无法移动";
                }
            }
            MakeZero();
            //右移赋值 y方向值不变， x方向值加 1
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.StationPre[0, x] = Positions.StationPre[0, x] - 1;
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
            }

            Positions.RotateX = Positions.RotateX - 1;
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
            //上一个判断已经判断是否在边界，不用担心超出索引长度 如果碰撞者返回
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                int XCol = Positions.StationPre[0, x] + 1;
                if (Positions.PositionValue[Positions.StationPre[1, x], XCol] ==2)
                {
                    for (int i = Positions.StationPre.GetLength(1) - 1; 0 <= i; i--)
                    {
                        Positions.PositionValue[Positions.StationPre[1, i], Positions.StationPre[0, i]] = 2;
                    }
                    return "无法移动";
                }
            }

            MakeZero();

            //右移赋值 y方向值不变， x方向值加 1
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.StationPre[0, x] = Positions.StationPre[0, x] + 1;
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
            }

            Positions.RotateX = Positions.RotateX + 1;

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
            #region 正常没有到达底部时的执行

            MakeZero();
            //检查下一布是否到底部 是的话则全部重新赋值 为2
            for (int y = 0; y < Positions.StationPre.GetLength(1); y++)
            {
                if (Positions.StationPre[1, y] == 1)
                {
                    for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
                    {
                        Positions.StationPre[1, x] = Positions.StationPre[1, x] - 1;
                        Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 2;
                        return "到达底部";
                    }
                }
            }
            //正常下落判断
            for (int y = 0; y < Positions.StationPre.GetLength(1); y++)
            {
                Positions.StationPre[1, y] = Positions.StationPre[1, y] - 1;
                Positions.PositionValue[Positions.StationPre[1, y], Positions.StationPre[0, y]] = 1;
            }
            //旋转坐标 Y方向 减一
            Positions.RotateY = Positions.RotateY - 1;
            return "向下移动返回消息";
            #endregion
        }


        /// <summary>
        /// 方块变形
        /// </summary>
        public string Switching(object data)
        {

            //判断是否适合旋转 若不适合旋转直接返回
            for (int xy = 0; xy < Positions.StationPre.GetLength(1); xy++)
            {
                int tempX = (int)Math.Round((Positions.StationPre[0, xy] - Positions.RotateX) * Math.Cos(Math.PI * 90 / 180) - (Positions.StationPre[1, xy] - Positions.RotateY) * Math.Sin(Math.PI * 90 / 180) + Positions.RotateX);
                int tempY = (int)Math.Round((Positions.StationPre[0, xy] - Positions.RotateX) * Math.Sin(Math.PI * 90 / 180) + (Positions.StationPre[1, xy] - Positions.RotateY) * Math.Cos(Math.PI * 90 / 180) + Positions.RotateY);
               //判断是否 到边界可以旋转 ,旋转是否有碰撞
                if (tempX < 0 || tempX > 9 || tempY < 0 || tempY > 20 || (Positions.PositionValue[tempY, tempX] == 2))
                {
                    return "无法旋转";
                }
            }

            MakeZero();
            //进行旋转 并记录旋转后的新坐标
            for (int xy = 0; xy < Positions.StationPre.GetLength(1); xy++)
            {
                int tempX = (int)Math.Round((Positions.StationPre[0, xy] - Positions.RotateX) * Math.Cos(Math.PI * 90 / 180) - (Positions.StationPre[1, xy] - Positions.RotateY) * Math.Sin(Math.PI * 90 / 180) + Positions.RotateX);
                int tempY = (int)Math.Round((Positions.StationPre[0, xy] - Positions.RotateX) * Math.Sin(Math.PI * 90 / 180) + (Positions.StationPre[1, xy] - Positions.RotateY) * Math.Cos(Math.PI * 90 / 180) + Positions.RotateY);
                Positions.StationPre[0, xy] = tempX;
                Positions.StationPre[1, xy] = tempY;
            }

            //对旋转后的坐标赋值为 1
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 1;
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            string s = js.Serialize(Positions.StationPre);
            return s;
        }

        //变换或者移动之前全部赋值为 0
        public void MakeZero()
        {
            for (int x = 0; x < Positions.StationPre.GetLength(1); x++)
            {
                Positions.PositionValue[Positions.StationPre[1, x], Positions.StationPre[0, x]] = 0;
            }
        }
        //判断是否 碰撞
        public bool CheckXY()
        {
            for (int checkXY = Positions.StationPre.GetLength(1) - 1; 0 <= checkXY; checkXY--)
            {
                //判断是否对下面碰撞
                if (Positions.PositionValue[Positions.StationPre[1, checkXY] - 1 >= 0 ? Positions.StationPre[1, checkXY] - 1 : 0, Positions.StationPre[0, checkXY]] == 2)
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
