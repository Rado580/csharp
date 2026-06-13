using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4_Cvicenie
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = NewStudentText.Text;
            Listofstudents.Items.Add(name);
        }

        private void Listofstudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Listofstudents.SelectedItem == null)
            {
                StudentName.Content = "No student selected";
            }
            else 
            {
                StudentName.Content = Listofstudents.SelectedItem.ToString();
            }
            SetDetailsToNull();
        }
        private void SetDetailsToNull()
        {
            Grades.Items.Clear();
            NumberOfGrades.Content = "0";
            AverageGrades.Content = "0";
        }

        private void Deletestudent_Click(object sender, RoutedEventArgs e)
        {
            Listofstudents.Items.Remove(Listofstudents.SelectedItem);
        }

        private void AddGrade_Click(object sender, RoutedEventArgs e)
        {
            if(Listofstudents.SelectedItem == null) { return; }
            string grade = GradeSelector.Text;
            List <int> grades = new List<int>();
            Grades.Items.Add(grade);

            foreach (var item in Grades.Items) 
            { 
                grades.Add(int.Parse(item.ToString()));
            }
            NumberOfGrades.Content = Grades.Items.Count.ToString();
            AverageGrades.Content = CalculateAverageGrades(grades);
        }
        private string CalculateAverageGrades(List <int> grades)
        {
            double total = 0;
            double gradesplused = 0;
            double max = grades.Count;

            foreach(var grade in grades)
            {
                gradesplused += grade;
            }     

            total = gradesplused / max;
            return total.ToString();
        }
}
}