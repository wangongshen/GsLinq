using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsLinq
{
    public delegate void NoReturnNoParaOutClass();
    public delegate void GenericDelegate<T>();
    public class LambdaShow
    {
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, string y);//1 声明委托
        public delegate int WithReturnNoPara();
        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            Console.WriteLine("lambda演变历史"); 

            {
                Console.WriteLine(".NetFramework1.0  1.1");
                Console.WriteLine("执行无参无返回值委托");
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                method.Invoke();
            }
            {
                Console.WriteLine("执行有参无返回值委托");
                NoReturnWithPara method = new NoReturnWithPara(this.Study);
                method.Invoke(20200316, "2020年3月16日17:56:21");
            }
            {
                Console.WriteLine(".NetFramework2.0  匿名方法，delegate关键字");
                //可以访问局部变量
                NoReturnWithPara method = new NoReturnWithPara(delegate (int id, string name)
                {
                    Console.WriteLine($"***这是方法***：匿名方法：{id} {name}");
                });
                method.Invoke(20200316, "2020年3月16日17:02:23");
            }
            {
                Console.WriteLine(".NetFramework3.0   把delegate关键字去掉，增加了一个箭头goes to 也就是：=>");
                NoReturnWithPara method = new NoReturnWithPara(
                    (int id, string name) =>
                    {
                        Console.WriteLine($"***这是方法***：{id} {name}");
                    });
                method.Invoke(20200316, "2020年3月16日17:06:31");
                Console.WriteLine("Action方法");
                Action<string, string> actionA = (string str1, string str2) =>
                {
                    Console.WriteLine($"***这是方法***：参数1：{str1}，参数2：{str2}");
                };
                actionA.Invoke("ABC","CBA");
                
            }
            {
                Console.WriteLine("//省略参数类型，编译器的语法糖，虽然没写，编译时还是有的，根据委托推算");
                NoReturnWithPara method = new NoReturnWithPara(
                    (id, name) =>
                    {
                        Console.WriteLine($"{id} {name}");
                    });
                method.Invoke(20200316, "2020年3月16日17:13:11");

                Console.WriteLine("Action方法");
                Action<int, string> actionB = (int1, str1) =>
                {
                    Console.WriteLine($"***这是方法***：参数1{str1}，参数2：{str1}");
                };
                actionB.Invoke(20200316,"2020年3月16日17:20:03");
            }
            {
                Console.WriteLine("如果方法体只有一行，可以去掉大括号和分号");
                NoReturnWithPara method = new NoReturnWithPara(
                    (id, name) => Console.WriteLine($"{id} {name}"));
                method.Invoke(20200316, "2020年3月16日17:22:59");
            }
            {
                Console.WriteLine("new NoReturnWithPara可以省掉，也是语法糖，编译器自动加上");
                NoReturnWithPara method = (id, name) => Console.WriteLine($"{id} {name}");
                method.Invoke(123, "大涛");
            }
            Console.WriteLine("lambda表达是什么？ lambda只是实力化委托的一个参数，就是个方法");
            Console.WriteLine("lambda是匿名方法，但是编译的时候会分配一个名字,还会产生一个私有sealed类，这里增加一个方法");
            {
                Console.WriteLine("lambda在多播委托");
                NoReturnWithPara method = new NoReturnWithPara(this.Study);
                method += this.Study;
                method += (id, name) => Console.WriteLine($"{id} {name}");

                method -= this.Study;
                method -= (id, name) => Console.WriteLine($"{id} {name}");
                Console.WriteLine("多播委托里面的lambda无法移除， 不是2个实例，其实是2个不同的方法,因为在编译的时候，会生成两个方法名不同的方法");
                method.Invoke(20200316, "2020年3月16日17:26:12");
            }
            {
                Console.WriteLine("==========有返回值，有参数==========");
                Func<int, int, int> funcA = (a, b) =>
                {
                    return a + b;
                };
                Console.WriteLine("如果方法体只有一行也可以省略大括号");
                Func<int, int, int> funcB = (a, b) => a + b;

                int c = funcA.Invoke(12,13);
                int d = funcB.Invoke(10,30);
                Console.WriteLine($"FuncA返回值：{c}");
                Console.WriteLine($"FuncB返回值：{d}");
            }
        }

        private void DoNothing()
        {
            Console.WriteLine("***这是方法***：什么也不做");
        }

        private void Study(int id, string name)
        {
            Console.WriteLine($"***这是方法***：ID：{id} ，Name：{name}");
        }
    }
}
