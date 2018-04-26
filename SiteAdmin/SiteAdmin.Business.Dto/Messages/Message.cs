using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace SiteAdmin.Business.Dto.Messages
{
    public class DtoMessage
    {
        public static Message GetMessage(string resourceName, string idMessage, string objectName = "", MessageType type = MessageType.Validation)
        {
            //ResourceManager resourceManager = new global::System.Resources.ResourceManager();// new global::System.Resources.ResourceManager(string.Concat("HorseManagement.Business.Dto.Messages.", resourceName), typeof(Messages.DtoMessages).Assembly);

            //string message = resourceManager.GetString(idMessage, System.Globalization.CultureInfo.CurrentCulture);
            //if (string.IsNullOrEmpty(message))
            //{
            //    message = "Mensagem não encontrada, favor verificar no Resource!!!";
            //}

            //Message returnMessage = new Message(idMessage, message, objectName, type);

            return new Message("",""); //returnMessage;
        }
    }

    public class Message
    {
        public string Id { get; private set; }
        public string Msg { get; private set; }
        public MessageType Type { get; private set; }
        public string ObjectName { get; private set; }

        public Message(string id, string message)
        {
            this.Id = id;
            this.Msg = message;
        }

        public Message(string id, string message, string objectName)
        {
            this.Id = id;
            this.Msg = message;
            this.ObjectName = objectName;
        }

        public Message(string id, string message, string objectName, MessageType type)
        {
            this.Id = id;
            this.Msg = message;
            this.Type = type;
            this.ObjectName = objectName;
        }

        public Message(string id, string message, MessageType type)
        {
            this.Id = id;
            this.Msg = message;
            this.Type = type;
        }
    }

    public enum MessageType
    {
        Affirmative,
        Alert,
        Validation
    }
}
