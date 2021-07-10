using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Shkolla_OOP
{
    public partial class FrmMain : Form
    {
        ElementarySchool elementarySchool;
        HighSchool highSchool;
        University university;

        public FrmMain()
        {
            InitializeComponent();
            elementarySchool = new ElementarySchool();
            highSchool = new HighSchool();
            university = new University();
        }


        //TAB ELEMENTARY SCHOOL
        private void btnAddStudentTeacher1_Click(object sender, EventArgs e)
        {
            if(cbStudentOrTeacher.SelectedIndex == 0)
            {
                ElementarySchoolStudent student = new ElementarySchoolStudent(
                txtName1.Text,
                txtSurname1.Text,
                Convert.ToInt32(numAge1.Value),
                Convert.ToChar(cbGender1.SelectedItem.ToString().Substring(0, 1)),
                new Address(cbCity1.SelectedItem.ToString(), txtNumber1.Text, txtStreet1.Text),
                cbAcademicYear.SelectedItem.ToString()
                ); 
                elementarySchool.addStudent(student);
                student.Display();
            }
            else
            {
                Teacher teacher = new Teacher(
                txtName1.Text,
                txtSurname1.Text,
                Convert.ToInt32(numAge1.Value),
                Convert.ToChar(cbGender1.SelectedItem.ToString().Substring(0, 1)),
                new Address(cbCity1.SelectedItem.ToString(), txtNumber1.Text, txtStreet1.Text)
                );
                elementarySchool.addTeacher(teacher);
                teacher.Display();
            }
        }

        private void btnAddSubject1_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject(txtSubjectName1.Text);
            elementarySchool.addSubject(subject);
            cbSubject1.Items.Clear();
            elementarySchool.subjects.ForEach(x => { cbSubject1.Items.Add(x.name);});
            subject.Display();
        }

        private void btnAddGrade1_Click(object sender, EventArgs e)
        {
            int sameOcurrences = 0;
            foreach (var student in elementarySchool.students)
            {
                if (student.name + " " + student.surname == txtNameSurnameID1.Text)
                {
                    sameOcurrences++;
                }
            }
            if (sameOcurrences >= 2)
                MessageBox.Show($"{sameOcurrences} nxenesa me emer te njejte, ju lutem specifikoni permes ID-se");

            bool response;
            int parsedValue;
            if (int.TryParse(txtNameSurnameID1.Text, out parsedValue))
                response = elementarySchool.addStudentGrade(parsedValue,cbSubject1.SelectedItem.ToString(), Convert.ToInt32(numGrade1.Value));
            else
                response = elementarySchool.addStudentGrade(txtNameSurnameID1.Text, cbSubject1.SelectedItem.ToString(), Convert.ToInt32(numGrade1.Value));

            Helper.showMessage(response, "Nota u shtua me sukses");
        }

        private void btnAddAcademicYear1_Click(object sender, EventArgs e)
        {
            bool response = elementarySchool.addAcademicYear(Convert.ToInt32((numAcademicYear1.Value)));
            if (!Helper.showMessage(response, "Viti akademik u krijua me sukses"))
                return;

            cbAcademicYear.Items.Clear();
            elementarySchool.academicYears.ForEach(year => { cbAcademicYear.Items.Add(year); });
        }

        private void cbStudentOrTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudentOrTeacher.SelectedIndex == 0)
            {
                cbAcademicYear.Visible = true;
                metroLabel40.Visible = true;
                numAge1.Minimum = 5;
                numAge1.Value = 5;
            }
            else
            {
                cbAcademicYear.Visible = false;
                metroLabel40.Visible = false;
                numAge1.Minimum = 18;
            }
        }



        //TAB HIGH SCHOOL
        private void btnAddStudentTeacher2_Click(object sender, EventArgs e)
        {
            if (cbStudentOrTeacher2.SelectedIndex == 0)
            {
                HighSchoolStudent student = new HighSchoolStudent(
                txtName2.Text,
                txtSurname2.Text,
                Convert.ToInt32(numAge2.Value),
                Convert.ToChar(cbGender2.SelectedItem.ToString().Substring(0, 1)),
                new Address(cbCity2.SelectedItem.ToString(), txtNumber2.Text, txtStreet2.Text),
                cbAcademicYear2.SelectedItem.ToString(),
                cbCourse2.SelectedItem.ToString()
                );
                highSchool.addStudent(student);
                student.Display();
            }
            else
            {
                Teacher teacher = new Teacher(
                txtName2.Text,
                txtSurname2.Text,
                Convert.ToInt32(numAge2.Value),
                Convert.ToChar(cbGender2.SelectedItem.ToString().Substring(0, 1)),
                new Address(cbCity2.SelectedItem.ToString(), txtNumber2.Text, txtStreet2.Text)
                );
                highSchool.addTeacher(teacher);
                teacher.Display();
            }
        }

        private void btnAddSubject2_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject(txtSubjectName2.Text);
            highSchool.addSubject(subject);
            cbSubject2.Items.Clear();
            highSchool.subjects.ForEach(x => { cbSubject2.Items.Add(x.name); });
            subject.Display();
        }

        private void btnAddGrade2_Click(object sender, EventArgs e)
        {
            int sameOcurrences = 0;
            foreach (var student in highSchool.students)
            {
                if (student.name + " " + student.surname == txtNameSurnameID2.Text)
                {
                    sameOcurrences++;
                }
            }
            if (sameOcurrences >= 2)
                MessageBox.Show($"{sameOcurrences} nxenesa me emer te njejte, ju lutem specifikoni permes ID-se");

            bool response;
            int parsedValue;
            if (int.TryParse(txtNameSurnameID2.Text, out parsedValue))
                response = highSchool.addStudentGrade(parsedValue, cbSubject2.SelectedItem.ToString(), Convert.ToInt32(numGrade2.Value));
            else
                response = highSchool.addStudentGrade(txtNameSurnameID2.Text, cbSubject2.SelectedItem.ToString(), Convert.ToInt32(numGrade2.Value));

            Helper.showMessage(response, "Nota u shtua me sukses");
        }

        private void btnAddCourse2_Click(object sender, EventArgs e)
        {
            bool response = highSchool.addCourse(txtCourseName2.Text);
            if (!Helper.showMessage(response, "Drejtimi u krijua me sukses"))
                return;

            cbCourse2.Items.Clear();
            highSchool.courses.ForEach(name => { cbCourse2.Items.Add(name); });
        }

        private void btnAddAcademicYear2_Click(object sender, EventArgs e)
        {
            bool response = highSchool.addAcademicYear(Convert.ToInt32((numAcademicYear2.Value)));
            if (!Helper.showMessage(response, "Drejtimi u krijua me sukses"))
                return;

            cbAcademicYear2.Items.Clear();
            highSchool.academicYears.ForEach(year => { cbAcademicYear2.Items.Add(year); });
        }

        private void cbStudentOrTeacher2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudentOrTeacher2.SelectedIndex == 0)
            {
                cbAcademicYear2.Visible = true;
                metroLabel22.Visible = true;
                numAge2.Minimum = 14;
                numAge2.Value = 14;
            }
            else
            {
                cbAcademicYear2.Visible = false;
                metroLabel22.Visible = false;
                numAge2.Minimum = 18;
            }
        }



        //TAB UNIVERSITY
        private void btnAddStudentTeacher3_Click(object sender, EventArgs e)
        {
            if (cbStudentOrTeacher3.SelectedIndex == 0)
            {
                UniversityStudent student = new UniversityStudent(
                txtName3.Text,
                txtSurname3.Text,
                Convert.ToInt32(numAge3.Value),
                Convert.ToChar(cbGender3.SelectedItem.ToString().Substring(0, 1)),
                new Address(cbCity3.SelectedItem.ToString(), txtNumber3.Text, txtStreet3.Text),
                cbAcademicYear3.SelectedItem.ToString(),
                cbCourse3.SelectedItem.ToString()
                );
                university.addStudent(student);
                student.Display();
            }
            else
            {
                Teacher teacher = new Teacher(
                txtName3.Text,
                txtSurname3.Text,
                Convert.ToInt32(numAge3.Value),
                Convert.ToChar(cbGender3.SelectedItem.ToString().Substring(0, 1)),
                new Address(cbCity3.SelectedItem.ToString(), txtNumber3.Text, txtStreet3.Text)
                );
                university.addTeacher(teacher);
                teacher.Display();
            }
        }

        private void btnAddSubject3_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject(txtSubjectName3.Text);
            university.addSubject(subject);
            cbSubject3.Items.Clear();
            cbPeriodSubject.Items.Clear();
            university.subjects.ForEach(x => { cbSubject3.Items.Add(x.name); cbPeriodSubject.Items.Add(x.name); });
            subject.Display();
        }

        private void btnAddGrade3_Click(object sender, EventArgs e)
        {
            int sameOcurrences = 0;
            foreach (var student in university.students)
            {
                if (student.name + " " + student.surname == txtNameSurnameID3.Text)
                {
                    sameOcurrences++;
                }
            }
            if (sameOcurrences >= 2)
                MessageBox.Show($"{sameOcurrences} nxenesa me emer te njejte, ju lutem specifikoni permes ID-se");

            int parsedValue;
            if (int.TryParse(txtNameSurnameID3.Text, out parsedValue))
                university.addStudentGrade(parsedValue, cbSubject3.SelectedItem.ToString(), Convert.ToInt32(numGrade3.Value));
            else
                university.addStudentGrade(txtNameSurnameID3.Text, cbSubject3.SelectedItem.ToString(), Convert.ToInt32(numGrade3.Value));
        }

        private void btnAddCourse3_Click(object sender, EventArgs e)
        {
            bool response = university.addCourse(txtCourseName3.Text);
            if (!Helper.showMessage(response, "Drejtimi u krijua me sukses"))
                return;

            cbCourse3.Items.Clear();
            university.courses.ForEach(name => { cbCourse3.Items.Add(name); });
        }

        private void addPeriodSubject_Click(object sender, EventArgs e)
        {
            foreach (var examPeriod in university.examPeriods)
            {
                if (examPeriod.date.ToString("MMMM") == cbPeriods.SelectedItem.ToString())
                {
                    var periodSubject = cbPeriodSubject.SelectedItem.ToString();
                    examPeriod.addSubject(periodSubject);
                    lbStudentSubject.Items.Clear();
                    university.examPeriods.ForEach(period => { 
                        period.subjects.ForEach(subject => { 
                            if(!lbStudentSubject.Items.Contains(subject))
                                lbStudentSubject.Items.Add(subject);
                        }); 
                    });
                    examPeriod.Display();
                }
            }
        }

        private void btnSubmitExam_Click(object sender, EventArgs e)
        {
            var studentSubjects = new List<Subject>();
            foreach (var item in lbStudentSubject.SelectedItems)
            {
                studentSubjects.Add(new Subject(item.ToString()));
            }

            bool response = university.submitStudentExams(int.Parse(txtStudentID.Text), studentSubjects);
            if (!Helper.showMessage(response, "Provimi u paraqit me sukses"))
                return;

            university.addRandomExams();
        }

        private void btnGenerateExamPeriods_Click(object sender, EventArgs e)
        {
            university.generateExamPeriods();
            cbPeriods.Items.Clear();
            foreach (var period in university.examPeriods)
            {
                cbPeriods.Items.Add(period.date.ToString("MMMM"));
            }
            MessageBox.Show("Afati i provimeve u gjenerua me sukses.");
        }

        private void btnAddAcademicYear3_Click(object sender, EventArgs e)
        {
            bool response = university.addAcademicYear(Convert.ToInt32((numAcademicYear3.Value)));
            if (!Helper.showMessage(response, "Viti akademik u krijua me sukses"))
                return;

            cbAcademicYear3.Items.Clear();
            university.academicYears.ForEach(year => { cbAcademicYear3.Items.Add(year); });
        }

        private void cbStudentOrTeacher3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStudentOrTeacher3.SelectedIndex == 0)
            {
                cbAcademicYear3.Visible = true;
                metroLabel35.Visible = true;
                numAge3.Minimum = 18;
                numAge3.Value = 18;
            }
            else
            {
                cbAcademicYear3.Visible = false;
                metroLabel35.Visible = false;
                numAge3.Minimum = 18;
            }
        }


        //REPORTS
        private void btnStudentPassedExams_Click(object sender, EventArgs e)
        {
            dgGeneral.Columns.Clear();
            var passedExams = university.passedExamsOfStudent(int.Parse(txtStudentIDForReport.Text));
            var report = passedExams.Select(i => new { studentName = i.student.name + " " + i.student.surname, subjectName = i.subject.name, i.examPoints }).ToList();

            dgGeneral.AutoGenerateColumns = false;
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Studenti", DataPropertyName = "studentName", Name = "student" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Provimi", DataPropertyName = "subjectName", Name = "subject" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Piket e Provimit", DataPropertyName = "examPoints", Name = "points" });

            dgGeneral.DataSource = report;
        }

        private void btnSubjectsPassedExamsNr_Click(object sender, EventArgs e)
        {
            dgGeneral.Columns.Clear();
            var report = university.nrOfSubjectPassedExams();

            dgGeneral.AutoGenerateColumns = false;
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Lenda", DataPropertyName = "Key", Name = "key" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Nr i Studentave qe e kane dhene provimin", DataPropertyName = "Value", Name = "value" });
            dgGeneral.DataSource = report;
        }

        private void btnStudentsReportByAcademicYear_Click(object sender, EventArgs e)
        {
            var tempReport = new Dictionary<string, int>();

            List<School> schools = new List<School>();
            schools.Add(elementarySchool);
            schools.Add(highSchool);
            schools.Add(university);

            foreach (var school in schools)
            {
                foreach (var keyValuePair in school.studentsNrByAcademicYear())
                {
                    if (!tempReport.ContainsKey(keyValuePair.Key))
                        tempReport.Add(keyValuePair.Key, +1);
                    else
                        tempReport[keyValuePair.Key]++;
                }
            }

            dgGeneral.Columns.Clear();
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Viti Akademik", DataPropertyName = "Key", Name = "key" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Numri i Nxenesve", DataPropertyName = "Value", Name = "value" });
            dgGeneral.DataSource = tempReport.ToList();
        }

        private void btnStudentsNrByCourse2_Click(object sender, EventArgs e)
        {
            var tempReport = new List<KeyValuePair<string, int>>();

            List<ICourse> schools = new List<ICourse>();
            schools.Add(highSchool);
            schools.Add(university);

            foreach (var school in schools)
            {
                tempReport = tempReport.Concat(school.studentsReportByCourse()).ToList();
            }

            dgGeneral.Columns.Clear();
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Drejtimi", DataPropertyName = "Key", Name = "key" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Numri i Nxenesve", DataPropertyName = "Value", Name = "value" });
            dgGeneral.DataSource = tempReport;
        }

        private void btnShowStudentsAverage1_Click(object sender, EventArgs e)
        {
            dgStudents1.Columns.Clear();
            dgStudents1.AutoGenerateColumns = false;
            dgStudents1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Id", DataPropertyName = "id", HeaderText = "ID" });
            dgStudents1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Name", DataPropertyName = "name", HeaderText = "Emri" });
            dgStudents1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Surname", DataPropertyName = "surname", HeaderText = "Mbiemri" });
            dgStudents1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "academicYear", DataPropertyName = "academicYear", HeaderText = "Viti Akademik" });
            dgStudents1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "AverageGrade", DataPropertyName = "averageGrade", HeaderText = "Nota Mesatare" });

            var averageGradesList = elementarySchool.studentsSuccessForEachCycle();
            dgStudents1.DataSource = averageGradesList;
        }

        private void btnShowStudentsStatistics1_Click(object sender, EventArgs e)
        {
            DataGridViewTextBoxColumn colGrade = new DataGridViewTextBoxColumn()
            {
                Name = "Grade",
                DataPropertyName = "Key",
                HeaderText = "Nota"
            };
            DataGridViewTextBoxColumn colStudentsNumber = new DataGridViewTextBoxColumn()
            {
                Name = "StudentsNumber",
                DataPropertyName = "Value",
                HeaderText = "Numri i nxenesve"
            };

            dgStudents1.Columns.Clear();
            dgStudents1.Columns.Add(colGrade);
            dgStudents1.Columns.Add(colStudentsNumber);
            dgStudents1.AutoGenerateColumns = false;

            var statisticsList = elementarySchool.showStudentsStatistics();
            dgStudents1.DataSource = statisticsList;
        }

        private void btnStudentsReportForEachCycle_Click(object sender, EventArgs e)
        {
            List<Student> tempStudents = new List<Student>();

            List<School> schools = new List<School>();
            schools.Add(elementarySchool);
            schools.Add(highSchool);
            schools.Add(university);

            foreach (var school in schools)
            {
                tempStudents = tempStudents.Concat(school.studentsSuccessForEachCycle()).ToList();
            }

            dgGeneral.Columns.Clear();
            dgGeneral.AutoGenerateColumns = false;
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { Name = "id", DataPropertyName = "id", HeaderText = "ID" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { Name = "name", DataPropertyName = "name", HeaderText = "Emri" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { Name = "surname", DataPropertyName = "surname", HeaderText = "Mbiemri" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { Name = "age", DataPropertyName = "age", HeaderText = "Mosha" });
            dgGeneral.Columns.Add(new DataGridViewTextBoxColumn() { Name = "averageGrade", DataPropertyName = "averageGrade", HeaderText = "Suksesi" });

            dgGeneral.DataSource = tempStudents;
        }
    }
}
