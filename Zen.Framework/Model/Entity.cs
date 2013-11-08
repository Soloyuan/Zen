using System;

namespace Zen.Framework.Domain
{
    /// <summary>
    /// 实体的基类
    /// </summary>
    public abstract class Entity
    {
        int? _requestedHashCode;

        public Entity()
        {
            //有效减少GUID作为数据库主键引起的索引碎片，提高主键索引效率
            this.Id = IdentityGenerator.NewSequentialGuid().ToString();
        }

        /// <summary>
        /// 主键
        /// </summary>
        public virtual string Id { get; private set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateTime { get; private set; }

        /// <summary>
        /// 并发控制
        /// </summary>
        public virtual int Version { get; private set; }

        /// <summary>
        /// 判断对象是否是非持久化对象
        /// </summary>
        public bool IsTransient()
        {
            //其实在构造函数里赋了Id的初值，这个判断会一直是false
            return this.Id == string.Empty;
        }

        /// <summary>
        /// 允许从外部赋值Id，应注意使用IdentityGenerator.NewSequentialGuid()方法去生成Id
        /// </summary>
        /// <param name="identity"></param>
        public void ChangeCurrentIdentity(string identity)
        {
            if (identity != string.Empty)
                this.Id = identity;
        }

        #region Overrides Methods

        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/></param>
        /// <returns><see cref="M:System.Object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.Id == this.Id;
        }

        /// <summary>
        /// <see cref="M:System.Object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="M:System.Object.GetHashCode"/></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.Id.GetHashCode() ^ 31; // XOR for random distribution (http://blogs.msdn.com/b/ericlippert/archive/2011/02/28/guidelines-and-rules-for-gethashcode.aspx)

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion
    }
}
