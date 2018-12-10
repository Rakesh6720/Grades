using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class Gradebook
    {

        public Gradebook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public virtual GradeStatistics ComputeStatistics()
        {

            Console.WriteLine("GradeBook::ComputerStatistics");

            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count();

            return stats;
        }

        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            // can you notify other parts of code that the grade book name habeen changed?
            // this is the role of Events and Delegates
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }

                if (_name != value && NameChanged != null)
                {
                    NamedChangedEventArgs args = new NamedChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }

                _name = value;

            }
        }

        public NameChangedDelegate NameChanged;

        protected List<float> grades;
    }
}
