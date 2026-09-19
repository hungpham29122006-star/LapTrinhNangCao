using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp
{
    public class StudentDAO
    {
        private readonly List<Student> _students = new();

        public void Add(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null) throw new InvalidOperationException($"Student with Id '{student.Id}' already exists.");
            _students.Add(student);
        }

        public bool Edit(Student student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing == null) return false;
            _students[_students.IndexOf(existing)] = student;
            return true;
        }

        public void UpdateStudent(Student student)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            var updated = Edit(student);
            if (!updated) throw new InvalidOperationException($"Student with Id '{student.Id}' not found.");
        }

        public bool Delete(string id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student is null) return false;
            _students.Remove(student);
            return true;
        }

        public void DeleteStudent(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id is required.", nameof(id));
            var deleted = Delete(id);
            if (!deleted) throw new InvalidOperationException($"Student with Id '{id}' not found.");
        }

        public List<Student> GetAlls()
        {
            return _students.ToList();
        }

        public Student? GetById(string id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return new List<Student>();
            return _students.Where(s => s.Name != null && s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
