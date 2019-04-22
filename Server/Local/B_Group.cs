﻿using EntityLocal;
using System;
using System.Linq;
using System.Collections.Generic;
using Tool;

namespace Server.Local
{
    public class Group
    {
        long id;
        string name;
        string describe;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Describe { get => describe; set => describe = value; }        
    }

    public class B_Group : DBComponent
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<BGroup> SelectAll()
        {
            return Context(db =>
            {
                return db.BGroups.ToList();
            });
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool Add(Group group)
        {
            if (string.IsNullOrWhiteSpace(group.Name))
                return false;

            return Context(db =>
            {
                db.BGroups.InsertOnSubmit(new BGroup
                {
                    Gid = TRandom.Instance.GetRandomString(20),
                    Gname = group.Name,
                    Gdescribe = group.Describe,
                    Operator = "hjh",
                    Createtime = DateTime.Now,
                    Systime = DateTime.Now
                });

                db.SubmitChanges();

                return true;
            });
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool Update(Group group)
        {
            return Context(db =>
            {
                BGroup bGroup = db.BGroups.Where(i => i.Id == group.Id).FirstOrDefault();
                if (bGroup == null)
                    return false;

                bGroup.Gname = string.IsNullOrWhiteSpace(group.Name) ? bGroup.Gname : group.Name;
                bGroup.Gdescribe = string.IsNullOrWhiteSpace(group.Describe) ? bGroup.Gdescribe : group.Describe;

                db.SubmitChanges();

                return true;
            });
        }
        
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool Delete(Group group)
        {
            return Context(db =>
            {
                BGroup bGroup = db.BGroups.Where(i => i.Id == group.Id).FirstOrDefault();
                if (bGroup == null)
                    return false;

                db.BGroups.DeleteOnSubmit(bGroup);

                db.SubmitChanges();

                return true;
            });
        }
    }
}
