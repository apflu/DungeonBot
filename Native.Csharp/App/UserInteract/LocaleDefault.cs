using System.Collections.Generic;

namespace Native.Csharp.App.UserInteract
{
    public class LocaleDefault : Locale
    {
        public override Dictionary<LocaleKey, string> Locales { get; protected set; }
        public LocaleDefault()
        {
            LocaleManager manager = Plugin.GetLocaleManager();

            Locales = new Dictionary<LocaleKey, string>
            {
                //基础
                { manager.Keys["CHARACTER"], "角色" },
                { manager.Keys["PLAYER"], "玩家" },
                { manager.Keys["NAME"], "名称"},
                { manager.Keys["ITEM"], "物品" },

                //基础状态
                { manager.Keys["EXIST"], "存在" },

                //字符
                { manager.Keys["CHAR_NAME_SPACE"], "空格" },
                { manager.Keys["CHAR_NAME_CHAR"], "汉字" },

                //角色状态
                { manager.Keys["CHARACTER_STATUS_BUSY"], "忙碌" },
                { manager.Keys["CHARACTER_STATUS_HELPLESS"], "无助" },

                //角色信息
                { manager.Keys["CHARACTER_NAME"], "名字" },
                { manager.Keys["CHARACTER_LIST"], "{player}的角色列表：\r\n" },
                { manager.Keys["CHARACTER_LIST_FORMAT"], "\r\n{character_name}（{status_list}），{level}级{class}"},

                //角色创建
                { manager.Keys["CHARACTER_CREATED"], "你成功创建了角色{character_name}！" },

                { manager.Keys["ERROR_CHARACTER_NOT_EXIST"], "角色{character_name}不存在！" },
                { manager.Keys["ERROR_CHARACTER_NONE_IN_LIST"], "你当前没有角色！\r\n" + "使用 #创建角色 来创建一个！" },
                
                //通用错误
                { manager.Keys["ERROR_IS_NOT_VALID"], "{key}“{value}”无效！" },
                { manager.Keys["ERROR_COMMAND_FAIL"], "命令{command}执行失败！" },
                { manager.Keys["ERROR_LIMIT_REACHED"], "你已达到最大{object}上限（{limit}）！" },
                { manager.Keys["ERROR_PARAM_REQUIRED"], "你需要为{key}指定{value}！" },
                { manager.Keys["ERROR_CANNOT_CONTAIN"], "{key}不能包括{value}！" },
                { manager.Keys["ERROR_CAN_ONLY_CONTAIN"], "{key}只能包括{value}！" },
                { manager.Keys["ERROR_PARAM_TOO_LONG"], "{key}过长！最大上限为{limit}。" },
                { manager.Keys["ERROR_ALREADY"], "{key}已{status}！" },

                //抱怨
                { manager.Keys["JOB_AMOUNT_TOO_BIG"],
                    "{player_name}，你{job_name_short}那么多，别人都没得{job_name_short}了！" },
                { manager.Keys["JOB_AMOUNT_OVERFLOW"], "{player_name}给我站住！你是要把整个地球都搬走嘛？！" },
                { manager.Keys["JOB_AMOUNT_TOO_SMALL"], "{player_name}，不想{job_name_short}就别{job_name_short}！" },

                //工作
                { manager.Keys["JOB_START_NEW"], "正在进行新的{job}工作：{job}{quantity}{quantifier}{job_target}…" },
                { manager.Keys["JOB_RESULT_LAST"], "上次{job}{result}了{quantity}{quantifier}{outcome}。" },
                { manager.Keys["JOB_GATHER"], "采集" },
                { manager.Keys["JOB_GATHER_SHORT"], "采" },
                { manager.Keys["JOB_CHECK"], "查看" },
                { manager.Keys["JOB_CHECK_SHORT"], "看" },

                //物品类型
                { manager.Keys["ITEM_TYPE_FOOD"], "食物" },
                { manager.Keys["ITEM_TYPE_HERB"], "草药" },

                //物品名称和描述
                { manager.Keys["ITEM_UNDEFINED_NAME"], "不明物体" },
                { manager.Keys["ITEM_UNDEFINED_DESCRIPTION"], "没有描述。（忘了加文本！快偷偷加上）" },
                { manager.Keys["ITEM_UNKNOWN_HERB_NAME"], "不明草药" },
                { manager.Keys["ITEM_UNKNOWN_HERB_DESCRIPTION"], 
                    "你不知道这是做什么的。（还能做什么？你忘了加文本，快偷偷加上）" },
                { manager.Keys["ITEM_UNKNOWN_FOOD_NAME"], "不明食物" },
                { manager.Keys["ITEM_UNKNOWN_FOOD_DESCRIPTION"], 
                    "你不知道这是作什么吃的。（还没来得及加文本！）"},

                { manager.Keys["ITEM_BERRY_NAME"], "浆果" },
                { manager.Keys["ITEM_BERRY_DESCRIPTION"],
                    "一捧五颜六色的果子，捏起来软软的，一般从一种不显眼的树丛中能够采集到。" +
                    "绝大多数拥有薄薄的表皮，对着阳光看隐隐有光透过；" +
                    "其中大多酸涩，不排除存在有毒浆果的可能性。\n" +
                    "经验丰富或受过训练的冒险者能从中分辨有毒的那些。" },
                { manager.Keys["ITEM_HONEY_BERRY_NAME"], "蜜汁浆果" },
                { manager.Keys["ITEM_HONEY_BERRY_DESCRIPTION"],
                    "这种浆果比它的近亲野果要大了不少：皮厚、捏起来较硬。" +
                    "用小刀轻轻削去一部分表皮可以闻到十分香甜的气味，并溢出果汁，味道类似蜂蜜。" +
                    "它还有增进伤口恢复的作用，但唯一的缺点是比它的近亲在数量上要稀少得多。"},
                { manager.Keys["ITEM_WEED_NAME"], "杂草" },
                { manager.Keys["ITEM_CATNIP_NAME"], "猫薄荷" },
                { manager.Keys["ITEM_SPARKLED_FERN_NAME"], "闪光蕨" },
                { manager.Keys["ITEM_DRAGONBREATH_NAME"], "龙息草" },

                //物品互动
                { manager.Keys["ITEM_NO_EFFECT"], "" },

                //物品栏
                { manager.Keys["INVENTORY_CONTENT"], "{character_name}的物品栏中有：{content}"},
                { manager.Keys["INVENTORY_CONTENT_EMPTY"], "{character_name}的物品栏为空！" },
                { manager.Keys["INVENTORY_FORMAT"], "{item_name} * {quantity}" },
                { manager.Keys["INVENTORY_FORMAT_SEPARATOR"], "，" },
            };
        }

        public new string GetValue(LocaleKey key)
        {
            try
            {
                return Locales[key];
            } catch (KeyNotFoundException)
            {
                return key.ToString();
            }
        }

        private void Add(string key, params string[] value)
        {
            LocaleManager manager = Plugin.LocaleManager;
            //Locales.Add(manager.Keys[key], value);
        }
    }
}
