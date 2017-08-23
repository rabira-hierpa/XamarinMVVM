using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XamarinMVVM.Annotations;
using XamarinMVVM.Models;
using XamarinMVVM.Services;

namespace XamarinMVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private List<Employeee> _employeeesList;

        public List<Employeee> EmployeeesList
        {
            get { return _employeeesList; }
            set
            {
                _employeeesList = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            var employeeservices = new EmployeeServices();

            EmployeeesList = employeeservices.GetEmployeees();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
