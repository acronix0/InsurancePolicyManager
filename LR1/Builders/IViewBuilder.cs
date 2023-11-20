using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1.Builders
{
    internal interface IViewBuilder
    {
        IViewBuilder SetTitleColor(ConsoleColor color);
        IViewBuilder SetWarningColor(ConsoleColor color);
    }
}
