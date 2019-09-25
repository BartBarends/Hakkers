using System;
using System.Collections.Generic;

namespace Hakkers.Models
{
    public partial class Assignments
    {
        public int Id { get; set; }
        public string FkPlanner { get; set; }
        public int FkClient { get; set; }
        public string FkMechanic { get; set; }
        public int FkCategory { get; set; }
        public int FkPriority { get; set; }
        public int FkStatus { get; set; }
        public string Description { get; set; }
        public DateTime Appointment { get; set; }
        public DateTime? Departure { get; set; }
        public DateTime? Arrival { get; set; }
        public DateTime? Finished { get; set; }
        public string Note { get; set; }
        public DateTime Created { get; set; }

        public virtual AssignmentCategories FkCategoryNavigation { get; set; }
        public virtual Clients FkClientNavigation { get; set; }
        public virtual AssignmentPriorities FkPriorityNavigation { get; set; }
        public virtual AssignmentStatuses FkStatusNavigation { get; set; }
    }
}
