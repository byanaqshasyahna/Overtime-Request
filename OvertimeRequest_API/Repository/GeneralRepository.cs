﻿
using Microsoft.EntityFrameworkCore;
using OvertimeRequest_API.Context;
using OvertimeRequest_API.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace OvertimeRequest_API.Repository
{
    public class GeneralRepository<Context, Entity, Key> : IRepository<Entity,Key>
        where Entity : class
        where Context : MyContext
    {
        //AHihihihihihi
        private readonly MyContext myContext;
        private readonly DbSet<Entity> entities;

        public GeneralRepository(MyContext myContext)
        {
            this.myContext = myContext;
            entities = myContext.Set<Entity>(); ;
        }

        public int Delete(Entity entity)
        {
            var allData = entities.ToList();
            myContext.RemoveRange(allData);
            var result = myContext.SaveChanges();
            return result;
        }

        public int DeleteByKey(Key key)
        {
            var data = entities.Find(key);
            myContext.Remove(data);
            return myContext.SaveChanges();
        }

        public IEnumerable<Entity> Get()
        {
            return entities.ToList();
        }

        public Entity Get(Key key)
        {
            return entities.Find(key);
        }

        public int Insert(Entity entity)
        {
            entities.Add(entity);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Update(Entity entity)
        {
            myContext.Entry(entity).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
