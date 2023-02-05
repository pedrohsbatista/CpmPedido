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
            if (!IsValid(cidadeDto) || cidadeDto.Id > 0)
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

        public long Update(CidadeDto cidadeDto)
        {
            var cidade = DbContext.Cidades.Find(cidadeDto.Id);

            if (cidade == null || !IsValid(cidadeDto))
                return 0;

            cidade.Nome = cidadeDto.Nome;
            cidade.Uf = cidadeDto.Uf;
            cidade.Ativo = cidadeDto.Ativo;

            try
            {
                DbContext.Cidades.Update(cidade);

                DbContext.SaveChanges();

                return cidade.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsValid(CidadeDto cidadeDto)
        {
            return !DbContext.Cidades.Any(x => x.Ativo 
                                        && x.Nome.ToUpper() == cidadeDto.Nome.ToUpper()
                                        && x.Id != cidadeDto.Id);
        }
    }
}
