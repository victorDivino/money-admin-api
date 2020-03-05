using AutoMapper;
using MoneyAdmin.Domain.Commands;

namespace MoneyAdmin.Domain.Profiles
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<CreateBankAccountCommand, BankAccount>()
                .ForMember(dest => dest.Balance, m => m.MapFrom(a => a.InitialValue));
        }
    }
}
