using System;
using System.Collections.Generic;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.Json;
using System.Text.Json.Serialization;
using static StudentManagement.IStudentService;


namespace StudentManagement
{
    public class SearchStudentViewModel : BaseViewModel
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
            get => m_selectedclass;
            set
            {
                m_selectedclass = value;
                OnPropertyChanged(nameof(m_selectedclass));
            }
        }
        private Student m_selectedstudent;
        public Student SelectedStudent
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
        public ICommand DeleteCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        private IStudentService m_studentSrv;
        public SearchStudentViewModel()
        {
            m_studentSrv = new StudentServiceWithFile();
            //m_studentSrv = new StudentServiceWithEF();
            Students = new ObservableCollection<Student>(m_studentSrv.SearchStudent(string.Empty, string.Empty));
            OpenDetailCommand = new ConditionalCommand(x => DoOpenDetail());
            SearchCommand = new ConditionalCommand(x => DoSearch());
            ResetCommand = new ConditionalCommand(x => DoReset());
            DeleteCommand = new ConditionalCommand(x => DoDelete());
        }
        public void DoReset()
        {
            Searchkeyword = null;
            SelectedClass = null;
            DoSearch();
        }
        private void DoSearch()
        {
            Students.Clear();
            var result = m_studentSrv.SearchStudent(Searchkeyword, SelectedClass);
            foreach (var s in result)
            {
                Students.Add(s);
            }
        }

        private void DoDelete()
        {
            m_studentSrv.DeleteStudentById(SelectedStudent.studentId);
            DoSearch();
        }


        public void DoOpenDetail()
        {
            var StudentDetailViewModel = new StudentDetailViewModel(m_studentSrv, SelectedStudent.studentId);
            Window1 studentDetail = new Window1(StudentDetailViewModel);
            studentDetail.DataContext = StudentDetailViewModel;
            studentDetail.ShowDialog();

        }
    }
}
