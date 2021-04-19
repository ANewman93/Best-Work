using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

using SchedulerModel;

namespace fileRepo
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T Find(string id);
        bool Add(T x);
        bool Update(T x);
        bool Remove(T x);
    }

    public class CourseFileRepo : IRepository<Course>
    {
        string _root;

        public CourseFileRepo(string root)
        {
            _root = root;
        }

        public List<Course> FindAll()
        {
            List<Course> courses = new List<Course>();

            using (StreamReader reader = File.OpenText(_root))
            {
                int count = 0;

                string line = null;

                line = reader.ReadLine(); // get line from file, or null at end of file

                while (line != null)
                {
                    if (count > 0) // skip first row
                    {
                        if(line.Contains("DATE:") || line.Contains("TALLY") || line == "" || line.Contains("CRSE") || line.Contains("   TE"))
                        {
                           
                        }
                        else
                        {
                            //string part1 = line.Substring(0, 10).Trim();

                            if(line.Length == 118)
                            {
                                Course cou = new Course(line.Substring(0, 10).Trim())
                                {
                                    section = line.Substring(11, 3).Trim(),
                                    crn = line.Substring(15, 5).Trim(),
                                    title = line.Substring(21, 32).Trim(),
                                    credits = line.Substring(54, 4).Trim(),
                                    c = line.Substring(59, 1).Trim(),
                                    pt = line.Substring(61, 3).Trim(),
                                    atr = line.Substring(65, 3).Trim(),
                                    begin = line.Substring(69, 7).Trim(),
                                    end = line.Substring(77, 7).Trim(),
                                    days = line.Substring(85, 7).Trim(),
                                    building = line.Substring(93, 6).Trim(),
                                    room = line.Substring(100, 4).Trim(),
                                    max = line.Substring(105, 2).Trim(),
                                    actual = line.Substring(108, 2).Trim(),
                                    remaining = line.Substring(111, 2).Trim(),
                                    r = line.Substring(115, 1).Trim(),
                                    wl = line.Substring(117, 1)
                                };

                                courses.Add(cou);
                            }
                            else
                            {
                                Course co = new Course(line.Substring(0, 10).Trim())
                                {
                                    section = line.Substring(11, 3).Trim(),
                                    crn = line.Substring(15, 5).Trim(),
                                    title = line.Substring(21, 32).Trim(),
                                    credits = line.Substring(54, 4).Trim(),
                                    c = line.Substring(59, 1).Trim(),
                                    pt = line.Substring(61, 3).Trim(),
                                    atr = line.Substring(65, 3).Trim(),
                                    begin = line.Substring(69, 7).Trim(),
                                    end = line.Substring(77, 7).Trim(),
                                    days = line.Substring(85, 7).Trim(),
                                    building = line.Substring(93, 6).Trim(),
                                    room = line.Substring(100, 4).Trim(),
                                    max = line.Substring(105, 2).Trim(),
                                    actual = line.Substring(108, 2).Trim(),
                                    remaining = line.Substring(111, 2).Trim(),
                                    r = line.Substring(115, 2).Trim(),
                                    wl = line.Substring(118, 3),
                                    faculty = line.Substring(121, line.Length - 121).Trim()
                                };

                                courses.Add(co);
                            }
                        }

                    }

                    count++;

                    line = reader.ReadLine(); // next line in file 
                } // end while 
            }// end using 

            return courses;
        }

        public Course Find(string id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Course x)
        {
            throw new NotImplementedException();
        }

        public bool Add(Course x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Course x)
        {
            throw new NotImplementedException();
        }
    }
}
