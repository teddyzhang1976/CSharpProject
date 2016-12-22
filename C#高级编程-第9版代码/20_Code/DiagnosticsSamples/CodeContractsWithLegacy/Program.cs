using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeContractsWithLegacy
{
  class Program
  {
    static void Main(string[] args)
    {

      PrecondtionsWithLegacyCode(new object()); // contract error
    }

    static void PrecondtionsWithLegacyCode(object o)
    {
      if (o == null) throw new ArgumentNullException("o");
      Contract.EndContractBlock();
    }
  }
}
