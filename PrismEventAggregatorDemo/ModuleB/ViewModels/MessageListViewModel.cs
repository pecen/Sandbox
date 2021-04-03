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
        private MessageSentEvent _event;
        private SubscriptionToken _token;

        private ObservableCollection<string> _messages = new ObservableCollection<string>();
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private bool _isSubscribed; // = true;
        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set 
            { 
                SetProperty(ref _isSubscribed, value);

                HandleSubsribe(_isSubscribed);
            }
        }

        private void HandleSubsribe(bool isSubscribed)
        {
            if (isSubscribed)
            {
                _token = _event.Subscribe(OnMessageReceived);
            }
            else
            {
                //_event.Unsubscribe(OnMessageReceived);
                _event.Unsubscribe(_token);
            }
        }

        public MessageListViewModel(IEventAggregator eventAggregator)
        {
            _event = eventAggregator.GetEvent<MessageSentEvent>();
            //.Subscribe(OnMessageReceived, ThreadOption.PublisherThread, false, message => message.Contains("Peter"));

            //HandleSubsribe(true);
            IsSubscribed = true;
        }

        private void OnMessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
