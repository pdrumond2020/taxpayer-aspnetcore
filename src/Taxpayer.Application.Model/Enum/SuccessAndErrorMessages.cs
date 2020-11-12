using System.ComponentModel;

namespace Taxpayer.Application.Model.Enum
{
    public enum SuccessAndErrorMessages
    {
        [Description("Incluído com sucesso")]
        SuccessfullyIncluded = 1,

        [Description("Listado com sucesso")]
        SuccessfullyListed = 2,

        [Description("Não foi possível adicionar")]
        ErrorOccurredWhileAdding = 3,

        [Description("Não foi possível adicionar, pois esse registro já existe.")]
        NotAddedAlreadyExists = 4,

        [Description("Não foi possível listar")]
        ErrorOccurredWhileListing = 5,

        [Description("Nenhum dado encontrado")]
        NoDateFound = 6
    }
}