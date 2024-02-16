using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Sorteio.Business.Interfaces;
using Sorteio.Business.Notificacoes;
using System.Net;

namespace Sorteio.Api.Controllers.Base
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected bool OperacaoValida()
                    => !_notificador.TemNotificacao();

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (OperacaoValida())
                return new ObjectResult(result) { StatusCode = Convert.ToInt32(statusCode) };

            return BadRequest(new { errors = _notificador.ObterNotificacoes().Select(x => x.Mensagem) });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) 
                  NotificarErroModelInvalida(modelState);

            return CustomResponse();

        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var msgErro = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(msgErro);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Manipular(new Notificacao(mensagem));
        }

    }
}
