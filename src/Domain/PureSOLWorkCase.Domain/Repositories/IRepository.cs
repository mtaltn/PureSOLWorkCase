﻿namespace PureSOLWorkCase.Domain;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    T GetById(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}