using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.UserInteract
{
    public class LocaleLila: LocaleDefault
    {
        public LocaleLila(): base()
        {
            LocaleManager manager = Plugin.GetLocaleManager();

            //Locales[manager.Keys[""]] = "";

            //基础
            Locales[manager.Keys["CHARACTER"]] = "下仆";
            Locales[manager.Keys["PLAYER"]] = "那家伙";

            //角色状态
            Locales[manager.Keys["CHARACTER_STATUS_BUSY"]] = "执行邪恶计划";
            Locales[manager.Keys["CHARACTER_STATUS_HELPLESS"]] = "偷懒";

            //角色信息
            Locales[manager.Keys["CHARACTER_LIST"]] = "这些是我下仆的下仆：";
            Locales[manager.Keys["CHARACTER_LIST_FORMAT"]] = "\r\n{character_name}、{level}级的{class}下仆！";

            //角色创建
            
        }
    }
}
