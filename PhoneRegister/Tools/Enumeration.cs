using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneRegister.Tools
{
    public enum UserViewEnum
    {
        PhonesView=1,
        Exit=2
    }
    public enum PhoneViewEnum
    {
        AddPhone=1,
        DeletePhone=2,
        PhoneManagement=3,
        SeeMyPhoes=4,
        Exit=5
    }
    public enum PhoneManagementViewEnum
    {
        AddContact = 1,
        DeleteContact = 2,
        EditContact = 3,
        SeeMyContacts = 4,
        DeleteAllContacts=5,
        Exit = 6
    }
}
