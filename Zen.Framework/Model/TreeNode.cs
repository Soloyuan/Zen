using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zen.Framework.Domain
{
    /// <summary>
    /// 树节点
    /// </summary>
    public abstract class TreeNode : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Text { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sorting { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        public virtual string Parent { get; set; }
        
        /// <summary>
        /// 是否叶
        /// </summary>
        public virtual bool IsLeaf { get; set; }
        
        /// <summary>
        /// 深度
        /// </summary>
        public virtual int NodeLevel { get; set; }
        
        /// <summary>
        /// 节点组
        /// </summary>
        public virtual string TreeIds { get; set; }

        /// <summary>
        /// 在添加节点时处理节点的深度和TreeIds
        /// </summary>
        /// <param name="parentEntity"></param>
        public virtual void Bulid(TreeNode parentEntity)
        {
            if (parentEntity == null)
            {
                TreeIds = Id;
                NodeLevel = 1;
            }
            else
            {
                TreeIds = parentEntity.TreeIds + "," + Id;
                NodeLevel = parentEntity.NodeLevel + 1;
            }
        }
    }
}
