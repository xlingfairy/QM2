using System.Collections.Generic;

namespace QM.Server.Api.Entity
{
    public class JobHistoryViewModel
    {
        public JobHistoryViewModel(IReadOnlyList<JobHistoryEntryDto> entries, string errorMessage)
        {
            HistoryEntries = entries;
            ErrorMessage = errorMessage;
        }

        public IReadOnlyList<JobHistoryEntryDto> HistoryEntries { get; }
        public string ErrorMessage { get; }
    }
}