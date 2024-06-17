
using LivePlay.Server.Application.Facade;
using LivePlay.Server.Application.Interfaces;
using LivePlay.Server.Persistence.Repositories;

namespace LivePlay.Server.Application.Services;

public class UserService(UserRepository repository, IJwtProvider jwtProvider, RegistrarUserFacade registrarUserFacade)
{
    private readonly UserRepository UserRep = repository;
    private readonly IJwtProvider JwtProvider = jwtProvider;
    private readonly RegistrarUserFacade RegistrarUserBackFacade = registrarUserFacade;

    public uint VerifyEmail(string email)
    {
        var enterNumber = RegistrarUserBackFacade.AddNewRegistrationUser?.Invoke(new() { Email = email})
            ?? throw new Exception($"There is no access to the back service throw facade {nameof(RegistrarUserFacade)}");
        return enterNumber;
    }

    public bool VerifyCodeEmail(uint numberRegistration, string code)
    {
        var isGood = RegistrarUserBackFacade.CheckCodeRegistrationUser?.Invoke(numberRegistration, code)
            ?? throw new Exception($"There is no access to the back service throw facade {nameof(RegistrarUserFacade)}");
        return isGood;
    }
}
