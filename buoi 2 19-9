using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPS
{
    public class StudentDAO
    {
        private readonly List<Student> _students = new List<Student>();

        public bool Add(Student s)
        {
            if (s == null || string.IsNullOrWhiteSpace(s.Id)) return false;
            if (_students.Any(x => x.Id == s.Id)) return false;
            _students.Add(s);
            return true;
        }

        public bool Edit(Student s)
        {
            if (s == null || string.IsNullOrWhiteSpace(s.Id)) return false;
            var idx = _students.FindIndex(x => x.Id == s.Id);
            if (idx < 0) return false;
            _students[idx] = s;
            return true;
        }

        public bool Delete(string id)
        {
            var s = _students.FirstOrDefault(x => x.Id == id);
            if (s == null) return false;
            return _students.Remove(s);
        }

        public List<Student> GetAlls()
        {
            return new List<Student>(_students);
        }

        public Student GetById(string id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return new List<Student>();
            return _students
                .Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
