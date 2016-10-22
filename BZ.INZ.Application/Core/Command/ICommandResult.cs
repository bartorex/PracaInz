namespace BZ.INZ.Application.Core.Command {
    public interface ICommandResult {

    };

    public interface ICommandResult<T> : ICommandResult {
        T Value { get; set; }
    }
}
