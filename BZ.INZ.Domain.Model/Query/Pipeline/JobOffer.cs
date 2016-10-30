using System;

namespace BZ.INZ.Domain.Model.Query.Pipeline {
    public class JobOffer {
        public Guid Id { get; set; }
        public Guid EmployerId { get; set; }
        public string Title { get; set; }
    }
}
