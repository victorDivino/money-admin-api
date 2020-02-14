using AutoMapper;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Profiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<CreateAccountCommand, Account>()
                .ForMember(dest => dest.Amount, m => m.MapFrom(a => a.InitialValue));
        }
    }
}
