using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;

namespace N27EntityFramwork
{
    class Program
    {
        /// <summary>
        /// 针对DotNetStudy的数据上下文对象
        /// </summary>
        private static readonly EFContainer Db = new EFContainer();
        static void Main(string[] args)
        {
            //Add();
            //Query();
            Edit2();
            //Delete();
            //Delete2();
            //Delete3();
            //SaveBatch();
        }

        #region 1 增 void Add()
        /// <summary>
        /// 1.0 新增
        /// </summary>
        private static void Add()
        {
            // 1.1 创建实体对象
            User uObj = new User() { uName = "Heab", uLoginName = "HeabKing", uAddtime = DateTime.Now, uIsDel = false, uPwd = "he394899990" };
            // 1.2 通过EF增加到数据库
            //      1.2.1 将对象加入到User集合中
            //Db.Users.Add(uObj);
            #region 使用Entry新增
            DbEntityEntry<User> entry = Db.Entry<User>(uObj);
            entry.State = System.Data.Entity.EntityState.Added;
            #endregion
            //      1.2.2 保存对象
            Db.SaveChanges();
        } 
        #endregion

        #region 2 查 void Query()
        private static void Query()
        {
            //// 2.0 注意: -- IEnumerable 和 IQueryable 不一样 
            ////      集合的 标准查询运算符方法 来自 System.Linq.Enumerable 里给IEnumerable中拓展的方法
            ////      EF上下文里的DBSet<T> 里面的 标准查询运算符方法 来自 System.Linq.Queryable 里给IQueryable 添加的拓展方法

            //// DbSet<T>:    表映射的实体数据对象
            //// DbQuery:     对实体对象进行的查询条件, 用来生成Sql语句, 只是还未生成

            //// 2.1 ★延迟加载★
            //// 延迟加载(延迟生成Sql语句)是通过DbQuery实现的 -- ▲1▲当前可能有多个Sqo方法来 组合 查询条件, 每个方法
            ////      只是添加了一个查询条件, 无法确定本次查询条件 是否结束, 所以, 没办法在每个Sqo方法执行的时候确定Sql语句是什么, 只能返回一个包含了所有添加了条件的 DbQuery 对象, 当使用这个 DbQuery对象的时候, 才根据所有条件 生成Sql 语句, 查询数据库
            //System.Data.Entity.Infrastructure.DbQuery dbQuery = Db.Users.Where(u => u.uLoginName == "Heab") as System.Data.Entity.Infrastructure.DbQuery;
            //// System.Data.Entity.Infrastructure命名空间是在EntityFramework中的

            //// ★延迟加载★ - 针对于 外键 的延迟
            //// ▲2▲: 对于外键属性, EF会在用到这个属性的时候才会去查外键表
            //IQueryable<UsersAddress> addrs = Db.UsersAddresses.Where(a => a.udUid == 1);    // 真实返回的是DbQuery<UsersAddress>
            //UsersAddress addr01 = addrs.FirstOrDefault();   // 查询了地址表
            //Console.WriteLine(addr01.User.uName);   // 使用了地址表的外键属性的时候, 会去查外键表
            // ▲3▲: △3.1△缺点: 每次调用外键实体时, 都会去查数据库(EF小优化: 相同外键实体只查询一次), 这在循环的时候太low了
            //IQueryable<UsersAddress> addrs = Db.UsersAddresses;
            //foreach (UsersAddress add in addrs)
            //{
            //    Console.WriteLine(string.Format("姓名: {0}    地址: {1}", add.User.uName, add.udAddress));
            //}
            // △3.2△解决方案: inner Join 联合查询 直接在查询的时候把外键表也查了
            IQueryable<UsersAddress> addrs = Db.UsersAddresses.Include("User"); // 生成的Sql有Inner Join
            foreach (UsersAddress add in addrs)
            {
                Console.WriteLine(string.Format("姓名: {0}    地址: {1}", add.User.uName, add.udAddress));
            }

            //// 2.3 变相的 即时查询
            //List<User> list = Db.Users.Where(u => u.uName == "Heab").ToList();
            //list.ForEach(u => Console.WriteLine(u.ToString()));
        } 
        #endregion

        /// <summary>
        /// 生成连接查询的第二种方法: 自动生成连接查询的方法
        /// </summary>
        private static void AutoQueryInnerJoin()
        {
            var addrs = Db.UsersAddresses.Where(a => a.udUid == 1).Select(a => new { aId = a.udId, aUsrName = a.User.uName });// aUsrName = a.User.uName 在使用Sqo的时候如果使用了关联表的数据, 则会自动生成连接查询
        }

        #region 3 改 void Edit() 先查后该 官方推荐 修改永远是按照主键来修改
        private static void Edit()
        {
            // 3.1 查出要修改的对象     --  注意: 此时返回的是一个 User类 的代理对象(包装类对象)
            // User user = Db.Users.Where(u => u.uName == "Heab").FirstOrDefault();    // 返回查询到的第一个元素, 如果不存在返回默认值
            User user = Db.Users.FirstOrDefault(u => u.uName == "Heab");    // 返回查询到的第一个元素, 如果不存在返回默认值
            Console.WriteLine("修改前: " + user.ToString());
            // 3.2 修改内容             --  注意: 此时实际操作的 是 代理类对象, 这些属性会将 值 设置给内部类 User对象的属性, 同时标记此属性为 已修改 状态
            user.uLoginName = "Change";
            // 3.3 重新保存到数据库     --  注意: 此时EF上下文会检查容器内 所有的对象 找到标记为 修改的对象, 然后找到标记为 修改的 属性, 生成对应的UPDATE语句 执行
            Db.SaveChanges();
            Console.WriteLine("修改后: " + user.ToString());
        } 
        #endregion

