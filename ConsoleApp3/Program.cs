using QueueLab;

namespace QLab;
public class Program
//רועי עלימה יא'3 18/01/2025 20:53

{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Queue<int> q = new Queue<int>();
        q.Insert(7);
        q.Insert(10);
        q.Insert(3);
        Console.WriteLine(q);
        Queue<int> qCopy = SetQCopy(q);
        Console.WriteLine(q);
        Console.WriteLine(qCopy);
        q.Insert(7);
        qCopy.Insert(13);
        q.Insert(14);
        q.Insert(7);
        q.Insert(20);

        Queue<int> q2 = new Queue<int>();

        q2.Insert(1);
        q2.Insert(3);
        q2.Insert(2);
        q2.Insert(-2);

        bool checkPerfect = CheckQPerfect(q2);
        Console.WriteLine(checkPerfect);
        Console.WriteLine(q2);

        bool check = CheckAround(q, 5);

        Console.WriteLine(check);

        Console.WriteLine(q);
        Console.WriteLine(qCopy);

        Console.WriteLine(IsNumInQ(q, 7));

        Queue<int> q3 = new Queue<int>();

        q3.Insert(1);
        q3.Insert(3);
        q3.Insert(4);
        q3.Insert(5);
        q3.Insert(6);
        q3.Insert(7);
        q3 = OrderQ(q3, 8);

        Console.WriteLine(q3);

        Student s1 = new Student(91, "Lior");
        Student s2 = new Student(90, "Roei");
        Student s3 = new Student(92, "Eyal");
        Student s4 = new Student(93, "Mark");

        Queue<Student> q4 = new Queue<Student>();
        q4.Insert(s2);
        q4.Insert(s3);
        q4.Insert(s4);

        q4 = QueueStu(q4, s1);

        Console.WriteLine(q4);

    }

    public static Queue<T> SetQCopy<T>(Queue<T> q)
    {
        Queue<T> qCopy = new();
        Queue<T> qTemp = new();
        T currItem;
        //פריקת התור המקורי ויצירת תור העתק ותור זמני
        while (!q.IsEmpty())
        {
            currItem = q.Remove();
            qTemp.Insert(currItem);
            qCopy.Insert(currItem);
        }
        //שחזור התור המקורי
        while (!qTemp.IsEmpty())
        {
            q.Insert(qTemp.Remove());
        }
        return qCopy;
    }

    //פונקציה של השאלה השנייה
    public static bool CheckAround(Queue<int> q, int place)
    {

        bool check = false;
        int right = 0;
        int sum = 0;
        int current = 0;
        Queue<int> qCopy = SetQCopy(q);
        Queue<int> qCopy2 = SetQCopy(q);
        int Length = 0;

        //מחשב את אורך התור
        while (!qCopy2.IsEmpty())
        {
            Length++;
            qCopy2.Remove();
        }


        if (place < Length && place > 1)
        {
            //מחפש את המספר מצד ימין
            for (int i = 1; i < place; i++)
            {
                right = qCopy.Remove();
            }


            current = qCopy.Remove();
            sum = qCopy.Remove() + right;

            if (current == sum)
            {
                check = true;
            }
        }

        return check;
    }

    //פונקציה של השאלה השלישית
    public static bool CheckQPerfect(Queue<int> q)
    {
        Queue<int> qCopy = SetQCopy(q);
        int length = 0;
        int count = 0;

        //בודק את אורך התור
        while (!qCopy.IsEmpty())
        {
            length++;
            qCopy.Remove();
        }

        for (int place = 2; place < length; place++)
        {
            if (CheckAround(q, place))
            {
                count++;
            }
        }

        //בודק אם בכל התור יש מספרים שלמים
        if (count == length - 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //פונקציה של השאלה הראשונה
    public static bool IsNumInQ(Queue<int> q, int num)
    {
        Queue<int> copyq = SetQCopy(q);
        bool check = false;

        //מפרק את התור ובודק אם כל מספר בתור שווה למספר המקובל 
        while (!copyq.IsEmpty())
        {
            int currItem = copyq.Remove();
            if (currItem == num)
            {
                check = true;
            }
        }
        return check;

    }

    //פונקציה של השאלה הרביעית
    public static Queue<int> OrderQ(Queue<int> q, int num)
    {
        Queue<int> copyq = SetQCopy(q);
        Queue<int> copyq2 = SetQCopy(q);
        Queue<int> orderq = new Queue<int>();
        int lastNum = 0;
        int currItem;
        int legnth=0;
        int count=0;

        //בודק מהו המספר האחרון בתור

        while (!copyq2.IsEmpty())
        {
            lastNum = copyq2.Remove();
            legnth++;
        }

        while (!copyq.IsEmpty())
        {
            currItem = copyq.Remove();

            //בודק אם המספר המקובל יותר גדול מהמספר בראש התור
            if (currItem < num)
            {
                orderq.Insert(currItem);
                count++;
                if (count == legnth) 
                {
                    orderq.Insert(num);
                }
            }
            else
            {
                orderq.Insert(num);
                orderq.Insert(currItem);
                num = lastNum + 1;
            }
        }
        q = orderq;

        return q;
    }

    public static Queue<Student> QueueStu(Queue<Student> q, Student s1)
    {
        Queue<Student> qCopy = SetQCopy(q);
        Queue<Student> qCopy2 = SetQCopy(q);
        int count = 0;
        int legnth = 0;
        int count2 = 0;

        //בודק את גודל התור
        while (!qCopy2.IsEmpty()) 
        {
            legnth++;
            qCopy2.Remove();
        }

        while (!qCopy.IsEmpty()) 
        {
            count2++;
            Student currS = qCopy.Remove();
            Student nextS;

            //בודק אם אין יותר ראש בתור
            if (count2 == legnth)
            {
                nextS = new Student(0, "0");
            }
            else 
            {
                nextS = qCopy.Head();
            }

            //בודק אם ציון התלמיד החדש קטן יותר משל התלמידים בתור
            if (currS.GetGrade() > s1.GetGrade())
            {
                qCopy2.Insert(currS);

                //למקרה ולתלמיד החדש יש את הציון הכי קטן
                count++;
            }
            //בודק אם הציון של התלמיד החדש יותר גדול מאשר התלמיד העכשוי בתור
            else if (currS.GetGrade() < s1.GetGrade() )
            {
                qCopy2.Insert(currS);

                //בודק אם הציון של התלמיד הבא בתור יותר גדול מהציון של התלמיד הבא
                if (nextS.GetGrade() > s1.GetGrade() && nextS.GetGrade() != 0)
                {
                    qCopy2.Insert(s1);
                }
                //במקרה ואין תלמיד נוסף בתור
                else if(count2 == legnth)
                {
                    qCopy2.Insert(s1);
                }
            }

 
        }
        while (!qCopy2.IsEmpty()) 
        {
            if (count == legnth) 
            {
                qCopy.Insert(s1);
                count = 0;
            }
            qCopy.Insert(qCopy2.Remove());
        }
        q = qCopy;
        return q;
    }

}

