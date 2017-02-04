using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDomain
{
    public interface IView<T>
    {
        ManualResetEvent Updating { get; }

        void Initialize(IDrawModel<T> model);

        void Display(IDrawModel<T> model);

        void Redraw();

        void Start();
    }
}
