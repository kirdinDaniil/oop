using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.ServiceException;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory;

public class CommandParser
{
    private string[] _splitData;

    public CommandParser()
    {
        _splitData = new string[1];
    }

    public BaseCommandData ParseCommand(string command)
    {
        if (string.IsNullOrEmpty(command))
            throw new ServiceLayerException("Command string must not be empty");

        _splitData = command.Split(" ");
        return _splitData[0] switch
        {
            "connect" => GetConnectData(),
            "disconnect" => GetDisconnectData(),
            "tree" => GetTreeData(),
            "file" => GetFileData(),
            _ => new UnknownData(),
        };
    }

    private static DisconnectData GetDisconnectData()
    {
        return new DisconnectData();
    }

    private ConnectData GetConnectData()
    {
        return new ConnectData(_splitData[1], _splitData[3]);
    }

    private BaseCommandData GetTreeData()
    {
        return _splitData[1] switch
        {
            "goto" => GetTreeGotoData(),
            "list" => GetTreeListData(),
            _ => new UnknownData(),
        };
    }

    private TreeGotoData GetTreeGotoData()
    {
        return new TreeGotoData(_splitData[2]);
    }

    private TreeListData GetTreeListData()
    {
        return _splitData.Length > 2 ?
            new TreeListData(int.Parse(_splitData[3], CultureInfo.CurrentCulture)) :
            new TreeListData(null);
    }

    private BaseCommandData GetFileData()
    {
        return _splitData[1] switch
        {
            "show" => GetFileShowData(),
            "move" => GetFileMoveData(),
            "copy" => GetFileCopyData(),
            "delete" => GetFileDeleteData(),
            "rename" => GetFileRenameData(),
            _ => new UnknownData(),
        };
    }

    private FileShowData GetFileShowData()
    {
        return _splitData.Length > 3 ?
            new FileShowData(_splitData[2], _splitData[5])
            : new FileShowData(_splitData[2], null);
    }

    private FileMoveData GetFileMoveData()
    {
        return new FileMoveData(_splitData[2], _splitData[3]);
    }

    private FileCopyData GetFileCopyData()
    {
        return new FileCopyData(_splitData[2], _splitData[3]);
    }

    private FileDeleteData GetFileDeleteData()
    {
        return new FileDeleteData(_splitData[2]);
    }

    private FileRenameData GetFileRenameData()
    {
        return new FileRenameData(_splitData[2], _splitData[3]);
    }
}