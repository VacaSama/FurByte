namespace FurByte.Models;

public class RehomeRequest
{
	// primary key 
	public int RehomeRequestId { get; set; } 

	// pet name being rehomed 
	public required string PetName { get; set; }

	// the pets current owner 
	public required string OwnerId { get; set; }
	public required ApplicationUser Owner { get; set; }

	// new owner taking the pet in
	public required string NewOwnerId { get; set; }
	public required ApplicationUser NewOwner { get; set; }

	// the reason the current owner is rehoming the pet
	// description field 
	public required string ReasonForRehome { get; set; }
	// ----------------------------Separator---------------------------------

	// created a custom RehomeStatus called status that 
	// allows our Overseers to approve or reject rehome requests, 
	// and the users to view the status of their requests.
	public RehomeStatus Status { get; set; } = RehomeStatus.Pending;

	// the different statuses for the rehome request
	// enum = enumeration, this enumeration defines a set of named constants
	public enum RehomeStatus
	{
		Pending, 
		Approved, 
		Rejected
	}
}
