/**********************************************************
 * 
 * Taylor Perkins
 * ITSE 1430
 * 4/13/2019
 * 
 * ********************************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.UI
{
    public class MessageService : IMessageService
    {
        /// <summary>
        /// "sends" the Message. just adds it to a list of Message, to be rewritten everytime 
        /// </summary>
        public void Send( Message message )
        {
            if (message == null)
                throw new ArgumentNullException();
            else
                _messages.Add(message);

        }

        /// <summary>
        /// reutnrs an IEnumerable of all the Messages in List
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Message> GetAll()
        {
            foreach (var message in _messages)
                yield return message;
        }

        private List<Message> _messages = new List<Message>();
    }
}
