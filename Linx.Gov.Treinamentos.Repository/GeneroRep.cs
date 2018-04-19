using System.Collections.Generic;
using System.Linq;
using Linx.Gov.Treinamentos.Model;

namespace Linx.Gov.Treinamentos.Repository
{
    public class GeneroRep
    {
        public List<GeneroMod> ListaGeneros()
        {
            using (var conexao = new treinamentoEntities())
            {
                //aqui nos fisemos um select na tabela de genero
                //pegando todos os generos cadastrados no banco e retornando para o nosso repositorio
                //apos receber o retorno nos convertemos para uma classe de modelo
                //e assim retornamos o resultado da solicitação a camada solicitante
                //select * From tb_genero
                conexao.TB_GENERO.ToList();
                return conexao.TB_GENERO.ToList().ConvertAll(x => new GeneroMod()
                {
                    Id = x.ID_GENERO,
                    Descricao = x.DS_GENERO
                });
            }
        }
    }
}
