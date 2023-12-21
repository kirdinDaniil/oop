using Itmo.ObjectOrientedProgramming.Lab3.Enums;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Builder;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;

public class Message : IMessage
{
    private Message(string header, string body, ImportanceLevels importance)
    {
        Header = header;
        Body = body;
        Importance = importance;
    }

    public static IHeaderBuilder Builder => new MassageBuilder();
    public string Header { get; private set; }
    public string Body { get; private set; }
    public ImportanceLevels Importance { get; private set; }

    public override bool Equals(object? obj)
    {
        if (obj is not Message message)
            return false;

        if (message.Importance == Importance &&
            message.Body == Body &&
            message.Header == Header)
            return true;

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private class MassageBuilder : IHeaderBuilder, IBodyBuilder, IImportanceBuilder, IMessageBuilder
    {
        private string _body = string.Empty;
        private string _header = string.Empty;
        private ImportanceLevels _importance = ImportanceLevels.NULL;

        public IImportanceBuilder WithBody(string body)
        {
            _body = body;

            return this;
        }

        public IBodyBuilder WithHeader(string header)
        {
            _header = header;

            return this;
        }

        public IMessageBuilder WithImportance(ImportanceLevels importance)
        {
            _importance = importance;

            return this;
        }

        public IMessage Build()
        {
            return new Message(_body, _header, _importance);
        }
    }
}