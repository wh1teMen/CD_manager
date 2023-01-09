using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auditorka
{
    internal class Disk
    {
        public string name;
        public long freeSize;
        public long fullSize;

        public string Name
        {
            get=>name;
            set=>name = value;  
        }
        public long FreeSize 
        {
            get=>freeSize;
            set => freeSize = value;
        }
        public long FullSize
        {
            get => fullSize;
            set => fullSize = value;
        }
       public Disk(string name_, long freeSize_, long fullSize_)
        {
           name = name_;
           freeSize = freeSize_;
           fullSize = fullSize_;            
        }
    }
}
