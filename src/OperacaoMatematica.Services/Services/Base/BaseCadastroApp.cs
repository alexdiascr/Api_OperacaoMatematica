using AutoMapper;
using FluentValidation;
using SomaNumeros.Application.Notificacoes;
using SomaNumeros.Application.Services.Base.Interfaces;
using SomaNumeros.Application.ViewModels.Base;
using SomaNumeros.Dominio.Core.Models;
using SomaNumeros.Dominio.Interfaces;
using SomaNumeros.Services.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SomaNumeros.Services.Services.Base
{
    public class BaseCadastroApp<TModel, TViewModel, TViewModelAdicionar, TViewModelAtualizar, TValidator>
        : BaseApp,
        IBaseCadastroApp<TModel, TViewModel, TViewModelAdicionar, TViewModelAtualizar, TValidator>
        where TModel : Entity, new()
        where TViewModel : BaseViewModelCadastro, new()
        where TViewModelAtualizar : BaseViewModelCadastro, new()
        where TValidator : AbstractValidator<TModel>, new()
    {

        protected readonly IMapper _mapper;
        protected readonly IBaseCadastroService<TModel, TViewModel, TViewModelAdicionar, TViewModelAtualizar, TValidator> _appService;
        protected readonly IRepository<TModel> _repository;

        protected virtual string _NomeCompletoApp { get; set; }

        public BaseCadastroApp(INotificador notificador,
                               IMapper mapper,
                               IBaseCadastroService<TModel, TViewModel, TViewModelAdicionar, TViewModelAtualizar, TValidator> appService,
                               IRepository<TModel> repository)
                               : base(notificador)
        {
            _mapper = mapper;
            _appService = appService;
            _repository = repository;
        }

        public bool ValidarModel(TModel model)
        {
            return _appService.ValidarModel(model);
        }

        public bool ValidarModelSemRelacionamentos(Guid id)
        {
            return _appService.ValidarModelSemRelacionamentos(id);
        }

        public TModel MapearDominio(TViewModelAdicionar viewmodel)
        {
            return _appService.MapearDominio(viewmodel);
        }

        public Task<bool> Adicionar(TModel model)
        {
            return _appService.Adicionar(model);
        }

        public Task<bool> Atualizar(TViewModelAtualizar viewmodel)
        {
            return _appService.Atualizar(viewmodel);
        }

        public Task<bool> Remover(Guid id, TModel model)
        {
            return _appService.Remover(id, model);
        }
    }
}
