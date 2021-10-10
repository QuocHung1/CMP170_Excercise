using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.Json;

namespace StudentManagement
{
    class SearchStudentViewModel : BaseViewModel
    {
        public class Student
        {
            public int studentId { get; set; }
            public String firstname { get; set; }
            public String lastname { get; set; }
            public String email { get; set; }
            public String gender { get; set; }
            public String Class { get; set; }
            public decimal gpa { get; set; }
        }
        private String m_Searchkeyword;

        public String Searchkeyword
        {
            get => m_Searchkeyword;
            set
            {
                m_Searchkeyword = value;
                OnPropertyChanged(nameof(Searchkeyword));
            }
        }
        private String m_selectedclass;
        public String SelectedClass
        {
            get => m_Searchkeyword;
            set
            {
                m_selectedclass = value;
                OnPropertyChanged(nameof(m_selectedclass));
            }
        }
        private String m_selectedstudent;
        public String SelectedStudent
        {
            get => m_selectedstudent;
            set
            {
                m_selectedstudent = value;
                OnPropertyChanged(nameof(m_selectedstudent));
            }
        }

        public ObservableCollection<Student> Students { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        public ICommand OpenDetailCommand { get; set; }


        public SearchStudentViewModel()
        {
            var jsonString = File.ReadAllText("Student_Data.json");
            var students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            Students = new ObservableCollection<Student>(students);

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}