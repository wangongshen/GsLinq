using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsLinq
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{

				#region lambda演化史
				{
					Console.WriteLine("***************Lambda*****************");
					LambdaShow lambdaShow = new LambdaShow();
					lambdaShow.Show();
				}
                #endregion

                #region 匿名类 var 3.0
                {
                    Console.WriteLine("==========匿名类==========");
                    Student student = new Student()
                    {
                        Id = 1,
                        Name = "2020年3月16日17:51:56",
                        Age = 25,
                        ClassId = 2
                    };
                    student.Study();

                    object model = new //3.0
                    {
                        Id = 2,
                        Name = "undefined",
                        Age = 25,
                        ClassId = 2,
                        Teacher = "Eleven"
                    };
                    //Console.WriteLine(model.Id);
                    //Console.WriteLine(model, Name);
                    //C#强类型语言，编译时会确定类型，object 决定了没有Id属性,运行时确实有Id和Name  但是编译器不认可,我们可以利用dynamic避开编译器检查

                    Console.WriteLine("dynamic避开编译器检查，dynamic是4.0才出现的"); 
                    dynamic dModel = new
                    {
                        Id = 2,
                        Name = "2020年3月16日17:56:15",
                        Age = 25,
                        ClassId = 2
                    };
                    Console.WriteLine(dModel.Id);
                    Console.WriteLine(dModel.Name);
                    //dModel.Study();//因为编译器不检查，所以，即使你写错了，编译器也不会报错，但运行时会报错

                    Console.WriteLine("var");
                    var mode2 = new //3.0
                    {
                        Id = 2,
                        Name = "2020年3月16日18:42:21",
                        Age = 25,
                        ClassId = 2,
                        Teacher = "苍老师"
                    };
                    Console.WriteLine($"ID:{mode2.Id}");
                    Console.WriteLine($"Teacher:{mode2.Teacher}");
                    Console.WriteLine($"类型：{mode2.GetType().Name}");
                    //mode2.Id = 3;//这样写会报错，因为是只读的，只有初始化的时候能指定

                    Console.WriteLine("var就是个语法糖，由编译器自动根据值推算类型");
                    int i2 = 2;
                    var i1 = 1;
                    var s = "str1";
                    //var aa;//var声明的变量必须初始化，才能能推算出类型，所以var必须赋值，不然的话语法上不通过

                    Console.WriteLine($"i2类型：{i2.GetType().Name}");
                    Console.WriteLine($"i1类型：{i1.GetType().Name}");
                    Console.WriteLine($"s类型：{s.GetType().Name}");

                    Console.WriteLine("var 配合匿名类型使用");
                    var varModel = new//3.0
                    {
                        Id = 2,
                        Name = "2020年3月16日18:48:11",
                        Age = 25,
                        ClassId = 2
                    };
                    Console.WriteLine(varModel.Id);
                }
                #endregion

                #region 扩展方法 3.0
                {
                    Console.WriteLine("==========扩展方法==========");
                    Student student = new Student()
                    {
                        Id = 1,
                        Name = "2020年3月16日18:51:35",
                        Age = 25,
                        ClassId = 2
                    };
                    student.Study();
                    Console.WriteLine("用ExtendMethod直接调用StudyPractise()");
                    ExtendMethod.StudyPractise(student);
                    Console.WriteLine("扩展方法，用student调用StudyPractise()");
                    student.StudyPractise();
                    //扩展方法调用，很像实例方法，就像扩展了Student的逻辑
                    //1 第三方的类，不适合修改源码，可以通过扩展方法增加逻辑 优先调用实例方法，最怕扩展方法增加了，别人类又修改了
                    //2 适合组件式开发的扩展(.NetCore)，定义接口或者类，是按照最小需求，但是在开发的时候又经常需要一些方法，就通过扩展方法context.Response.WriteAsync 中间件的注册
                    //3 扩展一些常见操作
                    //会污染基础类型，一般少为object  没有约束的泛型去扩展
                    int? k = 23; //int? 表示可空类型，即是值可以为null
                    int l = 4;
                    int r = k.ToInt() + l;
                    string result = "2342543546546464564656".ToLength(20);
                    Console.WriteLine("扩展方法");
                    string strK = k.ToStringCustom();
                    string strL = l.ToStringCustom();
                    string strR = result.ToStringCustom();
                    Console.WriteLine($"strK:{strK}");
                    Console.WriteLine($"strL:{strL}");
                    Console.WriteLine($"strR:{strR}");

                }
                #endregion

                #region Linq
                {
                    Console.WriteLine("==========Linq==========");
                    LinqShow show = new LinqShow();
                    show.Show();
                }
                #endregion

            }
            catch (Exception Ex)
			{
				Console.WriteLine($"错误信息：{Ex.Message}");
				Console.Read();
			}
			Console.Read();
        }
    }
}
