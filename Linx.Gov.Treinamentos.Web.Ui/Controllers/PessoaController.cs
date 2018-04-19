using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;
using Linx.Gov.Treinamentos.Model;
using Linx.Gov.Treinamentos.Repository;

namespace Linx.Gov.Treinamentos.Web.Ui.Controllers
{
    public class PessoaController : Controller
    {
        private readonly GeneroRep _generoRep = new GeneroRep();
        private readonly PessoaRep _pessoaRep = new PessoaRep();

        #region HTTPGET
        // GET: Pessoa
        //aqui voce retorna uma view no padrao MVC
        public ActionResult Index()
        {
            //aqui nos geramos um select list que vai popular um dropdow
            //da nossa tela com os generos gerados pela controle
            ViewBag.Generos = new SelectList(_generoRep.ListaGeneros(), "Id", "Descricao");
            return View(new PessoaMod() { DataNascimento = DateTime.Now });
        }

        [HttpGet]
        public ActionResult lista()
        {
            return View(_pessoaRep.ListaPessoas());
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                _pessoaRep.ExcluirPessoa(id);

                TempData.Add("MensagemOK",
                    String.Format("Client {0} Excluido com Sucesso",
                        id));
            }
            catch (Exception)
            {

                TempData.Add("MenssagemErro",
                    "Não foi Possivel Excluir o usuario");
            }
            return RedirectToAction("Lista");
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {

            try
            {


                ViewBag.Generos = new SelectList(_generoRep.ListaGeneros(), "Id", "Descricao");

                return View(_pessoaRep.retornapessoa(id));

            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion

        #region HTTPPOST

        //Aqui nos informamos para o nosso metodo que ele sera do tipo post
        // ou seja ele vai receber informações da nossa view
        [HttpPost]
        public ActionResult CadastrodeCliente(PessoaMod dadosPessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pessoaRep.AdicionarPessoa(dadosPessoa);
                }
                //Aqui nos redirecionamos o usuario para a action informada 
                //dentro do parametro

                TempData.Add("MensagemOK",
                    String.Format("Client {0} Cadastrado com Sucesso",
                        dadosPessoa.Nome));

                return RedirectToAction("Lista");
            }
            catch (HttpException)
            {
                //enviar
                TempData.Add("MensagenErro",
                    String.Format("Não foi possivel Cadastrar o Cliente {0}",
                        dadosPessoa.Nome));
                return RedirectToAction("Lista");
            }
            catch (SqlException)
            {
                TempData.Add("MensagenErro",
                    String.Format("Não foi possivel Cadastrar o Cliente {0}",
                        dadosPessoa.Nome));
                return RedirectToAction("Lista");
            }
            catch (Exception)
            {
                TempData.Add("MensagenErro",
                    String.Format("Não foi possivel Cadastrar o Cliente {0}",
                        dadosPessoa.Nome));
                return RedirectToAction("Lista");
            }

        }
        public ActionResult Editar(int id, PessoaMod dadosPessoa)
        {
            try
            {
                _pessoaRep.AlterarPessoa(id, dadosPessoa);

                TempData.Add("MensagemOK", "Cliente Atualizado");
            }
            catch (Exception)
            {
                TempData.Add("MensagemErro", "Tente Novamente Mais tarde");
                throw;
            }
            return RedirectToAction("Lista");
        }


        #endregion

    }
}