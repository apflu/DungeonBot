using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay.AbstractTool
{
    public interface IFlagable
    {
        Flag GetFlag(string name);
        void SetFlag(params Flag[] flags);
        bool RemoveFlag(string flagName);
        bool IsFlagExist(string flagName);
    }
}
