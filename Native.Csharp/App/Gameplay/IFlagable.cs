using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public interface IFlagable
    {
        Flag GetFlag(string name);
        void SetFlag(Flag flag);
        bool RemoveFlag(string flagName);
        bool IsFlagExist(string flagName);
    }
}
