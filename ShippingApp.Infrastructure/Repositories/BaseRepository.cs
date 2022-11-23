﻿using ShippingApp.Application.Repository;
using ShippingApp.Domain.Entities;

namespace ShippingApp.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext dbContext;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T? GetById(int id)
        {
            return Query().FirstOrDefault(x => x.Id == id);
        }
        public IQueryable<T> Query()
        {
            return dbContext.Set<T>();
        }
        public T Create(T entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public T Update(T entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
            return entity;
        }
        public T Delete(T entity)
        {
            dbContext.Remove(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}