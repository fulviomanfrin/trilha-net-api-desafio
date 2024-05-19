using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Contracts;

public interface ITarefaRepository
{
    public Task<Tarefa> Create(Tarefa tarefa);
    public Task<Tarefa> Update(Tarefa tarefa);
    public Task Delete(int id);
    public IQueryable<Tarefa> GetAll();
    public IQueryable<Tarefa> GetById(int id);
    public IQueryable<Tarefa> GetByTitle(string title);
    public IQueryable<Tarefa> GetByDate(DateTime date);
}