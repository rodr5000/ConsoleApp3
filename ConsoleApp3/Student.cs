using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLab
{
    public class Student
    {
        private int grade;
        private string name;

        public Student(int grade, string name) 
        {
            this.grade = grade;
            this.name = name;
        }

        public int GetGrade() => grade;

        public string GetName() => name;

        public override string ToString() => $"name: {name}, grade: {grade}";
    }
}
