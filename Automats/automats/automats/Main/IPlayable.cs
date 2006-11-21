using System;
using System.Collections.Generic;
using System.Text;

namespace automats
{
    public interface IPlayableMDIChild
    {
        void Play();

        void Step();
    }
}
