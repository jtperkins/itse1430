using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.UI
{
    class MessageService : IMessageService
    {
        public void Send( Message message )
        {
            _messages.Add(message);
        }

        public IEnumerable<Message> GetAll()
        {
            foreach (var message in _messages)
                yield return message;
        }

        private List<Message> _messages = new List<Message>();
    }
}
