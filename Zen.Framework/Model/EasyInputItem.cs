using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zen.Framework.Domain
{
    /// <summary>
    /// 维护后便于录入的项
    /// </summary>
    public class EasyInputItem : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// 五笔码
        /// </summary>
        public virtual string Wb { get; set; }

        /// <summary>
        /// 拼音码
        /// </summary>
        public virtual string Py { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sorting { get; set; }
    }
}
