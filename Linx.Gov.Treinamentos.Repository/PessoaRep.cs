using System.Collections.Generic;
using System.Linq;
using Linx.Gov.Treinamentos.Model;

namespace Linx.Gov.Treinamentos.Repository
{
    public class PessoaRep
    {
        //aprender repositorio Generico

        public List<PessoaMod> ListaPessoas()
        {
            using (var conexao = new treinamentoEntities())
            {
                return conexao.TB_PESSOA.ToList().ConvertAll(x => new PessoaMod()
                {
                    Id = x.ID_PESSOA,
                    Nome = x.NM_PESSOA,
                    endereco = x.EN_PESSOA,
                    Email = x.EM_PESSOA,
                    DataNascimento = x.DTNASC_PESSOA,
                    Genero = new GeneroMod()
                    {
                        Id = x.TB_GENERO.ID_GENERO,
                        Descricao = x.TB_GENERO.DS_GENERO
                    }
                });
            }
        }

        public void AdicionarPessoa(PessoaMod dadosPessoa)
        {
            using (var conexao = new treinamentoEntities())
            {
                conexao.TB_PESSOA.Add(new TB_PESSOA
                {
                    NM_PESSOA = dadosPessoa.Nome,
                    EN_PESSOA = dadosPessoa.endereco,
                    EM_PESSOA = dadosPessoa.Email,
                    DTNASC_PESSOA = dadosPessoa.DataNascimento,
                    ID_GENERO = dadosPessoa.Genero.Id
                });
                //aqui executamos o savechanges e assim ele grava as alterações no banco
                conexao.SaveChanges();
            }
        }

        public void ExcluirPessoa(int id)
        {
            using (var conexao = new treinamentoEntities())
            {

                conexao.TB_PESSOA.Remove(conexao.TB_PESSOA.Single(x => x.ID_PESSOA.Equals(id)));
                conexao.SaveChanges();
            }
        }

        public PessoaMod retornapessoa(int id)
        {
            using (var conexao = new treinamentoEntities())
            {
                var resultado = conexao.TB_PESSOA.Single(x => x.ID_PESSOA.Equals(id));
                return new PessoaMod
                {
                    Id = resultado.ID_PESSOA,
                    Nome = resultado.NM_PESSOA,
                    endereco = resultado.EN_PESSOA,
                    Email = resultado.EM_PESSOA,
                    DataNascimento = resultado.DTNASC_PESSOA,
                    Genero = new GeneroMod
                    {
                        Id = resultado.TB_GENERO.ID_GENERO,
                        Descricao = resultado.TB_GENERO.DS_GENERO
                    }
                };
            }
        }

        public void AlterarPessoa(int id, PessoaMod dadosPessoa)
        {
            using (var conexao = new treinamentoEntities())
            {
                var pessoa = conexao.TB_PESSOA.Single(x => x.ID_PESSOA.Equals(id));

                pessoa.NM_PESSOA = dadosPessoa.Nome;
                pessoa.EN_PESSOA = dadosPessoa.endereco;
                pessoa.EM_PESSOA = dadosPessoa.Email;
                pessoa.DTNASC_PESSOA = dadosPessoa.DataNascimento;
                pessoa.ID_GENERO = dadosPessoa.Genero.Id;

                conexao.SaveChanges();
            }
        }
    }
}

