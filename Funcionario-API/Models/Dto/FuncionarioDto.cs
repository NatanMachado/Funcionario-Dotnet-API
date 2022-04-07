namespace FuncionarioApi.Middlewares.Dto
{
    public class FuncionarioDto
    {
        public FuncionarioDto(long? id)
        {
            this.Id = id;
        }
        public long? Id { get; }
    }
}