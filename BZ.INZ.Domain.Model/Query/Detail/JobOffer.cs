using System;

namespace BZ.INZ.Domain.Model.Query.Detail {
    public class JobOffer {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateRequested { get; set; }
    }
}
