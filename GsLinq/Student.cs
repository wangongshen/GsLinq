using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsLinq
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine($"执行Study()方法，参数：{this.Id},参数：{this.Name}");
        }

        public void StudyHard()
        {
            Console.WriteLine($"执行StudyHard()方法，参数：{this.Id},参数：{this.Name}");
        }

        public void StudyPractise()
        {
            Console.WriteLine($"执行StudyPractise()方法，参数：{this.Id},参数：{this.Name}");
        }
    }

    /// <summary>
    /// 班级实体
    /// </summary>
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}
