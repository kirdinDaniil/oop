using Itmo.ObjectOrientedProgramming.Lab4.BusinessLogicLayerDirectory.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.CommandsRecords;

namespace Itmo.ObjectOrientedProgramming.Lab4.ServiceLayerDirectory.Service.States;

public interface IServiceState
{
    public IService Context { get; }

    public ICommand GetConnectOperation(ConnectData connectData);

    public ICommand GetDisconnectOperation(DisconnectData disconnectData);

    public ICommand GetTreeGotoOperation(TreeGotoData treeGotoData);

    public ICommand GetTreeListOperation(TreeListData treeListData);

    public ICommand GetFileCopyOperation(FileCopyData fileCopyData);

    public ICommand GetFileDeleteOperation(FileDeleteData fileDeleteData);

    public ICommand GetFileMoveOperation(FileMoveData fileMoveData);

    public ICommand GetFileRenameOperation(FileRenameData fileRenameData);

    public ICommand GetFileShowOperation(FileShowData fileShowData);
}