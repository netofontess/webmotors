using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebMotors.Domain.Filtros
{
    public class Filtro
    {
        [BindRequired]
        public long Id { get; set; }
    }
}
