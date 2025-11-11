using RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusniess
{
    public interface ILoginBussniess
    {
        LoginResponse Login(LoginRequest login);
    }
}
