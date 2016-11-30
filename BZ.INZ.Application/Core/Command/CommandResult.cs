namespace BZ.INZ.Application.Core.Command {
    public class CommandResult : ICommandResult {
    }

    public class CommandResult<T> : CommandResult, ICommandResult<T> {
        public T Value { get; set; }
    }
}
