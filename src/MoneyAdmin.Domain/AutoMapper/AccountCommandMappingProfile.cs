using AutoMapper;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.AutoMapper
{
    public sealed class AccountCommandMappingProfile : Profile
    {
        public AccountCommandMappingProfile()
        {
            CreateMap<CreateAccountCommand, Account>()
                .ForMember(dest => dest.Amount, m => m.MapFrom(a => a.InitialValue));
        }
    }
}