        #region 3.1 改  void Edit2() 创建对象直接改 自己优化 -- 我这个版本貌似不支持了

        private static void Edit2()
        {
            // 1. 自己新建对象 跟EF没有一毛钱关系
            User user = new User() {uId = 5, uLoginName = "3.1 改 创建对象直接改 自己优化"};
            // 2. 将对象加入EF容器
            //var u = Db.Users.Attach(user);  // 1. 将数据以"未修改"状态添加到上下文中, 就好像数据库查询出来的一样 2. 返回的实体类(不是代理类), 所以u.Name = xx 是不会生成Sql的   3. 所以这个方法总是会出各种错误, 在修改中不要用
            // 2. 将对象加入 EF容器, 返回的是 当前实体对象 的 状态管理 对象DbEntityEntry<User>
            DbEntityEntry<User> entry = Db.Entry<User>(user);
            // 3. 设置该对象未被修改过 -- 各个属性都设置为 "未修改"
            entry.State = System.Data.Entity.EntityState.Unchanged; // Ef6.x 里面不支持了
            // 4. 设置 该对象的 uName属性 为 "修改"状态, 同时entry.State被修改为Modifed状态, 到时候就知道生成的是UPDATE语句了
            entry.Property("uName").IsModified = true;
            // 5. 更新到数据库    -- EF上下文根据实体的状态生成Sql(根据entry.State -- Modefied(UPDATE), Deleted(DELETED))
            Db.SaveChanges();

            // 我这个版本不支持了貌似    本地验证异常
//            System.Data.Entity.Validation.DbEntityValidationException”类型的第一次机会异常在 EntityFramework.dll 中发生

//其他信息: 对一个或多个实体的验证失败。有关详细信息，请参阅“EntityValidationErrors”属性。
        }

        #endregion

        #region 4 删除 void Delete() 直接删除 Attach Remove方式
        private static void Delete()
        {
            // 4.1 创建要删除的对象
            User u = new User() { uId = 6 };    // 只能通过uId标志一个对象
            // 4.2 附加到EF中
            Db.Users.Attach(u);
            // 4.3 标记为删除
            Db.Users.Remove(u); // 把对象状态改成"删除"
            // 4.4 执行删除SQL
            Db.SaveChanges();
            Console.WriteLine("删除成功!");
            // 如果删除不存在的数据
            // "System.Data.Entity.Core.OptimisticConcurrencyException”类型的第一次机会异常在 EntityFramework.dll 中发生
            // 其他信息: 存储区更新、插入或删除语句影响到了意外的行数(0)。实体在加载后可能被修改或删除。刷新 ObjectStateManager 项。
        } 
        #endregion
        #region 4 删除 void Delete2() 直接删除 Entry 方式
        private static void Delete2()
        {
            // 4.1 创建要删除的对象
            User u = new User() {uId = 7};
            // 4.2 附加到EF中
            DbEntityEntry<User> entry = Db.Entry<User>(u);
            // 4.3 标记为删除
            entry.State = System.Data.Entity.EntityState.Deleted; // 把对象状态改成"删除"
            // 4.4 执行删除SQL
            Db.SaveChanges();
            Console.WriteLine("删除成功!");
            // 如果删除不存在的数据
            // "System.Data.Entity.Core.OptimisticConcurrencyException”类型的第一次机会异常在 EntityFramework.dll 中发生
            // 其他信息: 存储区更新、插入或删除语句影响到了意外的行数(0)。实体在加载后可能被修改或删除。刷新 ObjectStateManager 项。
        }
        #endregion

        #region 4 删除 void Delete3() 先查后删
        private static void Delete3()
        {
            // 1. 查询
            User us = Db.Users.FirstOrDefault(u => u.uId == 8);
            // 2. 删除
            if (us != null)
            {
                Db.Users.Remove(us);
            }
            else
            {
                Console.WriteLine("要删除的数据不存在!");
            }
            Db.SaveChanges();
        } 
        #endregion

        #region 5. 批处理 void SaveBatch() -- 上下文最大的好处

        private static void SaveBatch()
        {
            // 5.1 增
            User obj1 = new User()
            {
                uName = "Heab1",
                uLoginName = "LNHeab1",
                uPwd = "123",
                uIsDel = false,
                uAddtime = DateTime.Now
            };
            Db.Users.Add(obj1);

            // 5.2 增2
            User obj2 = new User()
            {
                uName = "Heab2",
                uLoginName = "LNHeab2",
                uPwd = "456",
                uIsDel = false,
                uAddtime = DateTime.Now
            };
            Db.Users.Add(obj2);

            //// 5.3 修改数据    -- 我这个版本貌似不支持了
            //User user = new User()
            //{
            //    uId = 5,
            //    uName = "wojiuxiugaile"
            //};
            //DbEntityEntry entry = Db.Entry<User>(user); // 获取给定实体的条目对象
            //entry.State = System.Data.Entity.EntityState.Unchanged;
            //entry.Property("uName").IsModified = true;

            // 5.3 修改数据
            User user = Db.Users.FirstOrDefault(u => u.uId == 6);
            if (user != null)
            {
                user.uLoginName = "daxionggege";    
            }

            //// 5.4 删除数据
            //User u = new User()
            //{
            //    uId = 4
            //};
            //Db.Users.Attach(u);
            //Db.Users.Remove(u);

            Db.SaveChanges();
        }

        #endregion

    }
}
