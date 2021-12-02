using Aware.Model;
using Aware.BL.Model;
using Aware.Util.Constants;

namespace Aware.Manager
{
    public interface ISessionManager : IBaseManager<User>
    {
        OperationResult<TokenResponse> GetAuthenticationToken(SessionDataModel sessionData, int expireMinutes = CommonConstants.JwtTokenExpire);

        OperationResult<TokenResponse> GetApiToken(TokenRequest request, ApplicationModel application);

        bool CheckApiToken(TokenRequest tokenRequest);

        OperationResult<SessionDataModel> Open(SessionDataModel sessionData);

        bool Terminate(string sessionKey);

        SessionDataModel Authenticate(string sessionKey);

        SessionDataModel GetSessionData(string sessionKey);

        OperationResult<TokenResponse> Simulate(ApplicationModel application);
    }
}
