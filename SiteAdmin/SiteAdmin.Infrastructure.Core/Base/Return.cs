using SiteAdmin.Business.Dto.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteAdmin.Infrastructure.Core.Base
{
    public class Return<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public List<Message> Messages { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionStackTrace { get; set; }

        public Return(T data)
        {
            this.Data = data;
            Success = true;
            this.Messages = null;
        }

        public Return(List<Message> messages)
        {
            this.Messages = messages;
            Success = false;
        }

        public Return(Message message)
        {
            this.Messages = new List<Message> { message };
            this.Success = false;
        }

        public Return(Exception error)
        {
            this.InitializeErrorReturn(error);
        }

        private void InitializeErrorReturn(Exception error)
        {
            this.Success = false;
            this.ExceptionMessage = error.Message;
            this.ExceptionSource = error.Source;
            this.ExceptionStackTrace = error.StackTrace;
        }
    }
}
