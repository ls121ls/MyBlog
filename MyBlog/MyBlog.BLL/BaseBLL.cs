using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.DAL;

namespace MyBlog.BLL
{
    public class BaseBLL<T> where T : class
    {
        public MyBlogModel db;
        private DbSet<T> dbSet;

        public BaseBLL()
        {
            db = new MyBlogModel();
            dbSet = db.Set<T>();
        }

        /// <summary>
        /// 获取全部实体
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAllEntities()
        {
            return dbSet;
        }

        public IQueryable<T> Take(int count)
        {
            return dbSet.Take(count);
        }

        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public List<T> GetEntities(Func<T, bool> whereLambda)
        {
            return dbSet.Where(whereLambda).ToList();
        }

        /// <summary>
        /// 根据id获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetEntity(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entities"></param>
        public void AddEntity(T entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
        }

        /// <summary>
        /// 导入实体
        /// </summary>
        /// <param name="entities"></param>
        public void ImportEntities(IList<T> entities)
        {
            //dbContext.Configuration.AutoDetectChangesEnabled = false;       ///关闭对象关联，提高添加速度
            foreach (var entity in entities)
            {
                dbSet.Add(entity);
            }
            //dbContext.Configuration.AutoDetectChangesEnabled = true;
            db.SaveChanges();
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateEntity(T entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="horResearchProject"></param>
        public void DeleteEntity(T entity)
        {
            dbSet.Remove(entity);
            //dbContext.SaveChanges();
        }


        /// <summary>
        /// 通用分页方法
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalCount"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public virtual IQueryable<T> LoadPageEntities<S>(System.Linq.Expressions.Expression<Func<T, bool>> whereLambda,
                                                         System.Linq.Expressions.Expression<Func<T, S>> orderBy,
                                                         int pageSize, int pageIndex, out int totalCount, bool isAsc)
        {
            //必须有：请求当前页，页的大小 ， 总页数  过滤条件

            totalCount = dbSet.Where(whereLambda).Count();

            IQueryable<T> enties = null;

            if (isAsc) //这是升序
            {
                enties = dbSet
                    .Where<T>(whereLambda)
                    .OrderBy<T, S>(orderBy) //语法糖
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);

            }
            else
            {
                enties = dbSet //降序查询
                    .Where<T>(whereLambda)
                    .OrderByDescending<T, S>(orderBy) //语法糖
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);

            }
            return enties;

        }
    }
}
