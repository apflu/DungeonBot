using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Csharp.App.Gameplay.AbstractTool;
using Native.Csharp.App.UserInteract;
using Native.Csharp.App.Util.Time;

namespace Native.Csharp.App.Gameplay.Jobs
{
    public abstract class Job : TimeElement, IElement
    {
        public Job(TimeSpan duration) 
            : base(duration)
        {

        }
        public abstract string InternalName { get; set; }
        public abstract LocaleKey DisplayName { get; set; }
        public abstract LocaleKey Description { get; set; }


    }
}
