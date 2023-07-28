using FluentValidation;
using SomaNumeros.Application.ViewModels.Base;
using SomaNumeros.Dominio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomaNumeros.Services.Services.Base.Interfaces
{
    public interface IBaseCadastroApp<TModel, TViewModel, TViewModelAdicionar, TViewModelAtualizar, TValidator>
        where TModel : Entity, new()
        where TViewModel : BaseViewModelCadastro, new()
        where TViewModelAtualizar : BaseViewModelCadastro, new()
        where TValidator : AbstractValidator<TModel>, new()
    {
        bool ValidarModel(TModel model);
        bool ValidarModelSemRelacionamentos(Guid id);
        TModel MapearDominio(TViewModelAdicionar viewmodel);
        Task<bool> Adicionar(TModel model);
        Task<bool> Atualizar(TViewModelAtualizar viewmodel);
        Task<bool> Remover(Guid id, TModel model);
    }
}
