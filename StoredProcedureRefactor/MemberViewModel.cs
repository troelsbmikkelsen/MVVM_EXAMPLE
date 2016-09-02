using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_EXAMPLE {
    class MemberViewModel : ObservableObject {
        private Member _member = new Member();

        //public string str = "asgokdhifg";
        public string Fornavn
        {
            get { return _member.Fornavn; }
            set { _member.Fornavn = value; RaisePropertyChangedEvent("Fornavn");
            }
        }

        public string Efternavn
        {
            get
            {
                return _member.Efternavn;
            }
            set
            {
                _member.Efternavn = value;
                RaisePropertyChangedEvent("Efternavn");
            }
        }
        
        private void _Load() {
            var __member = DatabaseAccess.GetMemberNr(1);

            Fornavn = __member.Fornavn;
            Efternavn = __member.Efternavn;
            //RaisePropertyChangedEvent("Fornavn");
            //RaisePropertyChangedEvent("Efternavn");
        }

        public ICommand Load
        {
            get { return new DelegateCommand(_Load); }
        }

        private void _RemoveLastChar() {
            Fornavn = Fornavn.Remove(Fornavn.Length - 1);
        }

        public ICommand RemoveLastChar
        {
            //get { return new DelegateCommand(_RemoveLastChar); }
            get { return new DelegateCommand(() => Fornavn = Fornavn.Remove(Fornavn.Length - 1)); }
        }

    }
}
