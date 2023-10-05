using ControleEstoque.API.Controllers.Base;
using ControleEstoque.API.ProblemDetailsModels;
using ControleEstoque.App.Dtos;
using ControleEstoque.App.Handlers.Fornecedor;
using ControleEstoque.App.Handlers.GrupoProduto;
using ControleEstoque.App.Handlers.LocalArmazenamento;
using ControleEstoque.App.Handlers.MarcaProduto;
using ControleEstoque.App.Handlers.Produto;
using ControleEstoque.App.Handlers.UnidadeMedida;
using ControleEstoque.App.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : MainController
    {

        private readonly IProdutoHandlers handler;
        private readonly IGrupoProdutoHandlers grupoHandler;
        private readonly ILocalArmazenamentoHandlers localHandler;
        private readonly IUnidadeMedidaHandlers unidadeHandler;
        private readonly IFornecedorHandlers fornecedorHandler;
        private readonly IMarcaProdutoHandlers marcaHandler;
        public ProdutoController(IProdutoHandlers _handler, IGrupoProdutoHandlers _grupoHandler, ILocalArmazenamentoHandlers _localHandler, IFornecedorHandlers _fornecedorHandler, IUnidadeMedidaHandlers _unidadeHandler, IMarcaProdutoHandlers _marcaHandler, INotificador notificador, IUser user) : base(notificador, user)
        {
            this.handler = _handler;
            this.grupoHandler = _grupoHandler;
            this.localHandler = _localHandler;
            this.fornecedorHandler = _fornecedorHandler;
            this.unidadeHandler = _unidadeHandler;
            this.marcaHandler = _marcaHandler;
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retona um produto</returns>
        /// <response code="201">Returna um novo produto </response>
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] ProdutoCommand command)
        {
            if (!ModelState.IsValid) return Resposta(ModelState);
   
            var idGrupo = grupoHandler.RecuperarPeloId(command.IdGrupo);
            if (idGrupo is null) return IdInvalido("Grupo", command.IdGrupo);

            var idLocalArmazenamento = localHandler.RecuperarPeloId(command.IdLocalArmazenamento);
            if (idLocalArmazenamento is null) return IdInvalido("LocalArmazenamento", command.IdLocalArmazenamento);

            var idFornecedor = fornecedorHandler.RecuperarPeloId(command.IdFornecedor);
            if (idFornecedor is null) return IdInvalido("UnidadeMedida", command.IdUnidadeMedida);

            var idUnidadeMedida = unidadeHandler.RecuperarPeloId(command.IdUnidadeMedida);
            if (idUnidadeMedida is null) return IdInvalido("UnidadeMedida", command.IdUnidadeMedida);


            var idMarca = marcaHandler.RecuperarPeloId(command.IdMarca);
            if (idMarca is null) return IdInvalido("Marca", command.IdMarca);
            

            //var imagemNome = Guid.NewGuid() + "_" + command.Imagem;
            //if (!UploadArquivo(command.ImagemUpload, imagemNome))
            //{
            //    return Resposta(command);
            //}

            //command.Imagem = imagemNome;
            var model = handler.Salvar(command);
            if (model is not null)
            {
                    

                return Criado(model.Id, model);
            }
            else
            {
                return BadRequest();
            }
            

        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }






        /// <summary>
        /// Alterar um produto.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="id"></param>
        /// <returns>Um produto foi alterado</returns>
        /// <response code="200">Quando produto é alterado com sucesso</response>
        /// <response code="404">Quando  produto não existir</response>  
        /// <response code="400">se o item for nulo</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, [FromBody] ProdutoCommand command)
        {
            //verifica se o tipo  existe
            var idGrupo = grupoHandler.RecuperarPeloId(command.IdGrupo);
            var idLocalArmazenamento = localHandler.RecuperarPeloId(command.IdLocalArmazenamento);
            var idFornecedor = fornecedorHandler.RecuperarPeloId(command.IdFornecedor);
            var idUnidadeMedida = unidadeHandler.RecuperarPeloId(command.IdUnidadeMedida);
            var idMarca = marcaHandler.RecuperarPeloId(command.IdMarca);

            if (idGrupo is null)
                return BadRequest(new CustomBadRequest("O Id do Grupo é invalido e não foi encontrado", Request));

            else if (idLocalArmazenamento is null)
                return BadRequest(new CustomBadRequest("O Id do Local de armazenamento é invalido e não foi encontrado", Request));

            else if (idUnidadeMedida is null)
                return BadRequest(new CustomBadRequest("O Id do Unidade de medida é invalido e não foi encontrado", Request));

            else if (idFornecedor is null)
                return BadRequest(new CustomBadRequest("O Id do Fornecedor é invalido e não foi encontrado", Request));

            else if (idMarca is null)
                return BadRequest(new CustomBadRequest("O Id do Marca de Produto é invalido e não foi encontrado", Request));
            else
            {
                var model = handler.Alterar(id, command);
                if (model is not null)
                {
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// Buscar uma lista de produto
        /// </summary>    
        /// <returns>Uma lista de produto</returns>
        /// <response code="200">Quando produto existir</response>
        /// <response code="404">Quando produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public IActionResult Get()
        {
            
            var model = handler.RecuperarLista();
            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }


        /// <summary>
        /// Buscar  de produto pelo id.
        /// </summary>
        /// <returns> retorna um produto</returns>
        /// <response code="200">Quando produto existir</response>
        /// <response code="404">Quando produto não existir</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoView))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var model = handler.RecuperarPeloId(id);

            if (model is not null)
            {
                return Ok(model);
            }
            else
            {
                return NotFound();
            }

        }

        /// <summary>
        /// Contar a quantidade de produto   
        /// </summary>  
        /// <returns>a quantidade de produto foi recuperada</returns>
        /// <response code="200"></response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [HttpGet("Cont")]
        public IActionResult GetQuantidade()
        {
            return Ok(handler.RecuperarQuantidade());
        }

        /// <summary>
        /// Excluir produto.
        /// </summary>        
        /// <param name="id"></param>
        /// <returns>Um produto excluido</returns>
        /// <response code="204">Quando produto excluido com sucesso</response>
        /// <response code="404">Quando produtor não existir</response> 
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id)
        {

            var model = handler.RecuperarPeloId(id);

            if (model is not null)
            {
                handler.ExcluirPeloId(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
