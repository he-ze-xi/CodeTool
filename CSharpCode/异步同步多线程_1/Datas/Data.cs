using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 异步同步多线程_1.Datas
{
    public class Data
    {
        public readonly static List<Book> books = new() { 
            new Book("封神演义",1),
            new Book("三国演义",2),
            new Book("水浒传",1),
            new Book("西游记",1),
            new Book("红楼梦",2),
            new Book("聊斋志异",2),
            new Book("儒林外史",1),
            new Book("隋唐演义",1)
        };

        #region 注释
        //public readonly static List<string> urlCollect = new()
        //{
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/",
        //    "https://www.sina.com.cn/"

        //};
        #endregion

    }
}
