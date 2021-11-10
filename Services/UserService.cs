using System.Text.RegularExpressions;
using System.Threading.Tasks;
public class UserService {
    private UserRepository user_repository;
    public async Task<bool> create_new_user(string username, string password, int user_id) {
        return await new Task<bool>(false);
    }
}