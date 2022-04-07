using FuncionarioApi.Context;
using FuncionarioApi.Models;
using FuncionarioApi.Models.Entity;

namespace FuncionarioApi.Data.Repositories
{

    public interface IFuncionarioRepository : IDisposable
    {
        IEnumerable<Funcionario> GetAll();
        Funcionario GetById(long id);
        void Insert(Funcionario entity);

        bool Exists(Func<Funcionario, bool> predicate);
    }

    public class FuncionarioRepository : IFuncionarioRepository, IDisposable
    {
        private DBFuncionarioContext context;
        public FuncionarioRepository(DBFuncionarioContext context)
        {
            this.context = context;
        }

        public IEnumerable<Funcionario> GetAll()
        {
            return context.Funcionarios.ToList();
        }

        public Funcionario? GetById(long id)
        {
            return context.Funcionarios.Find(id);
        }

        public void Insert(Funcionario entity)
        {
            context.Funcionarios.Add(entity);
            context.SaveChanges();
        }

        public bool Exists(Func<Funcionario, bool> predicate)
        {
            return context.Funcionarios.Where(predicate).Any();
        }
        
        public void Dispose()
        {
            context.Dispose();
        }

    }
}