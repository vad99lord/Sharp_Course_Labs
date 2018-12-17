using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{

    class Program
    {
        public class Worker
        {

            public int id;
            public string surname;
            public int department_id;
            public Worker(int i, string s, int d)
            {
                this.id = i;
                this.surname = s;
                this.department_id = d;
            }
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; surname=" + this.surname + "; dep_id=" + this.department_id + ")";
            }
        }
        public class Department
        {

            public int id;
            public string name;
            public Department(int i, string s)
            {
                this.id = i;
                this.name = s;
            }
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + " name=" + this.name + ")";
            }
        }
        public class Worker_Department
        {

            public int work_id;
            public int dep_id;
            public Worker_Department(int w, int d)
            {
                this.work_id = w;
                this.dep_id = d;
            }
            public override string ToString()
            {
                return "(work_id=" + this.work_id.ToString() + " dep_id = " + this.dep_id.ToString() + ")";
            }
        }
        public class DataLink
        {
            public int d1;
            public int d2;

            public DataLink(int i1, int i2)
            {
                this.d1 = i1;
                this.d2 = i2;
            }
        }

        //Пример данных
        static List<Worker> workers = new List<Worker>()
            {
                new Worker(1, "Аносов", 1),
                new Worker(2, "Андронов", 1),
                new Worker(3, "Бессонов", 3),
                new Worker(4, "Лобачев", 2),
                new Worker(5, "Амелин", 2),
                new Worker(6, "Попов", 3),
                new Worker(7, "Иванов", 2),
                new Worker(8, "Туполев", 3)
            };

        static List<Department> deps = new List<Department>()
            {
                new Department(1, "Руководство"),
                new Department(2, "Маркетинг"),
                new Department(3, "Разработчики")
            };
        static List<Worker_Department> work_deps = new List<Worker_Department>()
            {
                new Worker_Department(1,1),
                new Worker_Department(1,3),
                new Worker_Department(2,1),
                new Worker_Department(3,2),
                new Worker_Department(3,1),
                new Worker_Department(4,2),
                new Worker_Department(5,3),
                new Worker_Department(5,1),
                new Worker_Department(6,2),
                new Worker_Department(6,3)
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Сотрудники");
            var q00 = from x in workers select x;
            foreach (var x in q00) Console.WriteLine(x);
            Console.WriteLine("Отделы");
            var q01 = from x in deps select x;
            foreach (var x in q01) Console.WriteLine(x);

            Console.WriteLine("\n\nСписок всех сотрудников и отделов, отсортированный по отделам");
            var q1 = from x in deps
                     join y in workers on x.id equals y.department_id
                     orderby x.name
                     group y by x.id into g
                     select new { Key = g.Key, Values = g };
            foreach (var x in q1)
            {
                var q2 = from z in deps
                         where z.id == x.Key
                         select z.name;
                foreach (var z in q2) Console.WriteLine(z);
                foreach (var y in x.Values)
                    Console.WriteLine("   " + y.surname);
            }

            Console.WriteLine("\n\n\nСписок всех сотрудников, у которых фамилия начинается с буквы «А»");
            var q3 = from x in workers
                     where x.surname[0] == 'А'
                     select x;
            foreach (var x in q3) Console.WriteLine(x.surname);

            Console.WriteLine("\n\nСписок всех отделов и количество сотрудников в каждом отделе");
            var q4 = from x in deps
                     join y in workers on x.id equals y.department_id
                     group y by x.id into g
                     select new { Key = g.Key, Values = g };
            foreach (var x in q1)
            {
                string depName = deps.Where(z => z.id == x.Key).First().name;
                Console.WriteLine(depName);
                Console.WriteLine("Количество сотрудников: {0}", x.Values.Count());
            }

            Console.WriteLine("\n\nCписок отделов, в которых у всех сотрудников фамилия начинается с буквы «А»");
            var q5 = from x in deps
                     join y in workers on x.id equals y.department_id
                     where y.surname[0] == 'А'
                     group y by x.id into g
                     select new { Key = g.Key, Values = g };
            foreach (var x in q5)
            {
                int workCounts = workers.Where(z => z.department_id == x.Key).Count();
                if (x.Values.Count() == workCounts)
                {
                    string depName = deps.Where(z => z.id == x.Key).First().name;
                    Console.WriteLine(depName);
                    foreach (var y in x.Values)
                        Console.WriteLine("   " + y.surname);
                }
            }
            Console.WriteLine("\n\nCписок отделов, в которых хотя бы у одного сотрудника фамилия начинается с буквы «А»");
            var q6 = from x in deps
                     join y in workers on x.id equals y.department_id
                     where y.surname[0] == 'А'
                     group y by x.id into g
                     select new { Key = g.Key, Values = g };
            foreach (var x in q6)
            {
                {
                    string depName = deps.Where(z => z.id == x.Key).First().name;
                    Console.WriteLine(depName);
                    foreach (var y in x.Values)
                        Console.WriteLine("   " + y.surname);
                }
            }
            Console.WriteLine("\n\nМногие-к-многим");
            var lnk0 = from x in workers
                       join l in work_deps on x.id equals l.work_id into temp
                       from t1 in temp
                       join y in deps on t1.dep_id equals y.id into temp2
                       from t2 in temp2
                       select new { x.surname, t2.name };
            foreach (var x in lnk0)
            {
                    Console.WriteLine(x);
            }
            Console.WriteLine("\n\nСписок всех отделов и список сотрудников в каждом отделе");
            var lnk1 = from x in workers
                       join l in work_deps on x.id equals l.work_id into temp
                       from t1 in temp
                       join y in deps on t1.dep_id equals y.id into temp2
                       from t2 in temp2
                       group x by t2.id into g
                       select new { Key = g.Key, Values = g };
            foreach (var x in lnk1)
            {
                string depName = deps.Where(z => z.id == x.Key).First().name;
                Console.WriteLine(depName);
                foreach (var y in x.Values)
                    Console.WriteLine("\t" + y.surname);
            }
            Console.WriteLine("\n\nCписок всех отделов и количество сотрудников в каждом отделе");
            var lnk2 = from x in workers
                       join l in work_deps on x.id equals l.work_id into temp
                       from t1 in temp
                       join y in deps on t1.dep_id equals y.id into temp2
                       from t2 in temp2
                       group x by t2.id into g
                       select new { Key = g.Key, Values = g };
            foreach (var x in lnk2)
            {
                string depName = deps.Where(z => z.id == x.Key).First().name;
                Console.WriteLine(depName);
                Console.WriteLine("Количество сотрудников: {0}", x.Values.Count());
            }

            Console.ReadLine();
        }
    }
}
