using Prism.Mvvm;

namespace ModuleA.Business
{
    public class Person : BindableBase
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
