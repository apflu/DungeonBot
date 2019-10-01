using Native.Csharp.App.Locale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Command
{
    public class Player
    {
        private PlayerData PlayerData;

        private long CurrentGroup { get; set; }
        private long QQID;
        private LocaleType Locale;

        public Player(long QQID)
        {
            this.QQID = QQID;
        }

        public long GetCurrentGroup()
        {
            return CurrentGroup;
        }

        public void SetCurrentGroup(long group)
        {
            CurrentGroup = group;
        }

        public LocaleType GetCurrentLocale()
        {
            return Locale;
        }

        public static Player Parse(long QQID)
        {
            return new Player(QQID);
        }
    }
}
