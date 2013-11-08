using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zen.Framework.Data
{
    /// <summary>
    /// 存储层接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> 
    {
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        void Copy(T source, T target);
        void Flush();
    }
}
