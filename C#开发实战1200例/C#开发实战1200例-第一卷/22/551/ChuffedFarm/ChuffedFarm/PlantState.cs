using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChuffedFarm
{
        public enum PlantState
        {
            /// <summary>
            /// 无任何操作
            /// </summary>
            Nothing = 0,
            /// <summary>
            /// 播种
            /// </summary>
            Inseminate = 1,
            /// <summary>
            /// 生长
            /// </summary>
            Vegetate = 2,
            /// <summary>
            /// 开花
            /// </summary>
            BlossomOut = 3,
            /// <summary>
            /// 结果
            /// </summary>
            MakeFruitage = 4,
            /// <summary>
            /// 收获
            /// </summary>
            Harvest = 5
        }
}
