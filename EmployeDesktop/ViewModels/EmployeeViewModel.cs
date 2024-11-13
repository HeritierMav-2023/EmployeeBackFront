using EmployeDesktop.Models;
using EmployeDesktop.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EmployeDesktop.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region Propriétes

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        private string _isAddEmp = "Collapsed";
        public string IsAddEmp
        {
            get { return _isAddEmp; }
            set
            {
                _isAddEmp = value;
                NotifyPropertyChanged("IsAddEmp");
            }
        }
        private List<EmployeeModel> _employeeList;
        public List<EmployeeModel> EmployeeList
        {
            get { return _employeeList; }
            set
            {
                _employeeList = value;
                NotifyPropertyChanged("EmployeeList");

            }
        }

        private EmployeeModel _selectedData;
        public EmployeeModel SelectedData
        {
            get { return _selectedData; }
            set
            {
                _selectedData = value;
                NotifyPropertyChanged("SelectedData");
            }
        }

        public ICommand cmdUpdateItem { get; private set; }
        public ICommand cmdCancelEmp { get; private set; }
        public ICommand cmdAddaEmp { get; private set; }
        public ICommand cmdAddEmp { get; private set; }
        public ICommand cmdDeleteItem { get; private set; }

        public bool CanExectute
        {
            get { return !string.IsNullOrEmpty(FirstName); }
        }
        public bool CanExectute_Update
        {
            get { return IsAddEmp == "Collapsed"; }
        }
        public bool CanDelete
        {
            get { return SelectedData != null; }
        }
        public bool CanAddaEmp
        {
            get { return IsAddEmp== "Collapsed"; }
        }

        #endregion
        private bool isUpdate = false;

        #region Constructeur
        public EmployeeViewModel()
        {
            getEmployee();
        }
        #endregion

        //ITaskService task = new TaskService();
        IEmployeeService service = new EmployeeService();

        #region Methode
        public void getEmployee()
        {
            EmployeeList = service.GetEmployee();
        }
        #endregion
    }
}
