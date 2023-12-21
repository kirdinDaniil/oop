using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands.LfsEntities;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath;
using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.FilePath.Entities;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.ServiceException;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.Service.States;

public class LfsState : IServiceState
{
    private AbsoluteFilePath? _absoluteFilePath;
    private BaseFilePath? _currentFilePath;
    public LfsState(IService context)
    {
        Context = context;
        _absoluteFilePath = null;
        _currentFilePath = null;
    }

    public IService Context { get; private set; }
    public ICommand GetConnectOperation(ConnectData connectData)
    {
        if (connectData == null)
            throw new ServiceLayerException("Null connect data");

        _absoluteFilePath = new AbsoluteFilePath(connectData.Address);
        _currentFilePath = _absoluteFilePath.Clone();

        return new LfsConnect(connectData.Address, _absoluteFilePath, _currentFilePath);
    }

    public ICommand GetDisconnectOperation(DisconnectData disconnectData)
    {
        if (disconnectData == null)
            throw new ServiceLayerException("Null disconnect data");

        _absoluteFilePath = null;
        _currentFilePath = null;

        return new LfsDisconnect(_absoluteFilePath, _currentFilePath);
    }

    public ICommand GetTreeGotoOperation(TreeGotoData treeGotoData)
    {
        if (treeGotoData is null)
            throw new ServiceLayerException("Null tree goto data");

        _currentFilePath = MakeFilePath(treeGotoData.Path);

        return new LfsTreeGoto(MakeFilePath(treeGotoData.Path), _currentFilePath);
    }

    public ICommand GetTreeListOperation(TreeListData treeListData)
    {
        if (treeListData is null)
            throw new ServiceLayerException("Null tree list data");
        if (_currentFilePath is null)
            throw new ServiceLayerException("Missing connection");

        return new LfsTreeList(_currentFilePath, treeListData.Depth ?? 1);
    }

    public ICommand GetFileCopyOperation(FileCopyData fileCopyData)
    {
        if (fileCopyData is null)
            throw new ServiceLayerException("Null file copy data");

        return new LfsFileCopy(
            MakeFilePath(fileCopyData.SourcePath),
            MakeFilePath(fileCopyData.DestinationPath));
    }

    public ICommand GetFileDeleteOperation(FileDeleteData fileDeleteData)
    {
        if (fileDeleteData is null)
            throw new ServiceLayerException("Null file delete data");

        return new LfsFileDelete(MakeFilePath(fileDeleteData.Path));
    }

    public ICommand GetFileMoveOperation(FileMoveData fileMoveData)
    {
        if (fileMoveData is null)
            throw new ServiceLayerException("Null file move data");

        return new LfsFileMove(
            MakeFilePath(fileMoveData.SourcePath),
            MakeFilePath(fileMoveData.DestinationPath));
    }

    public ICommand GetFileRenameOperation(FileRenameData fileRenameData)
    {
        if (fileRenameData is null)
            throw new ServiceLayerException("Null file rename data");

        return new LfsFileRename(
            MakeFilePath(fileRenameData.Path),
            MakeFilePath(fileRenameData.FileName).GetFullFilePath());
    }

    public ICommand GetFileShowOperation(FileShowData fileShowData)
    {
        if (fileShowData is null)
            throw new ServiceLayerException("Null file show data");

        return new LfsFileShow(MakeFilePath(fileShowData.Path));
    }

    private static bool IsAbsolute(string filePath)
    {
        return filePath.Substring(1, 2) == ":\\";
    }

    private BaseFilePath MakeFilePath(string filePath)
    {
        if (_currentFilePath is null)
            throw new ServiceLayerException("Missing connection");

        return IsAbsolute(filePath) ? new AbsoluteFilePath(filePath) : new RelativeFilePath(filePath, _currentFilePath);
    }
}