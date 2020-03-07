using AutoMapper;
using MoneyAdmin.Domain;
using MoneyAdmin.WebApi.ViewModels;

namespace MoneyAdmin.WebApi.Profiles
{
    public sealed class BankAccountProfile : Profile
    {
        public BankAccountProfile()
        {
            CreateMap<BankAccount, BankAccountViewModel>();
        }
    }
}
