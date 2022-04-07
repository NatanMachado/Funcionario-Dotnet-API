using FuncionarioApi.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioApi.Context
{
    public class DBFuncionarioContext : DbContext
    {
        public DBFuncionarioContext(DbContextOptions<DBFuncionarioContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}