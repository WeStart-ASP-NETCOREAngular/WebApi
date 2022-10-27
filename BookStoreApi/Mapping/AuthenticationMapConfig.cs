using BookStoreApi.Data;
using BookStoreApi.DTOs;
using Mapster;

namespace BookStoreApi.Mapping
{
    public class AuthenticationMapConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequestDto, ApplicationUser>()
                .Map(dest => dest.UserName, src => src.Username)
                //.TwoWays()
                ;
            //throw new NotImplementedException();
        }
    }
}
