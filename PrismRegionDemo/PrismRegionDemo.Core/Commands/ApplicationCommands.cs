using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismRegionDemo.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveAllCommand => new CompositeCommand();
    }
}
