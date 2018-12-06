using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicTrainer.Handler
{
    public class Handler
    {
        protected readonly Main main;

        public Handler(Main instaceOfMain)
        {
            this.main = instaceOfMain;
        }
    }
}
