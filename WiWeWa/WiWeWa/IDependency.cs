using System;
using System.Collections.Generic;
using System.Text;

namespace WiWeWa
{
    public interface IDependency
    {
        string GetLocalFilePath(string file);
    }
}
