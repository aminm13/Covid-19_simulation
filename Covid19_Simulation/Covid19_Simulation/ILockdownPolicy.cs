using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19_Simulation
{
    public interface ILockdownPolicy
    {
        List<Member> socialEvent(   List<Member> members, 
                                    String culture, 
                                    int density, 
                                    int districts, 
                                    int nrPatients);
    }
}
