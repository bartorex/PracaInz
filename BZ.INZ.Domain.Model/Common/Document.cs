using System;

namespace BZ.INZ.Domain.Model.Common {
    public class Document {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
