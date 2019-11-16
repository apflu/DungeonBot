using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Native.Csharp.App.Gameplay
{
    public class Inventory
    {
        public ArrayList Items;

        public Inventory()
        {
            Items = new ArrayList();
        }

        /// <summary>
        /// 添加1个物品到物品栏中
        /// </summary>
        /// <param name="item">欲要添加的物品</param>
        public void AddItem(params Item[] items)
        {
            foreach(Item item in items)
            {
                ItemStack existedStack = SearchInventory(item);

                if (!(existedStack == null))
                    existedStack.Quantity++;
                else
                    Items.Add(new ItemStack(item, 1));
            }
        }

        /// <summary>
        /// 添加一组物品到物品栏中
        /// </summary>
        /// <param name="stack">欲要添加的一组物品</param>
        public void AddItem(ItemStack stack)
        {
            ItemStack existedStack = SearchInventory(stack);

            if (!(existedStack == null))
                existedStack.Quantity += stack.Quantity;
            else
                Items.Add(stack);
        }

        /// <summary>
        /// 丢弃物品栏中所有指定物品
        /// </summary>
        /// <param name="item"></param>
        public bool AbandonItems(Item item)
        {
            ItemStack stack = SearchInventory(item);
            if(stack != null)
            {
                Items.Remove(stack);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 丢弃物品栏中指定数量的物品
        /// </summary>
        /// <param name="itemStack"></param>
        /// <returns></returns>
        public bool AbandonItems(ItemStack itemStack)
        {
            ItemStack stack = SearchInventory(itemStack.Item);
            if ((stack != null) && (stack.Quantity > itemStack.Quantity))
            {
                stack.Quantity -= itemStack.Quantity;
                return true;
            }
            return false;
        }


        /// <summary>
        /// 匹配任何物品为指定物品的ItemStack，反之为null
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ItemStack SearchInventory(Item item)
        {
            foreach (ItemStack stack in Items)
                if (stack.Item.Equals(item))
                    return stack;
            return null;
        }

        /// <summary>
        /// 严格匹配完全相同的ItemStack（包括数量），反之为null
        /// </summary>
        /// <param name="itemStack"></param>
        /// <returns></returns>
        private ItemStack SearchInventory(ItemStack itemStack)
        {
            foreach (ItemStack stack in Items)
                if (stack.Equals(itemStack))
                    return stack;
            return null;
        }

        /// <summary>
        /// 将物品栏的内容列为文本，每行一项
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            foreach(ItemStack itemStack in Items)
            {
                // "\r\n": 换行符
                result += "\r\n" + itemStack.Item.ItemName + " * " + itemStack.Quantity;
            }
            return result;
        }
    }
}
