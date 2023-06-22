﻿using ControleEstoque.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.App.Handlers.MarcaProduto
{
    public interface IMarcaProdutoHandlers
    {
        public int RecuperarQuantidade();

        public List<MarcaProdutoView> RecuperarLista();

        public MarcaProdutoView RecuperarPeloId(int id);

        public MarcaProdutoView Salvar(MarcaProdutoCommand marca);
        public MarcaProdutoView Alterar(int id, MarcaProdutoCommand marca);

        public void ExcluirPeloId(int id);
    }
}
