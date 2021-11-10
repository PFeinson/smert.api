using System.Threading.Tasks;
public abstract class IUserService {
    private IUserRepository user_repository;
    public abstract Task<bool> create_new_user(string username, string password, int user_id);
}