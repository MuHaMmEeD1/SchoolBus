﻿using Microsoft.EntityFrameworkCore;
using SchoolBusModel.Entitys.abstrcut;
using ShcoolBusDataAccess.Contexts;
using ShcoolBusDataAccess.Repositoriess.Abstructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShcoolBusDataAccess.Repositoriess.Concrets
{
    public class BaseRepositories<T> : IBaseRepositories<T> where T : BaseEntity, new()
    {

        internal SchoolBusContext SchoolBusContext { get; set; }
        internal DbSet<T> Entity { get; set; }

        public BaseRepositories()
        {
            SchoolBusContext = new SchoolBusContext();
            Entity = SchoolBusContext.Set<T>();
        }

        public List<T> GetAllEntity()
        {

            return Entity.ToList();
        }

        public void Save()
        {
            SchoolBusContext.SaveChanges();
        }

        public void Add(T entity)
        {
            SchoolBusContext.Add(entity);
        }

        public void Delete(T entity)
        {
            SchoolBusContext.Remove(entity);
        }

        public T GetEntity(int id)
        {

            foreach (T entity in Entity)
            {
                if (entity.Id == id) { return entity; }
            }
            return Entity.ToList()[0];
        }
    }
}
