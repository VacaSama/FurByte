using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurByte.Models;

public class RehomeRequest
{
	// primary key 
	[Key]
	public int RehomeRequestId { get; set; }

	// pet name being rehomed 
	[Required]
	public required string PetName { get; set; }

	// the pets current owner 
	[Required]
	public required string OwnerId { get; set; }
	[Required]
	public required ApplicationUser Owner { get; set; }

	// new owner taking the pet in
	[Required]
	public required string NewOwnerId { get; set; }
	[Required]
	public required ApplicationUser NewOwner { get; set; }

	// the reason the current owner is rehoming the pet
	// description field 
	[Required]
	public required string ReasonForRehome { get; set; }
	// ----------------------------Separator---------------------------------

	// created a custom RehomeStatus called status that 
	// allows our Overseers to approve or reject rehome requests, 
	// and the users to view the status of their requests.
	[Required]
	public required RehomeStatus Status { get; set; } = RehomeStatus.Pending;

	// the different statuses for the rehome request
	// enum = enumeration, this enumeration defines a set of named constants
	public enum RehomeStatus
	{
		Pending, 
		Approved, 
		Rejected
	}
}
