using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.User.Records;

public record MessageStatus(IMessage Message, bool IsRead);