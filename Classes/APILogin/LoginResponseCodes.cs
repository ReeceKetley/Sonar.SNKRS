using System;
using System.Collections.Generic;
using System.Text;

namespace SonarSNKRS
{
    public enum LoginResponseCode
    {
        Sucess,
        InvalidCredentials,
        DecryptFail,
        LinkedDevice,
        MaxDevices,
        JsonFail,
        UnkownFail,
        HttpError
    }
}

