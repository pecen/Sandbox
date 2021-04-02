using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismEventAggregatorDemo.Core.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ModuleB.ViewModels
{
    public class MessageListViewModel : BindableBase
    {
        private ObservableCollection<string> _messages = new ObservableCollection<string>();

        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<MessageSentEvent>()
                .Subscribe(OnMessageReceived);
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
