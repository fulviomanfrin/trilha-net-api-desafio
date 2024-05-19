using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Contracts;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly OrganizadorContext _context;

    public TarefaRepository(OrganizadorContext context)
    {
        _context = context;
    }
    
    public async Task<Tarefa> Create(Tarefa tarefa)
    {
         _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();

        return tarefa;
    }

    public Task<Tarefa> Update(Tarefa tarefa)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Tarefa> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Tarefa> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Tarefa> GetByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Tarefa> GetByDate(DateTime date)
    {
        throw new NotImplementedException();
    }
}