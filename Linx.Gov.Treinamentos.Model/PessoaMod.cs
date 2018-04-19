using System;
using System.ComponentModel.DataAnnotations;

namespace Linx.Gov.Treinamentos.Model
{
    public class PessoaMod
    {
        //variaveis com letras em minusculas são referente a linguagem
        //em maiuscula ao dot net e pode ser usado em varias linguagens

        public int Id { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public string endereco { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        [EmailAddress(ErrorMessage = "Informe um E-mail Válido")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascismento")]
        [Required(ErrorMessage = "Campo Obrigatorio")]
        public DateTime DataNascimento { get; set; }

        //não vamos usar o dysplay pois sera usada apenas como referencia para o GeneroMod
        public GeneroMod Genero { get; set; }
    }
}
