﻿using ControleEstoque.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControleEstoque.App.Models.Command
{
    public class  UsuarioCommand
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage ="senha diferente")]
        [Required(ErrorMessage = "Informe a  confirmação da Senha")]
        public string ConfirmeSenha { get; set; }


        [Required(ErrorMessage = "Informe o e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }


        [Compare("Email", ErrorMessage = "email diferente")]
        [Required(ErrorMessage = "Informe a confirmação do e-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        
        public string ConfirmarEmail { get; set; }

        public UsuarioCommand(ApplicationUserEntity model)
        {
            this.Email= model.Email;
            this.Nome = model.FullName;
            this.Senha = model.PasswordHash;
            this.Login = model.UserName;

        }

        //retorna os valores da entidade
        //public EntradaProdutoEntity retornoEntradaProdutoEntity()
        //{
        //    return new EntradaProdutoEntity
        //    {
        //        Numero = this.Numero,
        //        Data = this.Data,
        //        Quantidade = this.Quantidade,
        //        IdProduto = this.IdProduto
        //    };
        //}

        //public static implicit operator EntradaProdutoEntity(EntradaProdutoCommand model)
        //{
        //    return new EntradaProdutoEntity
        //    {
        //        Numero = model.Numero,
        //        Data = model.Data,
        //        Quantidade = model.Quantidade,
        //        IdProduto = model.IdProduto
        //    };

        //}
        //public static implicit operator EntradaProdutoCommand(EntradaProdutoEntity model)
        //{
        //    return new EntradaProdutoCommand
        //    {
        //        Numero = model.Numero,
        //        Data = model.Data,
        //        Quantidade = model.Quantidade,
        //        IdProduto = model.IdProduto
        //    };
        //}

    }
}