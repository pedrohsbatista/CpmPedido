using CpmPedido.Domain.Dtos;
using CpmPedido.Domain.Entities;
using CpmPedido.Interface.Repositories;
using CpmPedido.Repository.Common;

namespace CpmPedido.Repository.Repositories
{
    public class CidadeRepository : BaseRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public dynamic Get()
        {
            return DbContext.Cidades
                            .Where(x => x.Ativo)
                            .Select(x => new
                                {
                                    x.Id,
                                    x.Nome,
                                    x.Uf,
                                    x.Ativo
                                })
                            .ToList();
        }

        public long Insert(CidadeDto cidadeDto)
        {
            var exists = DbContext.Cidades.Any(x => x.Ativo && x.Nome.ToUpper() == cidadeDto.Nome.ToUpper());

            if (exists || cidadeDto.Id > 0)
                return 0;

            var cidade = new Cidade
            {
                Nome = cidadeDto.Nome,
                Uf = cidadeDto.Uf,
                Ativo = cidadeDto.Ativo
            };

            try
            {
                DbContext.Cidades.Add(cidade);

                DbContext.SaveChanges();

                return cidade.Id;
            }
            catch (Exception)
            {
                throw;
            }           
        }
    }
}
