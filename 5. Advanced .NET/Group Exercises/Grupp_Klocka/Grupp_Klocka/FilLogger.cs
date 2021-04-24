using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Grupp_Klocka
{
    class FilLogger
    {
        public void KlockSkrivaTillFil(object sender, TickEventArgs e)
        {
            if (sender != null)
                File.AppendAllText("klocka.txt", e.ToString() + "\n");
        }
    }
}
